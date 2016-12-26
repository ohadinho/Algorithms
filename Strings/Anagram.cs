using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Anagram
    {
        private static bool IsAnagram(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            Dictionary<char, int> dicCountChars = new Dictionary<char, int>();

            for (int i = 0; i < str1.Length; i++)
            {
                char str1CurrentChar = str1[i];
                char str2CurrentChar = str2[i];

                if (!dicCountChars.ContainsKey(str1CurrentChar))
                    dicCountChars.Add(str1CurrentChar, 0);
                dicCountChars[str1CurrentChar]++;

                if (!dicCountChars.ContainsKey(str2CurrentChar))
                    dicCountChars.Add(str2CurrentChar, 0);
                dicCountChars[str2CurrentChar]--;
            }
        
            foreach (int value in dicCountChars.Values)
            {
                if (value != 0)
                    return false;
            }

            return true;
        }

        public static void Test()
        {
            string str1 = "blabla";
            string str2 = "lablab";
            string str3 = "lablaba";
            string str4 = "lablabs";

            Console.WriteLine(IsAnagram(str1, str2)); // True
            Console.WriteLine(IsAnagram(str1, str3)); // False
            Console.WriteLine(IsAnagram(str1, str1)); // True
            Console.WriteLine(IsAnagram(str4, str3)); // False
        }
    }
}
