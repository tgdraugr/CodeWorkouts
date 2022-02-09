namespace Arithmetics;

internal class Division : MathOperation
{
    public Division(Constant first, Constant second) : 
        base(first, second)
    { }

    public override float Result => Result2.Value;
    public override Constant Result2 => First / Second;
}