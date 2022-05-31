using System.Collections.Generic;

namespace Sort
{
    public static class InsertionSort
    {
        public static int[] Sort(int[] arr, int index = 0)
        {
            // [7, 6, 10, 9, 11] current = 7; i = 0;
            // [7, 6, 10, 9, 11] current = 8; i = 1; for each element before 1 shift 7 to 8
            // [8, 7, 10, 9, 11] current = 10; i = 2; for each element before 2 shift 7 and 8 one more
            // [10, 6, 7, 9, 11] current = 9; i = 2; for each element before 2 shift 7 and 8 one more
            // [10, 9, 7, 6, 11] current = 9; i = 3; for each element before 3 shift 7 and 8 one more

            var current = arr[index];
            var changePosition = -1;
            for (var i = index; i >= 0; i--)
            {
                if (current > arr[i])
                {
                    changePosition = i;
                }
            }

            if (changePosition > -1)
            {
                for (var i = index; i > changePosition; i--)
                {
                    arr[i] = arr[i - 1];
                }

                arr[changePosition] = current;

            }

            return index == arr.Length - 1 ? arr : Sort(arr, ++index);
        }
    }
}
