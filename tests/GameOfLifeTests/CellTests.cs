using System.Runtime.CompilerServices;
using System;
using Xunit;
using GameOfLife;

namespace GameOfLifeTests
{
    public class CellTests
    {
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void Live_Cell_Should_Remain_Alive_Where_There_Are_Two_Or_Three_Live_Neighbours(int numberOfLiveNeighbours)
        {
            // Arrange
            var target = new Cell(CellState.Alive);

            // Act
            var result = target.IsAliveNextGeneration(numberOfLiveNeighbours);

            // Assert
            Assert.True(result);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Live_Cell_Should_Die_By_Underpopulation(int numberOfLiveNeighbours)
        {
            // Arrange
            var target = new Cell(CellState.Alive);

            // Act
            var result = target.IsAliveNextGeneration(numberOfLiveNeighbours);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void Live_Cell_Should_Die_By_Overpopulation(int numberOfLiveNeighbours)
        {
            // Arrange
            var target = new Cell(CellState.Alive);

            // Act
            var result = target.IsAliveNextGeneration(numberOfLiveNeighbours);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Dead_Cell_Should_Become_Alive_When_There_Are_Exactly_Three_Live_Neighbours()
        {
            // Arrange
            var target = new Cell(CellState.Dead);

            // Act
            var result = target.IsAliveNextGeneration(3);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(6)]
        public void Dead_Cell_Should_Remain_Dead(int numberOfLiveNeighbours)
        {
            // Arrange
            var target = new Cell(CellState.Dead);

            // Act
            var result = target.IsAliveNextGeneration(numberOfLiveNeighbours);

            // Assert
            Assert.False(result);
        }
    }
}
