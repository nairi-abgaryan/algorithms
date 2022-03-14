// <a href = 'https://leetcode.com/problems/all-divisions-with-the-highest-score-of-a-binary-array/'>All Divisions With the Highest Score of a Binary Array</a>

using System.Collections.Generic;

namespace Algorithms
{
    public class MaxScore
    {
        public IList<int> MaxScoreIndices(int[] nums) {
            var count = new int[nums.Length+1];
            var onesCount = 0;

            // Counting the one's
            foreach(var num in nums)
                if(num == 1) onesCount++;

            // assigning the 0 index to onesCount because when starting the we have the higest score for one's // left = 0
            count[0] = onesCount;
            var zeroCount = 0;
            for(var i = 0; i < nums.Length; i++){
                // we need to increase the zeros count because we are going left to right
                if(nums[i] == 0)
                    zeroCount+=1;

                // we need to Decrease the ones count because we are going left to right
                if(nums[i] == 1 && onesCount != 0)
                    onesCount-=1;

                // assignment for each iteration
                count[i+1] = onesCount + zeroCount;
            }


            // the below code just finding the higest and adding it to the array list
            var higest = 0;
            foreach(var num in count)
                if(num > higest)
                    higest =  num;

            var result = new List<int>();
            for(var i = 0; i < count.Length; i++)
                if(count[i] == higest)
                    result.Add(i);


            return result;
        }
    }
}
