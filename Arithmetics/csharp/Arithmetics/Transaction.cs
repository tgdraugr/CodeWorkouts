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

    private static float OperationResult(string operation, string firstOperand, string secondOperand)
    {
        return operation switch
        {
            "+" => Constant(firstOperand) + Constant(secondOperand),
            "-" => Constant(firstOperand) - Constant(secondOperand),
            "*" => Constant(firstOperand) * Constant(secondOperand),
            "/" => secondOperand != "0" ? 
                Constant(firstOperand) / Constant(secondOperand) : 
                throw new InvalidRecordException(InvalidRecordException.RecordError.DivisionByZero, "Division is not possible because denominator is 0"),
            _ => throw new InvalidRecordException(InvalidRecordException.RecordError.InvalidOperation, $"Expected one of [+, -, *, /] but got {operation}")
        };
    }

    private static float Constant(string token)
    {
        return float.TryParse(token, out var constant) ? 
            constant : 
            throw new InvalidRecordException(InvalidRecordException.RecordError.BadSyntax, "Wrong syntax");
    }
}