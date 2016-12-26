using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie t = new Trie();
            t.Add("Hello");
            t.Add("Hey");
            t.Add("Hellas");
        }
    }
}
