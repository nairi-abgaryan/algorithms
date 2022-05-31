namespace Sort
{
    public static class QuickSort
    {
        public static void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(int[] arr, int start, int end)
        {
            var b = Partition(arr, 0, end);
            if (start >= end) return;
            Sort(arr, 0, b - 1);
            Sort(arr, b + 1, end);
        }

        private static int Partition(int[] arr, int start, int end)
        {
            if (end <= 0) end = 0;

            var pivot = arr[end];
            var b = start - 1;

            for (var i = start; i <= end; i++)
            {
                if (arr[i] <= pivot)
                {
                    ++b;
                    (arr[i], arr[b]) = (arr[b], arr[i]);
                }

            }

            return b;
        }
    }
}
