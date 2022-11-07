package fizzbuzz_test

import (
	"github.com/tgdraugr/CodeWorkouts/FizzBuzz/internal/fizzbuzz"
	"testing"
)

var multiplesOf3And5 = func() map[int]bool {
	mm := map[int]bool{}
	for i := 15; i < 100; i += 15 {
		mm[i] = true
	}
	return mm
}()

func TestFizzBuzz(t *testing.T) {
	t.Run("Should print one line to 100", func(t *testing.T) {
		output := fizzBuzzed()
		want := 100
		got := len(output)
		if got != want {
			t.Errorf("should be '%d' but got '%d'", want, got)
		}
	})

	t.Run("Should print 'FizzBuzz' for multiples of 3 and 5", func(t *testing.T) {
		output := fizzBuzzed()
		want := "FizzBuzz"
		for i := range multiplesOf3And5 {
			got := output[i-1]
			if want != got {
				t.Errorf("should be '%s' but got '%s' (num=%d)", want, got, i)
			}
		}
	})

	t.Run("Should print 'Fizz' for multiples of 3", func(t *testing.T) {
		output := fizzBuzzed()
		verifyMultiples(t, output, 3, "Fizz")
	})

	t.Run("Should print 'Buzz' for multiples of 5", func(t *testing.T) {
		output := fizzBuzzed()
		verifyMultiples(t, output, 5, "Buzz")
	})
}

func verifyMultiples(t *testing.T, output []string, multiple int, want string) {
	for i := multiple; i <= 100; i += multiple {
		if _, ok := multiplesOf3And5[i]; !ok {
			got := output[i-1]
			if want != got {
				t.Errorf("should be '%s' but got '%s' (num=%d)", want, got, i)
			}
		}
	}
}

func fizzBuzzed() []string {
	var output []string
	fizzbuzz.FizzBuzz(func(n string) {
		output = append(output, n)
	})
	return output
}
