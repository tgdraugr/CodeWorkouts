package ransom_test

import (
	"testing"

	. "github.com/tgdraugr/CodeWorkouts/RansomNote/internal/ransom"
)

func TestCheckMagazine(t *testing.T) {
	// By default, responds 'no'
	want := "No"
	got, err := CheckMagazine([]string{}, []string{})
	if err != nil {
		t.Fail()
	}
	if want != got {
		t.Error()
	}

	// responds yes when magazine contains all the words needed for the note
	want = "Yes"
	magazine := []string{"give", "me", "one", "grand", "today", "night"}
	note := []string{"give", "one", "grand", "today"}
	got, err = CheckMagazine(magazine, note)
	if err != nil {
		t.Fail()
	}
	if want != got {
		t.Error()
	}
}
