namespace Sort
{
    public static class CountingSort
    {
        public static void Sort(int[] arr, int max)
        {
            // [1,2,3,4,4,2,3]
            // [0,0,0,0,0,0,0]
            // [0,1,5,2,2,0,0]
            var counts = new int[max+1];
            foreach (var i in arr)
                counts[i] += 1;

            var pos = 0;

            for (var i = 0; i < counts.Length; i++)
            {
                if (counts[i] == 0) continue;

                for (var j = 0; j < counts[i]; j++)
                    arr[pos++] = i;
            }
        }
    }
}
