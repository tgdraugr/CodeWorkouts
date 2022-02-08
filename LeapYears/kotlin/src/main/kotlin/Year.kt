class Year(private val year: Int) {
    fun isLeapYear(): Boolean {
        return divisibleBy(4)
                && notDivisibleBy(100) || divisibleBy(400)
    }

    private fun notDivisibleBy(divisor: Int) = year % divisor != 0

    private fun divisibleBy(divisor: Int) = year % divisor == 0
}