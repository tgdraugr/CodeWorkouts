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
            var operation = _tokens[2];
            var firstOperand = _tokens[1];
            var secondOperand = _tokens[3];
            return OperationResult(operation, firstOperand, secondOperand);
        }
        return Constant(_tokens[1]);
    }

    private int OperationResult(string operation, string firstOperand, string secondOperand)
    {
        return operation switch
        {
            "+" => Constant(firstOperand) + Constant(secondOperand),
            "-" => Constant(firstOperand) - Constant(secondOperand),
            "*" => Constant(firstOperand) * Constant(secondOperand),
            _ => 0
        };
    }

    private int Constant(string token)
    {
        return int.Parse(token);
    }
}