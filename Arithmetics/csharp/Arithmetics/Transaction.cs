namespace Arithmetics;

public class Transaction
{
    private const string Space = " ";

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
        var first = NextConstant();
        
        if (_tokenizer.NoTokensLeft())
            return first;
        
        if (_tokenizer.IsNextTokenEndingOperation())
        {
            _tokenizer.SkipNext();
            return first;
        }
        
        var @operator = _tokenizer.NextToken();
        var second = NextConstant();
        return Constant.From(@operator, first, second);
    }

    private Constant NextConstant()
    {
        if (_tokenizer.IsNextTokenOpeningOperation() is false) 
            return new Constant(_tokenizer.NextToken());
        
        _tokenizer.SkipNext();
        return EvaluateOperation();
    }
}