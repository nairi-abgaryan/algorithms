using System;

namespace Search
{
    public static class ExponentialSearch
    {
        public static int? Search(int[] arr, int target)
        {
            var bound = 1;

            while (bound < arr.Length && arr[bound] < target)
                bound *= 2;

            return BinarySearch.SearchRecursive(arr, target, bound/2, Math.Min(bound, arr.Length - 1));
        }
    }
}
