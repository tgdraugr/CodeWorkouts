public record Year(int year) {

    public boolean isLeap() {
        return isDivisible(4) && !isDivisible(100) || isDivisible(400);
    }

    private boolean isDivisible(int number) {
        return this.year % number == 0;
    }
}
