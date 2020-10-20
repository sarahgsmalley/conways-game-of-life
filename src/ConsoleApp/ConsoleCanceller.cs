using GameOfLife;

namespace ConsoleApp
{
    public class ConsoleCanceller : INotifyCancelling
    {
        public bool Cancelled { get; set; }
    }
}