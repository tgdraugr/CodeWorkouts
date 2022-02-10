namespace Arithmetics;

internal class Tokenizer
{
    private const string OpeningParenthesis = "(";
    private const string EndingParenthesis = ")";
    private readonly Queue<string> _tokens;

    public Tokenizer(IEnumerable<string> tokens)
    {
        _tokens = new Queue<string>(tokens);
    }

    public string NextToken()
    {
        return _tokens.Dequeue();
    }

    public void SkipNext()
    {
        NextToken();
    }

    public bool NoTokensLeft() 
    {
        return _tokens.Count == 0;
    }

    public bool IsNextTokenOpeningOperation()
    {
        return _tokens.Peek() == OpeningParenthesis;
    }

    public bool IsNextTokenEndingOperation()
    {
        return _tokens.Peek() == EndingParenthesis;
    }
}