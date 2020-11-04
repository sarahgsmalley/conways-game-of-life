using System.Collections.Generic;

namespace GameOfLife
{
    public class Input
    {
        public Dimension Dimension { get; set; }
        public List<List<CellState>> InitialCellStates { get; set; }

        public Input(Dimension dimension, List<List<CellState>> cellStates)
        {
            Dimension = dimension;
            InitialCellStates = cellStates;
        }       
    }
}