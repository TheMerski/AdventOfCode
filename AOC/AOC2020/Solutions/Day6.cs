using AOC2020.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Solutions
{
    class Day6
    {
        private TimeHelper timeHelper;
        private string[] input;
        public Day6()
        {
            timeHelper = new TimeHelper();
            input = ResourceReader.ReadResourceToStringArray(Properties.Resources.Day6, Environment.NewLine + Environment.NewLine);
            timeHelper.Start();
            List<string> inputList = input.ToList();
            int uniqueAnwsers = inputList.Select(anw => AllHAveUniqueChar(anw.Split("\r\n"))).Sum();
            Console.WriteLine(uniqueAnwsers);
            timeHelper.Stop();
        }


        private int UniqueChars(string anwsers)
        {
            return anwsers.Distinct().Count();
        }

        private int AllHAveUniqueChar(string[] anwsers)
        {
            char[] result = anwsers[0].ToArray();
            foreach (string anwser in anwsers) {
                result = result.Where(c => anwser.Contains(c)).ToArray();
            }
            return result.Distinct().Count();
        }
    }
}
