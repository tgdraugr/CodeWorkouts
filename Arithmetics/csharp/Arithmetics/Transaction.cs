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
        var value = NextConstant();
        
        if (_tokenizer.NoTokensLeft())
            return value;
        
        if (_tokenizer.IsNextTokenEndingOperation())
        {
            _tokenizer.SkipNext();
            return value;
        }
        
        var @operator = _tokenizer.NextToken();
        var secondValue = NextConstant();
        return Constant.From(@operator, value, secondValue);
    }

    private Constant NextConstant()
    {
        if (!_tokenizer.IsNextTokenOpeningOperation()) 
            return new Constant(_tokenizer.NextToken());
        
        _tokenizer.SkipNext();
        return EvaluateOperation();
    }
}