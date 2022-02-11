import org.junit.jupiter.api.Test
import org.junit.jupiter.api.Assertions.*

internal class PasswordValidationTests {

    @Test
    fun `should register error when password is not at least 8 characters long`(){
        shouldFailWithMessage("1234567", "Password must be at least 8 characters")
    }

    @Test
    fun `should register error when password does not contain at least 2 numbers`(){
        shouldFailWithMessage("1abcdefg", "The password must contain at least 2 numbers")
    }

    @Test
    fun `should register error when password does not contain at least 1 capital letter`() {
        shouldFailWithMessage("12abcdef", "Password must contain at least one capital letter")
    }

    private fun shouldFailWithMessage(password: String, expectedMessage: String) {
        val result = isValidPassword(password)
        assertFalse(result.isValid)
        assertEquals(expectedMessage, result.message)
    }
}