""" Leap Year tests """

import pytest
import leap_year

def test_should_not_be_leap_year_when_divisible_not_divisible_by_4():
    assert not leap_year.is_leap_year(1997)

def test_should_be_a_leap_year_when_divisible_by_4():
    assert leap_year.is_leap_year(1996)

def test_should_be_a_leap_year_when_divisible_by_400():
    assert leap_year.is_leap_year(1600)
