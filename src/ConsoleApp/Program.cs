using System.IO;
using System;
using System.Threading;
using GameOfLife;

namespace ConsoleApp
{
    class Program
    {
        private static ConsoleCanceller _consoleCanceller;

        static void Main(string[] args)
        {
            _consoleCanceller = new ConsoleCanceller();
            Console.CancelKeyPress += HandleCancelKeyPress;

            var consolePresenter = new ConsolePresenter();
            var controller = new GameController(consolePresenter, _consoleCanceller);
            controller.Run(args);
            
        }

        private static void HandleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            _consoleCanceller.Cancelled = true;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Stopped");
            Console.ResetColor();
        }

        
    }
}