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
            if(_input.InitialCellStates.Count != _input.RowCount)
            {
                throw new InvalidGridDimensionsException("Row");
            }
            
            foreach(var row in _input.InitialCellStates)
            {
                if(row.Count != _input.ColumnCount)
                {
                    throw new InvalidGridDimensionsException("Column");
                }
            }
        }
    }
}