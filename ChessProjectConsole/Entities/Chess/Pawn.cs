using ChessProjectConsole.Entities.board;


namespace ChessProjectConsole.Entities.Chess
{
    class Pawn : Piece
    {
        private ChessMatch chessMatch;
        public Pawn(Board board, Color color, ChessMatch chessMatch) : base(board, color)
        {
            this.chessMatch = chessMatch;
        }
        public override string ToString()
        {
            return "  P";
        }
        private bool enemyCheck(Position position)
        {
            Piece piece = board.piece(position);
            return piece != null && piece.color != color;
        }
        private bool freeMove(Position position)
        {
            return board.piece(position) == null;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.GetPosition(position.line - 1, position.column);

                if (board.ValidPosition(pos) && freeMove(pos))
                {
                    mat[pos.line, pos.column] = true;
                }

                pos.GetPosition(position.line - 2, position.column);

                Position pos2 = new Position(position.line, position.column);

                if (board.ValidPosition(pos2) && freeMove(pos2) && board.ValidPosition(pos) && freeMove(pos) && qtMoves == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.GetPosition(position.line - 1, position.column - 1);
                if (board.ValidPosition(pos) && enemyCheck(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.GetPosition(position.line - 1, position.column + 1);
                if (board.ValidPosition(pos) && enemyCheck(pos))
                {
                    mat[pos.line, pos.column] = true;
                }

                //#Special Move En Passant
                if (position.line==3 )
                {
                    Position leftPawn = new Position(position.line, position.column - 1);
                    if (board.ValidPosition(leftPawn) && enemyCheck(leftPawn) && board.piece(leftPawn)== chessMatch.enPassantOption)
                    {
                        mat[leftPawn.line, leftPawn.column] = true;
                    }
                    Position rightPawn = new Position(position.line, position.column + 1);
                    if (board.ValidPosition(rightPawn) && enemyCheck(rightPawn) && board.piece(rightPawn) == chessMatch.enPassantOption)
                    {
                        mat[rightPawn.line, leftPawn.column] = true;
                    }
                }
            }
            else
            {
                pos.GetPosition(position.line + 1, position.column);
                if (board.ValidPosition(pos) && freeMove(pos))
                {
                    mat[pos.line, pos.column] = true;
                }

                pos.GetPosition(position.line + 2, position.column);
                Position pos2 = new Position(position.line, position.column);
                if (board.ValidPosition(pos2) && freeMove(pos2) && board.ValidPosition(pos) && freeMove(pos) && qtMoves == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.GetPosition(position.line + 1, position.column - 1);
                if (board.ValidPosition(pos) && enemyCheck(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.GetPosition(position.line + 1, position.column + 1);
                if (board.ValidPosition(pos) && enemyCheck(pos))
                {
                    mat[pos.line, pos.column] = true;
                }

                //#Special Move En Passant
                if (position.line == 4)
                {
                    Position leftPawn = new Position(position.line, position.column - 1);
                    if (board.ValidPosition(leftPawn) && enemyCheck(leftPawn) && board.piece(leftPawn) == chessMatch.enPassantOption)
                    {
                        mat[leftPawn.line, leftPawn.column] = true;
                    }
                    Position rightPawn = new Position(position.line, position.column + 1);
                    if (board.ValidPosition(rightPawn) && enemyCheck(rightPawn) && board.piece(rightPawn) == chessMatch.enPassantOption)
                    {
                        mat[rightPawn.line, leftPawn.column] = true;
                    }
                }
            }
            return mat;
        }
    }
}
