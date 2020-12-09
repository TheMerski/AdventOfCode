using AOC2020.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace AOC2020.Solutions
{
    class Day9
    {
        private TimeHelper timeHelper;
        private long[] input;

        public Day9()
        {
            timeHelper = new TimeHelper();
            input = ResourceReader.ReadResourceToLongArray(Properties.Resources.Day9, Environment.NewLine);
            timeHelper.Start();
            long isNot = IsNotSumOfPreamble(25);
            long[] sums = findSetMakingSum(isNot);
            long weakness = sums.Max() + sums.Min();
            Console.WriteLine(weakness);
            timeHelper.Stop();
        }

        private long IsNotSumOfPreamble(int preamble)
        {
            for (int i = preamble; i < input.Length; i++)
            {
                long number = input[i];
                bool isSum = IsSumOf(number, input.SubArray(i - preamble, preamble));
                if (!isSum)
                {
                    return number;
                }
            }
            return 0;
        }

        private long[] findSetMakingSum(long number)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int y = 1; y < input.Length; y++)
                {
                    long[] sumArr = input.SubArray(i, y);
                    long sum = sumArr.Sum();
                    if (sum > number)
                    {
                        continue;
                    }
                    if (sum == number)
                    {
                        return sumArr;
                    }
                }
            }
            return null;
        }

        private bool IsSumOf(long number, long[] numbers)
        {
            Array.Sort(numbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int y = 0; y < numbers.Length; y++)
                {
                    long sum = numbers[i] + numbers[y];
                    if (sum > number)
                    {
                        continue;
                    }
                    if (sum == number)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
