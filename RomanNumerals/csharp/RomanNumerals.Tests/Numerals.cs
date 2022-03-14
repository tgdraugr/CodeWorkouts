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
            if (string.IsNullOrEmpty(arabicNumeral))
                return 0;
            
            var numerals =
                arabicNumeral.Select(numeral => numeral.ToString()).ToList();

            return ComputeRomanNumeral(numerals.ToList(), 0);
        }

        private static int ComputeRomanNumeral(IReadOnlyList<string> arabicNumerals, int result)
        {
            result += RomanToArabic[arabicNumerals[^1]];

            for (var index = 0; index < arabicNumerals.Count - 1; index++)
            {
                var current = RomanToArabic[arabicNumerals[index]];
                var next = RomanToArabic[arabicNumerals[index + 1]];

                if (current < next)
                    result -= current;
                else
                    result += current;
            }
            
            return result;
        }
    }
}
