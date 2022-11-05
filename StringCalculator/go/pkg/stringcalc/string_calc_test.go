package stringcalc_test

import (
	"testing"

	"github.com/tgdraugr/stringcalc/pkg/stringcalc"
)

type testCase struct {
	Name   string
	Params []testCaseParam
}

type testCaseParam struct {
	Expr string
	Want int
}

func TestAdd(t *testing.T) {
	tcc := []testCase{
		{"Should add two numbers", []testCaseParam{
			{"", 0},
			{"1", 1},
			{"1,2", 3},
		}},
		{"Should handle unknown amount of numbers", []testCaseParam{
			{"2,2,2", 6},
			{"1,3,4,6", 14},
			{"1,2, 6,1, 2", 12},
		}},
		{"Should new lines between numbers", []testCaseParam{
			{"1\n2,3", 6},
			{"1,\n", -1}, // this is meant as not ok (won't be return err for now)
		}},
		{"Should support different delimiters", []testCaseParam{
			{"//;\n1;2", 3},
			{"//-\n1-2-3", 6},
			{"//:\n1:2:3:4", 10},
		}},
	}
	for _, tc := range tcc {
		t.Run(tc.Name, func(t *testing.T) {
			VerifyAllTests(t, tc.Params)
		})
	}
}

func TestAddError(t *testing.T) {
	wantErr := "negatives not allowed: -1"
	_, gotErr := stringcalc.Add("-1")
	if gotErr.Error() != wantErr {
		t.Errorf("Should be err '%s' but instead got '%s'", wantErr, gotErr.Error())
	}

	wantErr = "negatives not allowed: -2"
	_, gotErr = stringcalc.Add("1,-2")
	if gotErr.Error() != wantErr {
		t.Errorf("Should be err '%s' but instead got '%s'", wantErr, gotErr.Error())
	}

	wantErr = "negatives not allowed: -3"
	_, gotErr = stringcalc.Add("//:\n1:2:-3:4")
	if gotErr.Error() != wantErr {
		t.Errorf("Should be err '%s' but instead got '%s'", wantErr, gotErr.Error())
	}
}

func VerifyAllTests(t *testing.T, params []testCaseParam) {
	for _, param := range params {
		got, _ := stringcalc.Add(param.Expr)
		if param.Want != got {
			t.Errorf("Should be %d but instead got %d", param.Want, got)
		}
	}
}
