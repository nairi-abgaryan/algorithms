using System;

namespace Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            var minStack = new MinStack();
            minStack.Push(-1);
            minStack.Push(-2);
            minStack.Push(-3);
            minStack.Push(10);
            minStack.Push(12);
            minStack.Push(-5);
            Console.WriteLine(minStack.GetMin());
            Console.WriteLine(minStack.Pop());
            Console.WriteLine(minStack.GetMin());
            /*var stack = new Stack<int>{1,2,3};
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(3);
            stack.Push(4);
            stack.Push(3);
            stack.Push(7);
            var last = stack.Pop();
            var preLast = stack.Peek();
            Console.WriteLine(last);
            Console.WriteLine(preLast);
            Console.WriteLine(stack.Count);*/
            /*const string str = "string";
            var stringReverser = new StringReverser();
            var newStr = StringReverser.Reverse(str);
            Console.WriteLine(Expression.IsBalanced(")jdjd>j("));*/

//             /*var twoStacks = new TwoStacks<int>();
//             twoStacks.Push1(1);
//             twoStacks.Push1(2);
//
//             twoStacks.Push2(-1);
//             twoStacks.Push2(-2);
//             twoStacks.Pop1();
//             twoStacks.Pop2();
//             twoStacks.Pop2();
//             twoStacks.Pop2();*/
            /*var minStack = new MinStack2();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            minStack.GetMin(); // return -3
            minStack.Pop();
            minStack.Top();    // return 0
            minStack.GetMin(); */// return -2

            var q = new StackWithQueue();
            q.Push(1);
            q.Push(2);
            q.Pop();
            q.Pop();
            q.Empty();
        }
    }
}
