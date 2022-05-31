using System;
using System.Collections;

namespace Stacks
{
    internal class Stack<T> : IEnumerable
    {
        private T[] _stack;
        public int Count;
        public Stack()
        {
            _stack = new T[1];
            Count = 0;
        }

        public void Push(T item)
        {
            if (_stack.Length == Count)
            {
                ScaleSpace();
            }

            _stack[Count++] = item;
        }

        public T Pop()
        {
            if (_stack.Length == 0)
            {
                throw new Exception("Empty Stack");
            }
            Count--;
            var lastElement = _stack[Count];
            _stack[Count] = default;

            return lastElement;
        }

        public T Peek()
        {
            return _stack[Count-1];
        }

        private void ScaleSpace()
        {
            var newStack = new T[Count * 2];
            for (var i = 0; i < _stack.Length; i++)
            {
                newStack[i] = _stack[i];
            }

            _stack = newStack;
        }

        public void Add(T i)
        {
            Push(i);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
