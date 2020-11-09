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
            var rowCount = input.Dimension.RowCount;
            if (rowCount < 3) throw new InvalidInputException("Error: The minimum number of rows allowed is 3.");
            if (input.InitialCellStates.Count != rowCount)
                throw new InvalidInputException("Error: RowCount does not match the number of Rows in InitialCellStates.");
        }

        private void ValidateColumnCount(Input input)
        {
            var colCount = input.Dimension.ColumnCount;
            if (colCount < 3) throw new InvalidInputException("Error: The minimum number of columns allowed is 3.");
            foreach (var row in input.InitialCellStates)
            {
                if (row.Count != colCount)
                    throw new InvalidInputException("Error: ColumnCount does not match the number of Columns in InitialCellStates.");
            }
        }
    }
}