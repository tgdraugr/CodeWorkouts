namespace BowlingScoreKeeper
{
    public class BowlingGame
    {
        private const int MaxPossibleRolls = 21;

        private int _currentRoll;
        private readonly int[] _rolls = new int[MaxPossibleRolls];

        public void Roll(int numberPins)
        {
            _rolls[_currentRoll++] = numberPins;
        }

        public int Score
        {
            get
            {
                var score = 0;
                var frameRollIndex = 0;

                for (var frame = 0; frame < 10; ++frame)
                {
                    if (ScoredStrike(frameRollIndex))
                    {
                        score += 10 + StrikeBonus(frameRollIndex);
                        frameRollIndex++;
                    }
                    else if (ScoredSpare(frameRollIndex))
                    {
                        score += 10 + SpareBonus(frameRollIndex);
                        frameRollIndex += 2;
                    }
                    else
                    {
                        score += DefaultScore(frameRollIndex);
                        frameRollIndex += 2;
                    }
                }

                return score;
            }
        }

        private bool ScoredStrike(int frameStart) => 
            _rolls[frameStart] == 10;

        private bool ScoredSpare(int frameRollIndex) => 
            _rolls[frameRollIndex] + _rolls[frameRollIndex + 1] == 10;

        private int StrikeBonus(int frameRollIndex) => 
            _rolls[frameRollIndex + 1] + _rolls[frameRollIndex + 2];

        private int SpareBonus(int frameRollIndex) => 
            _rolls[frameRollIndex + 2];

        private int DefaultScore(int frameRollIndex) => 
            _rolls[frameRollIndex] + _rolls[frameRollIndex + 1];
    }
}