using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class RepeatedNum
    {
        // מצא את המספר שחוזר הכי הרבה פעמים במערך
        // לדוגמא: במערך 2,3,2,2,4,1,3,3,2 המספר
        //שחוזר הכי הרבה הוא 2.
        public static void FindRepeatedNum()
        {
            const int len = 12;
            int[] arr = new int[len] { 2, 3, 2, 2, 4, 1, 3, 3, 2, 1, 4, 2 };
            int[] count = new int[10];

            for (int j = 0; j < count.Length; j++)
            {
                count[j] = 0;
            }

            int currentNum;
            for (int i = 0; i < arr.Length; i++)
            {
                currentNum = arr[i];
                count[currentNum]++;
            }

            int max = -1;
            int maxIndex = 0;
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > max)
                {
                    max = count[i];
                    maxIndex = i;
                }
            }

            Console.WriteLine("The max count num is: " + max);
            Console.WriteLine("The max num is: " + maxIndex);
        }
    }
}
