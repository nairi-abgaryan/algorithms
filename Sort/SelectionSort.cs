namespace Sort
{
    public static class SelectionSort
    {
        //[7, 8, 9, 0, 4, 3]
        // [9, 8, 7, 0, 4, 3]
        // []
        public static int[] Sort(int[] arr)
        {
            var start = 0;
            while (true)
            {
                if (start == arr.Length - 1) return arr;

                var maxIndex = start;
                var isChanged = false;
                for (var i = start; i < arr.Length; i++)
                {
                    if (arr[i] <= arr[maxIndex]) continue;

                    maxIndex = i;
                    isChanged = true;
                }

                if (isChanged)
                {
                    (arr[start], arr[maxIndex]) = (arr[maxIndex], arr[start]);
                }

                ++start;
            }
        }
    }
}
