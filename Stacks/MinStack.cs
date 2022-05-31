using System;
using System.Collections;

public class MinStack
{
	private readonly Stack _stack;
	private int _minEle;

	public MinStack()
	{
		_stack = new Stack();
	}

	public int GetMin()
	{
		if (_stack.Count==0) throw new Exception("Empty Stack");


		return _minEle;
	}

	public void Peek()
	{
		if (_stack.Count==0)
		{
			Console.WriteLine("Stack is empty ");
			return;
		}

		var t =(int)_stack.Peek();

		Console.WriteLine(t < _minEle ? _minEle : t);
	}

	/**
	 *  actualValue StackValue minElement
	 *  0            0           0
	 * -1           -3          -1 | currentStackValue = -1*3 - pMinElement(0)
	 *  5            5          -1
	 * -2                       -2 | currentStackValue = -2*3 - -1
	 */
	public void Push(int item)
	{
		Console.WriteLine("Inserted Item: $(1)", item);
		if (_stack.Count == 0)
		{
			_minEle = item;
			_stack.Push(item);
			return;
		}

		if (_minEle < item)
		{
			_stack.Push(item);
			return;
		}

		var changedValue = 3 * item - _minEle;
		_minEle = item;
		_stack.Push(changedValue);
	}

	/**
	 * if (- stackValue < minEle) -> stackPop value is -2 and
	 * getting min element after this min = 3*(currentMinEle)(-2) - -5 = -1
	 */
	public int Pop()
	{
		if (_stack.Count == 0)
		{
			throw new Exception("Empty Stack");
		}

		var currentStackValue = (int)_stack.Pop();

		if (currentStackValue >= _minEle) return currentStackValue;
		_minEle = 3 * _minEle - currentStackValue;

		return currentStackValue;
	}
}
