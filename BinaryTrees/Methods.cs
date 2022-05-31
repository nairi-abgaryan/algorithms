using System;
using System.Collections.Generic;

namespace BinaryTrees
{
    public class Methods
    {

        private int[] arr = new int[10];
        private int i = 0;

        public Methods()
        {
            arr[0] = 0;
            arr[1] = 1;
            arr[2] = 1;
        }

        public static int Factorial(int x)
        {
            // lets assume we want to calculate 4!
            // for calculating that we can use for loop or another iteration
            // Second approach is recursion for example when we want to calculate 4! it means we have expression like this
            // 4! = 4 * 3 * 2 * 1
            // 3! = 3* 2 * 1
            // 4! = 4 * 3!
            // n! = n * (n-1)!
            // f(4) = 4 * 3
            //              3 * 2
            //                  2 * 1
            //                      1 * 1

            // base condition
            if (x == 0)
                return 1;

            return x * Factorial(x-1);
        }

        // [0,1,1,2, 3]
        // 0 1 1 2 3 5 8 13
        // 0 1 2 3 4 5 6 7
        public int Fibonacci(int n)
        {
            if(arr[n] != default){
                return arr[n];
            }

            arr[n] = Fibonacci(n - 1) + Fibonacci(n-2);

            return arr[n];
        }

        public static int FindKthLargest(int[] arr, int k)
        {
            if (arr.Length < 10 || k <= 0)
                throw new Exception("Illegal argument exception");

            var heap = new Heap();
            if (k > arr.Length) k = arr.Length;
            for (var j = 0; j <= k - 1; j++)
            {
                heap.Insert(arr[j]);
            }

            return heap.Remove();
        }
    }
}
