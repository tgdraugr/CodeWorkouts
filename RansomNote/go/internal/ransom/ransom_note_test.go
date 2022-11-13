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
			sentence("give me one grand today night"),
			sentence("give one grand today"),
			"Yes",
		},
		"responds no when magazine does not have enough words for the note": {
			sentence("two times three is not four"),
			sentence("two times two is four"),
			"No",
		},
		"responds no when magazine does not have the intended word": {
			sentence("ive got a lovely bunch of coconuts"),
			sentence("ive got some coconuts"),
			"No",
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
		t.Errorf("Want '%s' but got '%s'", want, got)
	}
}

func sentence(s string) []string {
	return strings.Split(s, " ")
}
