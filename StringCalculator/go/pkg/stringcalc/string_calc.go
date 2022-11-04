package stringcalc

import (
	"strconv"
	"strings"
)

func Add(numExpr string) int {
	if strings.Contains(numExpr, ",\n") {
		return -1
	}
	delimiter := getDelimiterOrDefault(numExpr, ",") // extract delimiter
	sanitizedExpr := getSanitizedExpression(numExpr, delimiter)
	var sum int
	for _, splitNum := range strings.Split(sanitizedExpr, delimiter) {
		sum += convertedNumber(splitNum)
	}
	return sum
}

func getSanitizedExpression(numExpr string, del string) string {
	if strings.HasPrefix(numExpr, "//") {
		return strings.ReplaceAll(numExpr[4:], "\n", del)
	}
	return strings.ReplaceAll(numExpr, "\n", del)
}

func getDelimiterOrDefault(numExpr, def string) string {
	if strings.HasPrefix(numExpr, "//") {
		return numExpr[3:3]
	}
	return def
}

func convertedNumber(num string) int {
	resNum, err := strconv.Atoi(strings.Trim(num, " "))
	if err != nil {
		return 0
	}
	return resNum
}
