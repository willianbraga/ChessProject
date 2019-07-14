namespace ChessProjectConsole.Entities.board
{
    class Position
    {
        public int line { get; set; }
        public int column { get; set; }

        public Position(int line, int column)
        {
            this.line = line;
            this.column = column;
        }
        public void GetPosition(int line, int column)
        {
            this.line = line;
            this.column = column;
        }
    }
}
