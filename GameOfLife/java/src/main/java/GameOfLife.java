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
        var totalAliveNeighbors = totalAliveNeighbors(row, col);

        if (totalAliveNeighbors < 2) {
            return DEAD_CELL;
        } else if (totalAliveNeighbors == 2 || totalAliveNeighbors == 3) {
            return this.board[row][col];
        }

        return this.board[row][col];
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

    public boolean[][] getBoard() {
        return this.board;
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
            return inBounds() && board[x][y];
        }

        private boolean inBounds() {
            return this.x >= 0 && this.x < board.length && this.y >= 0 && this.y < board[x].length;
        }
    }
}