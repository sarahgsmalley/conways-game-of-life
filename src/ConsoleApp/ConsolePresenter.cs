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
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            foreach (var row in world.Cells)
            {
                foreach (var cell in row)
                {
                    Console.Write(cell.CellState == CellState.Alive ? aliveCell : deadCell);
                }
                Console.WriteLine();
            }
        }

        public void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}