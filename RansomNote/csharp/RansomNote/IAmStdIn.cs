using System.Collections.Generic;

namespace RansomNote
{
    public interface IAmStdIn
    {
        (int, int) NumberOfWords();
        List<string> Magazine();
        List<string> Note();
    }
}