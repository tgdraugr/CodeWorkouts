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
            var operation = _tokens[2];
            var firstOperand = _tokens[1];
            var secondOperand = _tokens[3];
            return OperationResult(operation, firstOperand, secondOperand);
        }
        return Constant(_tokens[1]);
    }

    private float OperationResult(string operation, string firstOperand, string secondOperand)
    {
        return operation switch
        {
            "+" => Constant(firstOperand) + Constant(secondOperand),
            "-" => Constant(firstOperand) - Constant(secondOperand),
            "*" => Constant(firstOperand) * Constant(secondOperand),
            "/" => Constant(firstOperand) / Constant(secondOperand),
            _ => 0
        };
    }

    private float Constant(string token)
    {
        return int.Parse(token);
    }
}