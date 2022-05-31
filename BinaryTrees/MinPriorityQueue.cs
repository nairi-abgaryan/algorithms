namespace BinaryTrees
{
    public class MinPriorityQueue
    {
        private MinHeap heap;

        public MinPriorityQueue()
        {
            heap = new MinHeap(10);
        }

        public void Enqueue(int item)
        {
            heap.Insert(item);
        }

        public int Dequeue(int item)
        {
            return heap.Remove();
        }
    }
}
