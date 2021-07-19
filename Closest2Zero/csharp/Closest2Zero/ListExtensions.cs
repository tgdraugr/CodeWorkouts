using System;
using System.Collections.Generic;
using System.Linq;

namespace Closest2Zero
{
    public static class ListExtensions
    {
        public static int ClosestToZero(this IList<int> numbers) 
        {
            if (numbers.Count == 0) 
            {
                throw new InvalidOperationException();
            }
            
            return numbers
                .OrderBy(number => number)
                .First(number => number > 0);
        }

        public static string ClosestToZero(this IList<string> words)
        {
            if (words.Count == 0) 
            {
                throw new InvalidOperationException();
            }

            var zero = new List<char> { 'z', 'e', 'r', 'o' };

            var possibleWords = new List<string>();

            foreach (var word in words)
            {
                if (word.IsCloseTo(zero))
                {
                    possibleWords.Add(word);
                }
            }

            return possibleWords
                .OrderBy(word => word)
                .First();
        }

        private static bool IsCloseTo(this string word, IList<char> baseline)
        {
            return word.ToCharArray().All(character => baseline.Contains(character));
        }
    }
}