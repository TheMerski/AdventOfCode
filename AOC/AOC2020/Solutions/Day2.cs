using AOC2020.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2020.Solutions
{
    class Day2
    {
        private TimeHelper timeHelper;
        private string[] input;
        public Day2()
        {
            timeHelper = new TimeHelper();
            input = ResourceReader.ReadResourceToStringArray(Properties.Resources.Day2, Environment.NewLine);
            timeHelper.Start();
            int valid = input.Count(v => CheckValidPasswordPosition(v));
            Console.WriteLine(valid);
            timeHelper.Stop();
        }

        private bool CheckValidPasswordCount(string databasePassword)
        {
            string numString = @"([0-9])+";
            string letterString = @"([a-z](?=:))+";
            string passwordString = @"(?<=: )([a-z]+)";
            Regex numRegex = new Regex(numString);
            Regex letterRegex = new Regex(letterString);
            Regex passwordRegex = new Regex(passwordString);

            MatchCollection numbers = numRegex.Matches(databasePassword);
            Match letter = letterRegex.Match(databasePassword);
            Match password = passwordRegex.Match(databasePassword);
            if (numbers.Count == 2 && letter.Success && password.Success)
            {
                int min = int.Parse(numbers[0].Value);
                int max = int.Parse(numbers[1].Value);
                char letterChar = letter.Value[0];
                int count = password.Value.Count(v => v == letterChar);
                return count >= min && count <= max;
            }
            else
            {
                return false;
            }
        }

        private bool CheckValidPasswordPosition(string databasePassword)
        {
            string numString = @"([0-9])+";
            string letterString = @"([a-z](?=:))+";
            string passwordString = @"(?<=: )([a-z]+)";
            Regex numRegex = new Regex(numString);
            Regex letterRegex = new Regex(letterString);
            Regex passwordRegex = new Regex(passwordString);

            MatchCollection numbers = numRegex.Matches(databasePassword);
            Match letter = letterRegex.Match(databasePassword);
            Match password = passwordRegex.Match(databasePassword);
            if (numbers.Count == 2 && letter.Success && password.Success)
            {
                int min = int.Parse(numbers[0].Value);
                int max = int.Parse(numbers[1].Value);
                char letterChar = letter.Value[0];
                bool val1 = password.Value[min - 1] == letterChar;
                bool val2 = password.Value[max - 1] == letterChar;
                return val1 ^ val2;
            }
            else
            {
                return false;
            }
        }
    }
}
