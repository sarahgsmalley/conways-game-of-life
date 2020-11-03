using System.IO;
using System;
using System.Threading;
using GameOfLife;

namespace ConsoleApp
{
    class Program
    {
        private static ConsolePresenter _consolePresenter;
        private static ConsoleCanceller _consoleCanceller;

        static void Main(string[] args)
        {
            _consolePresenter = new ConsolePresenter();
            _consoleCanceller = new ConsoleCanceller();
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
                return;
            }
            catch (Exception e)
            {
                _consolePresenter.PrintMessage("Unknown error occurred.", "Red");
            }
        }

        private static void HandleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            _consoleCanceller.Cancelled = true;
            e.Cancel = true;
            _consolePresenter.PrintMessage($"{Environment.NewLine}The Game of Life has been stopped.", "Green");
            _consolePresenter.PrintMessage($"{Environment.NewLine}Would you like to save the current World state? (y/n)", "Blue");
            var isSavingState = GetResponse();
            if(isSavingState) _consolePresenter.PrintMessage("World state has been saved.");
            Console.CursorVisible = true;
        }

        private static bool GetResponse()
        {
            bool result;
            var response = Console.ReadLine().ToLower();
            if(response.Equals("y")) result = true;
            if(response.Equals("n")) result = false;
            else
            {
                _consolePresenter.PrintMessage("Invalid response. Please enter 'y' to save or 'n' to quit without saving.");
                result = GetResponse();
            }
            return result;
        }
    }
}