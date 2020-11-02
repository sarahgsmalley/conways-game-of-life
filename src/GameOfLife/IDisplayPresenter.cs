using GameOfLife;

namespace GameOfLife
{
    public interface IDisplayPresenter
    {
        void PrintWorld(World world);
        void PrintMessage(string message, string colour = "White");
        void Clear();
    }
}