using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public partial class DayOne : IDailyChallenge<(List<int> ListA, List<int> ListB)>
{
    public int CalculateTotalDistance(List<int> listA, List<int> listB)
    {
        if (listA.Count != listB.Count)
        {
            throw new ArgumentException("Lists must be the same size!");
        }

        listA = listA.OrderBy(x => x ).ToList();
        listB = listB.OrderBy(x => x).ToList();

        var distances = new List<int>();


        for (int i = 0; i < listA.Count; i++)
        {
            var a = listA[i];
            var b = listB[i];

            var distance = Math.Abs(a - b);
            distances.Add(distance);
        }

        return distances.Sum(x => x);
    }

    #region Parse Input
    
    [GeneratedRegex(@"(\d+)\s+(\d+)", RegexOptions.Compiled)]
    private static partial Regex DayOneInputRegex();

    public (List<int> ListA, List<int> ListB) ParseInput(string input)
    {
        var listA = new List<int>();
        var listB = new List<int>();

        foreach (Match match in DayOneInputRegex().Matches(input))
        {
            if (match.Success)
            {
                // Add to respective lists
                listA.Add(int.Parse(match.Groups[1].Value));
                listB.Add(int.Parse(match.Groups[2].Value));
            }
        }

        return (listA, listB);
    }
    
    #endregion Parse Input
}