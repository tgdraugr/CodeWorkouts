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

    @Test
    fun shouldBeLeapYearWhenDivisibleBy400() {
        assertTrue { isLeapYear(1600) }
    }

    @Test
    fun shouldNotBeLeapYearWhenDivisibleBy100ButNotBy400() {
        assertFalse { isLeapYear(1800) }
    }

    private fun isLeapYear(year: Int) = Year(year).isLeapYear()
}