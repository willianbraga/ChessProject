using ChessProjectConsole.Entities.board;
using System;


namespace ChessProjectConsole.Entities.Chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        private int turn;
        private Color turnPlayer;
        public bool finished { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            turnPlayer = Color.White;
            finished = false;
            PutPieces();
        }
        public void move( Position origin, Position destiny)
        {
            Piece piece = board.RemovePiece(origin);
            piece.addQtMoves();          
            Piece RemovedPiece = board.RemovePiece(destiny);
            board.PutPiece(piece, destiny);
        }
        public void PutPieces()
        {
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.PutPiece(new King(board, Color.White), new ChessPosition('d', 1).toPosition());

            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.PutPiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());

        }
    }
}
