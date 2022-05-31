using System;
using System.Collections.Generic;

namespace Queues
{
    public class ArrayQueue
    {
        private readonly int[] _arr;
        private int _front;
        private int _rear;
        public int Count;
        public int Capacity;

        public ArrayQueue(int Capacity)
        {
            this.Capacity = Capacity;
            _arr = new int[Capacity];
            Count = _rear;
        }

        public void Enqueue(int element)
        {
            if (IsFull())
                throw new Exception("Queue is full");

            Count++;
            if (_rear == Capacity && Count < Capacity)
            {
                _rear = 0;
                _arr[_rear++] = element;
                return;
            }

            _arr[_rear++] = element;
        }

        public void Dequeue()
        {
            if (IsEmpty())
                throw new Exception("Queue is empty");

            _arr[_front] = default;
            _front += 1;
            Count--;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new Exception("Queue is empty");

            return _arr[_front];
        }

        public bool IsFull()
        {
            return Count == Capacity;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }


        public override string ToString()
        {
            return string.Join(",", _arr);
        }

    }
}
