using System.Collections.Generic;
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

        [Fact]
        public void Should_Convert_Cells_To_Cell_States()
        {
            // Arrange
            var cells = new List<List<Cell>>
            {
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Alive)},
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead)},
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Alive)}
            };
            var target = new World(new Dimension(3, 3), cells);

            // Act
            var result = target.ConvertCellsToCellState();

            // Assert
            var expectedCellStates = new List<List<CellState>>
            {
                new List<CellState> { CellState.Alive, CellState.Dead, CellState.Alive },
                new List<CellState> { CellState.Alive, CellState.Alive, CellState.Dead },
                new List<CellState> { CellState.Dead, CellState.Dead, CellState.Alive }
            };
            Assert.Equal<List<List<CellState>>>(expectedCellStates, result);
        }
    }
}