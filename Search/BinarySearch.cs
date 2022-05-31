namespace Search
{
    public static class BinarySearch
    {
        public static int? Search(int[] arr, int target)
        {
            return Search(arr, target, 0,arr.Length - 1);
        }

        public static int? SearchRecursive(int[] arr, int target, int start, int end)
        {
            if (end < start) return null;

            var half = (start + end) / 2;
            if (arr[half] == target) return target;

            if (target < arr[half])
                return SearchRecursive(arr, target, 0,  half - 1);

            return SearchRecursive(arr, target, half + 1, end);
        }

        private static int? Search(int[] arr, int target, int start, int end)
        {
            while (start <= end)
            {
                var half = (start + end) / 2;
                if (arr[half] == target) return target;
                if (target < arr[half])
                {
                    end = half - 1;
                    continue;
                }

                start = half + 1;
            }

            return null;
        }
    }
}
