using System;
using KarateChops.Library;
using Xunit;
using static KarateChops.Library.BinaryChops;

namespace KarateChops.UnitTests
{
    public class BinaryChopsTests
    {
        [Fact]
        public void TestChop()
        {
            Assert.Equal(-1, Chop(1, Array.Empty<int>()));
            Assert.Equal(0, Chop(1, new []{ 1 }));
            Assert.Equal(0, Chop(1, new []{ 1, 2 }));
            Assert.Equal(-1, Chop(0, new []{ 1, 2, 3 }));
            Assert.Equal(0, Chop(1, new []{ 1, 2, 3 }));
            Assert.Equal(1, Chop(2, new []{ 1, 2, 3 }));
            Assert.Equal(2, Chop(3, new []{ 1, 2, 3 }));
            Assert.Equal(-1, Chop(4, new []{ 1, 2, 3 }));
            Assert.Equal(3, Chop(5, new []{ 1, 2, 3, 5 }));
            Assert.Equal(2, Chop(3, new []{ 1, 2, 3, 5 }));
            Assert.Equal(1, Chop(2, new []{ 1, 2, 3, 5 }));
            Assert.Equal(-1, Chop(0, new []{ 1, 2, 3, 5 }));
        }
    }
}