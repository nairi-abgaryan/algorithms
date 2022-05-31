using System.Collections.Generic;

namespace Stacks
{
    internal static class Expression
    {
        public static bool IsBalanced(string str)
        {
            var map = new Dictionary<char, char> {{')', '('}, {'}', '{'}, {'>', '<'}};
            var stack = new Stack<char>();

            foreach (var c in str)
            {
                if (map.ContainsValue(c)) stack.Push(c);

                if ((map.ContainsKey(c) && stack.Count == 0 && map.ContainsKey(c) && map[c] != stack.Pop()))
                    return false;
            }

            return stack.Count == 0;
        }
    }
}

