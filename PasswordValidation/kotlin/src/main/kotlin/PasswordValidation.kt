fun isValidPassword(password: String): ValidationResult {
    return PasswordValidationResult(password)
        .assertCharactersCount()
        .assertDigitsCount()
        .assertCapitalLettersCount()
        .assertSpecialCharactersCount()
}