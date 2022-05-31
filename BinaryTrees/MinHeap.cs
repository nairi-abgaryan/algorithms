using System;

namespace BinaryTrees
{
    public class MinHeap
    {
        private int[] arr;
        private int count;

        public MinHeap(int capacity)
        {
            arr = new int[capacity];
        }

        public void Insert(int value)
        {
            if (IsFull())
                throw new Exception("Heap is  full");

            arr[count++] = value;
            BubbleUp();
        }

        public bool IsFull()
        {
            return arr.Length == count;
        }


        public int Remove()
        {
            if (IsEmpty())
                throw new Exception("Heap is empty");

            var minElement = arr[0];
            arr[0] =  arr[--count];
            arr[count] = default;
            BubbleDown(0);

            return minElement;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        private void BubbleDown(int parentIndex)
        {
            var left = 2 * parentIndex + 1;
            var right = 2 * parentIndex + 2;
            if (right > count -1)
                return;

            if (arr[parentIndex] < arr[left] && arr[parentIndex] < arr[right]) return;

            if (arr[left] <= arr[right])
            {
                Swap(left, parentIndex);
                BubbleDown(left);
                 return;
            }

            Swap(right, parentIndex);
            BubbleDown(right);
        }

        private void BubbleUp()
        {
            var currentIndex = count - 1;
            while (currentIndex > 0 && arr[currentIndex] <= arr[ParentIndex(currentIndex)])
            {
                var parentIndex = ParentIndex(currentIndex);
                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
            }
        }

        private void Swap(int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }

        private int ParentIndex(int current)
        {
            return (current - 1) / 2;
        }
    }
}
