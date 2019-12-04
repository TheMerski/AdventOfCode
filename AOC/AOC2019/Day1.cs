using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AOC2019
{
    class Day1
    {
        private int _total;

        public Day1()
        {
            _total = 0;
            Console.WriteLine("Please input the amount of values to add");
            int amount = GetValue();
            Calculate(amount);
            Console.WriteLine("Total fuel required: " + _total);

            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
        }

        private void Calculate(int valueAmount)
        {
            for (int i = 0; i < valueAmount; i++)
            {
                int value = GetValue();
                int mass = 0;
                int lastMass = value;
                while (lastMass > 0)
                {
                    lastMass = Calc(lastMass);
                    if (lastMass <= 0) break;
                    
                    mass += lastMass;
                    Console.WriteLine(lastMass);
                }
                _total += mass;
            }
        }

        private int Calc(int fuelMass)
        {
            return (int)(MathF.Floor((float) fuelMass / 3) - 2);
        }

        private int GetValue()
        {
            string input = Console.ReadLine();
            int amount;
            bool isInt = int.TryParse(input, out amount);
            if (isInt)
            {
                return amount;
            }
            else
            {
                Console.WriteLine("Please only insert a number");
                return GetValue();
            }
        }
    }
}
