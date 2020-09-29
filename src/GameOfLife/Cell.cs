using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Cell
    {
        private CellState _cellState;

        public Cell(CellState cellState)
        {
            SetCellState(cellState);
        }

        public bool IsAliveNextGeneration(int numberOfLiveNeighbours)
        {
            return _cellState == CellState.Alive 
            ? numberOfLiveNeighbours == 2 || numberOfLiveNeighbours == 3 
            : numberOfLiveNeighbours == 3;
        }

        public void SetCellState(CellState cellState)
        {
            _cellState = cellState;
        }

        public CellState GetCellState()
        {
            return _cellState;
        }
    }
}