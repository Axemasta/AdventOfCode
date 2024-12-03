using Xunit;

namespace AdventOfCode2024.Tests;

public class SampleTests
{
    [Fact]
    public void DayOneSample_Should_Calculate11()
    {
        var sut = new DayOne();

        List<int> listA = [3, 4, 2, 1, 3, 3];
        List<int> listB = [4, 3, 5, 3, 9, 3];

        var totalDistance = sut.CalculateTotalDistance(listA, listB);

        Assert.Equal(11, totalDistance);
    }

    [Fact]
    public void DayTwoSample_Should_Calculate2ReportsSafe()
    {
        var sut = new DayTwo();

        var sampleData = new List<int[]>()
        {
            new [] { 7, 6, 4, 2, 1 },
            new [] { 1, 2, 7, 8, 9 },
            new [] { 9, 7, 6, 2, 1 },
            new [] { 1, 3, 2, 4, 5 },
            new [] { 8, 6, 4, 4, 1 },
            new [] { 1, 3, 6, 7, 9 },
        };

        var safeReports = sut.GetSafeReports(sampleData);
        
        Assert.Equal(2, safeReports.Count);
    }
    
    [Fact]
    public void DayTwoSampleWithProblemDamper_Should_Calculate2ReportsSafe()
    {
        var sut = new DayTwo();

        var sampleData = new List<int[]>()
        {
            new [] { 7, 6, 4, 2, 1 },
            new [] { 1, 2, 7, 8, 9 },
            new [] { 9, 7, 6, 2, 1 },
            new [] { 1, 3, 2, 4, 5 },
            new [] { 8, 6, 4, 4, 1 },
            new [] { 1, 3, 6, 7, 9 },
        };

        var safeReports = sut.GetSafeReportsWithProblemDamper(sampleData);
        
        Assert.Equal(4, safeReports.Count);
    }

    [Fact]
    public void DayThreeSample_Should_Calculate161()
    {
        var sut = new DayThree();

        var sampleInput = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

        var commands = sut.DecipherCorruptedMultiplyCommands(sampleInput);

        var result = commands.CalculateSum();
        
        Assert.Equal(161, result);
    }
    
    [Fact]
    public void DayThreeSampleWithEnabledDisabled_Should_Calculate48()
    {
        var sut = new DayThree();

        var sampleInput = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

        var commands = sut.DecipherCorruptedCommands(sampleInput);

        var result = commands.CalculateSum();
        
        Assert.Equal(48, result);
    }
}