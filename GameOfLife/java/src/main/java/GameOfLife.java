public class GameOfLife {

    public static final boolean DEAD_CELL = false;
    public static final boolean LIVE_CELL = true;

    private final boolean[][] board;

    public GameOfLife(boolean[][] board) {
        this.board = board;
    }

    public void nextGen() {
        for (int row = 0; row < this.board.length; row++) {
            for (int col = 0; col < this.board[row].length; col++) {
                this.board[row][col] = nextCellState(row, col);
            }
        }
    }

    private boolean nextCellState(int row, int col) {
        var totalNeighbors = totalAliveNeighbors(row, col);

        if (totalNeighbors < 2) {
            return DEAD_CELL;
        }

        return this.board[row][col];
    }

    private int totalAliveNeighbors(int row, int col) {
        return 1;
    }

    public boolean[][] getBoard() {
        return this.board;
    }
}