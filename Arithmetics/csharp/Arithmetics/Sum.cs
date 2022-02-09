namespace Arithmetics;

internal class Sum : MathOperation
{
    public Sum(Constant first, Constant second)
        : base(first, second)
    { }

    public override float Result => Result2.Value;
    public override Constant Result2 => First + Second;
}