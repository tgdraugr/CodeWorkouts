package ransom_test

import (
	"strings"
	"testing"

	. "github.com/tgdraugr/CodeWorkouts/RansomNote/internal/ransom"
)

func TestCheckMagazine(t *testing.T) {
	cases := map[string]struct {
		magazine []string
		note     []string
		want     string
	}{
		"responds no, by default": {
			[]string{}, []string{}, "No",
		},
		"responds yes when magazine contains all the words needed for the note": {
			strings.Split("give me one grand today night", " "),
			strings.Split("give one grand today", " "),
			"Yes",
		},
	}

	for name, c := range cases {
		t.Run(name, func(t *testing.T) {
			verifyCheckMagazine(t, c.magazine, c.note, c.want)
		})
	}
}

func verifyCheckMagazine(t *testing.T, magazine []string, note []string, want string) {
	got, err := CheckMagazine(magazine, note)
	if err != nil {
		t.Fail()
	}
	if want != got {
		t.Error()
	}
}
