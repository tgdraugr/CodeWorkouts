using System;
using System.Collections;
using System.Collections.Generic;
using KarateChops.Library;
using Xunit;
using static KarateChops.Library.BinaryChops;

namespace KarateChops.UnitTests
{
    public class BinaryChopsTests
    {
        public static IEnumerable<object[]> ChopMethods()
        {
            yield return new object[] { (Func<int, int[], int>)Chop };
            yield return new object[] { (Func<int, int[], int>)ChopRecursive };
            yield return new object[] { (Func<int, int[], int>)ChopFunctional };
        }
        
        [Theory]
        [MemberData(nameof(ChopMethods))]
        public void TestChop(Func<int, int[], int> testingFn)
        {
            Assert.Equal(-1, testingFn(1, Array.Empty<int>()));
            Assert.Equal(0, testingFn(1, new []{ 1 }));
            Assert.Equal(0, testingFn(1, new []{ 1, 2 }));
            Assert.Equal(-1, testingFn(0, new []{ 1, 2, 3 }));
            Assert.Equal(0, testingFn(1, new []{ 1, 2, 3 }));
            Assert.Equal(1, testingFn(2, new []{ 1, 2, 3 }));
            Assert.Equal(2, testingFn(3, new []{ 1, 2, 3 }));
            Assert.Equal(-1, testingFn(4, new []{ 1, 2, 3 }));
            Assert.Equal(3, testingFn(5, new []{ 1, 2, 3, 5 }));
            Assert.Equal(2, testingFn(3, new []{ 1, 2, 3, 5 }));
            Assert.Equal(1, testingFn(2, new []{ 1, 2, 3, 5 }));
            Assert.Equal(-1, testingFn(0, new []{ 1, 2, 3, 5 }));
        }
    }
}