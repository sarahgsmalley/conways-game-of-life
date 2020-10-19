using GameOfLife;

namespace GameOfLife
{
    public interface IDisplayPresenter
    {
        void PrintError(string message);
        void PrintWorld(World world);
    }
}