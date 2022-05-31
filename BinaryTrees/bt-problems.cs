using System;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public partial class Solution
{
    private TreeNode root;
    public TreeNode DevareNode(TreeNode root, int key)
    {
        if(root == null) return null;
        var current = root;
        TreeNode prev = null;
        // find the node
        while(current != null){
            if(key == current.val)  break;

            prev = current;
            if(key < current.val) {
                current = current.left;
                continue;
            }
            if(key > current.val) current = current.right;
        }

        if(current == null) return root;
        if(root.left == null && root.right == null) return null;

        var node = current;
        if(node.right == null)
        {
            transplant(root, prev, node, node.left);

            return root;
        }

        if(node.left == null)
        {
            transplant(root, prev, node, node.right);

            return root;
        }

        var successor = GetSuccessor(root, node);
        transplant(root, prev, current, successor);
        Console.Write(root);
        successor.left = current.left;
        if(prev == null)
        {
            return successor;
        }

        return root;
    }

    private TreeNode GetSuccessor(TreeNode root, TreeNode node){
        var current = root;
        TreeNode result = null;
        while(current != null){
            if(current.val <= node.val){
                current = current.right;
            } else {
                result = current;
                current = current.left;
            }
        }

        return result;
    }


    private void transplant(TreeNode root, TreeNode parent, TreeNode u, TreeNode v){

        if(parent.left == u){
            parent.left = v;
        }

        if(parent.right == u){
            parent.right = v;
        }
    }
}
