using AOC2020.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;

namespace AOC2020.Solutions
{
    class Day10
    {
        private TimeHelper timeHelper;
        private List<int> input;
        private int OneJolt = 0;
        private int ThreeJolt = 1;
        long options = 1;

        readonly Dictionary<int, long> KnownCounts = new Dictionary<int, long>();

        public Day10()
        {
            timeHelper = new TimeHelper();
            input = ResourceReader.ReadResourceToIntArray(Properties.Resources.Day10Test, Environment.NewLine).ToList();
            input.Add(0);
            input.Add(input.Max() + 3);
            input.Sort();
            timeHelper.Start();
            Console.WriteLine(SolvePartTwo());
            timeHelper.Stop();
        }

        private void CalculateAdapterOptions()
        {
            int i = 0;
            while (i < input.Count)
            {
                List<int> options = findOptions(input[i]).ToList();
                if (options.Count > 0)
                {
                    i = input.IndexOf(options.Max());
                }
                else
                {
                    i++;
                }
                HandleOptions(options);

            }
        }

        private int[] findOptions(int number)
        {
            return input.Where(n => n > number && n <= (number + 3)).ToArray();
        }

        private void HandleOptions(List<int> possible)
        {
            if (possible.Count > 1)
            {
                options += options * (int)Math.Pow(possible.Count-1, possible.Count-1);
            } else if (possible.Count > 0)
            {
                options++;
            }

        }

        private void CalculateJoltDifferences()
        {
            DifferenceHandler(input[0]);
            for (int i = 0; i < input.Count - 1; i++)
            {
                int difference = input[i + 1] - input[i];
                DifferenceHandler(difference);
            }
        }

        private void DifferenceHandler(int difference)
        {
            switch (difference)
            {
                case 1:
                    OneJolt++;
                    break;
                case 3:
                    ThreeJolt++;
                    break;
                default:
                    break;
            }
        }

        //https://github.com/Bpendragon/AdventOfCodeCSharp/blob/master/AdventOfCode/Solutions/Year2020/Day10-Solution.cs
        protected string SolvePartTwo()
        {
            KnownCounts[input.Count - 1] = 0; //The Laptop has only paths to itself. 
            KnownCounts[input.Count - 2] = 1; //We know there is only one path from the final adapter to the laptop.
            FindValid(0);
            return KnownCounts[0].ToString();
        }

        long FindValid(int start)
        {
            if (KnownCounts.ContainsKey(start)) return KnownCounts[start];

            long tmp = 0;
            for (int i = 1; i <= 3; i++)
            {
                if ((start + i < input.Count) && (input[start + i] - input[start] <= 3))
                {
                    tmp += FindValid(start + i);
                }
            }
            KnownCounts[start] = tmp;
            return tmp;
        }
    }
}
