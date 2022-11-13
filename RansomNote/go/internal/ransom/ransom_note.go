package ransom

func CheckMagazine(magazine []string, note []string) (string, error) {
	if len(magazine) == 0 || len(note) == 0 {
		return "No", nil
	}

	m := map[string]bool{}
	for _, mw := range magazine {
		m[mw] = false
	}

	n := map[string]bool{}
	for _, nw := range note {
		n[nw] = false
	}

	for nw := range n {
		if _, ok := m[nw]; ok {
			delete(n, nw)
		}
	}

	if len(n) == 0 {
		return "Yes", nil
	}

	return "No", nil
}
