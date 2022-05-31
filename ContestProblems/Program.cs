using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContestProblems
{
    public class Program
    {
        static void Main()
        {
            var l = "abchekk";
            DivideString(l, 3, 'c');
        }

        public static int MinimumCost(int[] A) {
            Array.Sort(A);
            int res = 0, n = A.Length;
            for (int i = 0; i < n; ++i)
                if (i % 3 != n % 3)
                    res += A[i];
            return res;

        }

        public static int NumberOfArrays(int[] differences, int lower, int upper) {
            var a = 0;
            var max = 0;
            var min = 0;
            foreach(var el in differences){
                a += el;
                max = Math.Max(a, max);
                min = Math.Min(a, min);
            }

            return Math.Max((upper - max - lower - min + 1), 0);
        }

        public static int CountValidWords(string sentence) {
            var words = sentence.Split(' ');
            var count = 0;

            foreach(var word in words){
                if(word.Length == 0) continue;
                if(!char.IsLetter(word[0]) && word.Length != 1) continue;

                var hyphenCount = 0;
                for (var i = 0; i <= word.Length - 1; i++)
                {
                    if(word[i] == '-'
                       && ((i == 0 || i == word.Length - 1 ) || (i != word.Length - 1 && !char.IsLetter(word[i+1]))))break;
                    if(char.IsDigit(word[i]) || (!char.IsLetter(word[i]) && word[i] != '-' && i!= word.Length - 1)) break;
                    if(word[i] == '-') hyphenCount++;
                    if (hyphenCount > 1)
                        break;
                    if (i != word.Length - 1) continue;

                    hyphenCount = 0;
                    count++;
                }
            }

            return count;
        }

        public static int[] FindOriginalArray(int[] changed) {
            if(changed.Length % 2 > 0) return Array.Empty<int>();

            var dictionary = new Dictionary<int, int>();
            foreach(var n in changed){
                if(dictionary.ContainsKey(n)) {
                    dictionary[n]++;
                    continue;
                }

                dictionary[n] = 1;
            }

            var result = new int[changed.Length/2];
            var i = 0;

            foreach(var element in changed){
                if(element%2 != 0) continue;
                var doubled = element/2;
                if(dictionary.ContainsKey(doubled) && dictionary.ContainsKey(element)){
                    dictionary[doubled]--;
                    if(dictionary[doubled] == 0) dictionary.Remove(doubled);

                    dictionary[element]--;
                    result[i++] = element/2;
                    if(dictionary[element] == 0) dictionary.Remove(element);
                }
            }

            return dictionary.Count > 0 ? Array.Empty<int>() : result;
        }

        public static int DetectSquare(string[] operations) {
            var x = 0;
            var hashmap = new Dictionary<string, int>();
            hashmap.Add("X++", +1);
            hashmap.Add("++X", -1);
            foreach(var operation in operations){
                if(hashmap.ContainsKey(operation))
                    x += hashmap[operation];
            }

            return x;
        }

        public static int[][] Construct2DArray(int[] original, int m, int n) {
            if(m == 1 && n == 1) return new int[][]{};
            if(n > original.Length) return new int[][]{};
            int[][] newArr = new int[m][];

            var subArray = new int[n];
            for(var i = 0; i < original.Length; i++){
                if(i%n == 0 && i != 0) {
                    newArr[i/n - 1] = subArray;
                    subArray = new int[n];
                }
                subArray[i%n] = original[i];
            }

            newArr[(original.Length-1) / n] = subArray;

            return newArr;
        }

        public int NumOfPairs(string[] nums, string target) {
            var dictionary = new Dictionary<string, int>();
            foreach(var n in nums){
                if(dictionary.ContainsKey(n)){
                    dictionary[n] += 1;
                    return 1;
                }

                dictionary[n] = 1;
            }

            var result = 0;
            foreach (var n in nums){
                if(target.IndexOf(n) != 0) continue;
                var subStr = n.Substring(n.Length);

                if(dictionary.ContainsKey(subStr)) continue;

                var count = dictionary[subStr];
                if(count == 1 && subStr == n) continue;

                if(subStr == n) count--;

                result+=count;
            }

            return result;
        }

        public static int MinimumMoves(string s) {
            var count = 0;
            var str = "";
            var length = s.Length;
            for(var i = 1; i <= length; i++){
                str+= s[i-1];
                if(i == length) {
                    if(str.Contains("X"))
                        return count+=1;

                    return count;
                }

                if(!(i%3 == 0 && i != 0 && i!= length)){
                    continue;
                }

                if(str == "X0X") {
                    count += 2;
                    str = "";
                    continue;
                }

                if(str == "000") {
                    str = "";
                    continue;
                }

                count+=1;
                str="";
            }

            return count;
        }

        public static string[] DivideString(string s, int k, char fill) {
                var result = new List<string>();
                if(s.Length < k){
                    result.Add(fillWithK(s, k));

                    return result.ToArray();
                }

                if(s.Length == k){
                    result.Add(s);

                    return result.ToArray();
                }

                var loopCount = (int)Math.Ceiling((decimal)(s.Length / k));
                for (var i = 0; i < loopCount; i++)
                {
                    result.Add(s.Substring(i * k, k));
                }



                if (s.Length % k == 0) return result.ToArray();

                var lastStr = s.Substring(s.Length - s.Length % k, s.Length%k);
                result.Add(fillWithK(lastStr, k - (s.Length % k)));

                return result.ToArray();
            }

            private static string fillWithK(string s, int k){
                var stringBuilder = new StringBuilder(s);
                for(var i = 0; i< k; i++){
                    stringBuilder.Append('x');
                }

                return stringBuilder.ToString();
            }
    }

}
