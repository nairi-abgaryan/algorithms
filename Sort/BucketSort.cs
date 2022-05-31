using System.Collections.Generic;

namespace Sort
{
    public static class BucketSort
    {
        public static int[] Sort(int[] arr, int k)
        {
            var buckets = new List<int>[k];

            var d = new Dictionary<char, int>();
            for (var i = 0; i < k; i++)
                buckets[i] = new List<int>();

            foreach (var t in arr)
                buckets[t / k].Add(t);

            var pos = 0;
            foreach (var list in buckets)
            {
                list.Sort();
                foreach (var t in list)
                    arr[pos++] = t;
            }

            return arr;
        }
    }
}
