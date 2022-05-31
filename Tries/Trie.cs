using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tries
{
    public class Trie
    {
        private class Node
        {
            public char? value;
            public Dictionary<char, Node> children = new Dictionary<char, Node>();
            public bool IsEndOfWord { get; set; }

            public Node(char value)
            {
                this.value = value;
            }

            public bool HasChild(char ch)
            {
                return children.ContainsKey(ch);
            }

            public  void AddChild(char ch)
            {
                 children.Add(ch, new Node(ch));
            }

            public  Node GetChild(char ch)
            {
                return children[ch];
            }

            public Node[] GetChildren()
            {
                return children.Values.ToArray();
            }

            public bool HasChildren()
            {
                return children.Count != 0;
            }

            public bool HasChild()
            {
                return children.Count != 0;
            }


            public void RemoveChild(char ch)
            {
                 children.Remove(ch);
            }

            public override string ToString()
            {
                return "value=" + value;
            }
        }

        private Node root = new Node(' ');

        public void Insert(string word)
        {
            var current = root;
            if (word == "" && !current.HasChild(' '))
                current.AddChild(Convert.ToChar(""));

            foreach (var ch in word.ToCharArray())
            {
                if (!current.HasChild(ch))
                    current.AddChild(ch);
                current = current.GetChild(ch);
            }

            current.IsEndOfWord = true;
        }

        public bool Contains(string word)
        {
            if (word == null)
                return false;

            var current = root;
            foreach (var ch in word.ToCharArray())
            {
                if (!current.HasChild(ch))
                    return false;
                current = current.GetChild(ch);
            }

            return current.IsEndOfWord;
        }

        public bool ContainsRecursive(string word)
        {
            return ContainsRecursive(word, root, 0);
        }

        private bool ContainsRecursive(string word, Node node, int index)
        {
            if (word.Length == index + 1)
            {
                return node.GetChild(word[index]).IsEndOfWord;
            }

            return node.HasChild(word[index]) && ContainsRecursive(word, node.GetChild(word[index]), ++index);
        }

        public void Remove(string word)
        {
            if (word == null)
                return;

            var current = root;
            Remove(current, word, 0);
        }

        private void Remove(Node root, string word, int index)
        {
            if (index == word.Length)
            {
                Console.WriteLine(root.value);
                root.IsEndOfWord = false;
                return;
            }

            if (!root.HasChild(word[index]))
                return;


            var child = root.GetChild(word[index]);
            Remove(child, word, ++index);
            if (!child.HasChildren() && child.IsEndOfWord)
            {
                child.RemoveChild(word[index]);
            }

            Console.WriteLine(root.value);
        }

        public void Traversing()
        {
            Traversing(root);
        }

        private void Traversing(Node root)
        {
            foreach (var node in root.GetChildren())
            {
                Traversing(node);
            }

            Console.WriteLine(root);
        }

        public List<string> FindWords(string typedWord)
        {
            var list = new List<string>();
            if (!Contains(typedWord))
                return list;

            var current = typedWord.ToCharArray().Aggregate(root, (current1, ch) => current1.GetChild(ch));

            AutoComplete(typedWord, current, list);

            return list;
        }

        private void AutoComplete(string prefix, Node root, List<string> list)
        {
            if (root.IsEndOfWord)
            {
                list.Add(prefix);
            }

            var stringBuffer = new StringBuilder(prefix);
            foreach (var child in root.GetChildren())
            {
                stringBuffer.Append(child.value);
                AutoComplete(stringBuffer.ToString(), child, list);
            }
        }

        public int CountWords()
        {
            return CountWords(root, 0);
        }

        private int CountWords(Node node, int count)
        {
            if (node.IsEndOfWord)
            {
                count++;
            }

            foreach (var child in node.GetChildren())
            {
                 CountWords(child, count);
            }

            return count;
        }


        public string GetCommonPrefix()
        {
            return GetCommonPrefix(root, "");
        }

        private string GetCommonPrefix(Node current, string prefix)
        {
            while (true)
            {
                if (current.GetChildren().Length != 1)
                {
                    return prefix;
                }

                if (current.GetChildren().Length == 1 && current.IsEndOfWord)
                {
                    return prefix;
                }

                prefix += current.GetChildren()[0].value;

                current = current.GetChildren()[0];
            }
        }
    }
}
