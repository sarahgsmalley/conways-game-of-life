using System;
using System.Runtime.Serialization;

namespace GameOfLife
{
    public class InvalidGridDimensionsException : Exception
    {
        public InvalidGridDimensionsException(string invalidDimension) : base(GetErrorMessage(invalidDimension))
        {
        }

        private static string GetErrorMessage(string invalidDimension)
        {
            return $"Error: {invalidDimension}Count does not match the number of {invalidDimension}s in InitialCellStates.";
        }
    }
}