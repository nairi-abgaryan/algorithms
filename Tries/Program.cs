using System;

namespace Tries
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new Trie();
            trie.Insert("");
            trie.Insert("card");
            trie.Insert("careful");

            trie.Insert("eggs");
            trie.Insert("yes");
            trie.Insert("yesoo");

            var c = trie.ContainsRecursive("car");
            var autoList = trie.FindWords("car");
            var count = trie.CountWords();
            Console.WriteLine( trie.Contains("car"));
            Console.WriteLine( trie.Contains("care"));
            Console.WriteLine( trie.Contains("care"));
        }
    }
}
