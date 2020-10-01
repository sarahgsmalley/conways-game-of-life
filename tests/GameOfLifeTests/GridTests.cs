using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class GridTests
    {
        [Fact]
        public void Should_Create_Valid_Grid()
        {
            // Arrange
            var gridInput = new InputReader("TestFiles/WordCellInput.json").Parse();

            // Act
            var grid = new Grid(gridInput);

            // Assert
            var expectedCells = new List<List<Cell>> 
            {
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive)},
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)}
            };
            var expectedGrid = new Grid(3, 3, expectedCells);

            Assert.Equal(expectedGrid, grid);
        }
    }
}