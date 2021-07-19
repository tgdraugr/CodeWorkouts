using System;
using System.Collections.Generic;
using Xunit;

namespace Closest2Zero.Tests
{
    public class IntegerListTest 
    {
        [Fact]
        public void ShouldThrowAnExceptionWhenFindingClosestToZero()
        {
            List<int> numbers = new List<int>();
            Assert.Throws<InvalidOperationException>(() => numbers.ClosestToZero());
        }

        [Fact]
        public void ShouldFindTheValueClosestToZero() 
        {
            var numbers = new List<int> { 1 };
            Assert.True(numbers.ClosestToZero() == 1);

            numbers = new List<int> { 2, 1 };
            Assert.True(numbers.ClosestToZero() == 1);

            numbers = new List<int> { 10, 20, 2, 5 };
            Assert.True(numbers.ClosestToZero() == 2);
        }

        [Fact]
        public void ShouldConsiderThePositiveValueAsTheClosestToZeroWhenThereIsATie() 
        {
            List<int> numbers = new List<int> { 1, -1 };
            Assert.True(numbers.ClosestToZero() == 1);
        }
    }
}