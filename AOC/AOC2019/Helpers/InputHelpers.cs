using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2019.Helpers
{
    static class InputHelpers
    {
        /// <summary>
        /// Waits for any key to be pressed to stop the application
        /// </summary>
        public static void PressAnyKeyToExit()
        {
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        /// <summary>
        /// Parses a string to an integer
        /// </summary>
        /// <param name="input">The input string to parse</param>
        /// <returns>The parsed int or null</returns>
        public static int? ParseStringToInt(string input)
        {
            bool isInt = int.TryParse(input, out int amount);
            if (isInt)
            {
                return amount;
            }

            return null;
        }
    }
}
