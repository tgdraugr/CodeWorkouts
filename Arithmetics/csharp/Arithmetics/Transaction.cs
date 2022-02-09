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
            return OperationResult(@operator, firstOperand, secondOperand).Value;
        }
        return new Constant(_tokens[1]).Value;
    }

    private static Constant OperationResult(string @operator, string firstOperand, string secondOperand)
    {
        return @operator switch
        {
            "+" => new Sum(new Constant(firstOperand), new Constant(secondOperand)).Result,
            "-" => new Subtraction(new Constant(firstOperand), new Constant(secondOperand)).Result,
            "*" => new Multiplication(new Constant(firstOperand), new Constant(secondOperand)).Result,
            "/" => new Division(new Constant(firstOperand), new Constant(secondOperand)).Result,
            _ => ThrowInvalidOperation(@operator)
        };
    }

    private static Constant ThrowInvalidOperation(string @operator)
    {
        throw new InvalidRecordException(InvalidRecordException.RecordError.InvalidOperation, 
            $"Expected one of [+, -, *, /] but got {@operator}");
    }
}