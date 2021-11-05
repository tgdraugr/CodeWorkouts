import java.util.Map;

public class TennisGame {
    public static final int NO_POINTS = 0;
    public static final int ONE_POINT = 1;
    public static final int TWO_POINTS = 2;
    public static final int THREE_POINTS = 3;
    public static final int FOUR_POINTS = 4;

    private static final Map<Integer, String> TRANSLATION_PER_SCORE = Map.of(
      NO_POINTS, "Love",
      ONE_POINT, "15",
      TWO_POINTS, "30",
      THREE_POINTS, "40"
    );

    private final String firstPlayer;
    private int firstPlayerScore;
    private final String secondPlayer;
    private int secondPlayerScore;

    public TennisGame(String firstPlayer, String secondPlayer) {
        this.firstPlayer = firstPlayer;
        this.secondPlayer = secondPlayer;
        defineScore(NO_POINTS, NO_POINTS);
    }

    public void defineScore(int firstPlayerScore, int secondPlayerScore) {
        this.firstPlayerScore = firstPlayerScore;
        this.secondPlayerScore = secondPlayerScore;
    }

    public String status() {
        if (hasWinningScore(firstPlayerScore) || hasWinningScore(secondPlayerScore)) {
            return highestScoringPlayer() + " wins";
        }

        return TRANSLATION_PER_SCORE.get(firstPlayerScore) + "," + TRANSLATION_PER_SCORE.get(secondPlayerScore);
    }

    private String highestScoringPlayer() {
        return firstPlayerScore > secondPlayerScore ? firstPlayer : secondPlayer;
    }

    private boolean hasWinningScore(int score) {
        return atLeast(score, FOUR_POINTS) && atLeast(scoresDiff(), TWO_POINTS);
    }

    private int scoresDiff() {
        return Math.abs(firstPlayerScore - secondPlayerScore);
    }

    private boolean atLeast(int score, int minimum) {
        return score >= minimum;
    }
}
