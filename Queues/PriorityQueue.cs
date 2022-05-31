using System;

namespace Queues
{
    public class PriorityQueue
    {
        private int[] _arr;
        private int Count = 0;
        private readonly int _capacity;
        private int _front = 0;
        private int _rear = 0;

        public PriorityQueue(int capacity)
        {
            _capacity = capacity;
            _arr = new int[capacity];
        }

        public void Enqueue(int x)
        {
            // Insert Operation O(n)
            if (Count == _capacity)
                throw new Exception("Queue is full");

            if (Count == 0)
            {
                _arr[Count++] = x;
                return;
            }

            var position = ShiftingItems(x);
            _arr[position] = x;
            Count++;
        }

        private int ShiftingItems(int item)
        {
            int i;
            for (i = Count-1; i >= 0; i--)
            {
                if (_arr[i] > item)
                {
                    _arr[i+1] = _arr[i];
                } else
                  break;
            }

            return i+1;
        }

        public int Dequeue()
         {
             if (IsEmpty())
                 throw new Exception("Queue Is Empty");

             _arr[_front] = default;
             Count--;
             return _arr[0];
         }

         public int Peek() {
             if (IsEmpty())
                 throw new Exception("Queue Is Empty");

             return _arr[_rear];
         }

         private bool IsEmpty()
         {
             return Count == 0;
         }
    }
}
