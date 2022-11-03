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

	for _, tt := range tests {
		assertStringCalcResult(t, tt.want, stringcalc.Add(tt.expr))
	}
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

	for _, tt := range tests {
		assertStringCalcResult(t, tt.want, stringcalc.Add(tt.expr))
	}
}

func assertStringCalcResult(t *testing.T, want, got int) {
	if want != got {
		t.Errorf("Should be %d but instead got %d", want, got)
	}
}
