using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class NeighbourCounter
    {
        private List<LocationOffset> _offsets;
        
        public NeighbourCounter()
        {
            _offsets = LocationOffsetProvider.ProvideCentralCellOffsets();
        }
        
        public object GetLiveNeighbourCount(Cell cell)
        {
            throw new NotImplementedException();
        }

        private List<Cell> GetNeighbours(Cell cell)
        {
            throw new NotImplementedException();
        }

    }
}