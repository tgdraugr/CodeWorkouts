""" String Calculator implementation """

def add(str_numbers):

    def _add(expression, delimiter='+'):
        numbers = []
        negatives = []
        for sub_expression in expression.split("\n"):
            remaining_numbers, remaining_negatives = _parse(sub_expression, delimiter)
            numbers.extend(remaining_numbers)
            negatives.extend(remaining_negatives)
        if len(negatives) == 1:
            raise Exception(f"Negatives not allowed: {negatives[0]}")
        elif len(negatives) > 1:
            raise Exception(f"Negatives not allowed: {negatives}")
        else:
            return sum(numbers)

    def _extract_delimiters(expression):
        delimiters = [',']
        if expression.startswith("//"):
            expression = expression.lstrip("//")
            if not '[' in expression or not ']' in expression:
                delimiter = expression[0]
                delimiters.append(delimiter)
                expression = expression.lstrip(delimiter)
            while '[' in expression and ']' in expression:
                start = expression.index('[')
                end = expression.index(']')
                delimiter = expression[start+1:end]
                delimiters.append(delimiter)
                expression = expression[end+1:]
        return expression, delimiters

    def _normalize(expression, delimiters, normalizing_delimiter='+'):
        for delimiter in delimiters:
            expression = expression.replace(delimiter, normalizing_delimiter)
        return expression

    def _parse(expression, delimiter):
        if not expression or not expression.strip(): return [0], []
        int_numbers = list(map(int, expression.split(delimiter)))
        valid_numbers = list(filter(lambda number: number <= 1000, int_numbers))
        negatives = list(filter(lambda input: input < 0, int_numbers))
        return (valid_numbers, negatives)

    expression, delimiters = _extract_delimiters(str_numbers)
    expression = _normalize(expression, delimiters)
    return _add(expression)
