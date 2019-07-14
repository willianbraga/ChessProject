

namespace ChessProjectConsole.Entities.board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qtMoves { get; protected set; }
        public Board board { get; set; }

        public Piece(Board board, Color color)
        {
            this.position = null;
            this.board = board;
            this.color = color;
            this.qtMoves = 0;

        }
        public void addQtMoves()
        {
            qtMoves++;
        }
        public abstract bool[,] PossibleMoves();
    }
}
