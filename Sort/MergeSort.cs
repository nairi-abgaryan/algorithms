namespace Sort
{
    public static class MergeSort
    {
        public static void Sort(int[] arr)
        {

            // Divide this a
            if (arr.Length < 2) return;

            var middle = arr.Length / 2;
            var left = new int[middle];
            for (var i = 0; i < middle; i++)
                left[i] = arr[i];


            var right = new int[arr.Length - middle];
            for (var i = middle; i < arr.Length; i++)
                right[i - middle] = arr[i];

            Sort(left);
            Sort(right);

            MergeArr(left, right, arr);
        }

        private static void MergeArr(int[] left, int[] right, int[] result)
        {
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                    result[k++] = left[i++];
                else
                    result[k++] = right[j++];
            }

            while (i < left.Length)
                result[k++] = left[i++];

            while (j < right.Length)
                result[k++] = right[j++];
        }
    }
}
