using System.ComponentModel;
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
            return JsonConvert.DeserializeObject<Input>(json, new JsonSerializerSettings { Error = HandleInvalidCellStates });
        }

        private void HandleInvalidCellStates(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }
    }
}