using ChessProjectConsole.Entities.board;
using ChessProjectConsole.Entities.Exceptions;
using System;
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
        public bool check { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            turnPlayer = Color.White;
            finished = false;
            check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            PutPieces();
        }

        public Piece Move(Position origin, Position destiny)
        {
            Piece piece = board.RemovePiece(origin);
            piece.addQtMoves();
            Piece RemovedPiece = board.RemovePiece(destiny);
            board.PutPiece(piece, destiny);
            if (RemovedPiece != null)
            {
                captured.Add(RemovedPiece);
            }

            //Special Move Castling King Side
            if (piece is King && destiny.column == origin.column + 2)
            {
                Position rookOrigin = new Position(origin.line, origin.column + 3);
                Position rookDestiny = new Position(origin.line, origin.column + 1);
                Piece R = board.RemovePiece(rookOrigin);
                R.addQtMoves();
                board.PutPiece(R, rookDestiny);
            }
            //Special Move Castling Queen Side
            if (piece is King && destiny.column == origin.column - 2)
            {
                Position rookOrigin = new Position(origin.line, origin.column - 4);
                Position rookDestiny = new Position(origin.line, origin.column - 1);
                Piece R = board.RemovePiece(rookOrigin);
                R.addQtMoves();
                board.PutPiece(R, rookDestiny);
            }
            return RemovedPiece;
        }
        public void backMove(Position origin, Position destiny, Piece RemovedPiece)
        {
            Piece p = board.RemovePiece(destiny);
            p.rmvQtMoves();
            if (RemovedPiece != null)
            {
                board.PutPiece(RemovedPiece, destiny);
                captured.Remove(RemovedPiece);
            }
            board.PutPiece(p, origin);

            //Special Move Castling King Side
            if (p is King && destiny.column == origin.column + 2)
            {
                Position rookOrigin = new Position(origin.line, origin.column + 3);
                Position rookDestiny = new Position(origin.line, origin.column + 1);
                Piece R = board.RemovePiece(rookDestiny);
                R.rmvQtMoves();
                board.PutPiece(R, rookOrigin);
            }
            //Special Move Castling Queen Side
            if (p is King && destiny.column == origin.column + 2)
            {
                Position rookOrigin = new Position(origin.line, origin.column - 4);
                Position rookDestiny = new Position(origin.line, origin.column - 1);
                Piece R = board.RemovePiece(rookDestiny);
                R.addQtMoves();
                board.PutPiece(R, rookOrigin);
            }

        }
        public void MovingPieces(Position origin, Position destiny)
        {
            Piece RemovedPiece = Move(origin, destiny);

            if (checkTest(turnPlayer))
            {
                backMove(origin, destiny, RemovedPiece);
                throw new BoardException("You cannot do this move, you are in CHECK!");
            }
            if (checkTest(Enemy(turnPlayer)))
            {
                check = true;
            }
            else { check = false; }
            if (checkMateTest(Enemy(turnPlayer)))
            {
                finished = true;
            }
            else
            {
                turn++;
                ChangePlayer();
            }
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
        private Color Enemy(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }
        private Piece King(Color color)
        {
            foreach (Piece x in piecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }
        public bool checkTest(Color color)
        {
            Piece K = King(color);
            if (K == null)
            {
                throw new BoardException("There is no king " + color + "on the board!");
            }
            foreach (Piece x in piecesInGame(Enemy(color)))
            {
                bool[,] mat = x.PossibleMoves();
                if (mat[K.position.line, K.position.column])
                {
                    return true;
                }
            }
            return false;
        }
        public bool checkMateTest(Color color)
        {
            if (!checkTest(color))
            {
                return false;
            }
            foreach (Piece x in piecesInGame(color))
            {
                bool[,] mat = x.PossibleMoves();
                for (int i = 0; i < board.lines; i++)
                {
                    for (int j = 0; j < board.columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position destiny = new Position(i, j);
                            Piece removedPiece = Move(origin, destiny);
                            bool checktest = checkTest(color);
                            backMove(origin, destiny, removedPiece);
                            if (!checktest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void PutNewPieces(char column, int line, Piece piece)
        {
            board.PutPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }
        public void PutPieces()
        {
            PutNewPieces('a', 1, new Rook(board, Color.White));
            PutNewPieces('b', 1, new Knight(board, Color.White));
            PutNewPieces('c', 1, new Bishop(board, Color.White));
            PutNewPieces('d', 1, new Queen(board, Color.White));
            PutNewPieces('e', 1, new King(board, Color.White, this));
            PutNewPieces('f', 1, new Bishop(board, Color.White));
            PutNewPieces('g', 1, new Knight(board, Color.White));
            PutNewPieces('h', 1, new Rook(board, Color.White));

            PutNewPieces('a', 2, new Pawn(board, Color.White));
            PutNewPieces('b', 2, new Pawn(board, Color.White));
            PutNewPieces('c', 2, new Pawn(board, Color.White));
            PutNewPieces('d', 2, new Pawn(board, Color.White));
            PutNewPieces('e', 2, new Pawn(board, Color.White));
            PutNewPieces('f', 2, new Pawn(board, Color.White));
            PutNewPieces('g', 2, new Pawn(board, Color.White));
            PutNewPieces('h', 2, new Pawn(board, Color.White));


            PutNewPieces('a', 8, new Rook(board, Color.Black));
            //     PutNewPieces('b', 8, new Knight(board, Color.Black));
            //   PutNewPieces('c', 8, new Bishop(board, Color.Black));
            // PutNewPieces('d', 8, new Queen(board, Color.Black));
            PutNewPieces('e', 8, new King(board, Color.Black, this));
            //    PutNewPieces('f', 8, new Bishop(board, Color.Black));
            //  PutNewPieces('g', 8, new Knight(board, Color.Black));
            PutNewPieces('h', 8, new Rook(board, Color.Black));

            PutNewPieces('a', 7, new Pawn(board, Color.Black));
            PutNewPieces('b', 7, new Pawn(board, Color.Black));
            PutNewPieces('c', 7, new Pawn(board, Color.Black));
            PutNewPieces('d', 7, new Pawn(board, Color.Black));
            PutNewPieces('e', 7, new Pawn(board, Color.Black));
            PutNewPieces('f', 7, new Pawn(board, Color.Black));
            PutNewPieces('g', 7, new Pawn(board, Color.Black));
            PutNewPieces('h', 7, new Pawn(board, Color.Black));



        }
    }
}
