using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class InputValidatorTests
    {
        [Theory]
        [InlineData("TestFiles/InvalidRowCount.json")]
        [InlineData("TestFiles/InvalidColumnCount.json")]
        [InlineData("TestFiles/InvalidCellStates.json")]
        public void Should_Throw_When_Input_For_RowColumn_ColumnCount_Or_InitialCellStates_Is_Invalid(string inputPath)
        {
            // Arrange
            var input = new InputReader(inputPath).Parse();
            var target = new InputValidator(input);

            // Act & Assert
            var exception = Assert.Throws<InvalidInputException>(() => target.Validate());
            var expectedMessage =
                        "Error: RowCount or ColumnCount does not match InitialCellStates." +
                        "This could be because your RowCount or ColumnCount is incorrect," +
                        "or you may have invalid characters in InitialCellStates.";
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}