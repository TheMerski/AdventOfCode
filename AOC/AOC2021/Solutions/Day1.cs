namespace AOC2021.Solutions;

public class Day1 : AdventBase
{
    private long[] input;

    public Day1() : base("Day1.txt")
    {
        this.input = RawInput.ToLongArray(Environment.NewLine);
    }

    protected override Task<string> ExecutePart1()
    {
        return Task.FromResult(FindDepthIncreases().ToString());
    }

    protected override Task<string> ExecutePart2()
    {
        return Task.FromResult(FindDepthIncreasesWindow(3).ToString());
    }

    private long FindDepthIncreases()
    {
        var increases = 0;
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] > input[i - 1])
            {
                increases++;
            }
        }
        return increases;
    }

    private long FindDepthIncreasesWindow(int windowLength)
    {
        var increases = 0;
        for (int i = 1; i < input.Length; i++)
        {
            if (GetWindowSum(i, windowLength) > GetWindowSum(i - 1, windowLength))
            {
                increases++;
            }
        }
        return increases;
    }

    private long GetWindowSum(int index, int length)
    {
        long sum = 0;
        for (int i = index; i < index + length && i < input.Length; i++)
        {
            sum += input[i];
        }
        return sum;
    }
}

