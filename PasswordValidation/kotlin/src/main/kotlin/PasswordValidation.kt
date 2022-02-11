fun isValidPassword(password: String): ValidationResult {
    if (notAtLeast8CharactersLong(password))
        return ValidationResult(false, ValidationResult.AT_LEAST_8_CHARACTERS_MESSAGE)

    if (doesNotContainAtLeast2Numbers(password))
        return ValidationResult(false, ValidationResult.AT_LEAST_2_NUMBERS_MESSAGE)

    if (doesNotContainAtLeast1CapitalLetter(password))
        return ValidationResult(false, ValidationResult.AT_LEAST_1_CAPITAL_LETTER_MESSAGE)

    if (password.none { !it.isLetterOrDigit() })
        return ValidationResult(false, "Password must contain at least one special character")

    return ValidationResult()
}

private fun notAtLeast8CharactersLong(password: String) =
    password.length < ValidationResult.MIN_TOTAL_CHARACTERS

private fun doesNotContainAtLeast2Numbers(password: String) =
    password.chars().filter(Character::isDigit).count() < ValidationResult.MIN_DIGITS

private fun doesNotContainAtLeast1CapitalLetter(password: String) =
    password.chars().filter(Character::isUpperCase).count() < ValidationResult.MIN_CAPITAL_LETTERS


data class ValidationResult(val isValid: Boolean = true, val message: String = "") {
    companion object {
        const val MIN_TOTAL_CHARACTERS = 8
        const val MIN_DIGITS = 2
        const val MIN_CAPITAL_LETTERS = 1
        const val AT_LEAST_8_CHARACTERS_MESSAGE = "Password must be at least 8 characters"
        const val AT_LEAST_2_NUMBERS_MESSAGE = "The password must contain at least 2 numbers"
        const val AT_LEAST_1_CAPITAL_LETTER_MESSAGE = "Password must contain at least one capital letter"
    }
}