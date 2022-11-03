package stringcalc

import (
	"strconv"
	"strings"
)

func Add(numbers string) int {
	if strings.Contains(numbers, ",\n") {
		return -1
	}
	sanNums := strings.ReplaceAll(numbers, "\n", ",")
	var sum int
	for _, splitNum := range strings.Split(sanNums, ",") {
		sum += convertedNumber(splitNum)
	}
	return sum
}

func convertedNumber(num string) int {
	resNum, err := strconv.Atoi(strings.Trim(num, " "))
	if err != nil {
		return 0
	}
	return resNum
}
