import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.Test;

public class GameOfLifeTests {

    @Test public void
    should_generate_empty_board_when_an_empty_board_is_provided() {
        var emptyBoard = new boolean[][] {};
        assertEquals(emptyBoard, nextGenerationBoard(emptyBoard));
    }

    @Test public void
    should_generate_all_dead_cell_board_when_a_board_of_single_dead_cell_is_provided() {
        var board = new boolean[][] {
            new boolean[] {false}
        };
        assertSameBoards(board, nextGenerationBoard(board));
    }

    @Test public void
    should_generate_all_dead_cell_board_when_a_board_of_a_single_live_cell_is_provided() {
        var board = new boolean[][] {
            new boolean[] {true}
        };

        var expected = new boolean[][] {
            new boolean[] {false}
        };

        assertSameBoards(expected, nextGenerationBoard(board));
    }

    private void assertSameBoards(boolean[][] expected, boolean[][] actual) {
        for (int row = 0; row < expected.length; row++) {
            assertArrayEquals(expected[row], actual[row]);
        }
    }

    private boolean[][] nextGenerationBoard(boolean[][] board) {
        var game = new GameOfLife(board);
        game.nextGen();
        return game.getBoard();
    }
}
