namespace Arithmetics;

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
        var value = NextConstant();
        
        if (_tokenizer.IsFinished())
            return value;
        
        var nextToken = _tokenizer.NextToken();
        if (nextToken == EndingParenthesis)
            return value;
        
        var secondValue = NextConstant();
        return Constant.From(nextToken, value, secondValue);
    }

    private Constant NextConstant()
    {
        var token = _tokenizer.NextToken();
        return token == OpeningParenthesis ? EvaluateOperation() : new Constant(token);
    }
}