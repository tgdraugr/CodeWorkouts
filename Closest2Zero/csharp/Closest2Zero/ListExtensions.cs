using System;
using System.Collections.Generic;
using System.Linq;

namespace Closest2Zero
{
    public static class ListExtensions
    {
        public static int ClosestToZero(this List<int> numbers) 
        {
            if (numbers.Count == 0) 
            {
                throw new InvalidOperationException();
            }
            
            return numbers
                .OrderBy(number => number)
                .First(number => number > 0);
        }

        public static string ClosestToZero(this List<string> words)
        {
            return null;
        }
    }
}