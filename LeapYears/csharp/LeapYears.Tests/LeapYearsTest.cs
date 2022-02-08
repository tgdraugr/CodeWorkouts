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
}