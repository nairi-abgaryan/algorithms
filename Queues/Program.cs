using System;
using System.Collections.Generic;

namespace Queues
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            /*var arrayQueue = new ArrayQueue(4);
            arrayQueue.Enqueue(1);
            arrayQueue.Enqueue(2);
            arrayQueue.Enqueue(3);
            arrayQueue.Enqueue(3);
            arrayQueue.Dequeue();
            arrayQueue.Dequeue();
            arrayQueue.Enqueue(4);
            arrayQueue.Enqueue(5);
            arrayQueue.Enqueue(6);
            arrayQueue.Peek();
            arrayQueue.IsFull();
            arrayQueue.IsEmpty();
            Console.WriteLine(arrayQueue);*/

            /*
            var pq = new PriorityQueue(5);
            pq.Enqueue(2);
            pq.Enqueue(1);
            pq.Enqueue(-1);
            pq.Enqueue(-2);
            pq.Enqueue(-3);
            pq.Dequeue();
            pq.Enqueue(-3);
            pq.Enqueue(-3);*/

            var firstQueue = new Queue<int>();
            firstQueue.Enqueue(1);
            firstQueue.Enqueue(2);
            firstQueue.Enqueue(3);
            firstQueue.Enqueue(4);
            firstQueue.Enqueue(5);
            ReverseQueue(firstQueue, 3);

            var a = new Dictionary<int, int>();
            a.Add(1,2);
            a.Add(2,2);
            var listQueue = new LinkedListQueue(5);
            listQueue.Enqueue(1);
            listQueue.Enqueue(2);
            listQueue.Enqueue(3);
            listQueue.Dequeue();
            listQueue.Dequeue();
            listQueue.Peek();
        }

        private static Queue<int> ReverseQueue(Queue<int> que)
        {
            var stack = new Stack<int>();
            for (int i = 0; i < que.Count; i++)
            {
                stack.Push(que.Dequeue());
            }


            while (stack.Count != 0)
            {
                que.Enqueue(stack.Pop());
            }

            return que;
        }

        private static Queue<int> ReverseQueue(Queue<int> queue, int k)
        {
            var stack = new Stack<int>();
            var secondQueue = new Queue<int>();
            for (var i = 0; i < k; i++)
            {
                stack.Push(queue.Dequeue());
            }

            while (stack.Count != 0)
            {
                secondQueue.Enqueue(stack.Pop());
            }

            while (queue.Count != 0)
            {
                secondQueue.Enqueue(queue.Dequeue());
            }

            return secondQueue;
        }
    }
}
