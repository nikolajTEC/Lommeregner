using static Lommeregner.CalculatorEnum;

namespace Lommeregner
{
    internal class Program
    {
        //static field containing the length of a banana in cm
        static int banana = 9;
        /// <summary>
        /// starts the app, shows start display, and gives options for calculating.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DisplayCalculator();
            Console.WriteLine("Velkommen til min lommeregner");
            Console.WriteLine("Tryk 1 for plus, 2 for minus, 3 for gange, 4 for dividere, 5 for cm -> banan konvertering, 6 for udregning af livets formål");
            int response = (int)GetUserInput();
            //checks if the user input is defined in my enum, as a check to see if it's valid
            if (Enum.IsDefined(typeof(CalculatorChoices), response))
            {
                Calculation(response);
            }
        }
        /// <summary>
        /// multidimensional array, created to show a calculator figure.
        /// </summary>
        private static void DisplayCalculator()
        {
            Console.SetCursorPosition(0, 15);
            //multidimensional array, containing the buttons for my calculator
            string[,] calculatorButtons = {
            {"7", "8", "9", "/"},
            {"4", "5", "6", "*"},
            {"1", "2", "3", "-"},
            {"0", ".", "=", "+"}
        };

            Console.WriteLine("#####################");
            Console.WriteLine("#     Calculator    #");
            Console.WriteLine("#####################");
            //goes through the array, in order to display it correctly.
            for (int row = 0; row < calculatorButtons.GetLength(0); row++)
            {
                for (int col = 0; col < calculatorButtons.GetLength(1); col++)
                {
                    Console.Write($"| {calculatorButtons[row, col],-3} ");
                }
                Console.WriteLine("|");
                Console.WriteLine("#####################");
            }
            Console.SetCursorPosition(0, 0);
        }
        /// <summary>
        /// calculates based on what user selected in their response they want to calculate.
        /// </summary>
        /// <param name="response"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void Calculation(double response)
        {
            Console.WriteLine("Skriv tal du vil have regnet ud");

            double result = 0;
            List<double> numbers;
            switch (response)
            {
                case 1:
                    //gets a list of numbers, then runs through each of them to do the calculation.
                    numbers = GetNumbersForCalculation("+");
                    foreach (var number in numbers)
                    {
                        result += number;
                    }
                    break;
                case 2:
                    numbers = GetNumbersForCalculation("-");
                    foreach (var number in numbers)
                    {
                        if (result == 0)
                            result = number;
                        else
                            result = result - number;
                    }
                    break;
                case 3:
                    numbers = GetNumbersForCalculation("*");
                    foreach (var number in numbers)
                    {
                        if (result == 0)
                            result = number;
                        else
                            result = result * number;
                    }
                    break;
                case 4:
                    numbers = GetNumbersForCalculation("/");
                    foreach (var number in numbers)
                    {
                        if (result == 0)
                            result = number;
                        else
                            result = result / number;
                    }
                    break;
                case 5:
                    double cm = GetUserInput();
                    result = cm / banana;

                    break;
                case 6:
                    //TODO, Find a formula that returns a different answer to life than 42
                    throw new NotImplementedException();
                default:
                    Console.WriteLine("error");
                    break;
            }

            Console.WriteLine($"Result: {result}");
        }
        /// <summary>
        /// gets the numbers the user wants to use, checks if they are a valid double, and not 0
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        private static List<double> GetNumbersForCalculation(string symbol)
        {
            Console.WriteLine("Skriv tal du vil have udregnet, skriv f når du er færdig");
            bool finished = false;
            List<double> numbers = new List<double>();
            while (!finished)
            {
                //shows the numbers in my list, seperated by the symbol used for calculation for better readability
                Console.Write($"\r{string.Join($" {symbol} ", numbers)} {symbol} ");
                string input = Console.ReadLine().ToLower();
                if (input == "f")
                {
                    finished = true;
                }
                else if (double.TryParse(input, out double doubleValue) && input != "0")
                {
                    numbers.Add(doubleValue);
                }
                else
                {
                    Console.WriteLine("invalid input, try again");
                }
            }
            return numbers;
        }
        /// <summary>
        /// method for getting a double user input, defaults to returning 0 if input is invalid
        /// </summary>
        /// <returns></returns>
        private static double GetUserInput()
        {
            var response = Console.ReadLine();

            if (double.TryParse(response, out double doubleValue))
            {
                return doubleValue;
            }
            else
            {
                return 0;
            }

        }
    }
}