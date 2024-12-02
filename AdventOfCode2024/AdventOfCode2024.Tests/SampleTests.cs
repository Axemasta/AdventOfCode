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
}