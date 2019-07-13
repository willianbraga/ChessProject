﻿using ChessProjectConsole.Entities.board;
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

                    if (board.piece(i, j) == null)
                    {
                        Console.Write("-    ");
                    }
                    else
                    {
                        PrintPiece(board.piece(i, j));
                        Console.Write("    ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("  A    B    C    D    E    F    G    H");
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
        }
    }
}
