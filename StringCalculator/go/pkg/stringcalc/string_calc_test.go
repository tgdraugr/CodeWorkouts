package stringcalc_test

import (
	"fmt"
	"testing"

	"github.com/tgdraugr/stringcalc/pkg/stringcalc"
)

type testCase struct {
	Name   string
	Params []testCaseParam
}

type testCaseParam struct {
	Expr string
	Want string
}

func TestAdd(t *testing.T) {
	tcc := []testCase{
		{"Should add two numbers", []testCaseParam{
			{"", fmt.Sprint(0)},
			{"1", fmt.Sprint(1)},
			{"1,2", fmt.Sprint(3)},
		}},
		{"Should handle unknown amount of numbers", []testCaseParam{
			{"2,2,2", fmt.Sprint(6)},
			{"1,3,4,6", fmt.Sprint(14)},
			{"1,2, 6,1, 2", fmt.Sprint(12)},
		}},
		{"Should new lines between numbers", []testCaseParam{
			{"1\n2,3", fmt.Sprint(6)},
			{"1,\n", "invalid input"}, // this is meant as not ok (won't be return err for now)
		}},
		{"Should support different delimiters", []testCaseParam{
			{"//;\n1;2", fmt.Sprint(3)},
			{"//-\n1-2-3", fmt.Sprint(6)},
			{"//:\n1:2:3:4", fmt.Sprint(10)},
		}},
		{"Should throw error on negatives", []testCaseParam{
			{"-1", "negatives not allowed: -1"},
			{"1,-2", "negatives not allowed: -2"},
			{"//:\n1:2:-3:4", "negatives not allowed: -3"},
			{"//:\n-1:2:-3", "negatives not allowed: -1,-3"},
			{"//;\n-1;2;-3;4;-5", "negatives not allowed: -1,-3,-5"},
		}},
		{"Should ignore numbers bigger than 1000", []testCaseParam{
			{"1001", fmt.Sprint(0)},
			{"1,4,1100,5", fmt.Sprint(10)},
			{"//:\n1:2:2000:4", fmt.Sprint(7)},
		}},
		{"Should allow delimiters of any length", []testCaseParam{
			{"//[***]\n1***2***3", fmt.Sprint(6)},
			{"//[%]\n2%3%3", fmt.Sprint(8)},
			{"//[//]\n10//4//6", fmt.Sprint(20)},
		}},
		{"Should allow multiple delimiters of any length", []testCaseParam{
			{"//[*][%]\n1%2*3", fmt.Sprint(6)},
			{"//[&&][%]\n1%2&&9", fmt.Sprint(12)},
			{"//[aa][bbb]\n0aa1bbb9", fmt.Sprint(10)}}},
	}
	for _, tc := range tcc {
		t.Run(tc.Name, func(t *testing.T) {
			VerifyAllTests(t, tc.Params)
		})
	}
}

func VerifyAllTests(t *testing.T, params []testCaseParam) {
	for _, param := range params {
		got, err := stringcalc.Add(param.Expr)
		if err != nil {
			if err.Error() != param.Want {
				t.Errorf("Should be err '%s' but instead got '%s'", param.Want, err.Error())
			}
			continue
		}
		if fmt.Sprint(got) != param.Want {
			t.Errorf("Should be '%s' but instead got '%s'", param.Want, fmt.Sprint(got))
		}
	}
}
