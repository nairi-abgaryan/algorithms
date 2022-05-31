using System;

#nullable enable
namespace BinaryTrees
{
    internal class AVLNode
    {
        public int value;
        public int height = 0;
        public AVLNode? left;
        public AVLNode? right;

        public AVLNode(int value)
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

    public class AVLTree
    {
        private AVLNode root;
        public void Insert(int item)
        {
            root = Insert(root, item);
        }

        private void InsertImplementedByMe(AVLNode avlNode, int item)
        {
            var node = new AVLNode(item);
            if (root == null)
            {
                return;
            }

            if (avlNode == null)
            {
                return;
            }

            if (avlNode.value > item && avlNode.left == null)
            {
                avlNode.left = node;
                return;
            }

            if (avlNode.value < item && avlNode.right == null)
            {
                avlNode.right = node;
                return;
            }


            InsertImplementedByMe(avlNode.value > item ? avlNode.left : avlNode.right, item);
        }
        private AVLNode Insert(AVLNode root, int item)
        {
            if (root == null)
            {
                return new AVLNode(item);
            }

            if (root.value > item)
            {
                root.left = Insert(root.left, item);
            } else {
                root.right = Insert(root.right, item);
            }

            root = Balance(root);

            return root;
        }

        private AVLNode Balance(AVLNode root)
        {
            SetHeight(root);
            var balanceFactor = Height(root.left) - Height(root.right);
            if (balanceFactor > 1)
            {
                Console.WriteLine($"{root} is left heavy");
                if (BalanceFactor(root.left) > 0)
                {
                    Console.WriteLine($"RightRotate({root.right})");
                    root.left = LeftRotate(root.left);
                }

                RightRotate(root);
                Console.WriteLine($"RightRotate({root})");
            } else if (balanceFactor < -1) { //right heavy
                if (BalanceFactor(root.right) > 0)
                {
                    Console.WriteLine($"RightRotate({root.right})");
                    root.right = RightRotate(root.right);
                }

                root = LeftRotate(root);
                Console.WriteLine($"LeftRotate({root})");
            }

            return root;
        }

        private AVLNode LeftRotate(AVLNode root)
        {
            var newRoot = root.right;
            root.right = newRoot.left;
            newRoot.left = root;
            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }


        private AVLNode RightRotate(AVLNode root)
        {
            var newRoot = root.left;
            root.left = newRoot.right;
            newRoot.right = root;
            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }

        private void SetHeight(AVLNode root)
        {
            root.height = 1+ Math.Max(Height(root.left), Height(root.left));
        }


        private int Height(AVLNode? node)
        {
            return node?.height ?? -1;
        }

        private int BalanceFactor(AVLNode root)
        {
            return Height(root.left) - Height(root.right);
        }

        private static bool IsLeaf(AVLNode node)
        {
            return node.left == null && node.right == null;
        }
    }
}
