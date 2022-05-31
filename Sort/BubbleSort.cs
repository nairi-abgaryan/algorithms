using System.Collections.Generic;

namespace Sort
{
    public static class BubbleSort
    {
        public static IEnumerable<int> Sort(int[] arr)
        {
            while (true)
            {
                if (arr.Length <= 1) return arr;

                var swapping = false;
                for (var i = 1; i < arr.Length; i++)
                {
                    if (arr[i - 1] < arr[i]) continue;

                    (arr[i - 1], arr[i]) = (arr[i], arr[i - 1]);
                    swapping = true;
                }

                if (swapping) continue;

                return arr;
            }
        }
    }
}
