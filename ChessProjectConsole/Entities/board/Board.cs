

using ChessProjectConsole.Entities.Exceptions;

namespace ChessProjectConsole.Entities.board
{
    class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }
        public Piece piece (int line , int column)
        {
            return pieces[line, column];
        }
        public Piece piece( Position position)
        {
            return pieces[position.line, position.column];
        }
        public bool ExistPiece(Position position)
        {
            ValidPosition(position);
            return piece(position) != null;
        }
        public void PutPiece (Piece piece, Position position)
        {
            if (ExistPiece(position))
            {
                throw new BoardException("There is a piece in this position already!");
            }
            pieces[position.line, position.column] = piece;
            piece.position = position;
        }
        public bool ValidPosition(Position position)
        {
            if (position.line<0 || position.line>=lines || position.column<0 || position.column>=columns)
            {
                return false;
            }
            return true;
        }
        public void ValidatedPosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
