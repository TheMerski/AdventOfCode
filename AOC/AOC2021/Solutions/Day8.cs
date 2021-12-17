namespace AOC2021.Solutions;

public class Day8 : AdventBase
{
    List<string> outputLines;
    List<string> mappingLines;

    public Day8(string inputFile = "Day8.txt") : base(inputFile)
    {
        outputLines = this.InputLines.Select(l => l.Split('|')[1].Trim()).ToList();
        mappingLines = this.InputLines.Select(l => l.Split('|')[0].Trim()).ToList();
    }

    protected override Task<string> ExecutePart1()
    {
        long count = 0;
        foreach (var line in outputLines)
        {
            count += CountUniqueSegments(GetSegments(line));
        }
        return Task.FromResult($"Unique segment count: {count}");
    }

    protected override Task<string> ExecutePart2()
    {
        long sum = 0;
        for (int i = 0; i < mappingLines.Count(); i++)
        {
            var nums = GetNummerLetters(GetSegments(mappingLines[i]));
            sum += GetOutputValues(nums, GetSegments(outputLines[i]));
        }
        return Task.FromResult($"segments sum: {sum}");
    }

    private List<string> GetSegments(string line)
    {
        return line.Split(" ").Where(s => !string.IsNullOrWhiteSpace(s) && s != "|").Select(s => s.Trim()).ToList();
    }

    private int CountUniqueSegments(List<string> segments)
    {
        int[] unique = new int[] { 2, 3, 4, 7 };
        return segments.Where(s => unique.Contains(s.Count())).Count();
    }

    private int GetOutputValues(string[] nums, List<string> outputSeg)
    {
        string outStr = "";
        foreach (var seg in outputSeg)
        {
            var sortedSeg = seg.Sort();
            outStr += Array.IndexOf(nums, sortedSeg).ToString();
        }
        return int.Parse(outStr);
    }

    private string[] GetNummerLetters(List<string> inputSeg)
    {
        string[] nums = new string[10];

        // unique
        nums[1] = inputSeg.Where(s => s.Length == 2).First();
        nums[4] = inputSeg.Where(s => s.Length == 4).First();
        nums[7] = inputSeg.Where(s => s.Length == 3).First();
        nums[8] = inputSeg.Where(s => s.Length == 7).First();

        nums[0] = inputSeg.Where(s => s.Length == 6 && !nums[4].All(c => s.Contains(c)) && nums[7].All(c => s.Contains(c))).First();
        nums[9] = inputSeg.Where(s => s.Length == 6 && nums[4].All(c => s.Contains(c))).First();
        nums[6] = inputSeg.Where(s => s.Length == 6 && s.Sort() != nums[0].Sort() && s.Sort() != nums[9].Sort()).First();

        nums[3] = inputSeg.Where(s => s.Length == 5 && nums[7].All(c => s.Contains(c))).First();
        nums[5] = inputSeg.Where(s => s.Length == 5 && s.All(c => nums[6].Contains(c))).First();
        nums[2] = inputSeg.Where(s => s.Length == 5 && !s.All(c => nums[3].Contains(c)) && !s.All(c => nums[5].Contains(c))).First();

        // Sort the numbers
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = nums[i].Sort();
        }

        return nums;
    }
}

