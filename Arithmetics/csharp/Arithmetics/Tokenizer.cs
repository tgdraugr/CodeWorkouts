using System.Collections;

namespace Arithmetics;

internal class Tokenizer : IEnumerable<string>
{
    private readonly Queue<string> _tokens;

    public Tokenizer(IEnumerable<string> tokens)
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

    public IEnumerator<string> GetEnumerator() =>
        _tokens.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => 
        GetEnumerator();
}