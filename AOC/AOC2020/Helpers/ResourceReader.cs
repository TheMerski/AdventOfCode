using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC2020.Helpers
{
    /// <summary>
    /// Class for reading information from files
    /// </summary>

    static class ResourceReader
    {
        /// <summary>
        /// Read a file into an array of integers
        /// </summary>W
        /// <param name="filePath">Path of the file to read</param>
        /// <param name="seperator">Seperator used to seperate numbers (default = ,)</param>
        /// <returns>An array of numbers</returns>
        public static int[] ReadResourceToIntArray(string resource, string seperator =",")
        {
            string text = resource;
            string[] numbers = text.Split(seperator);
            return Array.ConvertAll(numbers, int.Parse);
        }

        /// <summary>
        /// Read a file into an array of integers
        /// </summary>
        /// <param name="filePath">Path of the file to read</param>
        /// <param name="seperator">Seperator used to seperate numbers (default = ,)</param>
        /// <returns>An array of numbers</returns>
        public static int[] ReadResourceToIntArray(string resource, char seperator = ',')
        {
            string text = resource;
            string[] numbers = text.Split(seperator);
            return Array.ConvertAll(numbers, int.Parse);
        }

        /// <summary>
        /// Read a file into an array of longs
        /// </summary>W
        /// <param name="filePath">Path of the file to read</param>
        /// <param name="seperator">Seperator used to seperate numbers (default = ,)</param>
        /// <returns>An array of numbers</returns>
        public static long[] ReadResourceToLongArray(string resource, string seperator =",")
        {
            string text = resource;
            string[] numbers = text.Split(seperator);
            return Array.ConvertAll(numbers, Int64.Parse);
        }

        /// <summary>
        /// Read a file into an array of longs
        /// </summary>
        /// <param name="filePath">Path of the file to read</param>
        /// <param name="seperator">Seperator used to seperate numbers (default = ,)</param>
        /// <returns>An array of numbers</returns>
        public static long[] ReadResourceToLongArray(string resource, char seperator = ',')
        {
            string text = resource;
            string[] numbers = text.Split(seperator);
            return Array.ConvertAll(numbers, Int64.Parse);
        }

        /// <summary>
        /// Read a file into an array of strings
        /// </summary>W
        /// <param name="filePath">Path of the file to read</param>
        /// <param name="seperator">Seperator used to seperate numbers (default = ,)</param>
        /// <returns>An array of strings</returns>
        public static string[] ReadResourceToStringArray(string resource, string seperator = ",")
        {
            string text = resource;
            return text.Split(seperator);
        }

    }
}
