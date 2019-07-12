

namespace ChessProjectConsole.Entities.board
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qtMoves { get; protected set; }
        public Board board { get; set; }

        public Piece(Position position, Board board, Color color)
        {
            this.position = position;
            this.board = board;
            this.color = color;
            this.qtMoves = 0;

        }
    }
}
