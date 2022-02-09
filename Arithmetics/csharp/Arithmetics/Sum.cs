namespace Arithmetics;

internal class Sum : MathOperation
{
    public Sum(Constant first, Constant second)
        : base(first, second)
    { }

    public override float Result => SumResult();

    private float SumResult()
    {
        var sum = First + Second;
        return sum.Value;
    }
}