package stringcalc_test

import (
	"github.com/tgdraugr/stringcalc/pkg/stringcalc"
	"testing"
)

func TestAddsUpToTwoNumbers(t *testing.T) {
	want := 0
	got := stringcalc.Add("")
	if want != got {
		t.Errorf("Should be %d but instead got %d", want, got)
	}

	want = 1
	got = stringcalc.Add("1")
	if want != got {
		t.Errorf("Should be %d but instead got %d", want, got)
	}

	want = 3
	got = stringcalc.Add("1,2")
	if want != got {
		t.Errorf("Should be %d but instead got %d", want, got)
	}
}
