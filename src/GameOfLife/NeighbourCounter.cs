using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class NeighbourCounter
    {
        private List<List<Cell>> _cells;
        private List<LocationOffset> _offsets;
        
        public NeighbourCounter(List<List<Cell>> cells)
        {
            _cells = cells;
            _offsets = LocationOffsetProvider.ProvideCentralCellOffsets();
        }
        
        public int GetLiveNeighbourCount(int cellRowIndex, int cellColIndex)
        {
            var neighbours = GetNeighbours(cellRowIndex, cellColIndex);
            return neighbours.Where(neighbour => neighbour.CellState == CellState.Alive).Count();
        }

        private List<Cell> GetNeighbours(int cellRowIndex, int cellColIndex)
        {
            var neighbours = new List<Cell>();
            foreach(var offset in _offsets)
            {
                int neighbourRowIndex = cellRowIndex + offset.RowOffset;
                int neighbourColIndex = cellColIndex + offset.ColumnOffset;
                neighbours.Add(_cells[neighbourRowIndex][neighbourColIndex]);
            }
            return neighbours;
        }

    }
}