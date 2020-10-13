using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class NeighbourCounter : INeighbourCounter
    {
        private List<List<Cell>> _cells;
        private int _maxRowCount;
        private int _maxColumnCount;
        private List<LocationOffset> _offsets;

        public NeighbourCounter(List<List<Cell>> cells)
        {
            _cells = cells;
            _maxRowCount = cells.Count();
            _maxColumnCount = cells[0].Count();
            _offsets = LocationOffsetProvider.GetLocationOffsets();
        }

        public int GetLiveNeighbourCount(int cellRowIndex, int cellColIndex)
        {
            var neighbours = GetNeighbours(cellRowIndex, cellColIndex);
            return neighbours.Count(neighbour => neighbour.CellState == CellState.Alive);
        }

        private List<Cell> GetNeighbours(int cellRowIndex, int cellColIndex)
        {
            var neighbours = new List<Cell>();
            foreach (var offset in _offsets)
            {
                int neighbourRowIndex = GetNeighbourRowIndex(cellRowIndex, offset.RowOffset);
                int neighbourColIndex = GetNeighbourColIndex(cellColIndex, offset.ColumnOffset);
                neighbours.Add(_cells[neighbourRowIndex][neighbourColIndex]);
            }
            return neighbours;
        }

        private int GetNeighbourRowIndex(int cellRowIndex, int rowIndexOffset)
        {
            var neighbourRowIndex = cellRowIndex + rowIndexOffset;
            if (neighbourRowIndex < 0)
            {
                neighbourRowIndex += _maxRowCount;
            }
            if (neighbourRowIndex > _maxRowCount - 1)
            {
                neighbourRowIndex -= _maxRowCount;
            }
            return neighbourRowIndex;
        }
        
        private int GetNeighbourColIndex(int cellColIndex, int columnIndexOffset)
        {
            var neighbourColIndex = cellColIndex + columnIndexOffset;
            if (neighbourColIndex < 0)
            {
                neighbourColIndex += _maxColumnCount;
            }
            if (neighbourColIndex > _maxColumnCount - 1)
            {
                neighbourColIndex -= _maxColumnCount;
            }
            return neighbourColIndex;
        }
    }
}