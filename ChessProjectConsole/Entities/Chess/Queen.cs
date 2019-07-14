using ChessProjectConsole.Entities.board;


namespace ChessProjectConsole.Entities.Chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "  Q";
        }
        private bool MoveCheck(Position position)
        {
            Piece piece = board.piece(position);
            return piece == null || piece.color != color;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            //UP
            pos.GetPosition(position.line - 1, position.column);
            while (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line - 1;
                pos.column = pos.column;
            }
            //UPRIGHT
            pos.GetPosition(position.line - 1, position.column + 1);
            while (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line - 1;
                pos.column = pos.column + 1;
            }
            //RIGHT
            pos.GetPosition(position.line, position.column + 1);
            while (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line;
                pos.column = pos.column + 1;
            }
            //DOWNRIGHT
            pos.GetPosition(position.line + 1, position.column + 1);
            while (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line + 1;
                pos.column = pos.column + 1;
            }
            //DOWN
            pos.GetPosition(position.line + 1, position.column);
            while (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line + 1;
                pos.column = pos.column;
            }
            //DOWNLEFT
            pos.GetPosition(position.line + 1, position.column - 1);
            while (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line + 1;
                pos.column = pos.column - 1;
            }
            //LEFT
            pos.GetPosition(position.line , position.column - 1);
            while (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line;
                pos.column = pos.column - 1;
            }
            //UPLEFT
            pos.GetPosition(position.line - 1, position.column - 1);
            while (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line - 1;
                pos.column = pos.column - 1;
            }
            return mat;

        }
    }
}
