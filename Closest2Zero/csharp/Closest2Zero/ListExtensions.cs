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

            // Could be using a 'Chain of responsibilites' pattern.
            // Where each of the handlers had a condition and a handling of the list.
            // For such a simple exercise, it is not worth it. Maybe next time.
            var candidateWords = words
                .Select((word, index) => new Word(word, index))
                .WithSameLettersAsZero();

            if (candidateWords.HasSeveralWordsWithSameLength())
            {
                candidateWords = candidateWords
                    .WithoutWordsOfDifferentLengths()
                    .OrderByDescending(word => word.Similarity);
            }

            if (candidateWords.HasSeveralWordsWithSimilarOrder())
            {
                candidateWords = candidateWords.OrderBy(word => word.Index);
            }

            return $"{candidateWords.First()}";
        }

        private static IEnumerable<Word> WithSameLettersAsZero(this IEnumerable<Word> words)
        {
            return words
                .Where(word => word.ContainsSameLettersAsZero())
                .OrderBy(word => word.ToString());
        }

        private static IEnumerable<Word> WithoutWordsOfDifferentLengths(this IEnumerable<Word> words)
        {
            var candidate = words.First();
            var wordsOfDifferentLengths = words.Where(word => word.Length > candidate.Length);
            return words.Except(wordsOfDifferentLengths);
        }

        private static bool HasSeveralWordsWithSameLength(this IEnumerable<Word> words) 
        {
            var candidate = words.First();
            return words.Count(word => word.Length == candidate.Length) > 1;
        }

        private static bool HasSeveralWordsWithSimilarOrder(this IEnumerable<Word> words) 
        {
            var candidate = words.First();
            return words.Count(word => word.Similarity == candidate.Similarity) > 1;
        }
    }
}