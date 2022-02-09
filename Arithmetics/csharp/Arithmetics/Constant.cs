namespace Arithmetics;

internal class Constant
{
    public Constant(string token)
    {
        ThrowErrorIfBadSyntax(token);
        Value = float.Parse(token);
    }

    public float Value { get; }

    private static void ThrowErrorIfBadSyntax(string token)
    {
        if (!float.TryParse(token, out _))
            throw new InvalidRecordException(InvalidRecordException.RecordError.BadSyntax, "Wrong syntax");
    }
}