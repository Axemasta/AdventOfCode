using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public partial class DayTwo : IDailyChallenge<List<int[]>>
{
    public List<int[]> GetSafeReports(List<int[]> reactorReports)
    {
        return reactorReports.Where(IsReportSafe)
            .ToList();
    }
    
    public List<int[]> GetSafeReportsWithProblemDamper(List<int[]> reactorReports)
    {
        return reactorReports.Where(IsReportSafeWithProblemDamper)
            .ToList();
    }

    private bool IsReportSafe(int[] levels)
    {
        if (levels.Length < 2)
        {
            throw new InvalidOperationException("More data required to analyze report!");
        }
        
        var isIncreasing = true;
        var isDecreasing = true;
        
        for (int i = 1; i < levels.Length; i++)
        {
            var difference = Math.Abs(levels[i] - levels[i - 1]);

            if (difference is < 1 or > 3)
            {
                return false;
            }
            
            if (levels[i] < levels[i - 1])
            {
                isIncreasing = false;
            }

            if (levels[i] > levels[i - 1])
            {
                isDecreasing = false;
            }

            if (!isIncreasing && !isDecreasing)
            {
                return false;
            }
        }

        return true;
    }

    private bool IsReportSafeWithProblemDamper(int[] levels)
    {
        if (levels.Length < 2)
        {
            throw new InvalidOperationException("More data required to analyze report!");
        }

        var isSafe = IsReportSafe(levels);

        if (isSafe)
        {
            return true;
        }

        var subLevels = GenerateSubArrays(levels);

        return subLevels.Any(IsReportSafe);
    }
    
    private List<int[]> GenerateSubArrays(int[] array)
    {
        List<int[]> subArrays = new List<int[]>();

        for (int i = 0; i < array.Length; i++)
        {
            // Create a new array excluding the element at index `i`
            int[] subArray = new int[array.Length - 1];
            int index = 0;

            for (int j = 0; j < array.Length; j++)
            {
                if (j != i)
                {
                    subArray[index] = array[j];
                    index++;
                }
            }

            subArrays.Add(subArray);
        }

        return subArrays;
    }
    
    #region Parse Input
    
    [GeneratedRegex(@"^\s*(\d+(?:\s+\d+)*)\s*$", RegexOptions.Multiline)]
    private static partial Regex DayTwoRegex();
    
    public List<int[]> ParseInput(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        return lines
            .Select(line => DayTwoRegex().Match(line))
            .Where(match => match.Success)
            .Select(match => match.Groups[1].Value
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray())
            .ToList();
    }

    #endregion Parse Input
}