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
            var input = new InputReader("TestFiles/InvalidRowCount.json").Parse();
            var target = new InputValidator(input);

            // Act & Assert
            var exception = Assert.Throws<InvalidGridDimensionsException>(() => target.Validate());
            Assert.Equal("Error: RowCount does not match the number of Rows in InitialCellStates.", exception.Message);
        }  

        [Fact]
        public void Should_Throw_When_Number_Of_Columns_Does_Not_Match_Row_Count()
        {
            // Arrange
            var input = new InputReader("TestFiles/InvalidColumnCount.json").Parse();
            var target = new InputValidator(input);

            // Act & Assert
            var exception = Assert.Throws<InvalidGridDimensionsException>(() => target.Validate());
            Assert.Equal("Error: ColumnCount does not match the number of Columns in InitialCellStates.", exception.Message);
        }   
    }
}