namespace Arithmetics;

internal class Sum : MathOperation
{
    public Sum(Constant first, Constant second)
        : base(first, second)
    { }

    public override float Result => First.Value + Second.Value;
}