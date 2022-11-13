package ransom

func CheckMagazine(magazine []string, note []string) (string, error) {
	if magazineHasWordsForNote(magazine, note) {
		return "Yes", nil
	}
	return "No", nil
}

func magazineHasWordsForNote(magazine []string, note []string) bool {
	availableWords := map[string]string{}
	for _, word := range magazine {
		availableWords[word] = word
	}

	hasAllWords := true
	for _, word := range note {
		if _, ok := availableWords[word]; ok {
			delete(availableWords, word)
		} else {
			hasAllWords = false
			break
		}
	}
	return len(magazine) > 0 && len(note) > 0 && hasAllWords
}
