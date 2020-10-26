namespace GameOfLife
{
    public interface IWorldGenerator
    {
        World CreateFirstGeneration(string initialStateFilePath);
        World CreateNextGeneration(World previousWorld);
        
    }
}