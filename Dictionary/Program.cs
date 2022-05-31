using System;
namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {

            var a = new int[]{3,1,4,1,5,7,7,7,7,7};

            Methods.CountPairsWithDiff(a, 1);
            var c = Methods.TopKFrequent(a, 1);
            var dictionary = new Dictionary();
            dictionary.Put(1, "string1");
            dictionary.Put(2, "string2");
            dictionary.Put(11, "string11");
            dictionary.Put(22, "string22");
            dictionary.Put(3, "string3");
            dictionary.Get(3);
            dictionary.Get(11);
            dictionary.Remove(22);

            var linerProbingDictionary = new LinerProbingDictionary(4);
            linerProbingDictionary.Put(1, "ds");
            linerProbingDictionary.Put(3, "4");
            linerProbingDictionary.Put(4, "4");
            linerProbingDictionary.Put(7, "daslda");
        }
    }
}
