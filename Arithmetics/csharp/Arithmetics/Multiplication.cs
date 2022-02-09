namespace Arithmetics;

internal class Multiplication : MathOperation
{
    public Multiplication(Constant first, Constant second) 
        : base(first, second)
    { }

    public override float Result => First.Value * Second.Value;
}