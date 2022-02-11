fun isValidPassword(password: String): ValidationResult {
    if (password.length < ValidationResult.MIN_TOTAL_CHARACTERS)
        return ValidationResult(false, ValidationResult.AT_LEAST_8_CHARACTERS_MESSAGE)

    if (password.count { it.isDigit() } < ValidationResult.MIN_DIGITS)
        return ValidationResult(false, ValidationResult.AT_LEAST_2_NUMBERS_MESSAGE)

    if (password.count { it.isUpperCase() } < ValidationResult.MIN_CAPITAL_LETTERS)
        return ValidationResult(false, ValidationResult.AT_LEAST_1_CAPITAL_LETTER_MESSAGE)

    if (password.none { !it.isLetterOrDigit() })
        return ValidationResult(false, ValidationResult.AT_LEAST_1_SPECIAL_CHARACTER_MESSAGE)

    return ValidationResult()
}

data class ValidationResult(val isValid: Boolean = true, val message: String = "") {
    companion object {
        const val MIN_TOTAL_CHARACTERS = 8
        const val MIN_DIGITS = 2
        const val MIN_CAPITAL_LETTERS = 1
        const val AT_LEAST_8_CHARACTERS_MESSAGE = "Password must be at least 8 characters"
        const val AT_LEAST_2_NUMBERS_MESSAGE = "The password must contain at least 2 numbers"
        const val AT_LEAST_1_CAPITAL_LETTER_MESSAGE = "Password must contain at least one capital letter"
        const val AT_LEAST_1_SPECIAL_CHARACTER_MESSAGE = "Password must contain at least one special character"
    }
}