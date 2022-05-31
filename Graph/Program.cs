using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var graph = new Graph();
            graph.AddNode("John");
            graph.AddNode("Alice");
            graph.AddNode("Bob");
            graph.AddNode("Mary");

            graph.AddEdge("John", "Mary");
            graph.AddEdge("John", "Alice");
            graph.AddEdge("Bob", "Alice");
            graph.AddEdge("John", "Bob");
            graph.AddEdge("Bob", "Mary");
            graph.TraverseDepthFirstIterative("John");
            graph.BreadthFirst("John");

            graph.RemoveEdge("John", "Mary");
            graph.RemoveEdge("John", "Mary");
                        graph.RemoveNode("John");
            */

            /*
            var graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddEdge("A", "B");
            graph.AddEdge("C", "A");
            graph.AddEdge("B", "C");
            graph.AddEdge("D", "A");*/

            //Console.WriteLine(graph.HasCycle());

            var graph = new WeightedGraph();

            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddEdge("A", "B", 2);
            graph.AddEdge("A", "C", 3);
            graph.Print();
        }


    }
}
