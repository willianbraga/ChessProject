using ChessProjectConsole.Entities.board;


namespace ChessProjectConsole.Entities.Chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {

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
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position position = new Position(0, 0);

            //UP
            position.GetPosition(position.line - 1, position.column);
            if (board.ValidPosition(position) && MoveCheck(position))
            {
                mat[position.line, position.column] = true;
            }
            //UP-RIGHT
            position.GetPosition(position.line - 1, position.column + 1);
            if (board.ValidPosition(position) && MoveCheck(position))
            {
                mat[position.line, position.column] = true;
            }
            //RIGHT
            position.GetPosition(position.line, position.column + 1);
            if (board.ValidPosition(position) && MoveCheck(position))
            {
                mat[position.line, position.column] = true;
            }
            //RIGHT-DOWN
            position.GetPosition(position.line - 1, position.column + 1);
            if (board.ValidPosition(position) && MoveCheck(position))
            {
                mat[position.line, position.column] = true;
            }
            //DOWN
            position.GetPosition(position.line + 1, position.column);
            if (board.ValidPosition(position) && MoveCheck(position))
            {
                mat[position.line, position.column] = true;
            }
            //DOWN-LEFT
            position.GetPosition(position.line + 1, position.column-1);
            if (board.ValidPosition(position) && MoveCheck(position))
            {
                mat[position.line, position.column] = true;
            }
            //LEFT
            position.GetPosition(position.line, position.column-1);
            if (board.ValidPosition(position) && MoveCheck(position))
            {
                mat[position.line, position.column] = true;
            }
            //LEFT-UP
            position.GetPosition(position.line - 1, position.column-1);
            if (board.ValidPosition(position) && MoveCheck(position))
            {
                mat[position.line, position.column] = true;
            }
            return mat;

        }
    }
}
