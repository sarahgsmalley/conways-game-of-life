using System.IO;
using System;
using System.Threading;
using GameOfLife;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CancelKeyPress += HandleCancelKeyPress;

            var presenter = new ConsolePresenter();
            var quitManager = new ConsoleQuitManager();
            var saveStateManager = new SaveStateManager();
            var worldGenerator = new WorldGenerator(new InputReader(), new InputValidator());

            var controller = new GameController(presenter, quitManager, saveStateManager, worldGenerator);
            try
            {
                var world = controller.InitialiseFirstWorld(args);
                controller.Run(world);
            }
            catch (InvalidInputException e)
            {
                presenter.PrintMessage(e.Message, "Red");
            }
            catch (Exception e)
            {
                presenter.PrintMessage($"Unknown error occurred: {e.Message}", "Red");
            }
        }

        private static void HandleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
