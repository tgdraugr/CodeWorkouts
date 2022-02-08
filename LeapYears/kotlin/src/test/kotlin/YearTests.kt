import org.junit.jupiter.api.Assertions.assertFalse
import org.junit.jupiter.api.Test

class YearTests {
    @Test
    fun shouldNotBeLeapWhenNotDivisibleBy4() {
        assertFalse(Year(1997).isLeapYear())
    }
}