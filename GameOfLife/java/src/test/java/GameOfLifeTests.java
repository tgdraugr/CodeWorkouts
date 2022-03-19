import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.Test;

public class GameOfLifeTests {
    @Test
    public void
    should_generate_empty_board_when_an_empty_board_is_provided() {
        var emptyBoard = new boolean[][] {};
        var game = new GameOfLife(emptyBoard);
        game.nextGen();
        assertEquals(emptyBoard, game.getBoard());
    }
}
