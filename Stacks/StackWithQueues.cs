using System;
using System.Collections.Generic;

namespace Stacks
{
    public class StackWithQueue
    {
        private Queue<int> _queue1;
        private Queue<int> _queue2;

        /** Initialize your data structure here. */
        public StackWithQueue() {
            _queue1 = new Queue<int>();
            _queue2 = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x) {
            if(Empty()) {
                _queue1.Enqueue(x);
                return;
            }

            while(_queue1.Count != 0){
                _queue2.Enqueue(_queue1.Dequeue());
            }

            _queue1.Enqueue(x);

            while(_queue2.Count != 0){
                _queue1.Enqueue(_queue2.Dequeue());
            }
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop() {
            if(Empty()) {
                throw new Exception("Stack is empty");
            }

            return _queue1.Dequeue();
        }

        /** Get the top element. */
        public int Top() {
            if(Empty()) throw new Exception("Stack is empty");

            return _queue1.Peek();
        }

        /** Returns whether the stack is empty. */
        public bool Empty() {
            return _queue1.Count == 0;
        }
    }
}
