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
        return EvaluateExpression(_tokens).Value;
    }

    private Constant EvaluateExpression(string[] tokens)
    {
        if (tokens.Length == 1)
            return new Constant(tokens[0]);
        
        var head = tokens[0];            
        var closingParenthesisIndex = Array.LastIndexOf(tokens, ")");

        if (closingParenthesisIndex < 0)
        {
            return ResultFrom(tokens[1], new Constant(tokens[0]), new Constant(tokens[2]));
        }

        if (float.TryParse(head, out _))
        {
            var remaining = EvaluateExpression(tokens[2..(closingParenthesisIndex+1)]);
            return ResultFrom(tokens[1], new Constant(head), remaining);
        }

        if (head == "(")
        {
            return EvaluateExpression(tokens[1..closingParenthesisIndex]);
        }
        
        return new Constant("0");
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