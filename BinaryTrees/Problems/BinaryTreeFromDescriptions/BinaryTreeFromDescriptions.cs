using System.Collections.Generic;

/**
 * Definition for a binary tree node.
 */
public class TreeNode {
    public int val;
    public TreeNode left;
     public TreeNode right;
     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
             this.val = val;
             this.left = left;
             this.right = right;
     }
}

public class Solution {
    public TreeNode CreateBinaryTree(int[][] descriptions) {
        var dictionary = new Dictionary<int, TreeNode>();
        var childrenSet = new HashSet<int>();

        foreach (var current in descriptions)
        {
            var node = GetOrDefault(dictionary, current[0]);
            if(current[2] == 1) {
                node.left = GetOrDefault(dictionary, current[1]);
                dictionary[current[1]] = node.left;
                childrenSet.Add(current[1]);
            }

            if(current[2] == 0) {
                node.right = GetOrDefault(dictionary, current[1]);
                dictionary[current[1]] = node.right;
                childrenSet.Add(current[1]);
            }

            dictionary[current[0]] = node;
        }

        var root = new TreeNode();
        foreach(var d in descriptions){
            if(childrenSet.Contains(d[0])) continue;

            root = dictionary[d[0]];
        }

        return root;
    }

    private static TreeNode GetOrDefault(IReadOnlyDictionary<int, TreeNode> dic, int val)
    {
        return dic.ContainsKey(val) ? dic[val] : new TreeNode(val);
    }
}
