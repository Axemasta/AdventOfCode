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
}