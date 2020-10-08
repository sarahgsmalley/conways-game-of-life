using System;
using System.Text;
using GameOfLife;

namespace ConsoleApp
{
    public class ConsolePresenter
    {
        const string aliveCell = "🟩";
        const string deadCell = "⬜️";

        public void PrintGrid(Grid grid)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            foreach (var row in grid.Cells)
            {
                foreach (var cell in row)
                {
                    Console.Write(cell.CellState == CellState.Alive ? aliveCell : deadCell);
                }
                Console.WriteLine();
            }
        }
    }
}