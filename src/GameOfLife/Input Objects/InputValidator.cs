using System;

namespace GameOfLife
{
    public class InputValidator : IInputValidator
    {
        public void Validate(Input input)
        {
            ValidateRowCount(input);
            ValidateColumnCount(input);
        }

        private void ValidateRowCount(Input input)
        {
            if (input.InitialCellStates.Count != input.RowCount)
            {
                throw new InvalidInputException("Error: RowCount does not match the number of Rows in InitialCellStates.");
            }
        }

        private void ValidateColumnCount(Input input)
        {
            foreach (var row in input.InitialCellStates)
            {
                if (row.Count != input.ColumnCount)
                {
                    throw new InvalidInputException("Error: ColumnCount does not match the number of Columns in InitialCellStates.");
                }
            }
        }
    }
}