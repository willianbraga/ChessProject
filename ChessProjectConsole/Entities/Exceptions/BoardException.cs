using System;
using System.Collections.Generic;
using System.Text;

namespace ChessProjectConsole.Entities.Exceptions
{
    class BoardException : Exception
    {
        public BoardException(string message) : base(message)
        {

        }
    }
}
