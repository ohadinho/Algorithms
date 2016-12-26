using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class BubbleSortClass
    {
        public static void BubbleSort(int[] numbers)
        {
            int temp = 0;

            for (int write = 0; write < numbers.Length; write++)
            {
                for (int sort = 0; sort < numbers.Length - 1; sort++)
                {
                    if (numbers[sort] > numbers[sort + 1])
                    {
                        temp = numbers[sort + 1];
                        numbers[sort + 1] = numbers[sort];
                        numbers[sort] = temp;
                    }
                }
            }
        }
    }
}
