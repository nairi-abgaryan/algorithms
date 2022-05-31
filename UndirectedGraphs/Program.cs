// See https://aka.ms/new-console-template for more information

using System;
using System.Text;

namespace UndirectedGraphs
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new WeightedGraph();
            var a = solution("The quick brown fox jumps over the lazy dog", 39);


            Console.Write(a);
        }

        public static string solution(string message, int K) {
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
                    continue;
                }
                break;
            }

            return sb.ToString();
        }
    }
}
