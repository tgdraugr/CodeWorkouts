fun isValidPassword(password: String): ValidationResult {
    if (notAtLeast8CharactersLong(password))
        return ValidationResult(false, ValidationResult.AT_LEAST_8_CHARACTERS_MESSAGE)

    if (doesNotContainAtLeast2Numbers(password))
        return ValidationResult(false, ValidationResult.AT_LEAST_2_NUMBERS_MESSAGE)

    return ValidationResult()
}

private fun notAtLeast8CharactersLong(password: String) =
    password.length < ValidationResult.MIN_NUM_CHARACTERS

private fun doesNotContainAtLeast2Numbers(password: String) =
    password.chars().filter(Character::isDigit).count() < ValidationResult.MIN_NUMBERS


data class ValidationResult(val isValid: Boolean = true, val message: String = "") {
    companion object {
        const val MIN_NUM_CHARACTERS = 8
        const val MIN_NUMBERS = 2
        const val AT_LEAST_8_CHARACTERS_MESSAGE = "Password must be at least 8 characters"
        const val AT_LEAST_2_NUMBERS_MESSAGE = "The password must contain at least 2 numbers"
    }
}