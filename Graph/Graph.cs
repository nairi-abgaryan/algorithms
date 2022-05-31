using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class Graph
    {
        private class Node
        {
            private string _label;

            public Node(string label)
            {
                _label = label;
            }

            public override string ToString()
            {
                return _label;
            }
        }

        private Dictionary<string, Node> nodes;
        private Dictionary<Node, LinkedList<Node>> edges;

        public Graph()
        {
            nodes = new Dictionary<string, Node>();
            edges = new Dictionary<Node, LinkedList<Node>>();
        }


        public void AddNode(string label)
        {
            nodes[label] = new Node(label);
        }

        public void RemoveNode(string label)
        {
            var node = nodes[label];
            if(node == null) return;

            foreach (var edge in edges)
                edge.Value.Remove(node);

            edges.Remove(node);
            nodes.Remove(label);
        }

        public void AddEdge(string from, string to)
        {
            if (!nodes.ContainsKey(from) || !nodes.ContainsKey(to)) return;

            var fromNode = nodes[from];
            var toNode = nodes[to];

            if (!edges.ContainsKey(fromNode))
                edges[fromNode] = new LinkedList<Node>();

            var relation = edges[fromNode].Find(toNode);
            if (relation == null)
                edges[fromNode].AddLast(toNode);

        }

        public void RemoveEdge(string from, string to)
        {
            var fromNode = nodes[from];
            var toNode = nodes[to];
            var index = fromNode;
            if (!edges.ContainsKey(index)) return;

            var relation = edges[fromNode].Find(toNode);
            if (relation == null)
                return;

            edges[index].Remove(toNode);
        }

         public void TraverseDepthFirst(string root)
         {
            TraverseDepthFirst(nodes[root], new HashSet<string>());
         }

         private void TraverseDepthFirst(Node root, ISet<string> visited)
         {
             Console.WriteLine(root);
             visited.Add(root.ToString());

             if (!edges.ContainsKey(root))
                 return;

             foreach (var node in edges[root].Where(node => !visited.Contains(node.ToString())))
             {
                 TraverseDepthFirst(node, visited);
             }
         }

         public void TraverseDepthFirstIterative(string root)
         {
             var stack = new Stack<Node>();
             var visited = new HashSet<Node>();
             var current = nodes[root];
             stack.Push(current);
             while (stack.Count != 0)
             {
                 current = stack.Pop();
                 Console.WriteLine(current);
                 if (!edges.ContainsKey(current))
                     continue;

                 var currentEdges = edges[current];
                 foreach (var node in currentEdges.Where(node => !visited.Contains(node)))
                 {
                     stack.Push(node);
                     visited.Add(node);
                 }

             }
         }

         public void  BreadthFirst(string root)
         {
             var queue = new Queue<Node>();
             var visited = new HashSet<Node>();
             var current = nodes[root];
             queue.Enqueue(current);
             while (queue.Count != 0)
             {
                 current = queue.Dequeue();
                 Console.WriteLine(current);
                 if (!edges.ContainsKey(current))
                     continue;

                 var currentEdges = edges[current];
                 foreach (var node in currentEdges.Where(node => !visited.Contains(node)))
                 {
                     queue.Enqueue(node);
                     visited.Add(node);
                 }
             }
         }

         public List<string> TopologicalSort()
         {
             var hashSet = new HashSet<Node>();
             var stack = new Stack<Node>();
             foreach (var node in nodes.Values)
             {
                 TopologicalSort(node, hashSet, stack);
             }

             Console.WriteLine(stack);
             var list = new List<string>();
             while (stack.Count != 0)
             {
                 list.Add(stack.Pop().ToString());
             }

             return list;
         }

         private void  TopologicalSort(Node root, HashSet<Node> visited, Stack<Node> stack)
         {
             if (visited.Contains(root))
                 return;

             visited.Add(root);

             foreach (var node in edges[root])
             {
                TopologicalSort(node, visited, stack);
             }

             stack.Push(root);
         }

         public bool HasCycle()
         {
             var visited = new HashSet<Node>();
             var visiting = new HashSet<Node>();
             foreach (var node in nodes.Values)
             {
                 if (HasCycle(node, visiting, visited))
                 {
                     return true;
                 }
             }

             return false;

         }

         private bool  HasCycle(Node root, HashSet<Node> visiting, HashSet<Node> visited)
         {
             if (!edges.ContainsKey(root) || visited.Contains(root))
                 return false;

             if (visiting.Contains(root))
                 return true;

             visiting.Add(root);
             if (edges[root].Any(node => HasCycle(node, visiting, visited)))
             {
                 return true;
             }

             visited.Add(root);
             visiting.Remove(root);

             return false;
         }
    }
}
