using ChessProjectConsole.Entities.board;
using ChessProjectConsole.Entities.Chess;
using System;

namespace ChessProjectConsole
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < board.columns; j++)
                {
                    PrintPiece(board.piece(i, j));
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("    A    B    C    D    E    F    G    H");
        }
        public static void PrintBoard(Board board, bool[,] PositionMoves)
        {
            ConsoleColor OriginalBackground = Console.BackgroundColor;
            ConsoleColor MoveColor = ConsoleColor.DarkGray;

            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < board.columns; j++)
                {
                    if (PositionMoves[i, j] == true)
                    {
                        Console.BackgroundColor = MoveColor;
                    }
                    else
                    {
                        Console.BackgroundColor = OriginalBackground;
                    }
                    PrintPiece(board.piece(i, j));
                    Console.BackgroundColor = OriginalBackground;
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("    A    B    C    D    E    F    G    H");
            Console.BackgroundColor = OriginalBackground;
        }

        public static ChessPosition GetChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("  -  ");
            }
            else
            {
                if (piece.color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write("  ");
            }
        }
    }
}
