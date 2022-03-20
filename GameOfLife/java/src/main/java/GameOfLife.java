import java.util.Arrays;

public class GameOfLife {

    public static final boolean DEAD_CELL = false;
    public static final boolean LIVE_CELL = true;

    private final boolean[][] board;
    private boolean[][] snapshotBoard;

    public GameOfLife(boolean[][] board) {
        this.board = board;
    }

    public void nextGen() {
        this.snapshotBoard = Arrays.stream(this.board)
                .map(row ->  Arrays.copyOf(row, row.length))
                .toArray(boolean[][]::new);

        for (int row = 0; row < this.snapshotBoard.length; row++) {
            for (int col = 0; col < this.snapshotBoard[row].length; col++) {
                this.board[row][col] = nextCellState(row, col);
            }
        }
    }

    private boolean nextCellState(int row, int col) {
        var totalAliveNeighbors = totalAliveNeighbors(row, col);

        if (totalAliveNeighbors == 3)
            return LIVE_CELL;

        if (totalAliveNeighbors < 2 || totalAliveNeighbors > 3)
            return DEAD_CELL;

        return this.snapshotBoard[row][col];
    }

    private int totalAliveNeighbors(int row, int col) {
        var neighbors = new Neighbor[] {
            new Neighbor(row - 1, col),
            new Neighbor(row - 1, col + 1),
            new Neighbor(row, col + 1),
            new Neighbor(row + 1, col + 1),
            new Neighbor(row + 1, col),
            new Neighbor(row + 1, col - 1),
            new Neighbor(row, col - 1),
            new Neighbor(row - 1, col - 1),
        };

        var total = 0;

        for (var neighbor : neighbors) {
            total += neighbor.weight();
        }

        return total;
    }

    private class Neighbor {
        private final int x;
        private final int y;

        public Neighbor(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public int weight() {
            return alive() ? 1 : 0;
        }

        private boolean alive() {
            return inBounds() && snapshotBoard[x][y];
        }

        private boolean inBounds() {
            return this.x >= 0 && this.x < snapshotBoard.length &&
                    this.y >= 0 && this.y < snapshotBoard[x].length;
        }
    }
}