using ChessProjectConsole.Entities.board;


namespace ChessProjectConsole.Entities.Chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {

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
            }
            return mat;
        }
    }
}
