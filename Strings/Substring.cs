using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strings
{
    public class Substring
    {
        public static string examplePattern = "nan";
        public static string exampleString = "banana";

        // http://www.geeksforgeeks.org/suffix-array-set-1-introduction/
        //        Let the given string be "banana".
        //0 banana                          5 a
        //1 anana     Sort the Suffixes     3 ana
        //2 nana      ---------------->     1 anana  
        //3 ana        alphabetically       0 banana  
        //4 na                              4 na   
        //5 a                               2 nana
        //So the suffix array for "banana" is {5, 3, 1, 0, 4, 2}
        // Remarks:
        // a. Sorting the array by letter allows to search the pattern in efficient time (Binary search)
        // b. If you only want to search pattern with O(n) complexity then just create the suffix array and search the pattern in it by iterating one by one
        private static SortedDictionary<string, int> BuildSuffix(string str)
        {
            SortedDictionary<string, int> suffixDic = new SortedDictionary<string, int>();
            for (int i = 0; i < str.Length; i++)
            {
                string currentTillEnd = str.Substring(i, str.Length - i);
                suffixDic.Add(currentTillEnd,i);
            }

            int[] suffixArray = new int[suffixDic.Count];
            for(int i=0;i<suffixDic.Values.Count;i++)
            {
                suffixArray[i] = suffixDic.Values.ElementAt(i);
            }

            return suffixDic;
        }

        public static int Search(string pattern, string str)
        {
            SortedDictionary<string, int> suffixDic = BuildSuffix(str);

            int left = 0;
            int right = str.Length - 1;

            // Binary search for the pattern in the str
            // Searching for the pattern in the keys of the dictionary
            // For instance:
            // a , ana, anana, banana, na, nana
            // Searching for "nan" will finally get us to "nana" which is value is 2 (startIndex)
            while (left < right)
            {
                int mid = (left + right) / 2;

                // For instnace: Comparing 3 letters from pattern "nan" in "nana"
                int res = String.Compare(pattern, 0, suffixDic.ElementAt(mid).Key, 0, pattern.Length);

                if (res == 0)
                    return suffixDic.ElementAt(mid).Value;                

                // Move to left half if pattern is alphabtically less than
                // the mid suffix
                if (res < 0) 
                    right = mid - 1;
                // Otherwise move to right half
                else 
                    left = mid + 1;
            }

            return -1;
        }

        public const string exampleStr = "ahishers";
        public static string[] exampleToFind = new string[] { "he", "she", "hers", "his" };

        public static void SimpleSubstring(string str,string[] toFind)
        {
            int prev = 0, cur = 0;

            for (int i = 0; i < str.Length; i++)
            {
                prev = i;

                for (int j = 0; j < toFind.Length; j++)
                {
                    while (cur != toFind[j].Length && str.Length != prev && str[prev] == toFind[j][cur])
                    {
                        prev++;
                        cur++;

                        if (cur == toFind[j].Length)
                            Console.WriteLine("Word {0} appears from {1} to {2}", toFind[j], i.ToString(), (i + cur - 1).ToString());
                    }

                    prev = i;
                    cur = 0;
                }
            }
        }
    }
}
