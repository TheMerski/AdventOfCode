using AOC2020.Helpers;
using AOC2020.Solutions;
using System;
using System.Diagnostics;

namespace AOC2020
{
    class Program
    {

        private static TimeHelper timeHelper;

        static void Main(string[] args)
        {
            timeHelper = new TimeHelper();
            Console.WriteLine("Day 11");
            timeHelper.Start();
            new Day11();
            timeHelper.Stop();
        }


    }
}
