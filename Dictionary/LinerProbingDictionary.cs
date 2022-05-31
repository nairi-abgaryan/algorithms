#nullable enable
using System;

namespace Dictionary
{
    class LinerProbingDictionary
    {
        private class Entry
        {
            public int Key;
            public string Value;

            public Entry(int key, string value)
            {
                Key = key;
                Value = value;
            }
        }

        private int _capacity;
        private Entry[] _array;
        public LinerProbingDictionary(int capacity)
        {
            _array = new Entry[capacity];
            _capacity = capacity;
        }

        public void Put(int k, string v)
        {
            var index = Hash(k);
            var entry = new Entry(k, v);
            if (_array[index] == default)
            {
                _array[index] = entry;
                return;
            }

            // [10, 20, 2, 0, 1] //1 hash(3)%5 +1
            //              ^
            int nextIndex;
            var startPoint= nextIndex = Hash(k);
            var collisionCount = 0;
            while (collisionCount != _capacity)
            {
                nextIndex = FindNextEmptySlot(++k);
                collisionCount++;
                if (_array[nextIndex] != null) continue;

                _array[nextIndex] = entry;
                return;
            }

            throw new Exception("HashTable is full");
        }

        public string Get(int k)
        {
            var index = Hash(k);
            if (_array[index] == null)
            {
                // find and return entry which key is equals to k
                // another solution is when removing the item change another key
            }

            // if key is not equal to k it means there was an collision
            // so we need to find on this (key%capacity+1)/%_capacity index
            return "";
        }

        public void Remove(int k)
        {
            //Entry class can contain some chain which will indicates that we had collision before and will
            // store indexes in which we stored next item after removing this one we can bring the second
            // entry in which we can add chain values.

        }

        private int Hash(int key)
        {
            return key%_capacity;
        }

        private int FindNextEmptySlot(int key)
        {
            return (key%_capacity + 1)%_capacity;
        }
    }
}
