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
            
            var consolePresenter = new ConsolePresenter();
            var gridGenerator = new GridGenerator(new InputReader(), new InputValidator());
            var initialStateFilePath = GetFilePath(args);
            
            var grid = gridGenerator.CreateFirstGeneration(initialStateFilePath);
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

        private static string GetFilePath(string[] args)
        {
            if (args == null || args.Length == 0) return "InputFiles/SmallDefaultState.json";
            return args[0];
        }
    }
}
