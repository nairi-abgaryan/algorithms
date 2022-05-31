using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Queues
{
    public class LinkedListQueue
    {
        private LinkedList<int> _list;
        public int Count = 0;
        public readonly int Capacity;

        public LinkedListQueue(int Capacity)
        {
            this.Capacity = Capacity;
            _list = new LinkedList<int>();
        }

        public void Enqueue(int element)
        {
            if (IsFull())
                throw new Exception("Queue is full");

            Count++;
            _list.AddLast(element);
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new Exception("Queue is empty");

            var element = _list.First;
            _list.RemoveFirst();

            Count--;
            return element.Value;
        }

        public int Peek()
        {
            if (_list.First == null)
                throw new Exception("Queue is empty");

            return _list.First.Value;
        }

        public bool IsFull()
        {
            return Count == Capacity;
        }

        public bool IsEmpty()
        {
            return _list.First == null;
        }


        public override string ToString()
        {
            return _list.ToString();
        }

    }
}
