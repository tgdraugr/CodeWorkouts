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
	e, err := newExpression(expr)
	if err != nil {
		return -1, err
	}
	return e.SumAll()
}

type expression struct {
	header string
	body   string
}

func newExpression(expr string) (*expression, error) {
	i := 0
	if strings.HasPrefix(expr, "//") {
		i = strings.Index(expr, "\n")
	}
	return &expression{header: expr, body: expr[i:]}, nil
}

func (e *expression) SumAll() (int, error) {
	var sum int
	var negs []string
	for _, token := range strings.Split(e.sanitizedBody(), defaultDelimiter) {
		num := number(token)
		if num < 0 {
			negs = append(negs, token)
		} else if num <= maxThreshold {
			sum += num
		}
	}
	if len(negs) > 0 {
		return -1, errors.New(fmt.Sprintf("negatives not allowed: %s", strings.Join(negs, ",")))
	}
	return sum, nil
}

func (e *expression) sanitizedBody() string {
	dd := delimiters(e.header)
	return sanitizedExpression(e.body, dd)
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
