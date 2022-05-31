using System.Collections.Generic;
using System.Linq;
using Queues;

namespace Dictionary
{
    public class Methods
    {
        private class Entry
        {
            public int Key;
            public int Value;

            public Entry(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }


        public static char? NonRepeatedChar(string str)
        {
            var dictionary = new Dictionary<char, bool>();
            foreach (var c in str)
            {
                if (dictionary.ContainsKey(char.ToLower(c)))
                {
                    dictionary[char.ToLower(c)] = true;
                    continue;
                }

                dictionary[c] = false;
            }

            foreach (var character in str.Where(character =>!dictionary[character]))
            {
                return character;
            }

            return null;
        }

        public static char? FirstRepeatedChar(string str)
        {
            var set = new HashSet<int>();
            foreach (var c in str)
            {
                if (!set.Contains(c))
                    return c;

                set.Add(c);
            }

            return null;
        }

        public static IEnumerable<int> TopKFrequent(int[] nums, int k) {
            var dictionary = new Dictionary<int, int>();
            int max = 1;

            foreach (var key in nums)
            {
                if(dictionary.ContainsKey(key)){
                    dictionary[key]++;
                    if(dictionary[key] > max){
                        max = dictionary[key];
                    }
                    continue;
                }

                dictionary[key] = 1;
            }

            var hashMapByCount = new Dictionary<int, LinkedList<Entry>>();
            var priorityQueue = new PriorityQueue(dictionary.Count);
            foreach(var (key, value) in dictionary)
            {
                if (!hashMapByCount.ContainsKey(value))
                    hashMapByCount[value] = new LinkedList<Entry>();

                hashMapByCount[value].AddLast(new Entry(key, value));
                priorityQueue.Enqueue(value);
            }

            var result = new int[k];
            for (var i = 0; i < k; i++)
            {
                result[i] = priorityQueue.Dequeue();
            }

            return result;
        }

        public static int CountPairsWithDiff(int[] nums, int k)
        {
            var map = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (map.ContainsKey(num))
                {
                    map[num]++;
                    continue;
                }

                map[num] = 0;
            }

            if (k == 0)
            {
                var count = 0;
                foreach (var (key, value) in map)
                {
                    if (value > 0)
                    {
                        count++;
                    }
                }

                return count;
            }

            var c = 0;
            foreach (var i in nums)
            {
                var pair = i + k;

                if (map.ContainsKey(pair) && map[i] != -1)
                {
                    c++;
                    map[i] = -1;
                }
            }

            return c;
        }
        public static int CountPairsWithDiffV2(int[] nums, int k)
        {
            var result = 0;
            var ints = new List<int>();

            // For k = 0 you have to just find if there are duplicate for an element and count them only once
            // hence just create dictionary to keep track of the same and increment the result when 2nd
            // element with same value exist.
            if (k == 0) {
                var dictionary = new Dictionary<int,int>();
                foreach (var x in nums) {
                    if (dictionary.Keys.Contains(x)) {
                        dictionary[x]++;
                        if (dictionary[x] == 1) {
                            result++;
                        }
                    } else {
                        dictionary.Add(x,0);
                    }
                }
                return result;
            }

            // Cerate set and detect the pairs in the set by trying to find for each element
            // if there is another one with the difference in the same set.
            var hashSet = new HashSet<int>(nums);
            foreach(var x in hashSet) {
                if(hashSet.Contains(x+k)) {
                    result++;
                }
            }

            return result;
        }
    }
}
