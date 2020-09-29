using System;

namespace GameOfLife
{
    public class Cell
    {
        private CellState _cellState;

        public Cell(CellState cellState)
        {
            _cellState = cellState;
        }

        public bool IsAliveNextGeneration(int numberOfLiveNeighbours)
        {
            return _cellState == CellState.Alive 
            ? numberOfLiveNeighbours == 2 || numberOfLiveNeighbours == 3 
            : numberOfLiveNeighbours == 3;
        }
    }
}