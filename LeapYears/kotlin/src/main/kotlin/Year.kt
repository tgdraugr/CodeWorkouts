class Year(private val year: Int) {
    fun isLeapYear(): Boolean {
        return year % 4 == 0
    }
}