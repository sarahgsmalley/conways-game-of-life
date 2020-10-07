using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class GameControllerTests
    {
        [Fact]
        public void Should_Get_Input_From_File()
        {
            // Arrange
            var target = new GameController();

            // Act
            var result = target.GetInput("TestFiles/ValidGridInput.json");

            // Assert
            var expectedInitialCellStates = new List<List<CellState>>
                                            {
                                                new List<CellState> { CellState.Dead, CellState.Alive, CellState.Dead, CellState.Dead, CellState.Dead },
                                                new List<CellState> { CellState.Alive, CellState.Dead, CellState.Dead, CellState.Alive, CellState.Alive },
                                                new List<CellState> { CellState.Alive, CellState.Alive, CellState.Dead, CellState.Dead, CellState.Dead },
                                                new List<CellState> { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Alive, CellState.Dead },
                                                new List<CellState> { CellState.Dead, CellState.Dead, CellState.Alive, CellState.Alive, CellState.Dead }
                                            };
            var expectedInput = new Input { RowCount = 5, ColumnCount = 5, InitialCellStates = expectedInitialCellStates };
            Assert.Equal(expectedInput.RowCount, result.RowCount);
            Assert.Equal(expectedInput.ColumnCount, result.ColumnCount);
            Assert.Equal(expectedInput.InitialCellStates, result.InitialCellStates);
        }
    }
}