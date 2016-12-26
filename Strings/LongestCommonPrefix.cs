using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strings
{
    // http://www.geeksforgeeks.org/longest-common-prefix-set-3-divide-and-conquer/
    // Given a set of strings, find the longest common prefix.
    // Input  : {“geeksforgeeks”, “geeks”, “geek”, “geezer”}
    // Output : "gee"
    // Input  : {"apple", "ape", "april"}
    // Output : "ap"
    public class LongestCommonPrefix
    {
        public static string[] exampleStrings = { "geeksforgeeks", "geeks", "geek", "geezer","geezmo" };

        public static string LongestPrefix(string firstWord, string secondWord)
        {
            int i = 0, j = 0;
            StringBuilder sb = new StringBuilder();

            while (i < firstWord.Length && j < secondWord.Length && firstWord[i] == secondWord[j])
            {
                sb.Append(firstWord[i]);
                i++;
                j++;
            }

            return sb.ToString();            
        }

        public static string BinarySearchCheck(string[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                string leftWord = BinarySearchCheck(arr, left, mid);
                string rightWord = BinarySearchCheck(arr, mid + 1, right);

                return LongestPrefix(leftWord,rightWord);
            }

            return arr[left];
        }
    }
}
