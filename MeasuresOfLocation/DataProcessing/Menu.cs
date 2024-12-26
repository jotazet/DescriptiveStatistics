using System;

namespace MeasuresOfLocation.DataProcessing
{
    class Menu
    {
        private readonly string[] _options = { "Select file", "Calculation options", "Calculate", "Exit" };
        private int _selectedIndex = 0;

        public void Show()
        {
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                DisplayMenu();

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    _selectedIndex = (_selectedIndex > 0) ? _selectedIndex - 1 : _options.Length - 1;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    _selectedIndex = (_selectedIndex < _options.Length - 1) ? _selectedIndex + 1 : 0;
                }

            } while (keyInfo.Key != ConsoleKey.Enter);

            ExecuteOption();
        }

        private void DisplayMenu()
        {
            int consoleWidth = Console.WindowWidth;

            for (int i = 0; i < _options.Length; i++)
            {
                string option = _options[i];
                string formattedOption;

                if (i == _selectedIndex)
                {
                    formattedOption = $"> {option} <";
                }
                else
                {
                    formattedOption = option;
                }

                int padding = (consoleWidth - formattedOption.Length) / 2;

                if (padding < 0) padding = 0;

                Console.WriteLine($"{new string(' ', padding)}{formattedOption}");
            }
        }

        private void ExecuteOption()
        {
            switch (_selectedIndex)
            {
                case 0:
                    SelectFile();
                    break;
                case 1:
                    CalculationOptions();
                    break;
                case 2:
                    Calculate();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        private void SelectFile()
        {
            Console.WriteLine("SelectFile");
        }

        private void CalculationOptions()
        {
            Console.WriteLine("CalculationOptions");
        }

        private void Calculate()
        {
            Console.WriteLine("Calculate");
        }
    }
}