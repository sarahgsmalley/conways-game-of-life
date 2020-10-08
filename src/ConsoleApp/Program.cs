using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CancelKeyPress += HandleCancelKeyPress;
        }

        private static void HandleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Stopped");
            Console.ResetColor();
        }
    }
}
