using AOC2020.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2020.Solutions
{
    class Day8
    {
        string numRegexString = @"((-|\+)[0-9]+)";
        Regex numRegex;

        private TimeHelper timeHelper;
        private string[] input;
        private string[] newInput;

        private List<int> IndexesRan;
        private int accumulator = 0;

        public Day8()
        {
            numRegex = new Regex(numRegexString);
            timeHelper = new TimeHelper();
            input = ResourceReader.ReadResourceToStringArray(Properties.Resources.Day8, Environment.NewLine);
            timeHelper.Start();
            RunInstructionsOnce();
            Console.WriteLine(accumulator);
            timeHelper.Stop();
        }

        private void RunInstructionsOnce()
        {
            for (int i = 0; i < input.Length; i++)
            {
                string oldInput = input[i];
                if (input[i].StartsWith("jmp"))
                {
                    input[i] = input[i].Replace("jmp", "nop");
                }
                else if (input[i].StartsWith("nop"))
                {
                    input[i] = input[i].Replace("nop", "jmp");
                }
                IndexesRan = new List<int>();
                accumulator = 0;
                bool notloop = RunInstruction(0);
                if (notloop)
                {
                    break;
                }
                input[i] = oldInput;
            }
        }

        private bool RunInstruction(int index)
        {

            if (index >= input.Length)
            {
                return true;
            }
            string instruction = input[index];
            string inst = instruction.Substring(0, 3);
            int val = Int32.Parse(numRegex.Match(instruction).Value);
            if (IndexesRan.Contains(index))
            {
                return false;
            }
            IndexesRan.Add(index);

            if (inst == "acc")
            {
                RunAcc(val, index);
            }
            else if (inst == "jmp")
            {
                RunJmp(val, index);
            }
            else
            {
                RunInstruction(index + 1);
            }
            return false;
        }

        private void RunAcc(int acc, int index)
        {
            accumulator += acc;
            RunInstruction(index + 1);
        }

        private void RunJmp(int jmp, int index)
        {
            int runAtIndex = index + jmp;
            RunInstruction(runAtIndex);
        }
    }
}
