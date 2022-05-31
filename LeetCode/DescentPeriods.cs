namespace LeetCode;

public class DescentPeriods
{
     public long GetDescentPeriods(int[] prices) {
        // start point first to third
        // if third minus fourth is not equal to 1 then save first to third then start from
        // forth, and repeat the cycles.
        // hash map
        // key start point
        // value end point
        // 1 -> 3
        // 4 -> null
        // 5 -> null
        // 6 -> null
        // 7 -> 10

        // print posibilities how to print values.
        // All posible values High to low
        // first 1, 2, 3, 4
        // second 1, 2, 3
        // third 1, 2
        // fourth 2, 3, 4
        // 2, 3
        // 2
        // 3, 4


        // arr = 3, 2, 1, 4
        var start = 0;
        var next = 0;
        var dictionary = new Dictionary<int, int>();
        dictionary[next] = 0;
        for(start = 0; next <= prices.Length - 2; next++){
            if (prices.Length == 1)
            {
                dictionary[next] = next;
                break;
            }

            if(prices[next] - prices[next+1] == 1) {
                dictionary[start] = next+1;
            } else {
                dictionary[next+1] = next+1;
                if (start == prices.Length - 1) break;
            }
        }

        var count = 0;

        foreach (var el in dictionary){
            if(el.Key == 0 && el.Value > 0){
                count += Sum(el.Value + 1);
                continue;
            }

            count+=Sum(el.Value - el.Key);
        }

        return count;
     }

    private int Sum(int n){
        if(n <= 1) return 1;

        return n + Sum(n-1);
    }
}
