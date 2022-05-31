using System.Collections.Generic;
using System.Text;

namespace Stacks
{
    internal class StringReverser
    {
        public static string Reverse(string str)
        {
            var i = 0;
            var reverserStack = new Stack<char>();
            while (i != str.Length)
            {
                reverserStack.Push(str[i]);
                i++;
            }

            var reversedStr = new StringBuilder();
            while (reverserStack.Count != 0)
            {
                reversedStr.Append(reverserStack.Pop());
            }

            return reversedStr.ToString();
        }
    }
}
