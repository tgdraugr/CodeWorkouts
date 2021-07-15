MIN = 'min'
MAX = 'max'
AVERAGE = 'avg'
COUNT = 'count'

def stats(values):
    """
        Computes the stats for the given list of numbers.
        It only accepts numeric types. Throws 'ValueError' exception otherwise.
    """
    def _are_numbers():
        for value in values:
            yield isinstance(value, (int, float))

    def _result(lamdba_expression):
        if not values: return 0
        return lamdba_expression()

    if all(_are_numbers()):
        return {
            MIN: _result(lambda: min(values)),
            MAX: _result(lambda: max(values)),
            COUNT: _result(lambda: len(values)),
            AVERAGE: _result(lambda: round(sum(values) / len(values), 6))
        }
    else:
        raise ValueError("The list contains invalid values")
