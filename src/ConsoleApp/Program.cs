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
            var worldGenerator = new WorldGenerator(new InputReader(), new InputValidator());
            var initialStateFilePath = GetFilePath(args);
            
            var world = worldGenerator.CreateFirstGeneration(initialStateFilePath);
            while (true)
            {
                consolePresenter.PrintWorld(world);
                Thread.Sleep(1000);
                world = worldGenerator.CreateNextGeneration(world);
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
