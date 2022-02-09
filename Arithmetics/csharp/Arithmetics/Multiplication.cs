namespace Arithmetics;

internal class Multiplication : MathOperation
{
    public Multiplication(Constant first, Constant second) 
        : base(first, second)
    { }

    public override Constant Result => First * Second;
}