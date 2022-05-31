using System;
using System.Collections.Generic;

namespace Graph
{
    public class WeightedGraph
    {
        private class Edge
        {
            private Node _from;
            private Node _to;
            private int _weight;

            public Edge(Node from, Node to, int weight)
            {
                _from = from;
                _to = to;
                _weight = weight;
            }

            public override string ToString()
            {
                return $"{_from} -> {_to}";
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

        public WeightedGraph()
        {
            _nodes = new Dictionary<string, Node>();
                                  //  'A' -> 'B' - > { from, to,  6}
                                  //  'B' -> 'A' - > { A, B,  6}
                                  //
        }


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

        public int FindShortestPath()
        {
            return 0;
        }
    }
}
