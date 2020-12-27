using AOC2020.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AOC2020.Solutions
{
    class Day11
    {
        private string[] input;
        public Day11()
        {
            input = ResourceReader.ReadResourceToStringArray(Properties.Resources.Day11, Environment.NewLine);
            SolvePart1();
        }


        private void SolvePart1()
        {
            int oldCount = 0;
            int newCount = 0;
            do
            {
                oldCount = newCount;
                string[] seats = (string[])input.Clone();
                for (int y = 0; y < input.Length; y++)
                {
                    for (int x = 0; x < input[y].Length; x++)
                    {
                        char? replace = ManageSeat(x, y);
                        if (replace != null)
                        {
                            seats[y] = seats[y].ReplaceAtIndex(x, (char)replace);
                        }
                    }
                }
                input = (string[])seats.Clone();
                newCount = CountOccupied();
            } while (newCount != oldCount);
            Console.WriteLine("Part 1: " + newCount);
        }

        private int CountOccupied()
        {
            int count = 0;
            Array.ForEach(input, row => count += row.Where(s => s == '#').Count());
            return count;
        }

        private char? ManageSeat(int x, int y)
        {
            if (input[y][x] == '.')
            {
                return null;
            }
            else if (input[y][x] == 'L')
            {
                if (CountAdjacent(x, y, new char[] { '#' }) == 0)
                {
                    return '#';
                }
            }
            else if (input[y][x] == '#')
            {
                if (CountAdjacent(x, y, new char[] { '#' }) >= 4)
                {
                    return 'L';
                }
            }
            return null;
        }

        private int CountAdjacent(int x, int y, char[] chars)
        {
            int count = 0;
            for (int i = y - 1; i <= y + 1; i++)
            {
                for (int j = x - 1; j <= x + 1; j++)
                {
                    if (i >= 0 && i < input.Length && j >= 0 && j < input[i].Length && !(i == y && j == x) && chars.Contains(input[i][j]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

    }
}
