import pytest
import stats_calculation

def max_of(result):
    return result[stats_calculation.MAX]

def min_of(result):
    return result[stats_calculation.MIN]

def avg_of(result):
    return result[stats_calculation.AVERAGE]

def count_of(result):
    return result[stats_calculation.COUNT]

class TestAnEmptyList:
    def test_should_have_results_set_to_zero(self):
        result = stats_calculation.stats([])
        assert min_of(result) == 0
        assert max_of(result) == 0
        assert count_of(result) == 0
        assert avg_of(result) == 0


class TestListOfSingleNumber:
    def test_should_consider_the_element_itself(self):
        result = stats_calculation.stats([1])
        assert min_of(result) == 1
        assert max_of(result) == 1
        assert avg_of(result) == 1

    def test_should_have_count_of_one(self):
        result = stats_calculation.stats([1])
        assert count_of(result) == 1
        

class TestListOfSeveralNumbers:
    def test_should_find_the_min_of_numbers(self):
        result = stats_calculation.stats([2, 1])
        assert min_of(result) == 1

    def test_should_find_the_max_of_numbers(self):
        result = stats_calculation.stats([1, 2])
        assert max_of(result) == 2

    def test_should_have_the_count_same_as_the_total_of_numbers(self):
        result = stats_calculation.stats([1, 2])
        assert count_of(result) == 2

    def test_should_find_the_average_of_numbers(self):
        result = stats_calculation.stats([1, 2])
        assert avg_of(result) == 1.5


class TestListContainingNotOnlyNumbers:
    def test_should_throw_type_error_exception(self):
        with pytest.raises(ValueError):
            stats_calculation.stats([1, 'a'])


class TestGivenExample:
    def test_should_compute_the_expected_results(self):
        input = [6, 9, 15, -2, 92, 11]
        result = stats_calculation.stats(input)
        assert min_of(result) == -2
        assert max_of(result) == 92
        assert count_of(result) == 6
        assert avg_of(result) == 21.833333
