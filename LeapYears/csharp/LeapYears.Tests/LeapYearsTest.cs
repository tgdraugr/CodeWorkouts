using Xunit;

namespace LeapYears.Tests;

public class LeapYearsTest
{
    [Theory]
    [InlineData(1997)]
    [InlineData(1800)]
    public void Should_not_be_a_leap_year(int year)
    {
        Assert.False(Years.IsLeapYear(year));
    }

    [Theory]
    [InlineData(1996)]
    [InlineData(1600)]
    public void Should_be_a_leap_year(int year)
    {
        Assert.True(Years.IsLeapYear(year));
    }
}