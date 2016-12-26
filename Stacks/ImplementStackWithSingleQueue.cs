using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacks
{
    public class ImplementStackWithSingleQueue
    {
        public Queue<int> q = new Queue<int>();

        public void Push(int item)
        {
            q.Enqueue(item);

            // q.Count - 1 = Pulling everyone out and then inserting back except the last one (item) which stays upfront
            for (int i = 0; i < q.Count - 1; i++)
            {
                int frontItem = q.Dequeue();
                q.Enqueue(frontItem); // Push it to the end of the queue
            }            
        }

        public int Pop()
        {
            if (q.Count == 0)
                return int.MinValue;

            return q.Dequeue();
        }
    }
}
