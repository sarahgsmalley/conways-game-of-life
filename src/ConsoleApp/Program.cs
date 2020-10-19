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

            var consolePresenter = new ConsolePresenter();
            var controller = new GameController(consolePresenter);
            controller.Run(args);
            
        }

        private static void HandleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Stopped");
            Console.ResetColor();
        }

        
    }
}