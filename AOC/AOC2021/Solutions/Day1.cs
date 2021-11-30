using System;
using AOCHelpers;
using AOCHelpers.Extensions;

namespace AOC2021.Solutions
{
    public class Day1 : AdventBase
    {
        private int[] input;

        public Day1() : base("Day1.txt")
        {
            this.input = RawInput.ToIntArray(Environment.NewLine);
        }

        protected override Task<string> ExecutePart1()
        {
            Array.Sort(input);
            return Task.FromResult(findMulOfTwoEntriesForSum(2020).ToString());
        }

        protected override Task<string> ExecutePart2()
        {
            Array.Sort(input);
            return Task.FromResult(findMulOfThreeEntriesForSum(2020).ToString());
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

