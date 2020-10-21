using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class WorldGenerator
    {
        private IInputReader _inputReader;
        private IInputValidator _inputValidator;

        public WorldGenerator(IInputReader reader, IInputValidator validator)
        {
            _inputReader = reader;
            _inputValidator = validator;
        }

        public World CreateFirstGeneration(string initialStateFilePath)
        {
            var initialWorldStateInput = _inputReader.Parse(initialStateFilePath);
            _inputValidator.Validate(initialWorldStateInput);
            return new World(initialWorldStateInput);
        }

        public World CreateNextGeneration(World previousWorld)
        {
            var neighbourCounter = new NeighbourCounter(previousWorld.Cells);
            var newCells = new List<List<Cell>>();
            var dimension = previousWorld.Dimension;
            for (int rowIndex = 0; rowIndex < dimension.RowCount; rowIndex++)
            {
                newCells.Add(new List<Cell>());
                for (int colIndex = 0; colIndex < dimension.ColumnCount; colIndex++)
                {
                    var liveNeighbours = neighbourCounter.GetLiveNeighbourCount(rowIndex, colIndex);
                    var currentCell = previousWorld.Cells[rowIndex][colIndex];
                    var isAlive = currentCell.IsAliveNextGeneration(liveNeighbours);
                    newCells[rowIndex].Add(new Cell(isAlive ? CellState.Alive : CellState.Dead));
                }
            }
            return new World(dimension, newCells);
        }

    }
}