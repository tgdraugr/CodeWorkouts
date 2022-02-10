namespace Arithmetics;

class Tokenizer : List<string>
{
    private readonly Queue<string> _tokens;

    public Tokenizer(string[] tokens)
        : base(tokens)
    {
        _tokens = new Queue<string>(tokens);
    }

    public string NextToken()
    {
        return _tokens.Dequeue();
    }
    
    public bool IsFinished() 
    {
        return _tokens.Count == 0;
    }
}
public class Transaction
{
    private const string Space = " ";
    private const string OpeningParenthesis = "(";
    private const string EndingParenthesis = ")";

    private readonly Tokenizer _tokenizer;

    public Transaction(string expression)
    {
        _tokenizer = new Tokenizer(expression.Split(Space));
    }

    public float? Result { get; private set; }

    public void Evaluate()
    {
        Result = EvaluateOperation().Value;
    }

    private Constant EvaluateOperation()
    {
        var value = NextConstant(_tokenizer);
        
        if (_tokenizer.IsFinished())
            return value;
        
        var nextToken = _tokenizer.NextToken();
        if (nextToken == EndingParenthesis)
            return value;
        
        var secondValue = NextConstant(_tokenizer);
        return ResultFrom(nextToken, value, secondValue);
    }

    private static Constant EvaluateOperation(Tokenizer tokens)
    {
        var value = NextConstant(tokens);
        
        if (tokens.IsFinished())
            return value;

        var nextToken = tokens.NextToken();
        if (nextToken == EndingParenthesis)
            return value;

        var secondValue = NextConstant(tokens);
        return ResultFrom(nextToken, value, secondValue);
    }
    
    private static Constant NextConstant(Tokenizer tokens)
    {
        var current = tokens.NextToken();
        return current == OpeningParenthesis ? EvaluateOperation(tokens) : new Constant(current);
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