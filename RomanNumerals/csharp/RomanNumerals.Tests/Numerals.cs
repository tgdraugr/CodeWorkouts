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
            RomanToArabic.Add("#", 0);
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

            for (var index = 0; index < arabicNumeral.Length; index+=2)
            {
                if (index + 1 >= arabicNumeral.Length)
                {
                    result += ComputeValue(arabicNumeral[index].ToString(), "#");
                }
                else
                {
                    var left = arabicNumeral[index].ToString();
                    var right = arabicNumeral[index + 1].ToString();
                    result += ComputeValue(left, right);    
                }
            }

            return result;
        }

        private static int ComputeValue(string left, string right)
        {
            if (RomanToArabic[left] < RomanToArabic[right])
                return RomanToArabic[right] - RomanToArabic[left];
            
            return RomanToArabic[left] + RomanToArabic[right];
        }
    }
}
