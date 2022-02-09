namespace Arithmetics;

public sealed class InvalidRecordException : Exception
{
    public enum RecordError
    {
        DivisionByZero = 0,
        InvalidOperation = 1 << 0,
        BadSyntax = 1 << 1
    }
    
    public InvalidRecordException(RecordError error, string message) : base(message)
    {
        Error = error;
    }

    public RecordError Error { get; }

    public override string ToString()
    {
        return $"{Error}: {Message}";
    }
}