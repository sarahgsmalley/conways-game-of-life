using System;

namespace GameOfLife
{
    public class InputValidator : IInputValidator
    {
        private Input _input;

        public InputValidator(Input input)
        {
            _input = input;
        }

        public void Validate()
        {
            ValidateRowCount();
            ValidateColumnCount();
        }

        private void ValidateRowCount()
        {
            if (_input.InitialCellStates.Count != _input.RowCount)
            {
                throw new InvalidInputException("Error: RowCount does not match the number of Rows in InitialCellStates.");
            }
        }

        private void ValidateColumnCount()
        {
            foreach (var row in _input.InitialCellStates)
            {
                if (row.Count != _input.ColumnCount)
                {
                    throw new InvalidInputException("Error: ColumnCount does not match the number of Columns in InitialCellStates.");
                }
            }
        }
    }
}