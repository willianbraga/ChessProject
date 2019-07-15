using ChessProjectConsole.Entities.board;
using ChessProjectConsole.Entities.Exceptions;
using System.Collections.Generic;

namespace ChessProjectConsole.Entities.Chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color turnPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            turnPlayer = Color.White;
            finished = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            PutPieces();
        }

        public void Move(Position origin, Position destiny)
        {
            Piece piece = board.RemovePiece(origin);
            piece.addQtMoves();
            Piece RemovedPiece = board.RemovePiece(destiny);
            board.PutPiece(piece, destiny);
            if (RemovedPiece != null)
            {
                captured.Add(RemovedPiece);
            }
        }
        public void MovingPieces(Position origin, Position destiny)
        {
            Move(origin, destiny);
            turn++;
            ChangePlayer();
        }
        public void ValidateOriginPosition(Position position)
        {
            if (board.piece(position) == null)
            {
                throw new BoardException("There is no piece on the ORIGIN chosen!");
            }
            if (turnPlayer != board.piece(position).color)
            {
                throw new BoardException("The chosen piece is not yours!");
            }
            if (!board.piece(position).existPossibleMoves())
            {
                throw new BoardException("There is no possible moves for the Origin piece!");
            }
        }
        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!board.piece(origin).possibleMoveTo(destiny))
            {
                throw new BoardException("Invalid destiny position!");
            }
        }
        private void ChangePlayer()
        {
            if (turnPlayer == Color.White)
            {
                turnPlayer = Color.Black;
            }
            else
            {
                turnPlayer = Color.White;
            }
        }
        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }
        public void PutNewPieces(char column, int line, Piece piece)
        {
            board.PutPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }
        public void PutPieces()
        {
            PutNewPieces('a', 1, new Rook(board, Color.White));
            PutNewPieces('b', 2, new Pawn(board, Color.White));
            PutNewPieces('c', 2, new Bishop(board, Color.White));
            PutNewPieces('d', 2, new Rook(board, Color.White));
            PutNewPieces('e', 1, new King(board, Color.White));
            PutNewPieces('f', 4, new Queen(board, Color.White));

            PutNewPieces('c', 7, new Bishop(board, Color.Black));
            PutNewPieces('c', 8, new Pawn(board, Color.Black));
            PutNewPieces('d', 7, new Knight(board, Color.Black));
            PutNewPieces('e', 7, new Rook(board, Color.Black));
            PutNewPieces('e', 8, new Queen(board, Color.Black));
            PutNewPieces('d', 8, new King(board, Color.Black));

        }
    }
}
