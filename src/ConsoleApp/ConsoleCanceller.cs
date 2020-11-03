using System.Runtime.CompilerServices;
using System;
using GameOfLife;

namespace ConsoleApp
{
    public class ConsoleCanceller : INotifyCancelling
    {
        private IDisplayPresenter _presenter;
        private string _userOption;

        public ConsoleCanceller(IDisplayPresenter presenter)
        {
            _presenter = presenter;
            _userOption = null;
        }

        private string GetUserOption()
        {
            if (!Console.KeyAvailable) return null;
            var key = Console.ReadKey(true).Key;
            return key.ToString();
        }

        public bool ShouldStop()
        {
            return _userOption == "Q" || _userOption == "S";
        }

        public bool ShouldSaveWorldState()
        {
            _presenter.PrintMessage($"{Environment.NewLine}Would you like to save the current World state? (y/n)", "Blue");
            return GetResponse();
        }

        private bool GetResponse()
        {
            bool result;
            var response = Console.ReadKey(true);
            if (response.Key == ConsoleKey.Y)
            {
                result = true;
            }
            else if (response.Key == ConsoleKey.N)
            {
                result = false;
            }
            else
            {
                _presenter.PrintMessage("Invalid response. Please enter 'y' to save or 'n' to quit without saving.");
                result = GetResponse();
            }
            return result;
        }

        public bool ShouldSave()
        {
            return _userOption == "S";
        }

        public void CheckUserOption()
        {
            _userOption = GetUserOption();
        }
    }
}