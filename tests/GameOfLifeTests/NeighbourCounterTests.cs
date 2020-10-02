using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class NeighbourCounterTests
    {
        [Fact]
        public void Should_Get_Live_Neighbour_Count_For_Central_Cell()
        {
            // Arrange
            var cells = new List<List<Cell>> 
            {
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive)},
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)}
            };
            var grid = new Grid(3, 3, cells);
            var target = new NeighbourCounter();

            // Act
            var result = target.GetLiveNeighbourCount(grid.Cells[1][1]);

            // Assert
            Assert.Equal(2, result);
        }

    }
}