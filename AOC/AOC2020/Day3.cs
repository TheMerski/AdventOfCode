using AOC2020.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020
{
    class Day3
    {
        private TimeHelper timeHelper;
        private string[] input;
        public Day3()
        {
            timeHelper = new TimeHelper();
            input = ResourceReader.ReadResourceToStringArray(Properties.Resources.Day3, Environment.NewLine);
            timeHelper.Start();
            int slope1 = FindTrees(1, 1, '#');
            int slope2 = FindTrees(3, 1, '#');
            int slope3 = FindTrees(5, 1, '#');
            int slope4 = FindTrees(7, 1, '#');
            int slope5 = FindTrees(1, 2, '#');
            long result = (long)slope1 * (long)slope2 * (long)slope3 * (long)slope4 * (long)slope5;
            Console.WriteLine(result);
            timeHelper.Stop();
        }

        private int FindTrees(int right, int down, char tree)
        {
            int trees = 0;
            int x = 0;
            for (int y = 0; y < input.Length; y += down)
            {
                string row = input[y];
                if (row[x % row.Length] == tree)
                {
                    trees++;
                }
                x += right;
            }
            return trees;
        }
    }
}
