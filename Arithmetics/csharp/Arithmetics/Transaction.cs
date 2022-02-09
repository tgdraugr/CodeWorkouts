namespace Arithmetics;

public class Transaction
{
    private const string Space = " ";
    
    private readonly string[] _tokens;

    public Transaction(string expression)
    {
        _tokens = expression.Split(Space);
    }

    public float? Result { get; private set; }

    public void Evaluate()
    {
        Result = EvaluateOperation();
    }

    private float EvaluateOperation()
    {
        if (_tokens.Length > 3)
        {
            var @operator = _tokens[2];
            var firstOperand = _tokens[1];
            var secondOperand = _tokens[3];
            return OperationResult(@operator, new Constant(firstOperand), new Constant(secondOperand)).Value;
        }
        return new Constant(_tokens[1]).Value;
    }

    private static Constant OperationResult(string @operator, Constant first, Constant second)
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