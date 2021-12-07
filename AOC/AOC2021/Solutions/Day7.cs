using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021.Solutions;

public class Day7 : AdventBase
{
    long[] crabPositions;
    public Day7(string inputFile = "Day7.txt") : base(inputFile)
    {
        var positions = InputLines[0].ToLongArray(',');
        var maxValue = positions.Max() + 1;
        crabPositions = new long[maxValue];
        foreach (var position in positions)
        {
            crabPositions[position] += 1;
        }
    }

    protected override Task<string> ExecutePart1()
    {
        long maxIndex = 0;
        long fuel = long.MaxValue;
        for (int i = 0; i < crabPositions.Length; i++)
        {
            var calculatedFuel = CalculateFuelForPosition(i);
            if (calculatedFuel < fuel)
            {
                maxIndex = i;
                fuel = calculatedFuel;
            }
        }
        return Task.FromResult($"Fuel: {fuel} for position: {maxIndex}");
    }

    protected override Task<string> ExecutePart2()
    {
        long maxIndex = 0;
        long fuel = long.MaxValue;
        Dictionary<int, long> cache = new Dictionary<int, long>();
        for (int i = 0; i < crabPositions.Length; i++)
        {
            var calculatedFuel = CalculateFuelForPositionPart2(cache, i);
            if (calculatedFuel < fuel)
            {
                maxIndex = i;
                fuel = calculatedFuel;
            }
        }
        return Task.FromResult($"Fuel: {fuel} for position: {maxIndex}");
    }

    private long CalculateFuelForPosition(int index)
    {
        long fuel = 0;
        for (int i = 0; i < crabPositions.Length; i++)
        {
            if (i != index)
            {
                var offset = i > index ? i - index : index - i;
                fuel += crabPositions[i] * offset;
            }
        }
        return fuel;
    }

    private long CalculateFuelForPositionPart2(Dictionary<int, long> cache, int index)
    {
        long fuel = 0;
        for (int i = 0; i < crabPositions.Length; i++)
        {
            if (i != index)
            {
                var offset = i > index ? i - index : index - i;
                if (!cache.ContainsKey(offset))
                {
                    int sum = 0;
                    for (var j = 0; j <= offset; j++)
                    {
                        sum = sum + j;
                    }
                    cache[offset] = sum;
                }


                fuel += crabPositions[i] * cache[offset];
            }
        }
        return fuel;
    }
}

public record Position(long position)
{
    public long Count { get; set; }
}