import java.util.*

internal class PasswordValidationResult(private val password: String) : ValidationResult {

    private companion object {
        const val MIN_TOTAL_CHARACTERS = 8
        const val MIN_DIGITS = 2
        const val MIN_CAPITAL_LETTERS = 1
    }

    private val messages: LinkedList<String> = LinkedList()

    override fun message() : String {
        return messages.joinToString(separator = "\n")
    }

    override fun valid() : Boolean {
        return messages.isEmpty()
    }

    fun assertCharactersCount() : PasswordValidationResult {
        if (password.length < MIN_TOTAL_CHARACTERS) {
            messages.add("Password must be at least 8 characters")
        }
        return this
    }

    fun assertDigitsCount(): PasswordValidationResult {
        if (password.count { it.isDigit() } < MIN_DIGITS) {
            messages.add("Password must contain at least 2 numbers")
        }
        return this
    }

    fun assertCapitalLettersCount(): PasswordValidationResult {
        if (password.count { it.isUpperCase() } < MIN_CAPITAL_LETTERS) {
            messages.add("Password must contain at least one capital letter")
        }
        return this
    }

    fun assertSpecialCharactersCount(): PasswordValidationResult {
        if (password.none { !it.isLetterOrDigit() }) {
            messages.add("Password must contain at least one special character")
        }
        return this
    }
}