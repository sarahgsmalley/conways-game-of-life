using System;
using System.IO;
using Newtonsoft.Json;

namespace GameOfLife
{
    public class InputReader
    {
        private readonly string _filePath;
        public InputReader(string filePath)
        {
            _filePath = filePath;
        }

        public Input Parse()
        {
            var json = File.ReadAllText(_filePath);
            var result = JsonConvert.DeserializeObject<Input>(json);
            var resultString = JsonConvert.SerializeObject(result);
            return result;
        }
    }
}