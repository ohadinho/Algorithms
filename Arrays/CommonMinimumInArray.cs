using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class CommonMinimumInArray
    {
        public static int[] arr1Example = new int[] { 14, 9, 22, 36, 8, 0, 64, 25 };
        public static int[] arr2Example = new int[] { 22, 42, 3, 10, 15, 36 };

        public static void FindCommonMinimumInArrays(int[] arr1,int[] arr2)
        {
            HashSet<int> arr1Hash = new HashSet<int>();

            // This loop would create a hash with all arr1 numbers
            foreach (int num in arr1)
            {
                if (!arr1Hash.Contains(num))
                    arr1Hash.Add(num);
            }

            // Search a minimum in arr2 only if it's exists in the hashset
            int min = Int32.MaxValue;
            foreach (int num in arr2)
            {
                if (num < min && arr1Hash.Contains(num))
                {
                    min = num;
                }
            }

            Console.WriteLine(min);
        }
    }
}
