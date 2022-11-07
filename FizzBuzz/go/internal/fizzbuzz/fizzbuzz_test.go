package fizzbuzz_test

import (
	"github.com/tgdraugr/CodeWorkouts/FizzBuzz/internal/fizzbuzz"
	"testing"
)

func TestFizzBuzz(t *testing.T) {
	t.Run("Should print one line to 100", func(t *testing.T) {
		output := doFizzFuzz()
		want := 100
		got := len(output)
		if got != want {
			t.Errorf("should be '%d' but got '%d'", want, got)
		}
	})

	t.Run("Should print 'FizzBuzz' for multiples of 3 and 5", func(t *testing.T) {
		output := doFizzFuzz()
		verifyMultiples(t, output, 15, "FizzBuzz", func(int) bool { return true })
	})

	t.Run("Should print 'Fizz' for multiples of 3", func(t *testing.T) {
		output := doFizzFuzz()
		assertOnlyIf := func(i int) bool {
			return i%5 != 0
		}
		verifyMultiples(t, output, 3, "Fizz", assertOnlyIf)
	})

	t.Run("Should print 'Buzz' for multiples of 5", func(t *testing.T) {
		output := doFizzFuzz()
		assertOnlyIf := func(i int) bool {
			return i%3 != 0
		}
		verifyMultiples(t, output, 5, "Buzz", assertOnlyIf)
	})
}

func verifyMultiples(t *testing.T, output []string, multiple int, want string, assertConditionFunc func(int) bool) {
	for i := multiple; i <= 100; i += multiple {
		if assertConditionFunc(i) {
			got := output[i-1]
			if want != got {
				t.Errorf("should be '%s' but got '%s' (num=%d)", want, got, i)
			}
		}
	}
}

func doFizzFuzz() []string {
	var output []string
	fizzbuzz.FizzBuzz(func(n string) {
		output = append(output, n)
	})
	return output
}
