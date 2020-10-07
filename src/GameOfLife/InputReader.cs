using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GameOfLife
{
    public class InputReader
    {
        private readonly string _filePath;
        private List<string> _errors;

        public InputReader(string filePath)
        {
            _filePath = filePath;
            _errors = new List<string>();
        }

        public Input Parse()
        {
            var json = File.ReadAllText(_filePath);
            var input = JsonConvert.DeserializeObject<Input>(json, new JsonSerializerSettings { Error = HandleParsingErrors });
            if (_errors.Count > 0)
            {
                throw new InvalidInputException(_errors);
            }
            return input;
        }

        private void HandleParsingErrors(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs errorArgs)
        {
            _errors.Add(errorArgs.ErrorContext.Error.Message);
            errorArgs.ErrorContext.Handled = true;
        }
    }
}