using System;

namespace GameOfLife
{
    public class GameController
    {
        public GameController()
        {
        }

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