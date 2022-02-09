namespace Arithmetics;

internal class Multiplication : MathOperation
{
    public Multiplication(Constant first, Constant second) 
        : base(first, second)
    { }

    public override float Result => Result2.Value;
    public override Constant Result2 => First * Second;
}