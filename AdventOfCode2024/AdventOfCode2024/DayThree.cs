using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public partial class DayThree
{
    [GeneratedRegex(@"(mul)\((\d+),(\d+)\)", RegexOptions.Compiled)]
    private static partial Regex ExtractMultiplyCommandRegex();
    
    public List<MultiplyCommand> DecipherCorruptedMultiplyCommands(string input)
    {
        var commands = new List<MultiplyCommand>();
        
        var matches = ExtractMultiplyCommandRegex().Matches(input);

        foreach (Match match in matches)
        {
            var inputA = int.Parse(match.Groups[2].Value);
            var inputB = int.Parse(match.Groups[3].Value);

            commands.Add(new MultiplyCommand(inputA, inputB));
        }
        
        return commands;
    }
    
    [GeneratedRegex(@"(mul|don'?t|do)\((\d*)?,?(\d*)?\)", RegexOptions.Compiled)]
    private static partial Regex ExtractCommandRegex();
    
    public List<Command> DecipherCorruptedCommands(string input)
    {
        var commands = new List<Command>();
        
        var matches = ExtractCommandRegex().Matches(input);

        foreach (Match match in matches)
        {
            if (match.Groups.Count == 4 && match.Groups[1].Value == "don't")
            {
                commands.Add(new DontCommand());
            }
            else if (match.Groups.Count == 4 && match.Groups[1].Value == "do")
            {
                commands.Add(new DoCommand());
            }
            else if (match.Groups.Count == 4 && match.Groups[1].Value == "mul")
            {
                var inputA = int.Parse(match.Groups[2].Value);
                var inputB = int.Parse(match.Groups[3].Value);

                commands.Add(new MultiplyCommand(inputA, inputB));
            }
            else
            {
                Console.WriteLine("Unable to process match: {0}", match);
            }
        }
        
        return commands;
    }
}

public abstract class Command()
{
}

public class MultiplyCommand(int a, int b) : Command
{
    public int A { get; } = a;
    public int B { get; } = b;
    
    public int Execute()
    {
        return A * B;
    }
}

public class DoCommand() : Command;

public class DontCommand() : Command;

public static class CommandExtensions
{
    public static int CalculateSum(this List<MultiplyCommand> commands)
    {
        return commands.Sum(command => command.Execute());
    }
    
    public static int CalculateSum(this List<Command> commands)
    {
        var multiplyEnabled = true;
        
        var enabledMultiplyCommands = commands
            .Where(command => 
            {
                if (command is DoCommand)
                {
                    multiplyEnabled = true;
                }
                else if (command is DontCommand)
                {
                    multiplyEnabled = false;
                }

                return command is MultiplyCommand && multiplyEnabled;
            })
            .OfType<MultiplyCommand>()
            .ToList();

        return enabledMultiplyCommands.CalculateSum();
    }
}