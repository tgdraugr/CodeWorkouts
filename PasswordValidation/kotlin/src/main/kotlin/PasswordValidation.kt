fun isValidPassword(password: String): ValidationResult {
    if (password.length < ValidationResult.MIN_NUM_CHARACTERS) {
        return ValidationResult(false, ValidationResult.AT_LEAST_8_CHARACTERS_MESSAGE)
    }
    return ValidationResult()
}

data class ValidationResult(val isValid: Boolean = true, val message: String = "") {
    companion object {
        const val MIN_NUM_CHARACTERS = 8
        const val AT_LEAST_8_CHARACTERS_MESSAGE = "Password must be at least 8 characters"
    }
}