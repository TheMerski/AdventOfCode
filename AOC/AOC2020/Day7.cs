using AOC2020.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2020
{
    class Day7
    {
        private TimeHelper timeHelper;
        private string[] input;
        public Day7()
        {
            timeHelper = new TimeHelper();
            input = ResourceReader.ReadResourceToStringArray(Properties.Resources.Day7, Environment.NewLine);
            timeHelper.Start();
            Console.WriteLine(HoldsShiny());
            timeHelper.Stop();
        }

        private int HoldsShiny()
        {
            List<string> directly = input.Where(input => input.Contains("shiny gold") && !input.StartsWith("shiny gold")).ToList();
            string bagRegex = @"^(.*?)(?=bags)";
            Regex bagR = new Regex(bagRegex);
            List<string> bags = new List<string>();
            directly.ForEach(direct => bags.Add(bagR.Match(direct).Value.Trim()));
            List<string> canContain = input.Where(bag => bags.Any(st => bag.Contains(st))).ToList();
            return canContain.Count();
        }
    }
}
