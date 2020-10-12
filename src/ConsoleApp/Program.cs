using System.Threading;
using System;
using GameOfLife;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CancelKeyPress += HandleCancelKeyPress;

            var filePath = "";
            if (args == null || args.Length == 0) filePath = "InputFiles/SmallDefaultState.json";
            else filePath = args[0];

            var consolePresenter = new ConsolePresenter();
            var gridGenerator = new GridGenerator();
            var grid = gridGenerator.CreateFirstGeneration(filePath);
            while (true)
            {
                consolePresenter.PrintGrid(grid);
                Thread.Sleep(1000);
                grid = gridGenerator.CreateNextGeneration(grid);
            }
        }

        private static void HandleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Stopped");
            Console.ResetColor();
        }
    }
}
