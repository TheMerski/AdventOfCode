using AOC2020.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2020.Solutions
{
    class Day7
    {
        private TimeHelper timeHelper;
        private string[] input;
        private string bagRegexString = @"(?:([0-9] ))?(\w+\s\w+(?=\sbag))";
        private string numRegexString = "([0-9])";
        private Regex numRegex;
        private Regex bagRegex;

        public Day7()
        {
            timeHelper = new TimeHelper();
            input = ResourceReader.ReadResourceToStringArray(Properties.Resources.Day7, Environment.NewLine);
            bagRegex = new Regex(bagRegexString);
            numRegex = new Regex(numRegexString);


            timeHelper.Start();

            Console.WriteLine(RecursiveCount("shiny gold", 1) - 1);
            timeHelper.Stop();
        }

        private int HoldsShiny()
        {
            List<string> directly = input.Where(input => input.Contains("shiny gold") && !input.StartsWith("shiny gold")).ToList();

            List<string> bags = new List<string>();
            directly.ForEach(direct => bags.Add(bagRegex.Match(direct).Value.Trim()));

            int previous = bags.Count();
            List<string> canContain = input.Where(bag => bags.Any(st => bag.Contains(st))).ToList();

            while (canContain.Count() != previous)
            {
                previous = canContain.Count();
                canContain.ForEach(bag => bags.Add(bagRegex.Match(bag).Value.Trim()));
                canContain = input.Where(bag => bags.Any(st => bag.Contains(st))).ToList();
            }
            return canContain.Count();
        }

        private string[] BagsInBag(string bag)
        {
            bag = Regex.Replace(bag, numRegexString, "").Trim();
            string bagString = input.Where(input => input.StartsWith(bag)).FirstOrDefault();
            if (bagString != null)
            {
                Match[] bags = bagRegex.Matches(bagString).ToArray();
                return bags.Select(b => b.Value).Where(b => b.Trim() != bag.Trim()).ToArray();
            }
            return new string[] { };
        }

        private int? BagAmount(string bag)
        {
            Match num = numRegex.Match(bag);
            int amount;
            bool parsed = Int32.TryParse(num.Value, out amount);
            if (parsed)
            {
                return amount;
            }
            return null;
        }

        private long RecursiveCount(string checkBag, long count)
        {
            string[] bags = BagsInBag(checkBag);
            long c = count;
            foreach (string bag in bags)
            {
                int? amount = BagAmount(bag);
                if (bag.Trim() != "no other" && amount != null)
                {
                    c += (int)amount * RecursiveCount(bag, count);
                }
            }
            return c;
        }
    }
}
