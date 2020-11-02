using System;
using System.Text;
using GameOfLife;

namespace ConsoleApp
{

    public class ConsolePresenter : IDisplayPresenter
    {
        const string aliveCell = "🟩";
        const string deadCell = "⬜️";

        public void PrintWorld(World world)
        {
            foreach (var row in world.Cells)
            {
                foreach (var cell in row)
                {
                    Console.Write(cell.CellState == CellState.Alive ? aliveCell : deadCell);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void PrintMessage(string message, string colour = "White")
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colour);
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Clear()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }
    }
}