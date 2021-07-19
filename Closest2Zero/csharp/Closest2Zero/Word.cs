using System;
using System.Collections.Generic;
using System.Linq;

namespace Closest2Zero
{
    internal class Word
    {
        private static readonly IList<char> Zero = new List<char> { 'z', 'e', 'r', 'o' };

        private string _value;

        public Word(string value, int index)
        {
            _value = value;
            Index = index;
        }

        public int Index { get; }

        public int Similarity => SimilarOrderScore();

        public int Length => _value.Length;

        public bool ContainsSameLettersAsZero() => _value.ToCharArray().All(ContainLetterInZero);

        public override string ToString() => _value;

        private int SimilarOrderScore()
        {
            var letters = _value.ToCharArray();
            
            var score = 0;
            for (int letterIndex = 0; letterIndex < Zero.Count; ++letterIndex)
                score += Convert.ToInt32(letters[letterIndex] == Zero[letterIndex]);
            
            return score;
        }

        private bool ContainLetterInZero(char letter) => Zero.Contains(letter);
    }
}