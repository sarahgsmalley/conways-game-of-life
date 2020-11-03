using GameOfLife;
using Moq;
using Xunit;

namespace GameOfLifeTests
{
    public class GameControllerTests
    {
        [Fact]
        public void Should_Create_First_Generation_When_Initialising_World()
        {
            // Arrange
            var presenter = new Mock<IDisplayPresenter>();
            var canceller = new Mock<INotifyCancelling>();
            var worldGenerator = new Mock<IWorldGenerator>();
            worldGenerator.Setup(o => o.CreateFirstGeneration(It.IsAny<string>())).Returns(It.IsAny<World>());
            var controller = new GameController(presenter.Object, canceller.Object, worldGenerator.Object);

            // Act
            var world = controller.InitialiseFirstWorld(new[] {"TestFiles/ValidInitialState.json"});

            // Assert
            worldGenerator.Verify(o => o.CreateFirstGeneration(It.IsAny<string>()), Times.AtMostOnce());
        }

        [Fact]
        public void Should_Create_And_Print_Next_World_During_Running_Game()
        {
            // Arrange
            var world = It.IsAny<World>();
            var presenter = new Mock<IDisplayPresenter>();
            presenter.Setup(o => o.PrintWorld(world));
            var canceller = new Mock<INotifyCancelling>();
            canceller.SetupSequence(o => o.ShouldStop()).Returns(false).Returns(true);
            var worldGenerator = new Mock<IWorldGenerator>();
            worldGenerator.Setup(o => o.CreateNextGeneration(world)).Returns(world);
            var controller = new GameController(presenter.Object, canceller.Object, worldGenerator.Object);

            // Act
            controller.Run(world);

            // Assert
            presenter.Verify(o => o.PrintWorld(world), Times.AtLeastOnce());
            presenter.Verify(o => o.PrintMenu(), Times.AtLeastOnce());
            canceller.Verify(o => o.CheckUserOption(), Times.AtLeastOnce());
            canceller.Verify(o => o.ShouldStop(), Times.AtLeastOnce());
            canceller.Verify(o => o.ShouldSave(), Times.AtLeastOnce());
            worldGenerator.Verify(o => o.CreateNextGeneration(world), Times.AtLeastOnce());

        }
    }
}