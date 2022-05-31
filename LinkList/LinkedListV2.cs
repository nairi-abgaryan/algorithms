using System;
using System.Collections.Generic;

namespace LinkList
{
    class LinkedListV2
    {
        private Node first;
        private Node last;
        private int count;

        private class Node
        {
            public int value;
            public Node next;

            public Node(int value)
            {
                this.value = value;
            }
        }

        public void AddFirst(int val)
        {
            count++;
            var node = new Node(val)
            {
                            next = first
            };
            if (first == null)
            {
                 first = last = node;
                 return;
            }

            first = node;
        }

        public void AddLast(int val)
        {
            count++;
            var node = new Node(val);
            if (first == null)
            {
                first = last = node;
                return;
            }

            last.next = node;
            last = node;
        }

        public void DeleteLast()
        {
            if (count == 0)
                return;

            count--;
            var current = first;
            while (current.next != last)
            {
                current = current.next;
            }

            current.next = null;
            last = current;
        }

        public void DeleteFirst()
        {
            if (count == 0)
                return;

            var second = first.next;
            first.next = null;
            first = second;
            count--;
        }

        public bool Contains(int val)
        {
            var current = first;
            while (current != null)
            {
                if (current.value == val) return true;
                current = current.next;
            }

            return false;
        }

        public int IndexOf(int index)
        {
            if (index > count - 1)
                return -1;

            var current = first;
            while (index > 0)
            {
                --index;
                current = current.next;
            }

            return current.value;
        }

        public int[] ToArray()
        {
            var arr = new int[count];
            var current = first;
            var i = 0;
            while (current != null)
            {
                arr[i] = current.value;
                current = current.next;
                i++;
            }

            return arr;
        }

        public void Print()
        {
            var current = first;
            while (current != null)
            {
                Console.WriteLine(current.value);
                current = current.next;
            }
        }

        public void RemoveDuplicates()
        {
            // We need to store node value and count how many duplications do we have there
            // then we can loop over the linked list and remove item if dictionary value is greater then 1
            var hashMap = new Dictionary<int, int>();
            var current = first;
            while (current != null)
            {
                current = current.next;
            }
        }
    }
}
