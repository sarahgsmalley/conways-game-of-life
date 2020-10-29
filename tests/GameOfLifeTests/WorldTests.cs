using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class WorldTests
    {
        [Fact]
        public void Should_Create_Valid_World()
        {
            // Arrange
            var worldInput = new InputReader().Parse("TestFiles/WordCellInput.json");

            // Act
            var world = new World(worldInput);

            // Assert
            var expectedCells = new List<List<Cell>> 
            {
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive)},
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)}
            };
            var dimension = new Dimension(3, 3);
            var expectedWorld = new World(dimension, expectedCells);

            Assert.Equal(expectedWorld, world);
        }
    }
}