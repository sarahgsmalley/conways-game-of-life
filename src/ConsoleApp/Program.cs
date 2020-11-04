using System.IO;
using System;
using System.Threading;
using GameOfLife;

namespace ConsoleApp
{
    class Program
    {
        private static ConsolePresenter _consolePresenter;
        private static ConsoleQuitManager _consoleCanceller;

        static void Main(string[] args)
        {
            _consolePresenter = new ConsolePresenter();
            _consoleCanceller = new ConsoleQuitManager();
            Console.CancelKeyPress += HandleCancelKeyPress;

            var worldGenerator = new WorldGenerator(new InputReader(), new InputValidator());
            var controller = new GameController(_consolePresenter, _consoleCanceller, worldGenerator);
            try
            {
                var world = controller.InitialiseFirstWorld(args);
                controller.Run(world);
            }
            catch (InvalidInputException e)
            {
                _consolePresenter.PrintMessage(e.Message, "Red");
            }
            catch (Exception)
            {
                _consolePresenter.PrintMessage("Unknown error occurred.", "Red");
            }
        }

        private static void HandleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            //Console.CursorVisible = true;
            e.Cancel = true;
        }


    }
}