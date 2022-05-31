using System;
using System.Collections;

namespace Stacks
{
    internal class TwoStacks<T> : IEnumerable
    {
        private T[] _stack;
        public int Count1;
        public int Count2;
        public int Size = 4;
        public TwoStacks()
        {
            _stack = new T[Size];
            Count1 = 0;
            Count2 = 0;
        }

        public void Push1(T item)
        {
            if (!IsFull())
                throw new Exception("Stack is Full");

            _stack[Count1++] = item;
        }

        public void Push2(T item)
        {
            if (!IsFull())
                throw new Exception("Stack is Full");

            _stack[Size - 1 - Count2++] = item;
        }


        public void Pop1()
        {
            if (Count1 == 0)
                throw new Exception("Stack is empty");

            Count1--;
            _stack[Count1] = default;
        }

        public void Pop2()
        {
            if (Count2 == 0)
                throw new Exception("Stack is empty");

            _stack[Size - Count2--] = default;
        }

        private bool IsFull()
        {
            return Count1 + Count2 != Size;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
