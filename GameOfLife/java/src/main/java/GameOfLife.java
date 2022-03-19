public class GameOfLife {
    private final boolean[][] board;

    public GameOfLife(boolean[][] board) {
        this.board = board;
    }

    public void nextGen() {
        if (this.board.length == 0)
            return;

        boolean alive = this.board[0][0];
        if (alive) {
            this.board[0][0] = false;
        }
    }

    public boolean[][] getBoard() {
        return this.board;
    }
}
