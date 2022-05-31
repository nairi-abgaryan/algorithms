
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinkList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedListV2();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddFirst(8);
            list.AddFirst(9);
            list.DeleteLast();
            list.DeleteFirst();
            Console.Write(list.ToArray().ToString());
            //var kth = list.FindKthElementFromTheEnt(1);

            Console.Write(list.ToString());


            // AddFirst
            // AddLast
            // deleteFirst
            // deleteLast
            // contains
            // indexOf
        }
    }
}
