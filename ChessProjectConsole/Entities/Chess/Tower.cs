using ChessProjectConsole.Entities.board;
using System;

namespace ChessProjectConsole.Entities.Chess
{
    class Tower : Piece
    {
        public Tower(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "T";
        }
    }
}
