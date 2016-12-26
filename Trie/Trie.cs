using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trie
{
    //http://blog.ivank.net/aho-corasick-algorithm-in-as3.html
    public class TrieNode
    {
        // Current letter char
        public char Value { get; set; }
        // Key - a letter (the next letter of the string), Value - TrieNode which it points to
        public Dictionary<char, TrieNode> Children { get; set; }        
        public bool IsLeaf { get; set; }
        // Holds possible words until current letter
        public List<string> PossibleWords;

        // Used for substring finder
        public TrieNode Fall { get; set; }
        public TrieNode Parent { get; set; }
    }

    public class Trie
    {
        public TrieNode root = new TrieNode() { Children = new Dictionary<char, TrieNode>(), PossibleWords = new List<string>() };

        public void Add(string word)
        {
            TrieNode currentTrieNode = root;            

            for (int i = 0; i < word.Length; i++)
            {
                // Adding the word to the current node
                //           h (hey, hello)
                //           |
                //           e (hey, hello)
                //         /  \
                //     y(hey)   l (hello)
                //              |
                //              l (hello)
                //              |
                //              o (hello) 
                currentTrieNode.PossibleWords.Add(word);
                char currentChar = word[i];                

                TrieNode child;
                // If the current node doesn't have this letter on its children - then create a new child, add it to children and set it as current
                if (!currentTrieNode.Children.ContainsKey(currentChar))
                {
                    child = new TrieNode() { Value = currentChar, Children = new Dictionary<char, TrieNode>(), PossibleWords = new List<string>(), Parent = currentTrieNode };
                    currentTrieNode.Children.Add(currentChar, child);                    
                    currentTrieNode = child;
                }
                else
                {
                    // Get existing child and set it to current
                    currentTrieNode = currentTrieNode.Children[currentChar];
                }
            }

            currentTrieNode.IsLeaf = true;
            currentTrieNode.PossibleWords.Add(word); // Adding the word to the leaf node
        }

        public bool IsInTrie(string word)
        {
            TrieNode currentTrieNode = root;

            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];

                if (!currentTrieNode.Children.ContainsKey(currentChar))
                    return false;

                currentTrieNode = currentTrieNode.Children[currentChar];
            }

            return currentTrieNode.IsLeaf == true; // If the last char of the word is a leaf in the trie - then it's found
        }

        // Doesn't Work
        public void BuildFall()
        {            
            root.Fall = root; // Fall function for the root is root
            root.Parent = null;

            Queue<TrieNode> q = new Queue<TrieNode>();
            q.Enqueue(root);  // I add the root to the queue

            while (q.Count > 0) // BFS
            {
                TrieNode currentNode = q.Dequeue();

                for (int i = 0; i < currentNode.Children.Count; i++)
                {
                    TrieNode nextNode = currentNode.Children.ElementAt(i).Value;                    
                    q.Enqueue(nextNode);
                }

                if (currentNode == root)
                    continue;

                var fall = currentNode.Parent.Fall;

                while (!fall.Children.ContainsKey(currentNode.Value) && fall != root)
                    fall = fall.Fall;

                currentNode.Fall = fall.Children.ContainsKey(currentNode.Value) ? fall.Children[currentNode.Value] : root;
                if (currentNode.Fall == currentNode)
                    currentNode.Fall = root;
            }
        }
    }
}
