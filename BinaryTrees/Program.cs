using System;
using System.Text;

namespace BinaryTrees
{
    static class Program
    {
        static void Main(string[] args)
        {
            var heap = new Heap();
            solution("The quick brown fox jumps over the lazy dog", 39);
        }
        public string solution(string message, int K) {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var count = 0;
            var words = message.Split(' ');
            var sb = new StringBuilder();
            foreach(string word in words){
                if(count + word.Length + 1 <= K){
                    if(count == 0){
                        count += word.Length;
                        sb.Append(word);
                        continue;
                    }
                    sb.Append(' ');
                    sb.Append(word);
                    count += word.Length + 1;
                }
                break;
            }

            return sb.ToString();
        }
    }


}
