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

        private static readonly IDictionary<string, int> RomanToArabic = 
            ArabicToRoman.ToDictionary(entry => entry.Value, entry => entry.Key);
        
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
            return ConvertToRoman(arabicNumeral.Select(numeral => numeral.ToString()));
        }

        private static int ConvertToRoman(IEnumerable<string> arabicNumerals)
        {
            var result = 0;
            
            foreach (var arabicNumeral in arabicNumerals)
            {
                result += RomanToArabic[arabicNumeral];
            }

            return result;
        }
    }
}
