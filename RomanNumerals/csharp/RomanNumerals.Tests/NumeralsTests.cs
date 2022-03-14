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
            Assert.True(Numerals.ConvertToArabic(amount) == expected);
        }
    }
}
