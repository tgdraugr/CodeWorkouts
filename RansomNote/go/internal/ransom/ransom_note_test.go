package ransom_test

import (
	. "github.com/tgdraugr/CodeWorkouts/RansomNote/internal/ransom"
	"testing"
)

func TestCheckMagazine(t *testing.T) {
	want := "Yes"
	got := CheckMagazine([]string{}, []string{})
	if want != got {
		t.Errorf("misses implementation")
	}
}
