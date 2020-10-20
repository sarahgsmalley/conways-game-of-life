using GameOfLife;
using Moq;
using Xunit;

namespace GameOfLifeTests
{
    public class GameControllerTests
    {

        [Fact]
        public void Should_Print_Current_World_During_Running_Game()
        {
            // Arrange
            var presenter = new Mock<IDisplayPresenter>();
            presenter.Setup(o => o.PrintWorld(It.IsAny<World>()));
            var canceller = new Mock<INotifyCancelling>();
            canceller.SetupSequence(o => o.Cancelled).Returns(false).Returns(true);
            var controller = new GameController(presenter.Object, canceller.Object);

            // Act
            controller.Run(new[] {"TestFiles/ValidInitialState.json"});

            // Assert
            presenter.Verify(o => o.PrintWorld(It.IsAny<World>()), Times.AtLeastOnce());
        }
    }
}