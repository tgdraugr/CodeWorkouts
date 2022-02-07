using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTest
    {
        [Fact]
        public void Should_print_number_when_not_multiple_of_either()
        {
            var fizzBuzz = new FizzBuzz();
            var output = fizzBuzz.DoFizzBuzz(1);
            Assert.Equal("1", output);
        }
        
        [Theory]
        [MemberData(nameof(MultiplesOf), 3)]
        public void Should_be_fizz_when_multiple_of_three(int number)
        {
            var fizzBuzz = new FizzBuzz();
            var output = fizzBuzz.DoFizzBuzz(number);
            Assert.Equal("Fizz", output);
        }

        private static IEnumerable<object[]> MultiplesOf(int multiplier)
        {
            var multiple = multiplier;
            do
            {
                yield return new object[] { multiple };
                multiple += multiplier;
            } while (multiple < 100);
        }
    }
}