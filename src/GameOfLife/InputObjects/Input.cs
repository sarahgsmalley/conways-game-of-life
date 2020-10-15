using System.Collections.Generic;

namespace GameOfLife
{
    public class Input
    {
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
        public List<List<CellState>> InitialCellStates { get; set; }
        
    }
}