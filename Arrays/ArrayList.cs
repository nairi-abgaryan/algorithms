using System;

namespace Algorithms
{
    public class ArrayList
    {
        private int[] _items;
        private int _count;

        public ArrayList(int capacity = 10)
        {
            _items = new int[capacity];
            _count = 0;
        }

        public void Insert(int element)
        {
            if (_count < _items.Length)
            {
                _items[_count++] = element;
                return;
            }

            var temArray = new int [_items.Length * 2];
            for (var i = 0; i < _items.Length; i++)
            {
                temArray[i] = _items[i];
            }

            _count++;
            _items = temArray;
        }

        public void RemoveAt(int index)
        {
            if (_count < index || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (var i = index; i < _count; i++)
            {
                _items[i] = _items[i + 1];
            }
        }

        public int IndexOf(int value)
        {
            for (var i = 0; i < _count; i++)
            {
                if (_items[i] == value)
                    return -i;
            }

            return -1;
        }

        public int FindByIndex(int index)
        {
            if (_count < index || index < 0)
            {
                throw new Exception("The element you want to delete out of the array boarder");
            }

            return _items[index];
        }

        public int Length()
        {
            return _items.Length;
        }

        public void Print()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
