namespace Arithmetics;

internal class Subtraction : MathOperation
{
    public Subtraction(Constant first, Constant second)
        : base(first, second)
    { }

    public override float Result => (First - Second).Value;
}