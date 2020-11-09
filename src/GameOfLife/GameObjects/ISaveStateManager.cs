namespace GameOfLife
{
    public interface ISaveStateManager
    {
        void Save(string originalFilePath, World world);
    }
}