using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Cell
    {
        public CellState CellState { get; private set; }

        public Cell(CellState cellState)
        {
            CellState = cellState;
        }

        public bool IsAliveNextGeneration(int numberOfLiveNeighbours)
        {
            return CellState == CellState.Alive 
            ? numberOfLiveNeighbours == 2 || numberOfLiveNeighbours == 3 
            : numberOfLiveNeighbours == 3;
        }

        public override bool Equals(object obj)
        {
            return obj is Cell cell &&
                   CellState == cell.CellState;
        }
    }
}