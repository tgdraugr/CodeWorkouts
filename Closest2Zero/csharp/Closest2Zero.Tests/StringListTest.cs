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
            var words = new List<string>();
            Assert.Throws<InvalidOperationException>(() => words.ClosestToZero());
        }

        [Fact]
        public void ShouldFindTheClosestToZero() 
        {
            var words = new List<string> { "zero" };
            Assert.True(words.ClosestToZero() == "zero");

            words = new List<string> { "ezro" };
            Assert.True(words.ClosestToZero() == "ezro");
        }

        [Fact]
        public void ShouldFindTheClosestToZeroByChoosingTheShortestOne() 
        {
            var words = new List<string> { "zerooo", "zeor" };
            Assert.True(words.ClosestToZero() == "zeor");
        }

        [Fact]
        public void ShouldFindTheClosestToZeroByChoosingTheOneWithLettersInTheMostSimilarOrder() 
        {
            var words = new List<string> { "eorz", "oezr", "zore" };
            Assert.True(words.ClosestToZero() == "zore");
        }

        [Fact]
        public void ShouldFindTheClosestToZeroByChoosingTheOneThatAppearedFirst() 
        {
            var words = new List<string> { "zeor", "zore", "zoree" };
            Assert.True(words.ClosestToZero() == "zeor");
        }
    }
}