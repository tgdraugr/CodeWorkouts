using System.Collections.Generic;
using System.Linq;

namespace RansomNote.Tests
{
    public class FakeStdIn : IAmStdIn
    {
        private readonly string _magazineSentence;
        private readonly string _noteSentence;
        private readonly (int, int) _totalWords;

        private FakeStdIn((int, int) totalWords, string magazineSentence, string noteSentence)
        {
            _totalWords = totalWords;
            _magazineSentence = magazineSentence;
            _noteSentence = noteSentence;
        }

        public int NumberOfWordsCall { get; private set; }
        public int MagazineCall { get; private set; }
        public int NoteCall { get; private set; }

        public (int, int) NumberOfWords()
        {
            NumberOfWordsCall += 1;
            return _totalWords;
        }

        public List<string> Magazine()
        {
            MagazineCall += 1;
            return _magazineSentence.Split(" ").ToList();
        }

        public List<string> Note()
        {
            NoteCall += 1;
            return _noteSentence.Split(" ").ToList();
        }

        public static FakeStdinBuilder New()
        {
            return new FakeStdinBuilder();
        }

        public class FakeStdinBuilder
        {
            private string _magazineSentence = string.Empty;
            private string _noteSentence = string.Empty;
            private int _totalWordsMagazine;
            private int _totalWordsNote;

            public FakeStdinBuilder WithNumberOfWords(int totalWordsMagazine, int totalWordsNote)
            {
                _totalWordsMagazine = totalWordsMagazine;
                _totalWordsNote = totalWordsNote;
                return this;
            }

            public FakeStdinBuilder WithMagazineSentence(string magazineSentence)
            {
                _magazineSentence = magazineSentence;
                return this;
            }

            public FakeStdinBuilder WithNoteSentence(string noteSentence)
            {
                _noteSentence = noteSentence;
                return this;
            }

            public FakeStdIn Build()
            {
                var totalWords = (_totalWordsMagazine, _totalWordsNote);
                return new FakeStdIn(totalWords, _magazineSentence, _noteSentence);
            }
        }
    }
}