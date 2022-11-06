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
	if strings.HasPrefix(expr, "//") { // has header
		i = strings.Index(expr, "\n")
	}
	return &expression{header: expr[:i], body: expr[i:]}, nil
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
	saneExpr := strings.ReplaceAll(e.body, "\n", defaultDelimiter)
	for _, delim := range e.delimiters() {
		saneExpr = strings.ReplaceAll(saneExpr, delim, defaultDelimiter)
	}
	return saneExpr
}

func (e *expression) delimiters() []string {
	if strings.HasPrefix(e.header, "//") {
		var dd []string
		var d string
		for i, token := range e.header {
			if i < 2 {
				continue
			}
			if string(token) == "[" {
				d = ""
				continue
			}
			if string(token) == "]" {
				dd = append(dd, d)
				continue
			}
			d += string(token)
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
