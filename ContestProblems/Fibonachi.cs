namespace ContestProblems
{
    public class Fibonachi
    {
        public int FibClassic(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            return FibClassic(n - 1) + FibClassic(n - 2);
        }

        // dynamic programming solution memoization
        public int Fib(int n) {
            if (n == 0) return 0;

            var a = 0;
            var b = 1;

            for(var i = 2; i < n; i++){
                var c = a + b;
                a = b;
                b = c;
            }

            return a + b;
        }

        public int Fib1(int n) {
            return Fib(n, new int[n+1]);
        }

        private int Fib(int i, int[] memo){
            if(i == 0) return 0;
            if(i == 1) return 1;

            if(memo[i] == 0){
                memo[i] = Fib(i - 1, memo) + Fib(i - 2, memo);
            }

            return memo[i];
        }
    }
}
