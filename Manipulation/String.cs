using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manipulation
{
    public static class StringUtils
    {
        public static int VowelsCount(string str)
        {
            if (str == null) return 0;
            var vowels = new HashSet<char>() { 'a', 'i', 'o', 'e', 'u'};

            return str.ToLower().Count(ch => vowels.Contains(ch));
        }

        public static string? Reverse(string str)
        {
            if (str == null) return null;
            var sb = new StringBuilder();
            for (var i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }

            return sb.ToString();
        }

        public static string? ReverseWords(string str)
        {
            if (str == null) return null;
            var arr = str.Trim().Split(' ');

            return string.Join(" ", arr.Reverse());
        }

        public static string? ReverseWordsIteration(string str)
        {
            if (str == null) return null;

            var sb = new StringBuilder();
            var arr = str.Split(' ');
            for (var i = arr.Length - 1; i >= 0; i--)
            {
                sb.Append(arr[i] + ' ');
            }

            return sb.ToString().Trim();
        }

        public static bool CheckRotation(string str1, string str2)
        {
            return (str1.Length != str2.Length && (str1 + str1).Contains(str2));
        }

        public static string RemoveDuplicates(string str)
        {
            var hashSet = new HashSet<char>();
            var sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (hashSet.Contains(str[i])) continue;
                hashSet.Add(str[i]);
                sb.Append(str[i]);
            }

            return sb.ToString();
        }

        public static char FindTheMostRepeatedChar(string str)
        {
            var hashMap = new Dictionary<char, int>();
            foreach (var t in str)
            {
                if (hashMap.ContainsKey(t))
                {
                    hashMap[t]++;
                    continue;
                }

                hashMap[t] = 1;
            }

            var maxValue = -1;
            var max = '\0';
           foreach (var (key, value) in hashMap.Where(keyValue => keyValue.Value > maxValue))
           {
               max = key;
               maxValue = value;
           }

           return max;
        }

        public static string Capitalize(string str)
        {
            var splitWords = str.Split(' ');
            var sb = new StringBuilder();
            foreach (var word in splitWords)
            {
                if (word.Length <= 0) continue;

                sb.Append(word.Substring(0, 1).ToUpper());
                sb.Append(word[1..].ToLower().Trim() + ' ');
            }

            return sb.ToString();
        }

        public static bool IsAnagram(string s, string t) {
            if(s.Length != t.Length) return false;
            var alphabet = new int[26];

            foreach(char ch in s)
                alphabet[ch - 'a']++;


            foreach(var ch in t)
            {
                if (alphabet[ch - 'a'] == 0) return false;
                alphabet[ch - 'a']--;
            }

            return true;
        }

        public static bool IsPalidrome(string s)
        {
            if (s == null) return false;
            var left = 0;
            var right = s.Length - 1;
            while (left < right)
                if (s[left++] != s[right--]) return false;


            return true;
        }

        public static string URLify(string s)
        {
            var url = new StringBuilder(s.Length - 1);
            for (var index = 0; index < s.Length -  1; index++)
            {
                var t = s[index];
                if (t == ' ')
                    url.Append("%20");
                else
                    url.Append(t);
            }

            return url.ToString();
        }

        public static bool IsPermutationPalindrome(string s)
        {
            var strValues = s.Split(' ');

            return strValues.All(IsPalidrome);
        }

        public static bool OneAwayEdits(string str1, string str2)
        {
            // Given two string check if they one edit away. (edit = replace, delete, add)
            if (str1.Length < str2.Length)
                (str2, str1) = (str1, str2);

            var diff = str1.Length - str2.Length;
            if (diff > 1) return false;

            var alphabet = new int[26];
            foreach (var ch in str1)
                alphabet[ch - 'a']++;

            foreach (var ch in str2)
            {
                if (alphabet[ch - 'a'] == 0)
                {
                    diff++;
                    continue;
                }

                alphabet[ch - 'a']--;
            }


            return diff <= 1;
        }

        public static string Compress(string str)
        {
            if (str.Length <= 2) return str;

            var sb = new StringBuilder();
            var current = str[0];
            var count = 1;
            foreach (var ch in str)
            {
                if (current == ch)
                {
                    count++;
                    continue;
                }

                sb.Append(current);
                sb.Append(count);
                current = ch;
                count = 1;
            }

            sb.Append(current);
            sb.Append(count);

            return sb.ToString().Length > str.Length ? str : sb.ToString();
        }

        public static bool IsSubString(string s1, string s2)
        {
            return (s2 + s2).Contains(s1);
        }

        public static bool CheckInclusion(string s1, string s2) {
            if(s1.Length > s2.Length) return false;

            var length = s1.Length;
            for(var i = 0; length <= s2.Length; i++){
                var k = i;
                var sb = new StringBuilder();
                while(k != length){
                    sb.Append(s2[k]);
                    k++;
                }

                if(Anagram(sb.ToString(), s1)) return true;
                length+=1;
            }


            return false;
        }

        private static bool Anagram(string s1, string s2) {
            // a, b, c, d, e, k
            // 0, 0, 0, 1, 1, 0

            // d, e
            if(s1.Length != s2.Length) return false;
            var count = new int[26];
            foreach (char ch in s1)
                count[ch - 'a']++;

            var counter = s1.Length;
            foreach(char ch in s2){
                if(count[ch - 'a'] != 0){
                    counter--;
                    continue;
                }
            }

            return counter == 0;
        }
    }
}
