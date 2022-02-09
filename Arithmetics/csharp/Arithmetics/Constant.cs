namespace Arithmetics;

internal class Constant
{
    public Constant(string token)
    {
        ThrowErrorIfBadSyntax(token);
        Value = float.Parse(token);
    }
    
    private Constant(float value)
    {
        Value = value;
    }

    public float Value { get; }
    
    public static Constant operator +(Constant one, Constant other) => new(one.Value + other.Value);
    
    public static Constant operator -(Constant one, Constant other) => new(one.Value - other.Value);

    public static Constant operator *(Constant one, Constant other) => new(one.Value * other.Value);

    public static Constant operator /(Constant one, Constant other)
    {
        ThrowErrorIfDenominatorIsZero(other);
        return new Constant(one.Value / other.Value);
    }

    private static void ThrowErrorIfDenominatorIsZero(Constant other)
    {
        if (other.Value == 0.0f)
            throw new InvalidRecordException(InvalidRecordException.RecordError.DivisionByZero,
                "Division is not possible because denominator is 0");
    }

    private static void ThrowErrorIfBadSyntax(string token)
    {
        if (!float.TryParse(token, out _))
            throw new InvalidRecordException(InvalidRecordException.RecordError.BadSyntax, "Wrong syntax");
    }
}