using GameOfLife;
using Xunit;

namespace tests.GameOfLifeTests
{
    public class InputReaderTests
    {
        [Fact]
        public void Can_Read_Input_As_Expected()
        {
            // Arrange
            var target = new InputReader("TestFiles/input.json");

            // Act
            var result = target.Parse();

            // Assert
            Assert.Equal(3, result.ColumnCount);
        }
    }
}