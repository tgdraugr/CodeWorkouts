namespace LeapYears;

public static class Years
{
    public static bool IsLeapYear(int year)
    {
        var divisibleBy4 = year % 4 == 0;
        var divisibleBy100 = year % 100 == 0;
        var divisibleBy400 = year % 400 == 0;
        
        return divisibleBy4 && !divisibleBy100 || divisibleBy400;
    }
}