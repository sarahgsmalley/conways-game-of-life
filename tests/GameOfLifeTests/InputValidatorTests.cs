using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class InputValidatorTests
    {
        [Fact]
        public void Should_Throw_When_Number_Of_Rows_Does_Not_Match_Row_Count()
        {
            // Arrange
            var input = new InputReader().Parse("TestFiles/InvalidRowCount.json");
            var target = new InputValidator();

            // Act & Assert
            var exception = Assert.Throws<InvalidInputException>(() => target.Validate(input));
            Assert.Equal("Error: RowCount does not match the number of Rows in InitialCellStates.", exception.Message);
        }

        [Fact]
        public void Should_Throw_When_Number_Of_Columns_Does_Not_Match_Row_Count()
        {
            // Arrange
            var input = new InputReader().Parse("TestFiles/InvalidColumnCount.json");
            var target = new InputValidator();

            // Act & Assert
            var exception = Assert.Throws<InvalidInputException>(() => target.Validate(input));
            Assert.Equal("Error: ColumnCount does not match the number of Columns in InitialCellStates.", exception.Message);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(2)]
        public void Should_Throw_When_Number_Of_Rows_Is_Below_Minimum(int rowCount)
        {
            // Arrange
            var input = new Input { Dimension = new Dimension(rowCount, 3), InitialCellStates = new List<List<CellState>>() };
            var target = new InputValidator();

            // Act & Assert
            var exception = Assert.Throws<InvalidInputException>(() => target.Validate(input));
            Assert.Equal("Error: The minimum number of rows allowed is 3.", exception.Message);
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        [InlineData(1)]
        public void Should_Throw_When_Number_Of_Columns_Is_Below_Minimum(int colCount)
        {
            // Arrange
            var input = new Input
            {
                Dimension = new Dimension(3, colCount),
                InitialCellStates = new List<List<CellState>>
                                    {
                                        new List<CellState>(),
                                        new List<CellState>(),
                                        new List<CellState>()
                                    }
            };
            var target = new InputValidator();

            // Act & Assert
            var exception = Assert.Throws<InvalidInputException>(() => target.Validate(input));
            Assert.Equal("Error: The minimum number of columns allowed is 3.", exception.Message);
        }
    }
}