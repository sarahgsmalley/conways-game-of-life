using System;
using System.IO;
using System.Threading;

namespace GameOfLife
{
    public class GameController
    {
        private IDisplayPresenter _presenter;
        private INotifyCancelling _canceller;
        private IWorldGenerator _worldGenerator;
        private string _initialStateFilePath;

        public GameController(IDisplayPresenter presenter, INotifyCancelling canceller, IWorldGenerator worldGenerator)
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

        private static string GetFilePath(string[] args)
        {
            if (args == null || args.Length == 0) return "InputFiles/DefaultState.json";
            if (File.Exists(args[0])) return args[0];
            else throw new InvalidInputException($"Invalid File Path: {args[0]}!");
        }

        public void Run(World world)
        {
            var generationCount = 0;
            //_presenter.Clear();
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
                world = _worldGenerator.CreateNextGeneration(world);
                generationCount++;
            }
            _presenter.PrintMessage($"{Environment.NewLine}The Game of Life has been stopped.", "Green");
            if(_canceller.ShouldSave())
            {
                _presenter.PrintMessage("TBD: Saving");
            }
            // if(_canceller.ShouldSaveWorldState())
            // {
            //     //SaveStateToFile(world);
            //     _presenter.PrintMessage("The current World state has been saved.", "Green");
            // }
        }

        private void SaveStateToFile(World world)
        {
            throw new NotImplementedException();
        }


    }
}