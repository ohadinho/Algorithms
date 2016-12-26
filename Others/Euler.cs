using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Others
{
    public class Euler
    {
        /// <summary>
        /// Given the array [5, 4, 12, 3, 11, 7, 2, 8, 1, 9] that forms a triangle like so:
        //    5
        //  4 12
        // 3 11 7
        //2 8 1 9

        //Write a function that will traverse the triangle and find the largest possible sum of values when you can go from one point to either directly bottom left, or bottom right:

        //Example:
        //5 + 4 + 11 + 1
        //but NOT:
        //5 + 4 + 7 + 8  
        //
        // http://www.mathblog.dk/project-euler-18/
        /// </summary>
        /// <param name="args"></param>
        public static void Euler18(int[] arr, int depth)
        {                       
            int length = arr.Length;

            while (depth > 0)
            {
                int initLength = length - 1 - depth;

                for (int i = initLength; i < initLength + depth; i++)
                {
                    arr[i - depth] = Max(arr[i], arr[i + 1]) + arr[i - depth];
                }

                length -= depth + 1;
                depth--;
            }
        }

        private static int Max(int v1, int v2)
        {
            if (v1 > v2)
                return v1;

            return v2;
        }

        public static void Test()
        {
            int[] arr = { 5, 4, 12, 3, 11, 7, 2, 8, 1, 9 };
            int depth = 3;

            Euler18(arr, depth);
        }
    }
}
