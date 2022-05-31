using System;
using System.Collections.Generic;

namespace Manipulation
{
    public class Array
    {
        public void rotate90degreeLeft(int n, int[,] arr)
        {
            /*
             *  N x N matrices
             *  1, 2, 3    ->  3, 6, 9 matrix 1
             *  4, 5, 6        2, 5, 8
             *  7, 8, 9        1, 4, 7
             *
             *  indexes
             *  00, 01, 02,  -> 02, 12, 22,  matrix 2
             *  10, 11, 12,     01, 11, 21,
             *  20, 21, 22      00, 10, 20
             *
             *  indexes large matrix
             *  00, 01, 02, 03  -> 03, 13, 23, 33,  matrix 3
             *  10, 11, 12, 13,    02, 12, 22, 32,
             *  20, 21, 22  23     01, 11, 21, 31,
             *  30, 31, 32, 33     00, 10, 20, 30
             */
            displayMatrix(n, arr);

             // 2 methods for solving this problem

             //1 we can use cycles method
             // we need to make cycles for example first cycle in matrix3 is first row last row first column and last column
             // then we need to take second cycle
             // Starting point. We are taking 4 elements then rotating them. 00, 03, 33, 30
             // Then.  01, 13, 32, 20 ... we need 2 cycles for making this it mens N/2/
             // Code; using cycles
             for (var i = 0; i < n/2; i++)
             {
                 var l = n - i - 1;

                 for (var j = i; j < n - i - 1; j++)
                 {
                     // store current cell
                     // in temp variable
                     var temp = arr[i, j];
                     // move values from
                     // right to top
                     arr[i, j] = arr[j, n - i - 1];
                     // move values from
                     // bottom to right
                     arr[j, n - i - 1] = arr[n - i - 1, n - j - 1];
                     // move values from
                     // left to bottom
                     arr[n - i - 1, n - j - 1] = arr[n - j - 1, i];
                     // assign temp to left
                     arr[n - j - 1, i] = temp;
                 }
             }

             displayMatrix(n, arr);
        }

        public void SetToZero(int[,] arr)
        {
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] != 0) continue;
                    arr[i, 0] = 0;
                    arr[0, j] = 0;
                }
            }

            displayMatrix(4,arr);

            for (var i = 0; i < arr.GetLength(0); i++)
                if (arr[i, 0] == 0)
                    NullifyRow(arr, i);


            for (var i = 0; i < arr.GetLength(1); i++)
                if (arr[0, i] == 0)
                    NullifyColumn(arr, i);



            displayMatrix(4,arr);
        }

        private void NullifyRow(int[,] matrix, int row) {
             for (int i= 0; i < matrix.GetLength(1); i++) {
                 matrix[i, row] = 0;
             }
        }

        private void NullifyColumn(int[,] matrix, int col) {
             for (int i= 0; i < matrix.GetLength(0); i++) {
                 matrix[col, i] = 0;
             }
        }


        // Function to print the matrix
        static void displayMatrix(int n, int[, ] mat)
        {
            for (var i = 0; i < n; i++) {
                for (var j = 0; j < n; j++)
                    Console.Write(" " + mat[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
