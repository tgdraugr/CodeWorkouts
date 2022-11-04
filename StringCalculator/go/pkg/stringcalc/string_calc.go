package stringcalc

import (
	"strconv"
	"strings"
)

func Add(numExpr string) int {
	if strings.Contains(numExpr, ",\n") {
		return -1
	}
	delimiter, sanitizedExpr := extractedDelimiterAndSanitizedExpression(numExpr)
	var sum int
	for _, splitNum := range strings.Split(sanitizedExpr, delimiter) {
		sum += convertedNumber(splitNum)
	}
	return sum
}

func extractedDelimiterAndSanitizedExpression(numExpr string) (del string, expr string) {
	if strings.HasPrefix(numExpr, "//") {
		remaining := numExpr[2:]
		del = string(remaining[0]) // extract delimiter
		remaining = remaining[1:]  // ignore \n or whatever comes next
	} else {
		del = ","
	}
	expr = strings.ReplaceAll(numExpr, "\n", del)
	return
}

func convertedNumber(num string) int {
	resNum, err := strconv.Atoi(strings.Trim(num, " "))
	if err != nil {
		return 0
	}
	return resNum
}
