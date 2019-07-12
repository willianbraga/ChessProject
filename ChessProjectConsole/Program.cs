using ChessProjectConsole.Entities.board;
using System;

namespace ChessProjectConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            Screen.PrintBoard(board);
            Console.WriteLine();
        }
    }
}
