namespace LeapYears;

public static class Years
{
    public static bool IsLeapYear(int year)
    {
        var isDivisibleBy4 = year % 4 == 0;
        var isDivisibleBy400 = year % 400 == 0;
        var isDivisibleBy100 = year % 100 == 0;
        
        // !(!isDivisibleBy4 || isDivisibleBy100 && !isDivisibleBy400)

        return !(!isDivisibleBy4 || isDivisibleBy100 && !isDivisibleBy400) && 
               (isDivisibleBy4 || isDivisibleBy400);
    }
}