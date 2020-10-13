namespace GameOfLife
{
    public interface INeighbourCounter
    {
        int GetLiveNeighbourCount(int cellRowIndex, int cellColIndex);
    }
}