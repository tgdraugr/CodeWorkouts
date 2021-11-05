public class TennisGame {

    private static final int ONE_POINT = 1;

    private final String firstPlayer;
    private int firstPlayerScore = 0;
    private final String secondPlayer;
    private int secondPlayerScore = 0;

    public TennisGame(String firstPlayer, String secondPlayer) {
        this.firstPlayer = firstPlayer;
        this.secondPlayer = secondPlayer;
    }

    public void firstPlayerScored() {
        this.firstPlayerScore += ONE_POINT;
    }

    public void secondPlayerScored() {
        this.secondPlayerScore += ONE_POINT;
    }

    public String status() {
        return winner() + " wins";
    }

    private String winner() {
        return firstPlayerWon() ? firstPlayer : secondPlayer;
    }

    private boolean firstPlayerWon() {
        return atLeast(firstPlayerScore, 4) && atLeast(scoresDiff(), 2);
    }

    private int scoresDiff() {
        return Math.abs(firstPlayerScore - secondPlayerScore);
    }

    private boolean atLeast(int score, int baseScore) {
        return score >= baseScore;
    }
}
