namespace Search
{
    public class LinerSearch
    {
        public int? Search(int[] arr, int target)
        {
            foreach (var i in arr)
            {
                if (i == target) return target;
            }

            return null;
        }
    }
}
