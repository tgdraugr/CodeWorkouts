public record Year(int year) {

    public boolean isLeap() {
        return this.year % 4 == 0;
    }
}
