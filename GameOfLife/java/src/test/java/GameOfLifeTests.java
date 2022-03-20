import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.Test;

public class GameOfLifeTests {

    public static final boolean DEAD_CELL = GameOfLife.DEAD_CELL;
    public static final boolean LIVE_CELL = GameOfLife.LIVE_CELL;

    @Test public void
    should_generate_empty_board_when_an_empty_board_is_provided() {
        var emptyBoard = new boolean[][] {};
        assertEquals(emptyBoard, nextGenerationBoard(emptyBoard));
    }

    @Test public void
    should_generate_all_dead_cell_board_when_a_board_of_single_dead_cell_is_provided() {
        var board = new boolean[][] {
            new boolean[] {DEAD_CELL}
        };
        assertFalse(nextGenerationBoard(board)[0][0]);
    }

    @Test public void
    should_generate_all_dead_cell_board_when_a_board_of_a_single_live_cell_is_provided() {
        var board = new boolean[][] {
            new boolean[] {LIVE_CELL}
        };
        assertFalse(nextGenerationBoard(board)[0][0]);
    }

    @Test public void
    should_generate_board_where_cells_die_when_a_cell_has_less_than_2_neighbors() {
        var board = new boolean[][] {
            new boolean[] { DEAD_CELL, DEAD_CELL, DEAD_CELL },
            new boolean[] { DEAD_CELL, LIVE_CELL, DEAD_CELL },
            new boolean[] { DEAD_CELL, DEAD_CELL, DEAD_CELL }
        };
        assertFalse(nextGenerationBoard(board)[1][1]);
    }

    @Test public void
    should_generate_board_where_cells_survive_when_a_living_cell_has_two_or_three_neighbors() {
        var board = new boolean[][] {
            new boolean[] { DEAD_CELL, LIVE_CELL, LIVE_CELL },
            new boolean[] { DEAD_CELL, LIVE_CELL, LIVE_CELL },
            new boolean[] { DEAD_CELL, DEAD_CELL, DEAD_CELL }
        };
        assertTrue(nextGenerationBoard(board)[1][1]);
    }

    @Test public void
    should_generate_board_where_cells_die_when_a_living_cell_has_more_then_three_neighbors() {
        var board = new boolean[][] {
            new boolean[] { DEAD_CELL, DEAD_CELL, DEAD_CELL },
            new boolean[] { DEAD_CELL, LIVE_CELL, LIVE_CELL },
            new boolean[] { LIVE_CELL, LIVE_CELL, LIVE_CELL }
        };
        assertFalse(nextGenerationBoard(board)[1][1]);
    }

    private boolean[][] nextGenerationBoard(boolean[][] board) {
        var game = new GameOfLife(board);
        game.nextGen();
        return board;
    }
}
