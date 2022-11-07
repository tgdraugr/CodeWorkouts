package fizzbuzz

import "strconv"

const defaultMax = 100

func FizzBuzz(printFunc func(string)) {
	for i := 1; i <= defaultMax; i++ {
		if i%5 == 0 {
			printFunc("Buzz")
		} else if i%3 == 0 {
			printFunc("Fizz")
		} else {
			printFunc(strconv.Itoa(i))
		}
	}
}
