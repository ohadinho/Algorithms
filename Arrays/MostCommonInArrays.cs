using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class MostCommonInArrays
    {
        // Those two should return: 2 (Most Common) 3 (Common occurences count)
        public static int[] arr1Example = new int[] { 1, 0, 2, 9, 9, 12, 10, 2, 29, 2, 9, 9, 9 };
        public static int[] arr2Example = new int[] { 0, 9, 9, 2, 2, 10, 14, 15, 2 };

        public static void FindMostCommonInArrays(int[] arr1,int[] arr2)
        {
            // Key - Number, Value - Count Appeared
            // For the example above:
            // 1 1
            // 0 1
            // 2 3
            // 9 5
            // 12 1
            // 10 1
            // 29 1            
            Dictionary<int, int> dicNumbersCount1 = new Dictionary<int, int>();
            foreach (int num in arr1)
            {
                if (!dicNumbersCount1.ContainsKey(num))
                    dicNumbersCount1.Add(num, 0);

                dicNumbersCount1[num]++;
            }

            Dictionary<int, int> dicNumbersCount2 = new Dictionary<int, int>();
            foreach (int num in arr2)
            {
                if (!dicNumbersCount2.ContainsKey(num))
                    dicNumbersCount2.Add(num, 0);

                dicNumbersCount2[num]++;
            }

            int commonNumber = -1;
            int maxValue = Int32.MinValue;

            // Loop in order to find the common maximum value (count)
            foreach (KeyValuePair<int, int> kp in dicNumbersCount1)
            {
                // If the second dictionary has the current number
                if (dicNumbersCount2.ContainsKey(kp.Key))
                {
                    // the current common maximum occurences is the minumum between the value of first array value occurences and second array value occurences
                    int currentMaxValueToCheck = Math.Min(dicNumbersCount1[kp.Key], dicNumbersCount2[kp.Key]);

                    if (currentMaxValueToCheck > maxValue)
                    {
                        maxValue = currentMaxValueToCheck;
                        commonNumber = kp.Key;
                    }
                }
            }

            Console.WriteLine("Common Number: " + commonNumber);
            Console.WriteLine("Max Times Appeared In Both: " + maxValue);
        }
    }
}
