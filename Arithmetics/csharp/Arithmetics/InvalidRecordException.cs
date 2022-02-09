namespace Arithmetics;

public sealed class InvalidRecordException : Exception
{
    public enum RecordError
    {
        DivisionByZero
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