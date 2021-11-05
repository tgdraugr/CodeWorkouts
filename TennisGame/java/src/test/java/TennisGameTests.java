import org.junit.*;
import static org.junit.Assert.*;

public class TennisGameTests {

    public static final String FIRST_PLAYER = "First Player";
    public static final String SECOND_PLAYER = "Second Player";

    private TennisGame game;

    @Before
    public void setUp() {
        game = new TennisGame(FIRST_PLAYER, SECOND_PLAYER);
    }

    @Test public void
    should_be_won_by_player_with_four_points_in_total() {
        defineScore(4, 0);
        assertEquals("First Player wins", game.status());
    }

    @Test public void
    should_be_won_by_player_with_four_points_in_total_and_at_least_two_points_more_than_opponent() {
        defineScore(2, 5);
        assertEquals("Second Player wins", game.status());
    }

    private void defineScore(int firstPlayerScore, int secondPlayerScore) {
        for (int i = 0; i < firstPlayerScore; i++) {
            game.firstPlayerScored();
        }
        for (int i = 0; i < secondPlayerScore; i++) {
            game.secondPlayerScored();
        }
    }
}
