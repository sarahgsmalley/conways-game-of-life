using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GameOfLife
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message)
        {
        }

        public InvalidInputException(List<string> errors) : base(FormatErrorList(errors))
        {
        }

        private static string FormatErrorList(List<string> errors)
        {
            var result = new StringBuilder();
            result.Append("Error: Your input file is invalid for the following reason(s):");
            foreach(string error in errors) {
                result.Append(error);
                result.AppendLine();
            }
            return result.ToString();
        }
    }
}