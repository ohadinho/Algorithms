using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class NonDecreasingSubsequences
    {
        public static int[] numbersExample = new int[] { 3, 6, 61, 6, 7, 9, 1, 7, 7, 2, 7, 7, 2, 388, 3, 72, 7 };

        //  Implement a function nondecreasing_subsequences() that, given a sequence of 
        //  numbers such as:
        //  [ 3,6,61,6,7,9,1,7,7,2,7,7,2,388,3,72,7 ]
        //  ... will identify and return each contiguous sub-sequence of non-decreasing 
        //  numbers. E.g. this example input should return this array-of-arrays (e.g. or 
        //  list-of-lists)
        //  [ [3,6,61],[6,7,9],[1,7,7],[2,7,7],[2,388],[3,72],[7] ]
        public static void FindNonDecreasingSubsequences(int[] numbers)
        {            
            List<List<int>> nonDecreasingSubsArr = new List<List<int>>();

            int j = 0;
            nonDecreasingSubsArr.Add(new List<int>());
            nonDecreasingSubsArr[j].Add(numbers[0]);

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < numbers[i - 1])
                {
                    j++;
                    nonDecreasingSubsArr.Add(new List<int>());
                }

                nonDecreasingSubsArr[j].Add(numbers[i]);
            }
        }
    }
}
