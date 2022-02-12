""" Leap Year tests """

import pytest
import leap_year

def test_should_not_be_leap_year_when_divisible_not_divisible_by_4():
    assert not leap_year.is_leap_year(1997)
