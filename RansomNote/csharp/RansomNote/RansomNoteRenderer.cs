using System;
using System.Collections;

namespace RansomNote
{
    public class RansomNoteRenderer
    {
        private readonly IAmStdIn _stdin;
        private readonly IAmStdOut _stdout;

        public RansomNoteRenderer(IAmStdIn stdin, IAmStdOut stdout)
        {
            _stdin = stdin;
            _stdout = stdout;
        }

        public void CheckMagazine()
        {
            var (numberMagazine, numberNote) = _stdin.NumberOfWords();
            var magazine = _stdin.Magazine();
            var note = _stdin.Note();

            CheckIfTotalWordsMatchesSentence(magazine, numberMagazine);
            CheckIfTotalWordsMatchesSentence(note, numberNote);

            var ransomNote = new RansomNote(magazine, note);
            var response = ransomNote.IsValid ? "Yes" : "No";
            _stdout.Display(response);
        }

        private static void CheckIfTotalWordsMatchesSentence(ICollection sentence, int totalOfWords)
        {
            if (sentence?.Count != totalOfWords)
                throw new ArgumentException(
                    "Given total and sentence do not match in number of words");
        }
    }
}