using Xunit;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTest
    {
        private readonly FizzBuzz _fizzBuzz = new();

        [Fact]
        public void Should_be_number_when_not_multiple_of_either()
        {
            var output = _fizzBuzz.DoFizzBuzz(1);
            Assert.Equal("1", output);
        }
        
        [Fact]
        public void Should_be_fizz_when_multiple_of_three()
        {
            Assert.Equal("Fizz", _fizzBuzz.DoFizzBuzz(3));
            Assert.Equal("Fizz", _fizzBuzz.DoFizzBuzz(6));
            Assert.Equal("Fizz", _fizzBuzz.DoFizzBuzz(9));
        }

        [Fact]
        public void Should_be_buzz_when_multiple_of_five()
        {
            Assert.Equal("Buzz", _fizzBuzz.DoFizzBuzz(5));
            Assert.Equal("Buzz", _fizzBuzz.DoFizzBuzz(10));
            Assert.Equal("Buzz", _fizzBuzz.DoFizzBuzz(20));
        }

        [Fact]
        public void Should_be_fizz_buzz_when_multiple_of_both_three_and_five()
        {
            Assert.Equal("FizzBuzz", _fizzBuzz.DoFizzBuzz(15));
            Assert.Equal("FizzBuzz", _fizzBuzz.DoFizzBuzz(30));
            Assert.Equal("FizzBuzz", _fizzBuzz.DoFizzBuzz(45));
        }
    }
}