
using System;

namespace Manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "The correct answer";
            var methods = StringUtils.CheckInclusion("dca", "ldca");
            Console.WriteLine(methods);
            var oneAway = StringUtils.OneAwayEdits("abac","apa");
            var compress = StringUtils.Compress("abaaaac");
            int[, ] mat = {
                            { 1, 2, 3, 4 },
                            { 5, 6, 0, 8 },
                            { 9, 0, 11, 12 },
                            { 13, 14, 15, 16 }
            };

            var a = new Array();
            a.SetToZero(mat);
        }


    }
}
