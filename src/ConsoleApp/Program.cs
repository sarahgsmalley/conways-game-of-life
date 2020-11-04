using System.IO;
using System;
using System.Threading;
using GameOfLife;

namespace ConsoleApp
{
    class Program
    {
        private static ConsolePresenter _presenter;
        private static ConsoleQuitManager _quitManager;

        static void Main(string[] args)
        {
            _presenter = new ConsolePresenter();
            _quitManager = new ConsoleQuitManager();
            Console.CancelKeyPress += HandleCancelKeyPress;

            var worldGenerator = new WorldGenerator(new InputReader(), new InputValidator());
            var controller = new GameController(_presenter, _quitManager, worldGenerator);
            try
            {
                var world = controller.InitialiseFirstWorld(args);
                controller.Run(world);
            }
            catch (InvalidInputException e)
            {
                _presenter.PrintMessage(e.Message, "Red");
            }
            catch (Exception)
            {
                _presenter.PrintMessage("Unknown error occurred.", "Red");
            }
        }

        private static void HandleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
        }


    }
}