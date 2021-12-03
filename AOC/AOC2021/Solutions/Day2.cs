namespace AOC2021.Solutions;

public class Day2 : AdventBase
{
    private readonly List<string> commands;
    public Day2() : base("Day2.txt")
    {
        commands = this.RawInput.ToStringList(Environment.NewLine);
    }

    protected override Task<string> ExecutePart1()
    {
        (var hor, var depth) = GetHorizontalAndDepth();
        return Task.FromResult($"Horizontal: {hor}, Depth: {depth}, Multiplication: {hor * depth}");
    }

    protected override Task<string> ExecutePart2()
    {
        (var hor, var depth) = GetHorizontalAndDepthPart2();
        return Task.FromResult($"Horizontal: {hor}, Depth: {depth}, Multiplication: {hor * depth}");
    }

    private (long, long) GetHorizontalAndDepthPart2()
    {
        var commands = ConvertInputToSubCommands();
        long hor = 0;
        long depth = 0;
        long aim = 0;

        commands.ForEach(c =>
        {
            switch (c.Command)
            {
                case CommandType.forward:
                    hor += c.Value;
                    depth += c.Value * aim;
                    break;
                case CommandType.down:
                    aim += c.Value;
                    break;
                case CommandType.up:
                    aim -= c.Value;
                    break;
            }
        });
        return (hor, depth);
    }

    private (long, long) GetHorizontalAndDepth()
    {
        var commands = ConvertInputToSubCommands();
        long hor = commands.Where(c => c.Command == CommandType.forward).Sum(c => c.Value);
        long depth = commands.Where(c => c.Command == CommandType.down).Sum(c => c.Value) - commands.Where(c => c.Command == CommandType.up).Sum(c => c.Value);
        return (hor, depth);
    }

    private List<SubCommand> ConvertInputToSubCommands()
    {
        return commands.Select(s => GetCommand(s)).ToList();
    }

    private SubCommand GetCommand(string commandstr)
    {
        var value = long.Parse(Regex.Match(commandstr, @"-?\d+").Value);
        CommandType type = Enum.Parse<CommandType>(commandstr.Split(' ')[0]);
        return new(type, value);
    }

}

public record SubCommand(CommandType Command, long Value);

public enum CommandType
{
    forward,
    down,
    up,
}

