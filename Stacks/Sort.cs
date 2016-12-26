using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    public class Sort
    {
        public static void SortStack(Stack<int> stack)
        {
          if(stack.Count != 0)
            {
                int temp = stack.Pop();
                SortStack(stack);
                SortedInsert(stack,temp);
            }
        }

        public static void SortedInsert(Stack<int> stack, int element)
        {
            if (stack.Count == 0)
                stack.Push(element);
            else
            {
                if (stack.Peek() > element)
                {
                    int temp = stack.Pop();
                    SortedInsert(stack, element);
                    stack.Push(temp);
                }
                else
                    stack.Push(element);
            }
        }
    }
}
