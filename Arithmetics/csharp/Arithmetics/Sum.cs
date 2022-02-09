namespace Arithmetics;

internal class Sum : MathOperation
{
    public Sum(Constant first, Constant second)
        : base(first, second)
    { }

    public override Constant Result => First + Second;
}