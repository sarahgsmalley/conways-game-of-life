using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class NeighbourCounterTests
    {
        [Fact]
        public void Should_Get_Live_Neighbour_Count_For_Central_Location()
        {
            // Arrange
            var cells = new List<List<Cell>> 
            {
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive)},
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)}
            };
            var target = new NeighbourCounter(cells);

            // Act
            var result = target.GetLiveNeighbourCount(1, 1);

            // Assert
            Assert.Equal(2, result);
        }

        [Theory]
        [InlineData(0, 0, 3)]
        [InlineData(2, 2, 2)]
        public void Should_Return_Live_Neighbour_Count_For_Boundary_Location(int rowIndex, int colIndex, int expectedLiveCount)
        {
            // Arrange
            var cells = new List<List<Cell>> 
            {
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead)},
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Alive)},
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)}
            };
            var target = new NeighbourCounter(cells);

            // Act
            var result = target.GetLiveNeighbourCount(rowIndex, colIndex);

            // Assert
            Assert.Equal(expectedLiveCount, result);
        }
    }
}