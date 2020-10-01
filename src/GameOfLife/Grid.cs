using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Grid
    {

        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }
        public List<List<Cell>> Cells { get; private set; }
        public Grid(Input input)
        {
            RowCount = input.RowCount;
            ColumnCount = input.ColumnCount;
            Cells = GenerateCellsFromCellState(input.InitialCellStates);
        }

        public Grid(int rowCount, int columnCount, List<List<Cell>> cells)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
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

        public override bool Equals(object obj)
        {
            if(obj is Grid grid && RowCount == grid.RowCount && ColumnCount == grid.ColumnCount)
            {
                for (int rowIndex = 0; rowIndex < RowCount; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < ColumnCount; colIndex++)
                    {
                        var currentCell = Cells[rowIndex][colIndex];
                        var otherCell = grid.Cells[rowIndex][colIndex];
                        if(!otherCell.Equals(currentCell))
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