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
    }
}