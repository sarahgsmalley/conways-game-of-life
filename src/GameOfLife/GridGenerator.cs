using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class GridGenerator
    {
        private IInputReader _inputReader;
        private IInputValidator _inputValidator;
        private INeighbourCounter _neighbourCounter;
        
        public Grid CreateFirstGeneration(string initialStateFilePath)
        {
            var inputReader = new InputReader(initialStateFilePath);
            var initialGridStateInput = inputReader.Parse();
            var inputValidator = new InputValidator(initialGridStateInput);
            inputValidator.Validate();
            return new Grid(initialGridStateInput);
        }
        
        public Grid CreateNextGeneration(Grid previousGrid)
        {
            var neighbourCounter = new NeighbourCounter(previousGrid.Cells);
            var newCells = new List<List<Cell>>();
            for (int rowIndex = 0; rowIndex < previousGrid.RowCount; rowIndex++)
            {
                newCells.Add(new List<Cell>());
                for(int colIndex = 0; colIndex < previousGrid.ColumnCount; colIndex++)
                {
                    var liveNeighbours = neighbourCounter.GetLiveNeighbourCount(rowIndex, colIndex);
                    var currentCell = previousGrid.Cells[rowIndex][colIndex];
                    var isAlive = currentCell.IsAliveNextGeneration(liveNeighbours);
                    newCells[rowIndex].Add(new Cell(isAlive ? CellState.Alive : CellState.Dead));               
                }
            }
            return new Grid(previousGrid.RowCount, previousGrid.ColumnCount, newCells);
        }

    }
}