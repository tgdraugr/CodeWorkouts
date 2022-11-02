package years_test

import (
	"github.com/tgdraugr/CodeWorkouts/LeapYears/years"
	"testing"
)

func TestDivisibility(t *testing.T) {
	t.Run("Should be leap year when year is divisible by 400", func(t *testing.T) {
		assertLeapYearIsTrue(t, 2000, true)
	})

	t.Run("Should be leap year when year divisible by 4 but not by 100", func(t *testing.T) {
		testCaseParams := []int{2008, 2012, 2016}
		for _, param := range testCaseParams {
			assertLeapYearIsTrue(t, param, true)
		}
	})

	t.Run(" Should not be leap year if it is not divisible by 4", func(t *testing.T) {
		testCaseParams := []int{2017, 2018, 2019}
		for _, param := range testCaseParams {
			assertLeapYearIsTrue(t, param, false)
		}
	})

	t.Run("Should not be leap year if it is divisible by 100 but not by 400", func(t *testing.T) {
		testCaseParams := []int{1700, 1800, 1900, 2100}
		for _, param := range testCaseParams {
			assertLeapYearIsTrue(t, param, false)
		}
	})
}

func assertLeapYearIsTrue(t *testing.T, year int, expected bool) {
	if years.IsLeapYear(year) != expected {
		t.Errorf("Fail(value=%d): expected=false, actual=true", year)
	}
}
