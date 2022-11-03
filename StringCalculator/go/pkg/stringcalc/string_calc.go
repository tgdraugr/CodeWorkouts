package stringcalc

import (
	"strconv"
	"strings"
)

func Add(numbers string) int {
	if numbers == "" {
		return 0
	}
	if len(numbers) == 1 {
		return convertedNumber(numbers)
	}
	if strings.Contains(numbers, ",") {
		splitNumbers := strings.Split(numbers, ",")
		if len(splitNumbers) == 2 {
			return convertedNumber(splitNumbers[0]) + convertedNumber(splitNumbers[1])
		} else {
			var sum int
			for _, n := range splitNumbers {
				sum += convertedNumber(n)
			}
			return sum
		}
	}

	return -1
}

func convertedNumber(n string) int {
	tn := strings.Trim(n, " ")
	res, err := strconv.Atoi(tn)
	if err != nil {
		return 0
	}
	return res
}
