using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeNode btnRoot = new BinaryTreeNode();
            btnRoot.Data = 10;
            BinaryTreeNode a = new BinaryTreeNode();
            a.Data = 8;
            BinaryTreeNode b = new BinaryTreeNode();
            b.Data = 9;
            BinaryTreeNode c = new BinaryTreeNode();
            c.Data = 15;
            BinaryTreeNode d = new BinaryTreeNode();
            d.Data = 1;
            BinaryTreeNode e = new BinaryTreeNode();
            e.Data = 13;
            BinaryTreeNode f = new BinaryTreeNode();
            f.Data = 11;

            btnRoot.Left = a;
            btnRoot.Right = b;
            a.Left = c;
            a.Right = d;
            b.Left = e;
            Search s = new Search(btnRoot);
            bool found = s.BFS(13);
        }
    }
}
