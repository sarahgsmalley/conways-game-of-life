using System;
using GameOfLife;

namespace ConsoleApp
{
    public class GameController
    {
        public Input GetInput(string filePath)
        {
            var inputReader = new InputReader(filePath);
            var initialGridStateInput = inputReader.Parse();
            var inputValidator = new InputValidator(initialGridStateInput);
            inputValidator.Validate();
            return initialGridStateInput;
        }
    }
}