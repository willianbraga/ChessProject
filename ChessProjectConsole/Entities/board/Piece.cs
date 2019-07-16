

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
        public void rmvQtMoves()
        {
            qtMoves--;
        }
        public bool existPossibleMoves()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < board.lines; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }

            }
            return false;
        }
        public bool possibleMoveTo(Position position)
        {
            return PossibleMoves()[position.line, position.column];
        }
        public abstract bool[,] PossibleMoves();
    }
}
