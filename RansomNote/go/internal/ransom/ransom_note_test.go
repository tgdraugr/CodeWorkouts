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
		t.Errorf("misses implementation")
	}
}
