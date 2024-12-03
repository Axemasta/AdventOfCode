using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public partial class DayThree
{
    [GeneratedRegex(@"(mul)\((\d+),(\d+)\)", RegexOptions.Compiled)]
    private static partial Regex ExtractMultipleRegex();
    
    public List<MultiplyCommand> DecidpherCorruptedCommands(string input)
    {
        var commands = new List<MultiplyCommand>();
        
        var matches = ExtractMultipleRegex().Matches(input);

        foreach (Match match in matches)
        {
            var inputA = int.Parse(match.Groups[2].Value);
            var inputB = int.Parse(match.Groups[3].Value);

            commands.Add(new MultiplyCommand(inputA, inputB));
        }
        
        return commands;
    }
}

public class MultiplyCommand(int A, int B)
{
    public int Execute()
    {
        return A * B;
    }
}

public static class CommandExtensions
{
    public static int CalculateSum(this List<MultiplyCommand> commands)
    {
        return commands.Sum(command => command.Execute());
    }
}