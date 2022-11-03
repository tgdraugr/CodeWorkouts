package stringcalc

import (
	"strconv"
	"strings"
)

func Add(numbers string) int {
	splitNums := strings.Split(numbers, ",")
	var sum int
	for _, splitNum := range splitNums {
		sum += convertedNumber(splitNum)
	}
	return sum
}

func convertedNumber(num string) int {
	trimmedNum := strings.Trim(num, " ")
	resNum, err := strconv.Atoi(trimmedNum)
	if err != nil {
		return 0
	}
	return resNum
}
