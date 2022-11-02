package years_test

import (
	"github.com/tgdraugr/CodeWorkouts/LeapYears/years"
	"testing"
)

func TestDivisibility(t *testing.T) {
	t.Run("Should be leap year when year is divisible by 400", func(t *testing.T) {
		expected := true
		actual := years.IsLeapYear(2000)
		if expected != actual {
			t.Error("Fail: expected=false, actual=true")
		}
	})
}
