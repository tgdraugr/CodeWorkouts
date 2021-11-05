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
        game.defineScore(4, 0);
        assertEquals("First Player wins", game.status());
    }

    @Test public void
    should_be_won_by_player_with_four_points_in_total_and_at_least_two_points_more_than_opponent() {
        game.defineScore(2, 5);
        assertEquals("Second Player wins", game.status());
    }

    @Test public void
    should_describe_status_accordingly() {
        assertEquals("Love,Love", game.status());
        game.defineScore(0, 1);
        assertEquals("Love,15", game.status());
        game.defineScore(0, 2);
        assertEquals("Love,30", game.status());
        game.defineScore(0, 3);
        assertEquals("Love,40", game.status());
        game.defineScore(1, 0);
        assertEquals("15,Love", game.status());
        game.defineScore(2, 0);
        assertEquals("30,Love", game.status());
        game.defineScore(3, 0);
        assertEquals("40,Love", game.status());
    }

    @Test public void
    should_be_deuce() {
        game.defineScore(3, 3);
        assertEquals("Deuce", game.status());
        game.defineScore(4, 4);
        assertEquals("Deuce", game.status());
    }

    @Test public void
    should_be_in_advantage() {
        game.defineScore(4, 3);
        assertEquals("Advantage: First Player", game.status());
        game.defineScore(3, 4);
        assertEquals("Advantage: Second Player", game.status());
        game.defineScore(5, 4);
        assertEquals("Advantage: First Player", game.status());
        game.defineScore(4, 5);
        assertEquals("Advantage: Second Player", game.status());
    }
}
