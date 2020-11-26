using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC2020.Helpers
{
    /// <summary>
    /// Class for reading information from files
    /// </summary>
    static class FileReader
    {
        /// <summary>
        /// Read a file into an array of integers
        /// </summary>
        /// <param name="filePath">Path of the file to read</param>
        /// <param name="seperator">Seperator used to seperate numbers (default = ,)</param>
        /// <returns>An array of numbers</returns>
        public static int[] readFileToIntArray(string filePath, char seperator = ',')
        {
            string text = File.ReadAllText(filePath);
            string[] numbers = text.Split(seperator);
            return Array.ConvertAll(numbers, int.Parse);
        }

    }
}
