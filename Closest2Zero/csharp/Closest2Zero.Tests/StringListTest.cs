using System;
using System.Collections.Generic;
using Xunit;

namespace Closest2Zero.Tests
{
    public class StringListTest 
    {
        [Fact]
        public void ShouldThrowAnExceptionWhenFindingClosestToZero() 
        {
            List<string> words = new List<string>();
            Assert.Throws<InvalidOperationException>(() => words.ClosestToZero());
        }
    }
}