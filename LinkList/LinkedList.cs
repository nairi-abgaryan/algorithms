using System;
using System.Collections.Generic;

namespace LinkList
{
    internal class Node
    {
        public int Value { get; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }

    class LinkedList
    {
        private Node _head;
        private Node _tail;
        public int Count;

        public void AddLast(int value)
        {
            var n = new LinkedList<Node>();
            var node = new Node(value);
            Count++;
            if (_head == null)
            {
                _head = _tail = node;
                return;
            }

            _tail.Next = node;
            _tail = node;
        }

        public void AddFirst(int value)
        {
            Count++;
            var newNode = new Node(value);

            if (_head == null)
            {
                _head = _tail = newNode;
                return;
            }

            newNode.Next = _head;
            _head = newNode;
        }

        public void DeleteFirst()
        {
            if (_head == null)
                return;

            Count--;
            var temp = _head;
            _head = temp.Next;
            temp.Next = null;
        }

        public void DeleteLast()
        {
            if (_tail == _head)
            {
                 _tail = _head = null;
                 return;
            }

            Count--;
            var previous = GetPrevious();
            _tail = previous;
            _tail.Next = null;
        }

        private Node GetPrevious()
        {
            var current = _head;
            while (current != null)
            {
                if (current.Next == _tail) return current;
                current = current.Next;
            }

            return null;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(int element)
        {
            if (_head == null)
                return -1;

            var index = 0;
            var temp = _head;

            while (temp != null)
            {
                if (temp.Value == element)
                {
                    return index;
                }

                temp = temp.Next;
                index++;
            }

            return -1;
        }

        public Array ToArray()
        {
            var array = new Array(Count);
            var temp = _head;

            while (temp != null)
            {
                array.Insert(temp.Value);
                temp = temp.Next;
            }

            return array;
        }

        private bool IsEmpty()
        {
            return _tail == null;
        }

        public void Reverse()
        {
            if (IsEmpty()) return;

            var first = _head;
            var second = _head.Next;

            while (second != null)
            {
                var temp = second;
                second = second.Next;
                temp.Next = first;
                first = temp;
            }

            _tail = _head;
            _tail.Next = null;
            _head = first;
        }

        public Node FindKthElementFromTheEnt(int k)
        {
            if (IsEmpty()) return null;

            var distance = k - 1;
            var firstPointer = _head;
            var secondPointer = _head;
            var i = 0;
            while (i != distance)
            {
                if (secondPointer != null)
                {
                    secondPointer = secondPointer.Next;
                    ++i;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            while (secondPointer.Next != null)
            {
                firstPointer = firstPointer.Next;
                secondPointer = secondPointer.Next;
            }

            return firstPointer;
        }

        public IEnumerable<Node> FindMiddleNodes()
        {
            var firstPoint = _head;
            var secondPoint = _head;
            while (secondPoint != _tail && secondPoint.Next != _tail)
            {
                firstPoint = firstPoint.Next;
                secondPoint = secondPoint.Next.Next;
            }

            return secondPoint == _tail ? new List<Node>() {firstPoint, firstPoint.Next} : new List<Node>(){firstPoint};
        }


        public void CreateLoop()
        {
            _tail.Next = _head.Next;
        }

        public bool HasLoop()
        {
            if (IsEmpty()) return false;
            var fast = _head.Next;
            var slow = _head;
            while (fast.Next != null && slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return slow == fast;
        }
    }
}
