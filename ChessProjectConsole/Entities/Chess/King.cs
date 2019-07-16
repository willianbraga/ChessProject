using ChessProjectConsole.Entities.board;


namespace ChessProjectConsole.Entities.Chess
{
    class King : Piece
    {
        private ChessMatch chessMatch;
        public King(Board board, Color color, ChessMatch chessMatch) : base(board, color)
        {
            this.chessMatch = chessMatch;
        }
        public override string ToString()
        {
            return "  K";
        }
        private bool MoveCheck(Position position)
        {
            Piece piece = board.piece(position);
            return piece == null || piece.color != color;
        }
        private bool checkCastling(Position position)
        {
            Piece piece = board.piece(position);
            return piece != null && piece is Rook && piece.color == color && piece.qtMoves == 0;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            //UP
            pos.GetPosition(position.line - 1, position.column);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //UP-RIGHT
            pos.GetPosition(position.line - 1, position.column + 1);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //RIGHT
            pos.GetPosition(position.line, position.column + 1);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //RIGHT-DOWN
            pos.GetPosition(position.line + 1, position.column + 1);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //DOWN
            pos.GetPosition(position.line + 1, position.column);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //DOWN-LEFT
            pos.GetPosition(position.line + 1, position.column - 1);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //LEFT
            pos.GetPosition(position.line, position.column - 1);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //LEFT-UP
            pos.GetPosition(position.line - 1, position.column - 1);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //#Special Moves Castling King Side
            if (qtMoves == 0 && !chessMatch.check)
            {
                Position posRook1 = new Position(position.line, position.column + 3);
                if (checkCastling(posRook1))
                {
                    Position p1 = new Position(position.line, position.column + 1);
                    Position p2 = new Position(position.line, position.column + 2);
                    if (board.piece(p1) == null && board.piece(p2) == null)
                    {
                        mat[position.line, position.column + 2] = true;
                    }
                }



                //#Special Moves Castling Queen Side

                Position posRook2 = new Position(position.line, position.column - 4);
                if (checkCastling(posRook2))
                {
                    Position p1 = new Position(position.line, position.column - 1);
                    Position p2 = new Position(position.line, position.column - 2);
                    Position p3 = new Position(position.line, position.column - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        mat[position.line, position.column - 2] = true;
                    }
                }

            }
            return mat;

        }
    }
}
