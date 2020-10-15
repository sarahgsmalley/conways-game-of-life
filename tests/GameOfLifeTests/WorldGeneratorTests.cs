using System.Collections.Generic;
using GameOfLife;
using Moq;
using Xunit;

namespace GameOfLifeTests
{
    public class WorldGeneratorTests
    {
        [Fact]
        public void Should_Create_First_Generation_From_File()
        {
            // Arrange
            var reader = new InputReader();
            var validator = new InputValidator();
            var target = new WorldGenerator(reader, validator);

            // Act
            var result = target.CreateFirstGeneration("TestFiles/ValidInitialState.json");

            // Assert
            var expectedWorld = new World(3, 3, new List<List<Cell>>
            {
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Alive), new Cell(CellState.Dead)},
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead)}
            });
            Assert.Equal(expectedWorld, result);
        }

        [Fact]
        public void Should_Throw_InvalidInputException_When_File_Doesnt_Exist()
        {
            // Arrange
            var reader = new InputReader();
            var validator = new InputValidator();
            var target = new WorldGenerator(reader, validator);

            // Act
            // Assert
            Assert.Throws<InvalidInputException>(() => target.CreateFirstGeneration("TestFiles/InvalidRowCount.json"));
        }

        [Fact]
        public void Should_Throw_InvalidInputException_When_Mocked_Invalid_Column_Count()
        {
            // Arrange
            var reader = new Mock<IInputReader>();
            Input value = new Input { RowCount = 3, ColumnCount = 3, InitialCellStates = new List<List<CellState>>() };
            reader.Setup(o => o.Parse(It.IsAny<string>())).Returns(value);
            var validator = new Mock<IInputValidator>();
            validator.Setup(o => o.Validate(It.IsAny<Input>())).Throws<InvalidInputException>();
            var target = new WorldGenerator(reader.Object, validator.Object);

            // Act
            // Assert
            Assert.Throws<InvalidInputException>(() => target.CreateFirstGeneration(string.Empty));
        }


        [Fact]
        public void Should_Create_Next_Generation()
        {
            // Arrange
            var target = new WorldGenerator(new InputReader(), new InputValidator());
            var cells = new List<List<Cell>>
            {
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive)},
                new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)}
            };
            var previousWorld = new World(3, 3, cells);

            // Act
            var result = target.CreateNextGeneration(previousWorld);

            // Assert
            var expectedWorld = new World(3, 3, new List<List<Cell>>
            {
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive)},
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive)},
                new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive)}
            });
            Assert.Equal(expectedWorld, result);

        }
    }
}