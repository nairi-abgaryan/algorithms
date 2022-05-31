System.Collections.Generic
namespace BinaryTrees
{
    public class PriorityQueues
    {
        private Heap heap;

        public void Enqueue(int x)
        {
           var q =  new Heap();
           heap.Insert(x);
        }

        public int Dequeue()
        {
            return heap.Remove();
        }

         private bool IsEmpty()
         {
             return heap.IsEmpty();
         }
    }
}
