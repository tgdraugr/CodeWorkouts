import org.junit.jupiter.api.Test
import org.junit.jupiter.api.Assertions.*

internal class PasswordValidationTests {

    @Test
    fun `should register error when password is not at least 8 characters long`(){
        val result = isValidPassword("1234567")
        assertFalse(result.isValid)
        assertEquals("Password must be at least 8 characters", result.message)
    }
}