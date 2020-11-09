using System;

namespace GameOfLife
{
    public class Cell : IEquatable<Cell>
    {
        public CellState CellState { get; }

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

        public bool Equals(Cell cell)
        {
            return CellState == cell.CellState;
        }
    }
}