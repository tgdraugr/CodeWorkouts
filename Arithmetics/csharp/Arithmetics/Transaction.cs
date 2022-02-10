namespace Arithmetics;

public class Transaction
{
    private const string Space = " ";
    
    private readonly string[] _tokens;
    private static int _currentIndex;

    public Transaction(string expression)
    {
        _tokens = expression.Split(Space);
        _tokens.GetEnumerator();
        _currentIndex = 0;
    }

    public float? Result { get; private set; }

    public void Evaluate()
    {
        Result = EvaluateOperation();
    }

    private float EvaluateOperation()
    {
        return EvaluateOperation(_tokens).Value;
    }

    private static Constant EvaluateOperation(IReadOnlyList<string> tokens)
    {
        var value = NextConstant(tokens);
        if (_currentIndex == tokens.Count)
            return value;

        var nextToken = NextToken(tokens);
        if (nextToken == ")")
            return value;

        var secondValue = NextConstant(tokens);
        return ResultFrom(nextToken, value, secondValue);
    }
    
    private static Constant NextConstant(IReadOnlyList<string> tokens)
    {
        var current = NextToken(tokens);
        return current == "(" ? EvaluateOperation(tokens) : new Constant(current);
    }

    private static string NextToken(IReadOnlyList<string> tokens)
    {
        var token = tokens[_currentIndex];
        _currentIndex++;
        return token;
    }

    private static Constant ResultFrom(string @operator, Constant first, Constant second)
    {
        return @operator switch
        {
            "+" => first + second,
            "-" => first - second,
            "*" => first * second,
            "/" => first / second,
            _ => ThrowInvalidOperation(@operator)
        };
    }

    private static Constant ThrowInvalidOperation(string @operator)
    {
        throw new InvalidRecordException(InvalidRecordException.RecordError.InvalidOperation, 
            $"Expected one of [+, -, *, /] but got {@operator}");
    }
}