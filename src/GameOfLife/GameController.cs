using System;
using System.IO;
using System.Threading;

namespace GameOfLife
{
    public class GameController
    {
        private IDisplayPresenter _presenter;
        private readonly INotifyCancelling _canceller;

        public GameController(IDisplayPresenter presenter, INotifyCancelling canceller)
        {
            _presenter = presenter;
            _canceller = canceller;
        }

        public void Run(World world)
        {
            var worldGenerator = new WorldGenerator(new InputReader(), new InputValidator());
            _presenter.Clear();
            while (!_canceller.Cancelled)
            {
                _presenter.PrintWorld(world);
                Thread.Sleep(1000);
                world = worldGenerator.CreateNextGeneration(world);
                _presenter.Clear();
            }
        }

        public World InitialiseFirstWorld(string[] args)
        {
            var worldGenerator = new WorldGenerator(new InputReader(), new InputValidator());
            var world = new World();
            var initialStateFilePath = GetFilePath(args);
            return world = worldGenerator.CreateFirstGeneration(initialStateFilePath);
        }

        private static string GetFilePath(string[] args)
        {
            if (args == null || args.Length == 0) return "InputFiles/DefaultState.json";
            if (File.Exists(args[0])) return args[0];
            else throw new InvalidInputException($"Invalid File Path: {args[0]}!");
        }
    }
}