using AOC2020.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AOC2020
{
    class Day1
    {
        private TimeHelper timeHelper;
        private int[] input;
        public Day1()
        {
            timeHelper = new TimeHelper();
            input = ResourceReader.readResourceToIntArray(Properties.Resources.Day1, Environment.NewLine);
            Array.Sort(input);
            timeHelper.Start();
            Console.WriteLine(findMulOfThreeEntriesForSum(2020).ToString());
            timeHelper.Stop();
        }


        private int findMulOfThreeEntriesForSum(int sum)
        {
            foreach (int a in input)
            { 
                foreach (int b in input)
                {
                    foreach (int c in input)
                    {
                        int result = a + b + c;
                        if (result == sum) return a * b * c;
                        else if (result > sum) continue;
                    }
                }
            }
            return 0;
        }

        private int findMulOfTwoEntriesForSum(int sum)
        {
            foreach (int a in input)
            {
                foreach (int b in input)
                {
                    int result = a + b;
                    if (result == sum) return a * b;
                    else if (result > sum) continue;
                }
            }
            return 0;
        }
    }
}
