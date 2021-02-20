namespace KarateChops.Library
{
    public static class BinaryChops
    {
        public static int Chop(int target, int[] numbers)
        {
            var begin = 0;
            var end = numbers.Length - 1;
            
            while (begin <= end)
            {
                var middle = begin + (end - begin) / 2;
                
                if (numbers[middle] == target)
                    return middle;
                if (numbers[middle] < target)
                    begin = middle + 1;
                if (numbers[middle] > target)
                    end = middle - 1;
            }
            
            return -1;
        }
    }
}