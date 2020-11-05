using System.IO;
using Newtonsoft.Json;

namespace GameOfLife
{
    public class SaveStateManager : ISaveStateManager
    {
        public void Save(string originalFilePath, World world)
        {
            var outputFilePath = GetOutputFilePath(originalFilePath);
            SaveStateToFile(outputFilePath, world);
        }

        private void SaveStateToFile(string outputFilePath, World world)
        {
            var cellStates = world.ConvertCellsToCellState();
            var input = new Input(world.Dimension, cellStates);
            var json = JsonConvert.SerializeObject(input, Formatting.Indented);
            File.WriteAllText(outputFilePath, json);
        }

        private string GetOutputFilePath(string originalFilePath)
        {
            var inputFileName = Path.GetFileNameWithoutExtension(originalFilePath);
            var directory = Path.GetDirectoryName(originalFilePath);
            var newFilePathName = Path.Combine(directory, $"{inputFileName}-output.json");
            return newFilePathName;
        }
    }
}