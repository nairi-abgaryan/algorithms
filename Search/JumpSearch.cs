using System;
using System.Threading;

namespace Search
{
    public class JumpSearch
    {
        public static int? Search(int[] arr, int target)
        {
            var start = 0;
            var blockSize = (int)Math.Sqrt(arr.Length);
            var next = blockSize;

            while (start < arr.Length)
            {
                if (next >= arr.Length) next = arr.Length;

                if (target > arr[next - 1])
                {
                    start += blockSize;
                    next += blockSize;
                    continue;
                }

                for (int i = start; i < next; i++)
                    if (arr[i] == target) return target;

                return null;
            }

            return null;
        }
    }
}
