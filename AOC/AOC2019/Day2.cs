using System;
using System.Collections.Generic;
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
            Console.WriteLine("Please insert the op-code");
            ReadOpcodeToArr();
            ExecuteOpcodes();
            PrintResult();
            InputHelpers.PressAnyKeyToExit();
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
            ReplaceCodes();
        }

        private void ReplaceCodes()
        {
            _opcodeArr[1] = 12;
            _opcodeArr[2] = 2;
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
