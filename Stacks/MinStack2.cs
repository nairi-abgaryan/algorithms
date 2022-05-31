using System;
using Stacks;

public class MinStack2 {
    private int s;
    private int min;
    private Stack<int> stack;

    /** initialize your data structure here. */
    public MinStack2() {
        stack = new Stack<int>();
        s = 0;
    }
    public void Push(int val) {
        if(stack.Count == 0){
            s = val;
            min = val;
        }
        else if(val <= min){
            min = val;
            s+= min;
        }

        stack.Push(val + s);
    }

    public void Pop() {
        if(stack.Count == 0) throw new Exception("empty stack");
        var value = stack.Pop() - s;
        if (value != min) return;

        s -= min;
        min = stack.Peek() - s;
    }

    public int Top() {
        if(stack.Count == 0) throw new Exception("empty stack");
        return stack.Peek() - s;
    }

    public int GetMin() {
        if(stack.Count == 0) throw new Exception("empty stack");
        return min;
    }
}
