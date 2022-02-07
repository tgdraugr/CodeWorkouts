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
        
        [Fact]
        public void Should_be_fizz_when_multiple_of_three()
        {
            var fizzBuzz = new FizzBuzz();
            Assert.Equal("Fizz", fizzBuzz.DoFizzBuzz(3));
            Assert.Equal("Fizz", fizzBuzz.DoFizzBuzz(6));
            Assert.Equal("Fizz", fizzBuzz.DoFizzBuzz(9));
        }

        [Fact]
        public void Should_be_buzz_when_multiple_of_five()
        {
            var fizzBuzz = new FizzBuzz();
            Assert.Equal("Buzz", fizzBuzz.DoFizzBuzz(5));
            Assert.Equal("Buzz", fizzBuzz.DoFizzBuzz(10));
            Assert.Equal("Buzz", fizzBuzz.DoFizzBuzz(20));
        }
    }
}