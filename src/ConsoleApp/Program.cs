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

            var controller = new GameController(_consolePresenter, _consoleCanceller);
            controller.Run(args);        
        }

        private static void HandleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            _consoleCanceller.Cancelled = true;
            _consolePresenter.PrintMessage("The Game of Life has ended.", "Green");
        }
    }
}