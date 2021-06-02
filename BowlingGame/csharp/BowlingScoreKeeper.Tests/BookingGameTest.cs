using NUnit.Framework;

namespace BowlingScoreKeeper.Tests
{
    public class BowlingGameTest
    {
        private BowlingGame _game;

        [SetUp]
        public void Setup()
        {
            _game = new BowlingGame();
        }

        [Test]
        public void ShouldScoreZeroWhenMissedAllRolls()
        {
            Roll(20, 0);
            Assert.That(_game.Score, Is.EqualTo(0));
        }

        [Test]
        public void ShouldScoreWithoutBonusInAbsenceOfSparesOrStrikes()
        {
            Roll(20, 1);
            Assert.That(_game.Score, Is.EqualTo(20));
        }

        [Test]
        public void ShouldScoreWithBonusWhenSpareHappens()
        {
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(3);
            Roll(17, 0);
            Assert.That(_game.Score, Is.EqualTo(16));
        }

        [Test]
        public void ShouldScoreWithBonusWhenStrikeHappens()
        {
            _game.Roll(10);
            _game.Roll(5);
            _game.Roll(3);
            Roll(17, 0);
            Assert.That(_game.Score, Is.EqualTo(26));
        }

        [Test]
        public void ShouldScorePerfectGameWithAllStrikes()
        {
            Roll(12, 10);
            Assert.That(_game.Score, Is.EqualTo(300));
        }

        private void Roll(int numberRolls, int numberPins)
        {
            for (var roll = 0; roll < numberRolls; ++roll)
                _game.Roll(numberPins);
        }
    }
}