using System;
using System.Collections.Generic;
using System.Linq;

namespace UndirectedGraphs
{
    public class WeightedGraph
    {
        public WeightedGraph()
        {
            _nodes = new Dictionary<string, Node>();
            //  'A' -> 'B' - > { from, to,  6}
            //  'B' -> 'A' - > { A, B,  6}
            //
        }

        private class Edge
        {
            private Node _from;
            private Node _to;
            public int Weight;

            public Edge(Node from, Node to, int weight)
            {
                _from = from;
                _to = to;
                Weight = weight;
            }

            public override string ToString()
            {
                return $"{_from} -> {_to}";
            }

            public Node GetToNode()
            {
                return _to;
            }

            public Node GetFromNode()
            {
                return _from;
            }
        }

        private class Node
        {
            private readonly string _label;
            private Dictionary<Node, Edge> _edges = new Dictionary<Node, Edge>();
            public Node(string label)
            {
                _label = label;
            }

            public override string ToString()
            {
                return _label;
            }

            public void AddEdge(Node to, int weight)
            {
                _edges[to] = new Edge(this, to, weight);
            }

            public Dictionary<Node, Edge>.ValueCollection GetEdges()
            {
                return _edges.Values;
            }
        }

        private Dictionary<string, Node> _nodes;
        private Dictionary<string, NodeEntry> _nodeEntries;



        public void AddNode(string label)
        {
            _nodes[label] = new Node(label);

        }

        public void AddEdge(string from, string to, int weight)
        {
            if (!_nodes.ContainsKey(from) || !_nodes.ContainsKey(to)) return;

            if (!(_nodes.ContainsKey(from) || _nodes.ContainsKey(to)))
                throw new Exception("Illegal argument exception");

            var fromNode = _nodes[from];
            var toNode = _nodes[to];
            fromNode.AddEdge(toNode, weight);
            toNode.AddEdge(fromNode, weight);
        }

        public void Print()
        {
            foreach (var node in _nodes.Values)
            {
                var targets = node.GetEdges();
                foreach (var target in targets)
                {
                    Console.WriteLine(node + "is connected with" + target);
                }
            }
        }

        private class NodeEntry
        {
            public Node node;
            public int priority;

            public NodeEntry(Node node, int priority)
            {
                this.priority = priority;
                this.node = node;
            }
        }

        public class Path
        {
            public List<string> Nodes { get; } = new();
            public int distance;
        }

        public Path FindShortestPath(string from, string to)
        {
            var map = new Dictionary<Node, Node>();
            var visited = new HashSet<Node>();
            if (!_nodes.ContainsKey(from) || !_nodes.ContainsKey(to))
                throw new Exception("There is no distances as mentioned");

            var toNode = _nodes[to];
            var fromNode = _nodes[from];
            var distances = _nodes.Values.ToDictionary(node => node, _ => int.MaxValue);
            distances[fromNode] = 0;

            var startedNodeEntry = new NodeEntry(fromNode, 0);
            var queue = new PriorityQueue<NodeEntry, int>();
            queue.Enqueue(startedNodeEntry, 0);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue().node;
                visited.Add(current);

                foreach (var edge in current.GetEdges())
                {
                    if (visited.Contains(edge.GetToNode()))
                        continue;

                    var newDistance = edge.Weight + distances[current];
                    if (newDistance >= distances[edge.GetToNode()]) continue;

                    distances[edge.GetToNode()] = newDistance;
                    map[edge.GetToNode()] = current;
                    queue.Enqueue(new NodeEntry(edge.GetToNode(), newDistance), newDistance);
                }
            }

            var node = toNode;
            var stack = new Stack<Node>();
            stack.Push(node);
            while (node != fromNode)
            {
                stack.Push(map[node]);
                node = map[node];
            }

            var path = new Path();
            path.distance = distances[toNode];
            while (stack.Count != 0)
            {
                path.Nodes.Add(stack.Pop().ToString());
            }


            return path;
        }

        public bool HasCycle()
        {
            var visited = new HashSet<Node>();
            foreach (var node in _nodes.Values)
            {
                if (!visited.Contains(node))
                    if(HasCycle(node, visited, null)) return true;
            }

            return false;
        }

        private bool HasCycle(Node node, HashSet<Node> visited, Node? parent)
        {
            visited.Add(node);

            foreach (var edge in node.GetEdges().Where(edge => edge.GetToNode() != parent))
            {
                if(visited.Contains(edge.GetToNode()) || HasCycle(edge.GetToNode(), visited, node)) return true;
            }

            return false;
        }

        public WeightedGraph GetMinimumSpanningTree()
        {
            var tree = new WeightedGraph();
            var visited = new HashSet<Node>();

            visited.Add(_nodes.Values.First());
            tree.AddNode(_nodes.Values.First().ToString());
            GetMinimumSpanningTree(tree, visited);

            return tree;
        }

        private WeightedGraph GetMinimumSpanningTree(WeightedGraph tree, HashSet<Node> visited)
        {
            var priorityQueue = new PriorityQueue<Edge, int>();

            foreach (var edge in tree._nodes.Values.SelectMany(node => _nodes[node.ToString()].GetEdges().Where(edge => !visited.Contains(edge.GetToNode()))))
            {
                priorityQueue.Enqueue(edge, edge.Weight);
            }

            if (priorityQueue.Count == 0) return tree;

            var smallestEdge = priorityQueue.Dequeue();
            tree.AddNode(smallestEdge.GetToNode().ToString());
            visited.Add(smallestEdge.GetToNode());
            tree.AddEdge(smallestEdge.GetFromNode().ToString(), smallestEdge.GetToNode().ToString(), smallestEdge.Weight);

            return GetMinimumSpanningTree(tree, visited);
        }
    }
}
