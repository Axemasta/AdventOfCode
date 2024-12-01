using System.Text.RegularExpressions;
using Xunit.Abstractions;

namespace AdventOfCode2024.Tests;

public partial class Answers(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void DayOneAnswer()
    {
        var sut = new DayOne();

        // Load input
        var dayOneInput = FileHelper.LoadEmbeddedFile("DayOne.txt");

        // Parse file into 2 lists
        var inputs = ParseDayOneInput(dayOneInput);

        var totalDistance = sut.CalculateTotalDistance(inputs.ListA, inputs.ListB);

        testOutputHelper.WriteLine("Todays answer is: {0}", totalDistance);
    }

    [GeneratedRegex(@"(\d+)\s+(\d+)", RegexOptions.Compiled)]
    private static partial Regex DayOneInputRegex();

    private (List<int> ListA, List<int> ListB) ParseDayOneInput(string input)
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
}