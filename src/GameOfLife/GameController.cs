using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace GameOfLife
{
    public class GameController
    {
        private IDisplayPresenter _presenter;
        private IQuitManager _canceller;
        private IWorldGenerator _worldGenerator;
        private string _initialStateFilePath;

        public GameController(IDisplayPresenter presenter, IQuitManager canceller, IWorldGenerator worldGenerator)
        {
            _presenter = presenter;
            _canceller = canceller;
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
            var isStopping = false;
            while (!isStopping)
            {
                _presenter.Clear();
                _presenter.PrintWorld(world);
                _presenter.PrintMessage($"Generation Count: {generationCount}");
                _presenter.PrintMenu();
                Thread.Sleep(1000);
                _canceller.CheckUserOption();
                isStopping = _canceller.ShouldStop();
                if (isStopping) break;
                world = _worldGenerator.CreateNextGeneration(world);
                generationCount++;
            }
            _presenter.PrintMessage($"{Environment.NewLine}The Game of Life has been stopped.", "Green");
            if (_canceller.ShouldSave())
            {
                SaveStateToFile(world);
                _presenter.PrintMessage("The current World state has now been saved in the same location as the original file.", "Blue");
            }
        }

        private static string GetFilePath(string[] args)
        {
            if (args == null || args.Length == 0) return "InputFiles/DefaultState.json";
            if (File.Exists(args[0])) return args[0];
            else throw new InvalidInputException($"Invalid File Path: {args[0]}!");
        }

        private void SaveStateToFile(World world)
        {
            var cellStates = world.ConvertCellsToCellState();
            var input = new Input(world.Dimension, cellStates);
            var json = JsonConvert.SerializeObject(input, Formatting.Indented);
            var newFilePathName = _initialStateFilePath.Remove(_initialStateFilePath.Length - 5) + "-output.json";
            File.WriteAllText(newFilePathName, json);
        }
    }
}