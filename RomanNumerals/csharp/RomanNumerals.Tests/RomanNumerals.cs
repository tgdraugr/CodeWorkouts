using System.Collections.Generic;

namespace RomanNumerals.Tests
{
    class RomanNumerals
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


        public static string Convert(int amount)
        {
            string result = "";
            
            foreach(var item in ArabicToRoman)
            {
                while (amount >= item.Key)
                {
                    result += item.Value;
                    amount -= item.Key;
                }
            }

            return result;
        }
    }
}
