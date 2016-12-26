using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class ArrBiggestSumSequence
    {
        // Find biggest positive sum sequence in array including startIndex & endIndex
        // e.g: [2, 9, -10, 2, 3, 8, 3, -1, 10, 5] - biggestSum = 16, startIndex = 3, endIndex = 6  
        public static void FindArrBiggestSumSequence(int[] arr)
        {
            int currentSum = 0;
            int maxSum = 0;
            int startIndex = 0;
            int currentStartIndex = 0;
            int endIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startIndex = currentStartIndex;
                        endIndex = i - 1;
                    }

                    currentSum = 0;
                    currentStartIndex = i + 1;
                }
                else
                {
                    currentSum += arr[i];
                }
            }

            Console.WriteLine(string.Format("Biggest sequence sum: {0}, Start Index: {1}, End Index: {2}", maxSum, startIndex, endIndex));
        }

        public static void Test()
        {
            int[] arr = new int[] { 2, 9, -10, 2, 3, 8, 3, -1, 10, 5 };
            FindArrBiggestSumSequence(arr);
        }
    }
}
