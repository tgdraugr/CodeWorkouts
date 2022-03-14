import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.Test;

public class LeapYearTests {
    @Test
    public void shouldNotBeLeapYearIfNotDivisibleBy4() {
        var year = new Year(1997);
        assertFalse(year.isLeap());
    }
}
