import org.junit.jupiter.api.Assertions.assertFalse
import org.junit.jupiter.api.Test
import kotlin.test.assertTrue

class YearTests {
    @Test
    fun shouldNotBeLeapWhenNotDivisibleBy4() {
        assertFalse { isLeapYear(1997) }
    }

    @Test
    fun shouldBeLeapYearWhenDivisibleBy4() {
        assertTrue { isLeapYear(1996) }
    }

    private fun isLeapYear(year: Int) = Year(year).isLeapYear()
}