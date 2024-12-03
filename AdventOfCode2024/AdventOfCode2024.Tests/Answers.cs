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
        var inputs = sut.ParseInput(dayOneInput);

        var totalDistance = sut.CalculateTotalDistance(inputs.ListA, inputs.ListB);

        testOutputHelper.WriteLine("Today's answer is: {0}", totalDistance);
    }

    [Fact]
    public void DayTwoAnswer()
    {
        var sut = new DayTwo();
        
        var dayTwoInput = FileHelper.LoadEmbeddedFile("DayTwo.txt");
        
        var reports = sut.ParseInput(dayTwoInput);
        
        var safeReports = sut.GetSafeReports(reports);
        
        // This is correct answer
        Assert.Equal(516, safeReports.Count);
        
        testOutputHelper.WriteLine("Today's answer is: There are {0} safe reports", safeReports.Count);
        
        var safeReportsWithProblemDamper = sut.GetSafeReportsWithProblemDamper(reports);
        
        testOutputHelper.WriteLine("Today's answer is: There are {0} safe reports with the problem damper enabled", safeReportsWithProblemDamper.Count);

        Assert.Equal(561, safeReportsWithProblemDamper.Count);
    }
    
    [Fact]
    public void DayThreeAnswer()
    {
        var sut = new DayThree();

        var dayThreeInput = FileHelper.LoadEmbeddedFile("DayThree.txt");
        
        var commands = sut.DecidpherCorruptedCommands(dayThreeInput);

        var partOneAnswer = commands.CalculateSum();

        testOutputHelper.WriteLine("Today's answer for part one is: {0}", partOneAnswer);
    }
}