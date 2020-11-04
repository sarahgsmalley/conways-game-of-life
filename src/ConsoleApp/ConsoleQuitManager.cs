using System.Runtime.CompilerServices;
using System;
using GameOfLife;

namespace ConsoleApp
{
    public class ConsoleQuitManager : IQuitManager
    {
        private string _userOption;

        public bool ShouldStop()
        {
            return _userOption == "Q" || _userOption == "S";
        }

        public bool ShouldSave()
        {
            return _userOption == "S";
        }

        public void CheckUserOption()
        {
            _userOption = GetUserOption();
        }

        private string GetUserOption()
        {
            if (!Console.KeyAvailable) return null;
            var key = Console.ReadKey(true).Key;
            return key.ToString();
        }
    }
}