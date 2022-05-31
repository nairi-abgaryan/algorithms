namespace Search
{
    public static class TernarySearch
    {
        public static int? Search(int[] arr, int target)
        {
            return SearchRecursive(arr, target, 0, arr.Length - 1);
        }

        private static int? SearchRecursive(int[] arr, int target, int start, int end)
        {
            var left = start + (end - start) / 3;
            var right = end - (end - start) / 3;
            if (left > right) return null;

            if (arr[right] == target) return target;
            if (arr[left] == target) return target;

            if (target < arr[left])
                return SearchRecursive(arr, target, 0,  left - 1);

            if (target > arr[right])
                return SearchRecursive(arr, target, right + 1, end);

            return SearchRecursive(arr, target, left + 1, right - 1);
        }
    }
}
