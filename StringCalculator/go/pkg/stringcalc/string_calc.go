package stringcalc

import (
	"errors"
	"fmt"
	"strconv"
	"strings"
)

const (
	defaultDelimiter = ","
	maxThreshold     = 1000
)

func Add(expr string) (int, error) {
	if strings.Contains(expr, ",\n") {
		return -1, nil // TODO: Make this an error
	}
	delimiters := delimitersOrDefault(expr, defaultDelimiter) // extract delimiter
	saneExpr := sanitizedExpression(expr, delimiters)

	for _, delim := range delimiters {
		saneExpr = strings.ReplaceAll(saneExpr, delim, defaultDelimiter)
	}

	sum, negatives := sumAll(saneExpr, defaultDelimiter)
	if len(negatives) > 0 {
		return -1, errors.New(fmt.Sprintf("negatives not allowed: %s", strings.Join(negatives, ",")))
	}
	return sum, nil
}

func sumAll(saneExpr string, delimiter string) (sum int, negs []string) {
	for _, token := range strings.Split(saneExpr, delimiter) {
		num := number(token)
		if num < 0 {
			negs = append(negs, token)
		} else if num <= maxThreshold {
			sum += num
		}
	}
	return
}

func sanitizedExpression(expr string, delimiters []string) string {
	if strings.HasPrefix(expr, "//") {
		return strings.ReplaceAll(expr[4:], "\n", defaultDelimiter)
	}

	return strings.ReplaceAll(expr, "\n", defaultDelimiter)
}

func delimitersOrDefault(expr, def string) []string {
	if strings.HasPrefix(expr, "//") {
		var delimiters []string
		var del string
		for i := 2; expr[i:i+1] != "\n"; i++ { // \n is the end of the header
			if expr[i:i+1] == "[" {
				del = ""
				continue
			}
			if expr[i:i+1] == "]" {
				delimiters = append(delimiters, del)
				continue
			}
			del += expr[i : i+1]
		}
		if len(delimiters) == 0 {
			delimiters = append(delimiters, del)
		}
		return delimiters
	}
	return []string{def}
}

func number(token string) int {
	num, err := strconv.Atoi(strings.Trim(token, " "))
	if err != nil {
		return 0
	}
	return num
}
