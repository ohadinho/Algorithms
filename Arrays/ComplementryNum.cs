using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class ComplementryNum
    {
        //מצא במערך זוגות מספרים שלמים שסכומם 10 (בסיבוכיות O(n)).
        public static void FindComplementry()
        {
            const int completeNum = 10;
            const int inputLen = 12;
            int[] arrHelp = new int[11];
            int[] input = new int[inputLen] { 1, 1, 1, 1, 4, 2, 3, 1, 9, 7, 8, 5 };

            for (int i = 0; i < input.Length; i++)
            {
                arrHelp[input[i]]++;
            }

            for (int i = 0; i < arrHelp.Length / 2; i++)
            {
                if (arrHelp[i] != 0)
                {
                    int completeIndex = completeNum - i;
                    if (arrHelp[completeIndex] != 0)
                    {
                        Console.WriteLine(i + ", " + completeIndex);
                    }
                }
            }
        }

        public static void FindComplementryWithDictionary()
        {
            const int completeNum = 10;
            const int inputLen = 14;          
            int[] input = new int[inputLen] { 1, 1, 1, 1, 4, 2, 3, 1, 9, 9, 7, 8, 5, 5 };
            Dictionary<int, int> numbersCountDic = new Dictionary<int, int>();

            foreach(int num in input)
            {
                if (!numbersCountDic.ContainsKey(num))
                    numbersCountDic.Add(num, 0);

                numbersCountDic[num]++;
            }

            foreach(KeyValuePair<int,int> pair in numbersCountDic)
            {
                int complement = completeNum - pair.Key;

                if (complement == pair.Key && numbersCountDic[complement] >= 2) // If it's a pair like (5,5) then the dictionary has 5 and 2 as count
                {
                    Console.WriteLine("(" + pair.Key + "," + complement + ") Count: " + numbersCountDic[pair.Key] / 2);
                }
                else
                {
                    if (numbersCountDic.ContainsKey(complement) && complement != pair.Key)
                    {
                        if (pair.Key < complement) // Just in order not to print the pair twice. That means: (1,9) will be printed. (9,1) wouldn't
                        {
                            int minCount = Math.Min(numbersCountDic[pair.Key], numbersCountDic[complement]);
                            Console.WriteLine("(" + pair.Key + "," + complement + ") Count: " + minCount);
                        }
                    }
                }
            }
        } 
    }
}
