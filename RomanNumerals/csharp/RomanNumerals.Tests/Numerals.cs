using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals.Tests
{
    internal static class Numerals
    {
        private static readonly IDictionary<int, string> ArabicToRoman =
            new Dictionary<int, string>
            {
                { 1000, "M" },
                { 900, "CM" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" }
            };

        private static readonly IDictionary<string, int> RomanToArabic;

        static Numerals()
        {
            RomanToArabic = ArabicToRoman.ToDictionary(entry => entry.Value, entry => entry.Key);
            RomanToArabic.Add("", 0);
        }

        public static string ConvertToArabic(int amount)
        {
            var result = "";
            
            foreach(var (romanNumeral, arabicNumeral) in ArabicToRoman)
            {
                while (amount >= romanNumeral)
                {
                    result += arabicNumeral;
                    amount -= romanNumeral;
                }
            }

            return result;
        }

        public static int ConvertToRoman(string arabicNumeral)
        {
            var result = 0;

            var arabicNumerals = GetArabicNumerals(arabicNumeral);

            for (var index = 0; index < arabicNumerals.Length; index+=2)
            {
                var left = RomanToArabic[arabicNumerals[index]];
                var right = RomanToArabic[arabicNumerals[index + 1]];
                result += left < right ? 
                    right - left : 
                    left + right;
            }

            return result;
        }

        private static string[] GetArabicNumerals(string arabicNumeral)
        {
            var numerals = arabicNumeral.Select(numeral => numeral.ToString());
            return arabicNumeral.Length % 2 == 0 ? 
                numerals.ToArray() : 
                numerals.Concat(new[] { "" }).ToArray();
        }
    }
}
