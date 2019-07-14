﻿using ChessProjectConsole.Entities.board;


namespace ChessProjectConsole.Entities.Chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "  K";
        }
        private bool MoveCheck(Position position)
        {
            Piece piece = board.piece(position);
            return piece == null || piece.color != color;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            //UP
            pos.GetPosition(position.line - 1, position.column);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //UP-RIGHT
            pos.GetPosition(position.line - 1, position.column + 1);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //RIGHT
            pos.GetPosition(position.line, position.column + 1);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //RIGHT-DOWN
            pos.GetPosition(position.line + 1, position.column + 1);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //DOWN
            pos.GetPosition(position.line + 1, position.column);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //DOWN-LEFT
            pos.GetPosition(position.line + 1, position.column - 1);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //LEFT
            pos.GetPosition(position.line, position.column - 1);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //LEFT-UP
            pos.GetPosition(position.line - 1, position.column - 1);
            if (board.ValidPosition(pos) && MoveCheck(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            return mat;

        }
    }
}
