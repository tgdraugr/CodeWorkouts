namespace Arithmetics;

public class Transaction
{
    private const string Space = " ";
    
    private readonly string[] _tokens;

    public Transaction(string expression)
    {
        _tokens = expression.Split(Space);
    }

    public int? Result { get; private set; }

    public void Evaluate()
    {
        Result = EvaluateOperation();
    }

    private int EvaluateOperation()
    {
        if (_tokens.Length > 3)
        {
            return Constant(_tokens[1]) + Constant(_tokens[3]);
        }
        return Constant(_tokens[1]);
    }

    private int Constant(string token)
    {
        return int.Parse(token);
    }
}