using AOC2020.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AOC2020.Solutions
{
    class Day5
    {
        private TimeHelper timeHelper;
        private string[] input;
        public Day5()
        {
            timeHelper = new TimeHelper();
            input = ResourceReader.ReadResourceToStringArray(Properties.Resources.Day5, Environment.NewLine);
            Array.Sort(input);
            timeHelper.Start();
            string[] bitInput = input.Select(seat => replaceLettersByNumbers(seat)).ToArray();
            int[] seatIds = bitInput.Select(seat => getSeatId(seat)).ToArray();
            Console.WriteLine(findMissingSeat(seatIds));
            timeHelper.Stop();
        }

        private int findMissingSeat(int[] seats)
        {
            Array.Sort(seats);
            for (int i = 1; i < seats.Length - 1; i++)
            {
                int seat = seats[i];
                if (seats[i+1] != seat + 1) {
                    return seat + 1;
                } 
            }
            return 0;
        }

        private string replaceLettersByNumbers(string seat)
        {
            seat = seat.Replace('F', '0');
            seat = seat.Replace('B', '1');
            seat = seat.Replace('L', '0');
            seat = seat.Replace('R', '1');
            return seat;
        }

        private int getSeatId(string seat)
        {
            int row = getRow(seat);
            int col = getCol(seat);
            int rowMul = row * 8;
            return rowMul + col;
        }

        private int getRow(string seat)
        {
            string rowS = seat.Substring(0, 7);
            return Convert.ToInt32(rowS, 2);
        }

        private int getCol(string seat)
        {
            string rowS = seat.Substring(7, 3);
            return Convert.ToInt32(rowS, 2);
        }
    }
}
