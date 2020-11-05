using System.IO;
using Newtonsoft.Json;

namespace GameOfLife
{
    public class SaveStateManager
    {
        private string _originalFilePath;
        private World _world;

        public SaveStateManager(string originalFilePath, World world)
        {
            _originalFilePath = originalFilePath;
            _world = world;
        }

        public void Save()
        {
            var outputFilePath = GetOutputFilePath();
            SaveStateToFile(outputFilePath);
        }

        private void SaveStateToFile(string outputFilePath)
        {
            var cellStates = _world.ConvertCellsToCellState();
            var input = new Input(_world.Dimension, cellStates);
            var json = JsonConvert.SerializeObject(input, Formatting.Indented);
            File.WriteAllText(outputFilePath, json);
        }

        private string GetOutputFilePath()
        {
            var inputFileName = Path.GetFileNameWithoutExtension(_originalFilePath);
            var directory = Path.GetDirectoryName(_originalFilePath);
            var newFilePathName = Path.Combine(directory, $"{inputFileName}-output.json");
            return newFilePathName;
        }
    }
}