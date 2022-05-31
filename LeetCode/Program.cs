// See https://aka.ms/new-console-template for more information


namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var periods = new DescentPeriods();
            Console.Write(periods.GetDescentPeriods(new []{8,6,7,7}));
        }
    }
}
