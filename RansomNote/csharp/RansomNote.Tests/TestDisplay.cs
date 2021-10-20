namespace RansomNote.Tests
{
    public class TestDisplay : IAmStdOut
    {
        public string Result { get; private set; } = string.Empty;

        public void Display(string value)
        {
            Result = value;
        }
    }
}