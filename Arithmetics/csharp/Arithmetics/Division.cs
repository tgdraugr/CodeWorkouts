namespace Arithmetics;

internal class Division : MathOperation
{
    public Division(Constant first, Constant second) : 
        base(first, second)
    { }

    public override float Result => Second.Value != 0.0f ? 
        First.Value / Second.Value: 
        throw new InvalidRecordException(InvalidRecordException.RecordError.DivisionByZero, "Division is not possible because denominator is 0");
}