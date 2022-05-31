using System;

namespace LinkList
{
    partial class LinkedListV1
    {
        internal class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }

            public Node(int value)
            {
                Value = value;
            }
        }

        private Node First { get; set; }
        private Node Last { get; set; }

        private int Count { get; set; }

        public LinkedListV1()
        {
            Count = 0;
        }

        public void AddFirst(int item)
        {
            var node = new Node(item);

            if (IsEmpty())
            {
                First = node;
                Last = node;
            }
            else
            {
                node.Next = First;
                First = node;
            }

            Count++;
        }

        public int IndexOf(int item)
        {
            var index = 0;
            var current = First;
            while (current != null)
            {
                if (current.Value == item)
                {
                    return index;
                }

                current = current.Next;
                index++;
            }

            return -1;
        }

        public void AddLast(int item)
        {
            var node = new Node(item);

            if (IsEmpty())
                First = Last = node;
            else
            {
                Last.Next = node;
                Last = node;
            }

            Count++;
        }

        public void DeleteFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Linked list os empty");
            }

            if (First == Last)
                First = Last = null;
            else
            {
                var second = First.Next;
                First.Next = null;
                First = second;
            }

            Count--;
        }

        public void DeleteLast()
        {
            if (IsEmpty())
            {
                throw new ArgumentNullException();
            }

            if (First == Last)
                First = Last = null;
            else
            {
                var previous = GetPrevious(Last);
                Last = previous;
                Last.Next = null;
            }

            Count--;
        }

        public bool Contains(int item)
        {
            return IndexOf(item) != -1;
        }

        public int[] ToArray()
        {
            var array = new int[Count];
            var current = First;
            var index = 0;
            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }

            return array;
        }

        public void Print()
        {
            var current = First;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }

        public LinkedListV1 Reverse()
        {
            if (Count == 0)
                return this;

            var current = First;
            var notChangedFirst = First;
            Node prev = null;
            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            First = Last;
            Last = notChangedFirst;

            return this;
        }

        public int Size()
        {
            return Count;
        }

        public Node GetKthFromTheEnd(int k)
        {
            if (IsEmpty())
                throw new Exception("Empty List");

            if (k <= 0)
                throw  new ArgumentOutOfRangeException();

            var first = First;
            var current = First;
            var i = 0;
            while (!i.Equals(k-1))
            {
                if (current == null)
                    throw new ArgumentOutOfRangeException();
                current = current.Next;
                i++;
            }

            var second = current;
            while (second != Last)
            {
                first = first.Next;
                second = second.Next;
            }

            return first;
        }

        private bool IsEmpty()
        {
            return First == null;
        }

        private Node GetPrevious(Node node)
        {
            var current = First;
            while (current != null)
            {
                if (current.Next == node) return current;
                current = current.Next;
            }

            return null;
        }
    }
}
