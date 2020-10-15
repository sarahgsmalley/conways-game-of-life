namespace GameOfLife
{
    public interface ICell
    {
        bool IsAliveNextGeneration(int numberOfLiveNeighbours);
         
    }
}