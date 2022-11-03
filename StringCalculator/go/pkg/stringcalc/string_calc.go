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
		return convertedNumber(splitNumbers[0]) + convertedNumber(splitNumbers[1])
	}

	return -1
}

func convertedNumber(n string) int {
	res, err := strconv.Atoi(n)
	if err != nil {
		return 0
	}
	return res
}
