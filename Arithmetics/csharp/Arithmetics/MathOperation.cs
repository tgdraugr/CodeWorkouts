namespace Arithmetics;

internal abstract class MathOperation
{
    protected readonly Constant First;
    protected readonly Constant Second;

    protected MathOperation(Constant first, Constant second)
    {
        First = first;
        Second = second;
    }

    public abstract float Result { get; }
    
    public abstract Constant Result2 { get; }

}