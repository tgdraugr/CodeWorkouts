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

	t.Run("Should print 'Fizz' for multiples of 3", func(t *testing.T) {
		output := doFizzFuzz()
		want := "Fizz"
		for i := 3; i <= 100; i += 3 {
			if i%5 == 0 {
				continue
			}
			got := output[i-1]
			if want != got {
				t.Errorf("should be '%s' but got '%s' (num=%d)", want, got, i)
			}
		}
	})

	t.Run("Should print 'Buzz' for multiples of 5", func(t *testing.T) {
		output := doFizzFuzz()
		want := "Buzz"
		for i := 5; i <= 100; i += 5 {
			if i%3 == 0 {
				continue
			}
			got := output[i-1]
			if want != got {
				t.Errorf("should be '%s' but got '%s' (num=%d)", want, got, i)
			}
		}
	})
}

func doFizzFuzz() []string {
	var output []string
	fizzbuzz.FizzBuzz(func(n string) {
		output = append(output, n)
	})
	return output
}
