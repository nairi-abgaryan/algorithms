using System.Collections.Generic;

namespace Algorithms
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // insert
            // find by index
            // delete removeAt
            // indexOf(100)
            // Testing Array List
            var arrList = new ArrayList();
            arrList.Insert(1);
            arrList.Insert(2);
            arrList.IndexOf(2);
            arrList.IndexOf(2);


            // Solution for the problem MaxScore
            var numbers = new int[] { 0, 0, 1, 0 };
            var maxScore = new MaxScore();
            var arr = maxScore.MaxScoreIndices(numbers);

        }
    }
}
