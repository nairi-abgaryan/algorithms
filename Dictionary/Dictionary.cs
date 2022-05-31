#nullable enable
using System;
using System.Collections.Generic;

namespace Dictionary
{
    class Dictionary
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

        private LinkedList<Entry>?[] _arr;
        private int _capacity;
        public Dictionary()
        {
            _capacity = 10;
            _arr = new LinkedList<Entry>[_capacity];
        }

        public void Put(int k, string v)
        {
            var entry = new Entry(k, v);
            var index = Hash(k);
            if (_arr[index] == null)
            {
                _arr[index] = new LinkedList<Entry>();
            }

            var bucket = _arr[index];
            var matchingEntry = FindEntry(bucket, k);
            if (matchingEntry != null)
            {
                matchingEntry.Value = v;
                return;
            }

            bucket.AddLast(entry);
        }

        public string? Get(int k)
        {
            var index = Hash(k);
            var bucket = _arr[index];
            if (bucket == null) return null;


            if (bucket.Count <= 1)
                return bucket.First.Value.Value;


            var entry = FindEntry(bucket, k);
            if (entry == null)
            {
                throw new Exception("Key is not found");
            }

            return entry.Value;
        }

        public void Remove(int k)
        {
            var index = Hash(k);
            var bucket = _arr[index];
            if (bucket == null)
            {
                throw new Exception("Key is not found");
            }

            if (bucket.Count <= 1)
            {
                _arr[index] = default;
                return;
            }

            var entry = FindEntry(bucket, k);
            if (entry == null)
            {
                throw new Exception("Key is not found");
            }
            bucket.Remove(entry);
        }

        private static Entry? FindEntry(LinkedList<Entry> bucket, int k)
        {
            var startEntry = bucket.First;
            while (startEntry != null)
            {
                if (startEntry.Value.Key == k)
                {
                    return startEntry.Value;
                }

                startEntry = startEntry.Next;
            }

            return null;
        }

        private int Hash(int key)
        {
            return key%_capacity;
        }

        public override string? ToString()
        {
            return _arr.ToString();
        }
    }
}
