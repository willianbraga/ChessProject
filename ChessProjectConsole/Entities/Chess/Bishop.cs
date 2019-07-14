using ChessProjectConsole.Entities.board;


namespace ChessProjectConsole.Entities.Chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "  B";
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

            //UPRIGHT
            pos.GetPosition(position.line - 1, position.column +1);
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
