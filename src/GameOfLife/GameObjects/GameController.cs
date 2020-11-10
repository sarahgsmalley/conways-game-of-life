using System;
using System.IO;
using System.Threading;

namespace GameOfLife
{
    public class GameController
    {
        private IDisplayPresenter _presenter;
        private IQuitManager _quitManager;
        private ISaveStateManager _saveStateManager;
        private IWorldGenerator _worldGenerator;
        private string _initialStateFilePath;

        public GameController(IDisplayPresenter presenter, IQuitManager quitManager,
            ISaveStateManager saveStateManager, IWorldGenerator worldGenerator)
        {
            _presenter = presenter;
            _quitManager = quitManager;
            _saveStateManager = saveStateManager;
            _worldGenerator = worldGenerator;
        }

        public World InitialiseFirstWorld(string[] args)
        {
            _initialStateFilePath = GetFilePath(args);
            return _worldGenerator.CreateFirstGeneration(_initialStateFilePath);
        }

        public void Run(World world)
        {
            var generationCount = 0;
            PrintGeneration(world, generationCount);
            var isStopping = false;
            while (!isStopping)
            {
                world = _worldGenerator.CreateNextGeneration(world);
                generationCount++;
                PrintGeneration(world, generationCount);
                Thread.Sleep(500);
                _quitManager.CheckUserOption();
                isStopping = _quitManager.ShouldStop();
            }
            _presenter.PrintMessage($"{Environment.NewLine}The Game of Life has been stopped.", "Green");
            if (_quitManager.ShouldSave())
            {
                _saveStateManager.Save(_initialStateFilePath, world);
                _presenter.PrintMessage("The current World state has now been saved in the same location as the original file.", "Blue");
            }
        }

        private void PrintGeneration(World world, int generationCount)
        {
            _presenter.Clear();
            _presenter.PrintWorld(world);
            _presenter.PrintMessage($"Generation Count: {generationCount}");
            _presenter.PrintMenu();
        }

        private static string GetFilePath(string[] args)
        {
            if (args == null || args.Length == 0) return "InputFiles/DefaultState.json";
            if (File.Exists(args[0])) return args[0];
            else throw new InvalidInputException($"Invalid File Path: {args[0]}!");
        }
    }
}