import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.Test;

public class LeapYearTests {
    @Test
    public void shouldNotBeLeapYearIfNotDivisibleBy4() {
        var year = new Year(1997);
        assertFalse(year.isLeap());
    }

    @Test
    public void shouldBeLeapYearIfDivisibleBy4() {
        var year = new Year(1996);
        assertTrue(year.isLeap());
    }

    @Test
    public void shouldBeLeapYearIfDivisibleBy400() {
        var year = new Year(1600);
        assertTrue(year.isLeap());
    }

    @Test
    public void shouldNotBeLeapYearIfDivisibleBy4AndBy100ButNotBy400() {
        var year = new Year(1800);
        assertFalse(year.isLeap());
    }
}
