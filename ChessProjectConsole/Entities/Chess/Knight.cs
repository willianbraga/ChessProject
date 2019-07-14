using ChessProjectConsole.Entities.board;


namespace ChessProjectConsole.Entities.Chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "  N";
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
            pos.GetPosition(position.line - 2, position.column + 1);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true; ;
            }
            //UPRIGHT2
            pos.GetPosition(position.line - 1, position.column + 2);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true; ;
            }
            //UPLEFT
            pos.GetPosition(position.line - 2, position.column - 1);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true; ;
            }
            //UPLEFT2
            pos.GetPosition(position.line - 1, position.column - 2);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true; ;
            }
            //DOWNLEFT
            pos.GetPosition(position.line + 2, position.column - 1);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true; ;
            }
            //DOWNLEFT2
            pos.GetPosition(position.line + 1, position.column - 2);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true; ;
            }

            //DOWNRIGHT
            pos.GetPosition(position.line + 2, position.column + 1);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true; ;
            }
            //DOWNRIGHT2
            pos.GetPosition(position.line + 1, position.column + 2);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true; ;
            }

            return mat;

        }
    }
}
