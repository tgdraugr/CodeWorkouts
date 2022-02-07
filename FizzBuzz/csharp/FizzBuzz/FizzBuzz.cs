namespace FizzBuzz;

public class FizzBuzz
{
    private static readonly IEnumerable<int> MultiplesOf3 = MultiplesOf(3);
    private static readonly IEnumerable<int> MultiplesOf5 = MultiplesOf(5);

    private static readonly Dictionary<string, IEnumerable<int>> MultiplesPerDescriptor =
        new()
        {
            { "FizzBuzz", MultiplesOf3.Intersect(MultiplesOf5) },
            { "Fizz", MultiplesOf3 },
            { "Buzz", MultiplesOf5 }
        };

    public string DoFizzBuzz(int number)
    {
        foreach (var (key, _) in MultiplesPerDescriptor.Where(pair => pair.Value.Contains(number)))
        {
            return key;
        }

        return number.ToString();
    }

    private static IEnumerable<int> MultiplesOf(int number, int limit = 100)
    {
        var multiple = number;
        do
        {
            yield return multiple;
            multiple += number;
        } while (multiple <= limit);
    }
}