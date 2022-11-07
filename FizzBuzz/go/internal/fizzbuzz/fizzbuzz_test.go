package fizzbuzz_test

import (
	"github.com/tgdraugr/CodeWorkouts/FizzBuzz/internal/fizzbuzz"
	"strconv"
	"testing"
)

func TestFizzBuzz(t *testing.T) {
	// Should print one line to 100
	var output []string
	fizzbuzz.FizzBuzz(func(n string) {
		output = append(output, n)
	})

	if len(output) == 0 {
		t.Error("Got no output")
	}

	want := 1
	for _, o := range output {
		got, err := strconv.Atoi(o)
		if err != nil {
			t.Error("The item is not a number")
		}
		if got != want {
			t.Errorf("should be '%d' but got '%d'", want, got)
		}
		want++
	}
}
