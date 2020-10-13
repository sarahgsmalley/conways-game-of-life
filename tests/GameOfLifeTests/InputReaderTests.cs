using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class InputReaderTests
    {
        [Fact]
        public void Can_Read_Dimension_Input_As_Expected()
        {
            // Arrange
            var target = new InputReader();

            // Act
            var result = target.Parse("TestFiles/WordCellInput.json");

            // Assert
            Assert.Equal(3, result.RowCount);
            Assert.Equal(3, result.ColumnCount);
        }

        [Theory]
        [InlineData("TestFiles/WordCellInput.json")]
        [InlineData("TestFiles/NumericalCellInput.json")]
        [InlineData("TestFiles/MixedCellInput.json")]
        public void Should_Read_Initial_Cell_States_Input_As_Expected_Using_Both_Word_And_Number_Representations(string path)
        {
            // Arrange
            var target = new InputReader();

            // Act
            var result = target.Parse(path);

            // Assert
            var expected = new List<List<CellState>>
                            {
                                new List<CellState> { CellState.Dead, CellState.Dead, CellState.Dead },
                                new List<CellState> { CellState.Alive, CellState.Alive, CellState.Alive },
                                new List<CellState> { CellState.Dead, CellState.Dead, CellState.Dead }
                            };
            Assert.Equal<List<List<CellState>>>(expected, result.InitialCellStates);
        }

        [Fact]
        public void Should_Handle_Parsing_Errors_On_Initial_CellState()
        {
            // Arrange
            var target = new InputReader();

            // Act & Assert
            var exception = Assert.Throws<InvalidInputException>(() => target.Parse("TestFiles/InvalidCellStates.json"));
            Assert.Contains("Error: Your input file is invalid for the following reason(s):", exception.Message);
        }
    }
}