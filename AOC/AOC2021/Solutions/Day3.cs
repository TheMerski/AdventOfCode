namespace AOC2021.Solutions;

public class Day3 : AdventBase
{
    private readonly List<string> input;
    private readonly List<char[]> inputChars;

    public Day3(): base("Day3.txt")
    {
        input = this.RawInput.ToStringList(Environment.NewLine);
        inputChars = input.Select(s => s.ToArray()).ToList();
    }

    protected override Task<string> ExecutePart1()
    {
        (string mostCommon, string leastCommon) = GetMostAndLeastCommonForPlace();
        int eps = Convert.ToInt32(mostCommon, 2);
        int gam = Convert.ToInt32(leastCommon, 2);

        return Task.FromResult($"Mostcommon: '{mostCommon} : {eps}', leastCommon: '{leastCommon}: {gam}', multiplication: {gam * eps}");
    }

    protected override Task<string> ExecutePart2()
    {
        (string oxygenStr, string coStr) = GetPart2Values();
        int eps = Convert.ToInt32(oxygenStr, 2);
        int gam = Convert.ToInt32(coStr, 2);

        return Task.FromResult($"oxygen: '{oxygenStr} : {eps}', co: '{coStr}: {gam}', multiplication: {gam * eps}");
    }

    private (string, string) GetPart2Values()
    {
        var oxygenStr = GetSingleElement(true);
        var coStr = GetSingleElement(false);

        if (coStr == null || oxygenStr == null)
        {
            throw new Exception("I fucked up");
        }
        return (oxygenStr, coStr);
    }

    private string? GetSingleElement(bool mostCommon)
    {
        var list = inputChars.ToList();
        for (int i = 0; i < list[0].Length; i++)
        {
            if (list.Count() == 1)
            {
                return new string(list[0]);
            }
            var zeroAtIndexList = list.Where(c => c[i] == '0');
            if ((zeroAtIndexList.Count() > list.Count / 2) == mostCommon)
            {
                list = zeroAtIndexList.ToList();
            } else
            {
                list = list.Where(c => c[i] == '1').ToList();
            }
        }
        return list.Count == 1 ? new string(list[0]) : null;
    }


    private (string, string) GetMostAndLeastCommonForPlace()
    {
        string mostCommon = "";
        string leastCommon = "";
        for (int i = 0; i < inputChars[0].Length; i++)
        {
            if (inputChars.Where(c => c[i] == '0').Count() > inputChars.Count / 2)
            {
                mostCommon += '0';
                leastCommon += '1';
            }
            else
            {
                mostCommon += '1';
                leastCommon += '0';
            }
        }
        return (mostCommon, leastCommon);
    }
}

