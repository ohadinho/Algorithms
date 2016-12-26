using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Search
    {        
        private BinaryTreeNode _root;

        public Search(BinaryTreeNode rootNode)
        {
            _root = rootNode;
            
        }

        public bool BFS(int data)
        {
            Queue<BinaryTreeNode> _searchQueue = new Queue<BinaryTreeNode>();
            _searchQueue.Enqueue(_root);

            while(_searchQueue.Count > 0)
            {
                BinaryTreeNode current = _searchQueue.Dequeue();

                if (current.Data == data)
                    return true;

                if(current.Left != null)
                     _searchQueue.Enqueue(current.Left);

                if (current.Right != null)
                    _searchQueue.Enqueue(current.Right);
            }

            return false;
        }

        public bool DFS(int data)
        {
            BinaryTreeNode _current;
            Stack _searchStack = new Stack();

            _searchStack.Push(_root);
            while (_searchStack.Count > 0)
            {
                _current = (BinaryTreeNode)_searchStack.Pop();

                if (_current.Data == data)
                    return true;

                if (_current.Left != null)
                    _searchStack.Push(_current.Left);

                if (_current.Right != null)
                    _searchStack.Push(_current.Right);
            }

            return false;
        }
    }
}
