using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using AOC2019.Helpers;

namespace AOC2019
{
    class Day2
    {
        private int[] _opcodeArr;

        public Day2()
        {
            Stopwatch stopwatch =   new Stopwatch();
            stopwatch.Start();
            InitArray();
            Console.WriteLine(FindOpcodes(19690720));
            stopwatch.Stop();
            Console.WriteLine("Program ran for: " + stopwatch.ElapsedMilliseconds + "ms");
            InputHelpers.PressAnyKeyToExit();
        }

        private void InitArray()
        {
            _opcodeArr = new[]
            {
                1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 1, 10, 19, 2, 9, 19, 23, 2, 23, 10, 27, 1, 6, 27, 31,
                1, 31, 6, 35, 2, 35, 10, 39, 1, 39, 5, 43, 2, 6, 43, 47, 2, 47, 10, 51, 1, 51, 6, 55, 1, 55, 6, 59, 1,
                9, 59, 63, 1, 63, 9, 67, 1, 67, 6, 71, 2, 71, 13, 75, 1, 75, 5, 79, 1, 79, 9, 83, 2, 6, 83, 87, 1, 87,
                5, 91, 2, 6, 91, 95, 1, 95, 9, 99, 2, 6, 99, 103, 1, 5, 103, 107, 1, 6, 107, 111, 1, 111, 10, 115, 2,
                115, 13, 119, 1, 119, 6, 123, 1, 123, 2, 127, 1, 127, 5, 0, 99, 2, 14, 0, 0
            };
        }

        private void ReadOpcodeToArr()
        { 
            List<int> opcodes = new List<int>();

            string opcodeString = Console.ReadLine();
            if (string.IsNullOrEmpty(opcodeString))
            {
                Console.WriteLine("Input was incorrect, exiting");
                InputHelpers.PressAnyKeyToExit();
            }

            opcodeString = opcodeString.Replace(" ", "");
            string[] strings = opcodeString.Split(',');
            foreach (string s in strings)
            {
                int? sToInt = InputHelpers.ParseStringToInt(s);
                if (sToInt != null) opcodes.Add(sToInt.Value);
            }

            _opcodeArr = opcodes.ToArray();
            ReplaceCodes(12, 2);
        }

        private int FindOpcodes(int output)
        {
            int noun = 0;
            int verb = 0;
            int i = 0;
            do
            {
                InitArray();
                if (noun == 99)
                {
                    noun = 0;
                    verb++;
                }
                else noun++;
                ReplaceCodes(noun, verb);
                try
                {
                    ExecuteOpcodes();
                }
                catch (Exception e)
                {
                    Console.WriteLine(noun + verb);
                }
                i++;
            } while (_opcodeArr[0] != output && verb <= 99 && noun <= 99);
            Console.WriteLine(noun);
            Console.WriteLine(verb);
            return 100 * noun + verb;
        }

        private void ReplaceCodes(int noun, int verb)
        {
            _opcodeArr[1] = noun;
            _opcodeArr[2] = verb;
        }

        private void ExecuteOpcodes()
        {
            for (int i = 0; i < _opcodeArr.Length; i++)
            {
                
                if (i % 4 == 0 || i == 0)
                {
                    if (_opcodeArr[i] == 99) break;
                    if (_opcodeArr[i] == 1) AddOpcode(i);
                    else if (_opcodeArr[i] == 2) MultiplyOpcode(i);
                }
            }
        }

        private void PrintResult()
        {
            Console.WriteLine("Printing result");
            foreach (int i in _opcodeArr)
            {
                Console.Write(i + ",");
            }
            Console.WriteLine();
        }

        private void MultiplyOpcode(int index)
        {
            int num1Index = _opcodeArr[index + 1];
            int num2Index = _opcodeArr[index + 2];
            int resIndex = _opcodeArr[index + 3];

            int num1 = _opcodeArr[num1Index];
            int num2 = _opcodeArr[num2Index];
            _opcodeArr[resIndex] = num1 * num2;
        }

        private void AddOpcode(int index)
        {
            int num1Index = _opcodeArr[index + 1];
            int num2Index = _opcodeArr[index + 2];
            int resIndex = _opcodeArr[index + 3];

            int num1 = _opcodeArr[num1Index];
            int num2 = _opcodeArr[num2Index];
            _opcodeArr[resIndex] = num1 + num2;
        }
    }
}
