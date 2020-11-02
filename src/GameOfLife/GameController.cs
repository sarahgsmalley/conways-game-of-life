using System;
using System.IO;
using System.Threading;

namespace GameOfLife
{
    public class GameController
    {
        private IDisplayPresenter _presenter;
        private readonly INotifyCancelling _canceller;
        private IWorldGenerator _worldGenerator;

        public GameController(IDisplayPresenter presenter, INotifyCancelling canceller, IWorldGenerator worldGenerator)
        {
            _presenter = presenter;
            _canceller = canceller;
            _worldGenerator = worldGenerator;
        }

        public void Run(World world)
        {
            var generationCount = 0;
            _presenter.Clear();
            while (!_canceller.Cancelled)
            {
                _presenter.PrintWorld(world);
                _presenter.PrintMessage($"Generation Count: {generationCount}");
                Thread.Sleep(1000);
                world = _worldGenerator.CreateNextGeneration(world);
                generationCount++;
                _presenter.Clear();
            }
        }

        public World InitialiseFirstWorld(string[] args)
        {
            var initialStateFilePath = GetFilePath(args);
            return _worldGenerator.CreateFirstGeneration(initialStateFilePath);
        }

        private static string GetFilePath(string[] args)
        {
            if (args == null || args.Length == 0) return "InputFiles/DefaultState.json";
            if (File.Exists(args[0])) return args[0];
            else throw new InvalidInputException($"Invalid File Path: {args[0]}!");
        }
    }
}