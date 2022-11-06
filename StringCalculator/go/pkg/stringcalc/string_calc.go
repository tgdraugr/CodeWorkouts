package stringcalc

import (
	"errors"
	"fmt"
	"strconv"
	"strings"
)

const defaultDelimiter = ","

func Add(numExpr string) (int, error) {
	if strings.Contains(numExpr, ",\n") {
		return -1, nil // TODO: Make this an error
	}
	delimiter := getDelimiterOrDefault(numExpr, defaultDelimiter) // extract delimiter
	sanitizedExpr := getSanitizedExpression(numExpr, delimiter)
	var sum int
	var negatives []string
	for _, splitNum := range strings.Split(sanitizedExpr, delimiter) {
		num := convertedNumber(splitNum)
		if num < 0 {
			negatives = append(negatives, splitNum)
			continue
		}
		sum += num
	}
	if len(negatives) > 0 {
		return -1, errors.New(fmt.Sprintf("negatives not allowed: %s", strings.Join(negatives, ",")))
	}
	return sum, nil
}

func getSanitizedExpression(numExpr string, del string) string {
	if strings.HasPrefix(numExpr, "//") {
		return strings.ReplaceAll(numExpr[4:], "\n", del)
	}
	return strings.ReplaceAll(numExpr, "\n", del)
}

func getDelimiterOrDefault(numExpr, def string) string {
	if strings.HasPrefix(numExpr, "//") {
		return numExpr[2:3]
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
