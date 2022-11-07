package fizzbuzz_test

import (
	"github.com/tgdraugr/CodeWorkouts/FizzBuzz/internal/fizzbuzz"
	"strconv"
	"testing"
)

func TestFizzBuzz(t *testing.T) {
	t.Run("Should print one line to 100", func(t *testing.T) {
		output := doFizzFuzz(t)
		want := 1
		for _, got := range output {
			if got != strconv.Itoa(want) {
				t.Errorf("should be '%d' but got '%s'", want, got)
			}
			want++
		}
	})
}

func doFizzFuzz(t *testing.T) []string {
	var output []string
	fizzbuzz.FizzBuzz(func(n string) {
		output = append(output, n)
	})
	if len(output) == 0 {
		t.Error("Got no output")
	}
	return output
}
