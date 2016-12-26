using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class Shift
    {
        public static int[] ExampleArr = { 3, 4, 5, 2, 3, 1, 4 };

        public static int[] Right(int[] arr, int numShift)
        {
            int[] newArr = new int[arr.Length];
            for(int i=0;i<arr.Length;i++)
            {
                int newIndex = (i + numShift) % arr.Length; // for example: ( 0 + 2 ) % 7 = 2, ( 5 + 2 ) % 7 = 0, ( 6 + 2 ) % 7 = 1 
                newArr[newIndex] = arr[i]; 
            }

            return newArr;
        }

        public static int[] Left(int[] arr, int numShift)
        {
            int[] newArr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                int newIndex = (i - numShift + arr.Length) % arr.Length; // for example: ( 0 - 2 + 7 ) % 7 = 5, ( 5 - 2 + 7 ) % 7 = 3, ( 6 - 2 + 7 ) % 7 = 4 
                newArr[newIndex] = arr[i];
            }

            return newArr;
        }
    }
}
