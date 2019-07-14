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
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            return mat;
        }
    }
}
