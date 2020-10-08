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

            // validate args[0] has the file
            // if null/empty use default
            
            var consolePresenter = new ConsolePresenter();
            var gridGenerator = new GridGenerator();
            var grid = new Grid(GetInput("InputFiles/InitialStateTemplate.json"));
            while(true)
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

        public static Input GetInput(string filePath)
        {
            var inputReader = new InputReader(filePath);
            var initialGridStateInput = inputReader.Parse();
            var inputValidator = new InputValidator(initialGridStateInput);
            inputValidator.Validate();
            return initialGridStateInput;
        }
    }
}
