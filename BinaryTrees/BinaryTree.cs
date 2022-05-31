using System.Collections.Generic;

namespace BinaryTrees
{
    internal class Node
    {
        public int value;
        public Node? left;
        public Node? right;

        public Node(int value)
        {
            right = null;
            left = null;
            this.value = value;
        }

        public override string ToString()
        {
            return $"Node = {value}";
        }
    }

    public class BinarySearchTree
    {
        private Node root;
        private int count = 0;
        public int min = int.MaxValue;
        public List<int> res = new List<int>();

        public void Insert(int item)
        {
            var node = new Node(item);
            if (root == null)
            {
                root = node;
                return;
            }

            var current = root;
            while (true)
            {
                if (current.value > item)
                {
                    if (current.left == null)
                    {
                        current.left = node;
                        break;
                    }

                    current = current.left;
                }
                else
                {
                    if (current.right == null)
                    {
                        current.right = node;
                        break;
                    }

                    current = current.right;
                }
            }
        }
    }
}
