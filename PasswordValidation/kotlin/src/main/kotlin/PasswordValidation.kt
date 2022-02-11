import java.util.*

fun isValidPassword(password: String): PasswordValidation {
    val result = PasswordValidation()

    if (password.length < PasswordValidation.MIN_TOTAL_CHARACTERS) {
        result.invalidCharactersCount()
    }

    if (password.count { it.isDigit() } < PasswordValidation.MIN_DIGITS) {
        result.invalidDigitsCount()
    }

    if (password.count { it.isUpperCase() } < PasswordValidation.MIN_CAPITAL_LETTERS) {
        result.invalidCapitalLettersCount()
    }

    if (password.none { !it.isLetterOrDigit() }) {
        result.invalidSpecialCharactersCount()
    }

    return result
}

class PasswordValidation {

    companion object {
        const val MIN_TOTAL_CHARACTERS = 8
        const val MIN_DIGITS = 2
        const val MIN_CAPITAL_LETTERS = 1
        private const val AT_LEAST_8_CHARACTERS_MESSAGE = "Password must be at least 8 characters"
        private const val AT_LEAST_2_NUMBERS_MESSAGE = "Password must contain at least 2 numbers"
        private const val AT_LEAST_1_CAPITAL_LETTER_MESSAGE = "Password must contain at least one capital letter"
        private const val AT_LEAST_1_SPECIAL_CHARACTER_MESSAGE = "Password must contain at least one special character"
    }

    private val messages: LinkedList<String> = LinkedList()

    fun message() : String {
        return messages.joinToString(separator = "\n")
    }

    fun valid() : Boolean {
        return messages.isEmpty()
    }

    fun invalidCharactersCount() {
        messages.add(AT_LEAST_8_CHARACTERS_MESSAGE)
    }

    fun invalidDigitsCount() {
        messages.add(AT_LEAST_2_NUMBERS_MESSAGE)
    }

    fun invalidCapitalLettersCount() {
        messages.add(AT_LEAST_1_CAPITAL_LETTER_MESSAGE)
    }

    fun invalidSpecialCharactersCount() {
        messages.add(AT_LEAST_1_SPECIAL_CHARACTER_MESSAGE)
    }
}