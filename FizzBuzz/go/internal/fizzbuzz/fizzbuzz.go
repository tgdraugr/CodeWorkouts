package fizzbuzz

import "strconv"

const defaultMax = 100

func FizzBuzz(printFunc func(string)) {
	for i := 1; i <= defaultMax; i++ {
		printFunc(strconv.Itoa(i))
	}
}
