""" Leap year implementation """

def is_leap_year(year):
    def _divisible_by(divisor):
        return int(year) % divisor == 0
    return _divisible_by(4) and not _divisible_by(100) or _divisible_by(400)