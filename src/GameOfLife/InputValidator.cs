using System;

namespace GameOfLife
{
    public class InputValidator
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
                throw new InvalidInputException();
            }
        }

        private void ValidateColumnCount()
        {
            foreach (var row in _input.InitialCellStates)
            {
                if (row.Count != _input.ColumnCount)
                {
                    throw new InvalidInputException();
                }
            }
        }
    }
}