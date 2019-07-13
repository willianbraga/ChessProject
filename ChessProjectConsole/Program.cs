using ChessProjectConsole.Entities.board;
using ChessProjectConsole.Entities.Chess;
using ChessProjectConsole.Entities.Exceptions;
using System;

namespace ChessProjectConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Board board = new Board(8, 8);

                board.PutPiece(new Tower(board, Color.Black), new Position(0, 0));
                board.PutPiece(new Tower(board, Color.Black), new Position(1, 3));
                board.PutPiece(new King(board, Color.Black), new Position(0, 2));


                Screen.PrintBoard(board);
                Console.WriteLine();
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
