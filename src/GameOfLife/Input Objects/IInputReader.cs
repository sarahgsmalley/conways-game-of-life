namespace GameOfLife
{
    public interface IInputReader
    {
        Input Parse(string filePath);
    }
}