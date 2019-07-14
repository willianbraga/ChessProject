using ChessProjectConsole.Entities.board;
using ChessProjectConsole.Entities.Exceptions;
using System;


namespace ChessProjectConsole.Entities.Chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color turnPlayer { get; private set; }
        public bool finished { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            turnPlayer = Color.White;
            finished = false;
            PutPieces();
        }
        
        public void Move( Position origin, Position destiny)
        {
            Piece piece = board.RemovePiece(origin);
            piece.addQtMoves();          
            Piece RemovedPiece = board.RemovePiece(destiny);
            board.PutPiece(piece, destiny);
        }
        public void MovingPieces(Position origin, Position destiny)
        {
            Move(origin, destiny);
            turn++;
            ChangePlayer();
        }
        public void ValidateOriginPosition(Position position)
        {
            if (board.piece(position)==null)
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
        public void ValidateDestinyPosition(Position origin,Position destiny)
        {
            if (!board.piece(origin).possibleMoveTo(destiny))
            {
                throw new BoardException("Invalid destiny position!");
            }
        }
        private void ChangePlayer()
        {
            if (turnPlayer== Color.White)
            {
                turnPlayer = Color.Black;
            }
            else
            {
                turnPlayer = Color.White;
            }
        }
        public void PutPieces()
        {
            board.PutPiece(new Rook(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.PutPiece(new Pawn(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.PutPiece(new Bishop(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.PutPiece(new Rook(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.PutPiece(new King(board, Color.White), new ChessPosition('d', 1).toPosition());
            board.PutPiece(new Queen(board, Color.White), new ChessPosition('d', 4).toPosition());

            board.PutPiece(new Bishop(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.PutPiece(new Pawn(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.PutPiece(new Knight(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.PutPiece(new Rook(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.PutPiece(new Queen(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.PutPiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());

        }
    }
}
