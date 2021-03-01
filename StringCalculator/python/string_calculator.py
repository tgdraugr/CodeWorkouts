""" String Calculator implementation """

def add(str_numbers, delimiter=","):
    def _add(str_numbers, delimiter):
        if not str_numbers or not str_numbers.strip():
            return 0
        int_numbers = list(map(int, str_numbers.split(delimiter)))
        negatives = list(filter(lambda input: input < 0, int_numbers))
        if len(negatives) == 1:
            raise Exception(f"Negatives not allowed: {negatives[0]}")
        elif len(negatives) > 1:
            raise Exception(f"Negatives not allowed: {negatives}")
        else:
            return sum(int_numbers)

    if str_numbers.startswith("//"):
        str_numbers = str_numbers.lstrip("//")
        delimiter = str_numbers[0]
        str_numbers = str_numbers.lstrip(delimiter)

    if "\n" in str_numbers:
        return sum([_add(str_number, delimiter) for str_number in str_numbers.split("\n")])
    else:
        return _add(str_numbers, delimiter)