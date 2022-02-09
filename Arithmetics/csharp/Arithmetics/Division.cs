namespace Arithmetics;

internal class Division : MathOperation
{
    public Division(Constant first, Constant second) : 
        base(first, second)
    { }

    public override Constant Result => First / Second;
}