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
    should_win_the_game_with_four_points_in_total() {
        scored(FIRST_PLAYER, 4);
        assertEquals("First Player wins", game.status());
    }

    @Test public void
    should_win_the_game_with_four_points_in_total_and_at_least_two_points_more_than_opponent() {
        scored(FIRST_PLAYER, 2);
        scored(SECOND_PLAYER, 5);
        assertEquals("Second Player wins", game.status());
    }

    private void scored(String player, int score) {
        for (int i = 0; i < score; i++) {
            switch (player) {
                case FIRST_PLAYER:
                    game.firstPlayerScored();
                    break;
                case SECOND_PLAYER:
                    game.secondPlayerScored();
                    break;
            }
        }
    }
}
