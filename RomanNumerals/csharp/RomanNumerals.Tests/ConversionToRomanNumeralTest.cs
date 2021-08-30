using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RomanNumerals.Tests
{
    public class ConversionToRomanNumeralTest
    {
        [Theory]
        [InlineData(-1, "")]
        [InlineData(0, "")]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(15, "XV")]
        [InlineData(20, "XX")]
        [InlineData(40, "XL")]
        [InlineData(50, "L")]
        [InlineData(90, "XC")]
        [InlineData(100, "C")]
        [InlineData(400, "CD")]
        [InlineData(500, "D")]
        [InlineData(900, "CM")]
        [InlineData(1000, "M")]
        public void TestConvert(int amount, string expected)
        {
            Assert.True(RomanNumerals.Convert(amount) == expected);
        }

        [Fact]
        public void TestAcceptance()
        {
            Assert.True(RomanNumerals.Convert(4) == "IV");
            Assert.True(RomanNumerals.Convert(9) == "IX");
            Assert.True(RomanNumerals.Convert(29) == "XXIX");
            Assert.True(RomanNumerals.Convert(80) == "LXXX");
            Assert.True(RomanNumerals.Convert(294) == "CCXCIV");
            Assert.True(RomanNumerals.Convert(2019) == "MMXIX");
        }
    }
}
