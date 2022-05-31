using System;
using System.Linq;
using Queues;

namespace BinaryTrees
{
    public class Heap
    {
        private readonly int[] _arr;
        private int _count = 0;

        public Heap()
        {
            _arr = new int[10];
        }

        public void Insert(int element)
        {
            if (_count == 0)
            {
                _arr[_count++] = element;
                return;
            }


            _arr[_count] = element;
            if (element > _arr[_count / 2])
            {
                BubbleUp(_count);
            }

            _count++;
        }

        public int Remove()
        {
            if (_count == 0) throw new Exception("There is no element in the heap");

            var maxElement = _arr[0];
            _arr[0] = _arr[--_count];
            _arr[_count] = default;
            BubbleDown(0);

            return maxElement;
        }

        public void BubbleUp(int index)
        {
            if (index == 0) return;
            if (_arr[index] < _arr[index / 2]) return;

            Swap(index, index/2);
            BubbleUp(index / 2);
        }

        public void BubbleDown(int index)
        {
            var left = 2 * index + 1;
            var right = 2 * index + 2;
            if (right >= _arr.Length) return;
            var largest = right;
            if (_arr[left] > _arr[right]) largest = left;
            if (_arr[index] > _arr[largest]) return;

            Swap(index, largest);
            BubbleDown(largest);
        }

        public bool IsFull()
        {
            return _arr.Length == _count;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        private void Swap(int first, int second)
        {
            (_arr[first], _arr[second]) = (_arr[second], _arr[first]);
        }

        private int ParentIndex(int current)
        {
            return (current - 1) / 2;
        }

        public int[] Heapify(int[] arr)
        {
            for (var i = (arr.Length - 1)/2; i >= 0; i--)
            {
                heapifyByDown(arr, i);
            }

            return arr;
        }

        private void Swap(int[] arr, int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }

        private void heapifyByDown(int[] arr, int index)
        {
            var largerIndex = index;
            var leftIndex = index * 2 + 1;
            var rightIndex = index * 2 + 2;
            if (leftIndex < arr.Length && arr[leftIndex] > arr[largerIndex])
                largerIndex = leftIndex;

            if (rightIndex < arr.Length && arr[rightIndex] > arr[largerIndex])
                largerIndex = rightIndex;

            if (largerIndex == index) return;

            Swap(arr, largerIndex, index);
            heapifyByDown(arr, largerIndex);
        }

        private int[] BubbleUp(int [] arr, int current)
        {
            while (current > 0 && arr[current] >= arr[ParentIndex(current)])
            {
                Swap(arr, current, ParentIndex(current));
                current = ParentIndex(current);
            }

            return arr;
        }

        public bool IsMaxHeap(int[] arr)
        {
            var heap = new PriorityQueue();
            foreach (var t in arr)
            {
                heap.Enqueue(t);
            }

            return arr.All(t => t == heap.Dequeue());
        }

        public bool IsMaxHeapRecursion(int[] arr)
        {
            return IsMaxHeapRecursion(arr, 0);
        }

        private bool IsMaxHeapRecursion(int[] arr, int index)
        {
            var left = index*2 + 1;
            var right = index*2 + 2;
            if (right > arr.Length || left > arr.Length)
                return true;

            if (left < arr.Length && arr[left] > arr[index]) return false;
            if (right < arr.Length && arr[right] > arr[index]) return false;

            return IsMaxHeapRecursion(arr, left) && IsMaxHeapRecursion(arr, right);
        }
    }
}
