package fizzbuzz

import (
	"strconv"
	"strings"
)

const defaultMax = 100

func FizzBuzz(printFunc func(string)) {
	for i := 1; i <= defaultMax; i++ {
		terms := termsFor(i)
		if len(terms) == 0 {
			printFunc(strconv.Itoa(i))
		} else {
			printFunc(strings.Join(terms, ""))
		}
	}
}

func termsFor(i int) []string {
	var terms []string
	if i%3 == 0 {
		terms = append(terms, "Fizz")
	}
	if i%5 == 0 {
		terms = append(terms, "Buzz")
	}
	return terms
}
