using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacks
{
    public class ImplementQueueWithSingleStack
    {
        public Stack<int> s = new Stack<int>();

        public void Enqueue(int item)
        {
            if (s.Count == 0)
            {
                s.Push(item);
                return;
            }

            int topItem = s.Pop();
            Enqueue(item);
            s.Push(topItem);          
        }

        public int Dequeue()
        {
            if (s.Count == 0)
                return Int32.MinValue;

            return s.Pop();
        }
    }
}
