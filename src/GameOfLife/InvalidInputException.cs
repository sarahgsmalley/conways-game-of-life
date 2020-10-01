using System;
using System.Runtime.Serialization;

namespace GameOfLife
{
    public class InvalidInputException : Exception
    {
        const string defaultMessage =
                    "Error: RowCount or ColumnCount does not match InitialCellStates." +
                    "This could be because your RowCount or ColumnCount is incorrect," +
                    "or you may have invalid characters in InitialCellStates.";
        public InvalidInputException(string message = defaultMessage) : base(message)
        {
        }
    }
}