using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class SameStringPatterns
    {
        public static string[] strArrayExample1 = new string[] { "abb", "abc", "xyz", "xyy" };
        public static string patternExample1 = "foo";

        // http://www.geeksforgeeks.org/find-all-strings-that-match-specific-pattern-in-a-dictionary/
        // Input:  
        //dict = ["abb", "abc", "xyz", "xyy"];
        //pattern = "foo"
        //Output: [xyy abb]
        //Explanation: 
        //xyy and abb have same character at index 1 and 2 like the pattern
        // Input:  
        // dict = ["abb", "abc", "xyz", "xyy"];
        // pattern = "aba"
        // Output: [] 
        // Explanation: 
        // Pattern has same character at index 0 and 2. 
        // No word in dictionary follows the pattern.
        private static void SameStringPatternsExec(string[] strArray, string pattern)
        {
            List<string> matches = new List<string>();
            StringBuilder sbHashPattern = new StringBuilder();

            // Key - char from pattern, Value - times appeard until now
            // Will create the following:
            // f 1
            // o 2
            // hashPattern : 1,1,2
            Dictionary<char, int> patternDic = new Dictionary<char, int>();
            for (int i = 0; i < pattern.Length; i++)
            {
                char currentChar = pattern[i];
                if (!patternDic.ContainsKey(currentChar))
                    patternDic.Add(currentChar, 0);

                patternDic[currentChar]++;
                sbHashPattern.Append(patternDic[currentChar]);
            }

            for (int i = 0; i < strArray.Length; i++)
            {
                // Creating the dictionary for the word
                string currentWord = strArray[i];
                // Key - char from pattern, Value - times appeard until now
                // For the first word ("abb") (A match) :
                // a 0
                // b 2

                // For the second word ("abc") (Not a match) :
                // a 1
                // b 1
                // c 1
                Dictionary<char, int> currentWordDic = new Dictionary<char, int>();
                StringBuilder sbWordPattern = new StringBuilder();
                for (int j = 0; j < currentWord.Length; j++)
                {
                    char currentChar = currentWord[j];
                    if (!currentWordDic.ContainsKey(currentChar))
                        currentWordDic.Add(currentChar, 0);

                    // Adding the current index to that char
                    currentWordDic[currentChar]++;
                    sbWordPattern.Append(currentWordDic[currentChar]);
                }

                // If the hashes are equal then it's a match!
                if (sbWordPattern.ToString() == sbHashPattern.ToString())
                    matches.Add(currentWord);
            }
        }
    }
}
