namespace AOC2021.Solutions;

public class Day6 : AdventBase
{
    private List<int> Fish;
    public Day6(string inputFile = "Day6.txt") : base(inputFile)
    {
        this.Fish = this.RawInput.Split(',').Select(s => int.Parse(s)).ToList();
    }

    protected override Task<string> ExecutePart1()
    {
        var fish = this.ExecuteDays(80);
        return Task.FromResult($"Fish: {fish}");
    }

    protected override Task<string> ExecutePart2()
    {
        var fish = this.ExecuteDays(256);
        return Task.FromResult($"Fish: {fish}");
        throw new NotImplementedException();
    }

    private long ExecuteDays(int days)
    {
        var initial = GetInitial();

        for (int i = 0; i < days; i++)
        {
            var ToAdd = initial[0];
            var newArray = new long[initial.Length];
            Array.Copy(initial, 1, newArray, 0, initial.Length - 1);
            newArray[6] += ToAdd;
            newArray[8] += ToAdd;
            initial = newArray;
        }
        return initial.Sum();
    }

    private long[] GetInitial()
    {
        var array = new long[9];
        foreach (var fishIndex in Fish)
        {
            array[fishIndex] += 1;
        }
        return array;
    }
}