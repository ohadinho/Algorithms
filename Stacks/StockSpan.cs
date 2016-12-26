using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    public class StockSpan
    {
        public static int[] StockSpanValuesExample = { 100, 80, 60, 70, 60, 75, 85 };

        // http://www.geeksforgeeks.org/the-stock-span-problem/
        public static List<int> StockSpanExec(List<int> stocks)
        {
            List<int> stockSpanValues = new List<int>();
            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i < stocks.Count; i++)
            {
                int currentSpan = 1;
                // Pop stack as long as the current tower is bigger than the last one
                // After the loop, this stack will have indexes of bigger towers than current
                // For instance:
                // If i=6 (then it's value is stocks[i] => 85)
                // After the loop, stack look likes:
                // 0 (because only stocks[0] (100) > stocks[6] (85) )
                while (indexes.Count != 0 && stocks[i] > stocks[indexes.Peek()])
                {
                    int currentIndex = indexes.Pop();
                    currentSpan += stockSpanValues[currentIndex];
                }

                stockSpanValues.Add(currentSpan);
                indexes.Push(i);
            }

            return stockSpanValues;
        }
    }
}
