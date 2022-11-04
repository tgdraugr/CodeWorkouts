package stringcalc_test

import (
	"github.com/tgdraugr/stringcalc/pkg/stringcalc"
	"testing"
)

func TestAddsUpToTwoNumbers(t *testing.T) {
	tests := []struct {
		expr string
		want int
	}{
		{"", 0}, {"1", 1}, {"1,2", 3},
	}
	VerifyAllTests(t, tests)
}

func TestHandlesUnknownAmountOfNumbers(t *testing.T) {
	tests := []struct {
		expr string
		want int
	}{
		{"2,2,2", 6},
		{"1,3,4,6", 14},
		{"1,2, 6,1, 2", 12},
	}
	VerifyAllTests(t, tests)
}

func TestHandlesNewLinesBetweenNumbers(t *testing.T) {
	tests := []struct {
		expr string
		want int
	}{
		{"1\n2,3", 6},
		{"1,\n", -1}, // this is meant as not ok (won't be return err for now)
	}
	VerifyAllTests(t, tests)
}

func TestSupportDifferentDelimiters(t *testing.T) {
	assertStringCalcResult(t, 3, stringcalc.Add("//;\n1;2"))
}

func VerifyAllTests(t *testing.T, tests []struct {
	expr string
	want int
}) {
	for _, tt := range tests {
		assertStringCalcResult(t, tt.want, stringcalc.Add(tt.expr))
	}
}

func assertStringCalcResult(t *testing.T, want, got int) {
	if want != got {
		t.Errorf("Should be %d but instead got %d", want, got)
	}
}
