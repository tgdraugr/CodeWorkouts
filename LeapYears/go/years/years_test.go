package years_test

import (
	"github.com/tgdraugr/CodeWorkouts/LeapYears/years"
	"testing"
)

func TestDivisibility(t *testing.T) {
	t.Run("Should be leap year when year is divisible by 400", func(t *testing.T) {
		assertLeapYearIsTrue(t, 2000)
	})

	t.Run("Should be leap year when year divisible by 4 but not by 100", func(t *testing.T) {
		testCaseParams := []int{2008, 2012, 2016}
		for _, param := range testCaseParams {
			assertLeapYearIsTrue(t, param)
		}
	})
}

func assertLeapYearIsTrue(t *testing.T, year int) {
	if !years.IsLeapYear(year) {
		t.Errorf("Fail(value=%d): expected=false, actual=true", year)
	}
}
