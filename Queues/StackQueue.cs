using System;
using System.Collections.Generic;

namespace Queues
{
    public class StackQueue
    {
        private readonly Stack<int> _stack;
        private readonly Stack<int> _stack1;

        /** Initialize your data structure here. */
        public StackQueue() {
            _stack = new Stack<int>();
            _stack1 = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Enqueue(int x) {
            _stack.Push(x);

        }

        /** Removes the element from in front of queue and returns that element. */
        public int Dequeue() {
            if(Empty())
                throw new Exception("Stack is empty");


            if (_stack1.Count != 0) return _stack1.Pop();
            while (_stack.Count != 0){
                _stack1.Push(_stack.Pop());
            }

            return _stack1.Pop();
        }

        /** Get the front element. */
        public int Peek() {
            if(Empty())
                throw new Exception("Stack is empty");


            if (_stack1.Count != 0) return _stack1.Peek();
            while (_stack.Count != 0){
                _stack1.Push(_stack.Pop());
            }

            return _stack1.Peek();
        }

        /** Returns whether the queue is empty. */
        private bool Empty() {
            return _stack1.Count == 0 && _stack.Count == 0;
        }
    }
}
