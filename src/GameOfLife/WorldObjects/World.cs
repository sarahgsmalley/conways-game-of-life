using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class World : IEquatable<World>
    {
        public Dimension Dimension { get; private set; }
        public List<List<Cell>> Cells { get; private set; }
        
        public World()
        {
        }

        public World(Input input)
        {
            Dimension = new Dimension(input.RowCount, input.ColumnCount);
            Cells = GenerateCellsFromCellState(input.InitialCellStates);
        }

        public World(Dimension dimension, List<List<Cell>> cells)
        {
            Dimension = dimension;
            Cells = cells;
        }

        private List<List<Cell>> GenerateCellsFromCellState(List<List<CellState>> initialCellStates)
        {
            List<List<Cell>> result = new List<List<Cell>>();
            foreach (var row in initialCellStates)
            {
                var currentRow = new List<Cell>();
                foreach (var cellState in row)
                {
                    currentRow.Add(new Cell(cellState));
                }
                result.Add(currentRow);
            }
            return result;
        }

        public bool Equals(World world)
        {
            if (world.Dimension.Equals(Dimension))
            {
                for (int rowIndex = 0; rowIndex < Dimension.RowCount; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < Dimension.ColumnCount; colIndex++)
                    {
                        var currentCell = Cells[rowIndex][colIndex];
                        var otherCell = world.Cells[rowIndex][colIndex];
                        if (!otherCell.Equals(currentCell))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }
    }
}