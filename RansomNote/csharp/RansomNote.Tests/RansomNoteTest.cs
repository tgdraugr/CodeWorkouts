using System.Collections.Generic;
using Xunit;

namespace RansomNote.Tests
{
    public class RansomNoteTest
    {
        [Fact]
        public void Should_consider_that_note_can_be_formed_with_all_available_words()
        {
            List<string> magazine = new() {"it", "is", "a", "note"};
            List<string> note = new() {"it", "is", "a", "note"};
            var ransomNote = new RansomNote(magazine, note);
            Assert.True(ransomNote.IsValid);
        }

        [Fact]
        public void Should_consider_that_note_can_be_formed_with_some_of_the_word()
        {
            List<string> magazine = new() {"give", "me", "one", "grand", "today", "night"};
            List<string> note = new() {"give", "one", "grand", "today"};
            var ransomNote = new RansomNote(magazine, note);
            Assert.True(ransomNote.IsValid);
        }

        [Fact]
        public void Should_consider_that_note_can_not_be_formed_due_to_diff_camel_case()
        {
            List<string> magazine = new() {"It", "is", "a", "note"};
            List<string> note = new() {"it", "is", "a", "note"};
            var ransomNote = new RansomNote(magazine, note);
            Assert.False(ransomNote.IsValid);
        }

        [Fact]
        public void Should_consider_that_note_can_not_be_formed_due_to_repeated_words()
        {
            List<string> magazine = new() {"two", "times", "three", "is", "not", "four"};
            List<string> note = new() {"two", "times", "two", "is", "four"};
            var ransomNote = new RansomNote(magazine, note);
            Assert.False(ransomNote.IsValid);
        }

        [Fact]
        public void Should_consider_that_note_can_not_be_formed_due_to_missing_word()
        {
            List<string> magazine = new() {"ive", "got", "a", "lovely", "bunch", "of", "coconuts"};
            List<string> note = new() {"ive", "got", "some", "coconuts"};
            var ransomNote = new RansomNote(magazine, note);
            Assert.False(ransomNote.IsValid);
        }
    }
}