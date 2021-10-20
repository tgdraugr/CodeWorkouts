using System;
using Xunit;

namespace RansomNote.Tests
{
    public class RansomNoteRendererTest
    {
        private readonly TestDisplay _stdout;

        public RansomNoteRendererTest()
        {
            _stdout = new TestDisplay();
        }

        [Fact]
        public void Should_render_positive_response_given_a_valid_input()
        {
            var stdin = FakeStdIn.New()
                .WithNumberOfWords(6, 4)
                .WithMagazineSentence("give me one grand today night")
                .WithNoteSentence("give one grand today")
                .Build();

            RansomNoteRenderer renderer = new(stdin, _stdout);
            renderer.CheckMagazine();
            Assert.Equal(1, stdin.NumberOfWordsCall);
            Assert.Equal(1, stdin.MagazineCall);
            Assert.Equal(1, stdin.NoteCall);
            Assert.Equal("Yes", _stdout.Result);
        }

        [Fact]
        public void Should_render_negative_response_when_words_are_repeated()
        {
            var stdin = FakeStdIn.New()
                .WithNumberOfWords(6, 5)
                .WithMagazineSentence("two times three is not four")
                .WithNoteSentence("two times two is four")
                .Build();

            RansomNoteRenderer renderer = new(stdin, _stdout);
            renderer.CheckMagazine();
            Assert.Equal(1, stdin.NumberOfWordsCall);
            Assert.Equal(1, stdin.MagazineCall);
            Assert.Equal(1, stdin.NoteCall);
            Assert.Equal("No", _stdout.Result);
        }

        [Fact]
        public void Should_render_negative_response_when_magazine_is_missing_words()
        {
            var stdin = FakeStdIn.New()
                .WithNumberOfWords(7, 4)
                .WithMagazineSentence("ive got a lovely bunch of coconuts")
                .WithNoteSentence("ive got some coconuts")
                .Build();

            RansomNoteRenderer renderer = new(stdin, _stdout);
            renderer.CheckMagazine();
            Assert.Equal(1, stdin.NumberOfWordsCall);
            Assert.Equal(1, stdin.MagazineCall);
            Assert.Equal(1, stdin.NoteCall);
            Assert.Equal("No", _stdout.Result);
        }

        [Theory]
        [InlineData(1, 3, "A magazine sentence", "A note sentence")]
        [InlineData(3, 1, "A magazine sentence", "A note sentence")]
        public void Should_throw_exception_when_totals_do_not_match_the_sentence_length(
            int totalWordsMagazine,
            int totalWordsNote,
            string magazineSentence,
            string noteSentence)
        {
            var stdin = FakeStdIn.New()
                .WithNumberOfWords(totalWordsMagazine, totalWordsNote)
                .WithMagazineSentence(magazineSentence)
                .WithNoteSentence(noteSentence)
                .Build();

            RansomNoteRenderer renderer = new(stdin, _stdout);
            Assert.Throws<ArgumentException>(() => renderer.CheckMagazine());
        }
    }
}