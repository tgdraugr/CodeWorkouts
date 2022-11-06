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
	dd := delimiters(expr) // extract delimiter
	saneExpr := sanitizedExpression(expr, dd)
	sum, negatives := sumAll(saneExpr)
	if len(negatives) > 0 {
		return -1, errors.New(fmt.Sprintf("negatives not allowed: %s", strings.Join(negatives, ",")))
	}
	return sum, nil
}

func sumAll(saneExpr string) (sum int, negs []string) {
	for _, token := range strings.Split(saneExpr, defaultDelimiter) {
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
	i := 0
	if strings.HasPrefix(expr, "//") {
		i = strings.Index(expr, "\n")
	}
	saneExpr := strings.ReplaceAll(expr[i:], "\n", defaultDelimiter)
	for _, delim := range delimiters {
		saneExpr = strings.ReplaceAll(saneExpr, delim, defaultDelimiter)
	}
	return saneExpr
}

func delimiters(expr string) []string {
	if strings.HasPrefix(expr, "//") {
		var dd []string
		var d string
		for i := 2; expr[i:i+1] != "\n"; i++ { // \n is the end of the header
			if expr[i:i+1] == "[" {
				d = ""
				continue
			}
			if expr[i:i+1] == "]" {
				dd = append(dd, d)
				continue
			}
			d += expr[i : i+1]
		}
		if len(dd) == 0 {
			dd = append(dd, d)
		}
		return dd
	}
	return []string{defaultDelimiter}
}

func number(token string) int {
	num, err := strconv.Atoi(strings.Trim(token, " "))
	if err != nil {
		return 0
	}
	return num
}
