using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace RansomNote
{
    public class RansomNote
    {
        private readonly List<string> _magazine;
        private readonly List<string> _note;

        public RansomNote(List<string> magazine, List<string> note)
        {
            _magazine = magazine;
            _note = note;
        }

        public bool IsValid => ValidMagazine();

        private bool ValidMagazine()
        {
            return DoesNotContainRepeatedWords() &&
                   _note.All(word => _magazine.Contains(word));
        }

        private bool DoesNotContainRepeatedWords()
        {
            return _note.ToImmutableHashSet().Count == _note.Count;
        }
    }
}