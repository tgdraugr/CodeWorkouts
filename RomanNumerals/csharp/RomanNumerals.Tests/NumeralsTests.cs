using Xunit;

namespace RomanNumerals.Tests
{
    public class NumeralsTests
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
        [InlineData(29, "XXIX")]
        [InlineData(80, "LXXX")]
        [InlineData(294, "CCXCIV")]
        [InlineData(2019, "MMXIX")]

        public void Should_convert_roman_to_arabic_numerals(int amount, string expected)
        {
            Assert.Equal(expected, Numerals.ConvertToArabic(amount));
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("I", 1)]
        [InlineData("II", 2)]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("V", 5)]
        [InlineData("VI", 6)]
        [InlineData("VII", 7)]
        [InlineData("VIII", 8)]
        [InlineData("IX", 9)]
        [InlineData("X", 10)]
        [InlineData("MCMXLIV", 1944)]
        [InlineData("MMVI", 2006)]
        [InlineData("XXIX", 29)]
        [InlineData("LXXX", 80)]
        [InlineData("CCXCIV", 294)]
        [InlineData("MMXIX", 2019)]
        public void Should_convert_arabic_to_roman_numerals(string arabic, int expected)
        {
            Assert.Equal(expected, Numerals.ConvertToRoman(arabic));
        }
    }
}
