using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class IsBSTClass
    {
        // http://www.geeksforgeeks.org/a-program-to-check-if-a-binary-tree-is-bst-or-not/
        // A binary search tree (BST) is a node based binary tree data structure which has the following properties.
        // The left subtree of a node contains only nodes with keys less than the node’s key.
        // The right subtree of a node contains only nodes with keys greater than the node’s key.
        // Both the left and right subtrees must also be binary search trees.
        public static bool IsBST(BinaryTreeNode current, int min, int max)
        {
            if (current == null)
                return true;

            if (current.Data < min && current.Data > max)
                return false;

            return IsBST(current.Left, min, max - 1) && IsBST(current.Right, min - 1, max);
        }
    }
}
