namespace LeapYears;

public static class Years
{
    public static bool IsLeapYear(int year)
    {
        return year % 4 == 0 && year % 400 == 0;
    }
}