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
		return &expression{header: expr[2:i], body: expr[i:]}, nil
	}
	return &expression{header: expr[:i], body: expr[i:]}, nil
}

func (e *expression) SumAll() (int, error) {
	var sum int
	var negs []string
	for _, token := range strings.Split(e.sanitizedBody(), defaultDelimiter) {
		num, err := strconv.Atoi(strings.Trim(token, " "))
		if err != nil {
			continue
		}
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
	dd := []string{defaultDelimiter}
	var d string
	for _, ht := range e.header {
		token := string(ht)
		if token == "[" {
			d = ""
		} else if token == "]" {
			dd = append(dd, d)
		} else {
			d += token
		}
	}
	if d != "" {
		dd = append(dd, d)
	}
	return dd
}
