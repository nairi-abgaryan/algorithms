using System;
using System.Collections.Generic;

namespace ContestProblems
{
    public class DetectSquares {
        private Dictionary<int, List<int>> points;
        private Dictionary<string, int> counts;

        public DetectSquares() {
            points = new Dictionary<int, List<int>>();
            counts = new Dictionary<string, int>();
        }

        public List<int> CheckResult(string[] arr1, int[][] arr2)
        {
            var res = new List<int>();
            for (int i = 1; i < arr2.Length; i++)
            {
                if (arr1[i] == "add")
                {
                    Add(arr2[i]);
                }

                if (arr1[i] == "count")
                {
                    res.Add(Count(arr2[i]));
                }
            }

            return res;
        }

        public void Add(int[] point)
        {
            var x = point[0];
            var y = point[1];
            var pair = $"{x}{y}";
            if (counts.ContainsKey(pair))
                counts[pair]++;
            else
                counts[pair]=1;

            if(!points.ContainsKey(x)){
                points[x] = new List<int>{y};
                return;
            }

            if(!points[x].Contains(y))
                points[x].Add(y);
        }

        private int GetCount(int x, int y){
            var pair = $"{x}{y}";
            return counts.ContainsKey(pair) ? counts[pair] : 1;
        }

        private int IncreaseCount(int x, int y){
            var pair = $"{x}{y}";
            return counts.ContainsKey(pair) ? counts[pair] += 1: counts[pair] = 1;
        }

        private void DecreaseCount(int x, int y){
            var pair = $"{x}{y}";
            if (counts[pair] <= 1)
            {
                counts.Remove(pair);
                return;
            }

            counts[pair]--;
        }

        public int Count(int[] point) {
            var x0 = point[0];
            var y0 = point[1];
            var count = 0;
            if(!points.ContainsKey(x0)) return 0;
            IncreaseCount(x0, y0);
            foreach(var y1 in points[x0]){
                if(y1 == y0) continue;
                var diff = Math.Abs(y1 - y0);
                if(points.ContainsKey(x0 + diff) && points[x0 + diff].Contains(y0) && points[x0 + diff].Contains(y1)){
                    count += GetCount(x0+diff, y0) * GetCount(x0 + diff, y1) * GetCount(x0, y0) * GetCount(x0, y1);
                }

                if(points.ContainsKey(x0 - diff) && points[x0 - diff].Contains(y0) &&  points[x0 - diff].Contains(y1)){
                    count += GetCount(x0-diff, y0) * GetCount(x0 - diff, y1) * GetCount(x0, y0) * GetCount(x0, y1);
                }
            }

            DecreaseCount(x0, y0);
            return count;
        }
    }
}
