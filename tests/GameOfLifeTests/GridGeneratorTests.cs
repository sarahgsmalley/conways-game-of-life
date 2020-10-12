using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class GridGeneratorTests
    {
        [Fact]
        public void Should_Create_First_Generation_From_File()
        {
            // Arrange
            var target = new GridGenerator();
            var initialStateFilePath = "TestFiles/ValidInitialState.json";

            // Act
            var result = target.CreateFirstGeneration(initialStateFilePath);

            // Assert
            var expectedGrid = new Grid(3, 3, new List<List<Cell>> 
            {
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Alive), new Cell(CellState.Dead)},
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead)}
            });
            Assert.Equal(expectedGrid, result);
        }

        [Fact]
        public void Should_Create_Next_Generation()
        {
            // Arrange
            var target = new GridGenerator();
            var cells = new List<List<Cell>> 
            {
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive)},
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)}
            };
            var previousGrid = new Grid(3, 3, cells);

            // Act
            var result = target.CreateNextGeneration(previousGrid);

            // Assert
            var expectedGrid = new Grid(3, 3, new List<List<Cell>> 
            {
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive)},
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive)},
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive)}
            });
            Assert.Equal(expectedGrid, result);
        
        }
    }
}