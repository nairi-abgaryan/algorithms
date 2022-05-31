/*
namespace BinaryTrees
{
    public class ReverseInt
    {


        public static int Reverse(int x) {
            var isNegative =  1;
            if (x < 0) {
                isNegative = -1;
                x = x * -1;
            }

            var k = 0;
            while(x >= 10){
                k = k * 10 + x%10;
                x = (int) Math.Truncate((double) x / 10);
            }

            var res = isNegative * ((long)k * 10 + x);
            if (res < Int32.MinValue  || res > Int32.MaxValue) return 0;

            return (int)res;
        }

        public static int ReverseStringBuilder(int x) {
            if (x < 10 && x > -10) return x;
            if (x == Int32.MaxValue || x == Int32.MinValue) return 0;

            var isNegative =  1;
            if (x < 0) {
                isNegative = -1;
                x = x * -1;
            }

            var sb = new StringBuilder();
            while(x >= 10){
                sb.Append(x%10);
                x = (int) Math.Truncate((double) x / 10);
            }

            var res = isNegative * ((long)int.Parse(sb.ToString()) * 10 + x);
            if (res < Int32.MinValue  || res > Int32.MaxValue) return 0;

            return (int)res;
        }
    }
}
*/
