using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class StringOrderByPattern
    {
        // False
        public const string strExample1 = "engineers rocke";
        public const string patternExample1 = "egr";

        // True
        public const string strExample2 = "engineers rock";
        public const string patternExample2 = "egr";

        //  http://www.geeksforgeeks.org/check-string-follows-order-characters-defined-pattern-not/
        //  Input: 
        //  string = "engineers rock"
        //  pattern = "er";
        //  Output: true
        //  Explanation: 
        //  All 'e' in the input string are before all 'r'.

        //  Input: 
        //  string = "engineers rock"
        //  pattern = "egr";
        //  Output: false
        //  Explanation: 
        //  There are two 'e' after 'g' in the input string.
        private static bool StringOrderByPatternExec(string str, string pattern)
        {
            // O(N) implementation           
            HashSet<char> patternChars = new HashSet<char>();
            foreach (char ch in pattern)
            {
                if (!patternChars.Contains(ch))
                    patternChars.Add(ch);
            }

            StringBuilder shortendStr = new StringBuilder();
            if (patternChars.Contains(str[0]))
                shortendStr.Append(str[0]);

            // We are running on "engineers rock"
            // Our goal is to create the same pattern by eliminating repeatable chars from original string            
            for (int i = 1; i < str.Length; i++)
            {
                char currentChar = str[i];
                char previousChar = str[i - 1];
                // 1. Check if the pattern contains the current char
                // 2. Current char has to be different from previous char - because we want to create a pattern
                // 3. The last char of the shortendStr should be different then the current char. For instance: pattern: "g",  originalString: "ogog", current shortendString: "g", then we don't need to add the second "g" of the original string
                if (patternChars.Contains(currentChar) && currentChar != previousChar && currentChar != shortendStr[shortendStr.Length - 1])
                    shortendStr.Append(currentChar);
            }

            if (shortendStr.ToString() == pattern)
                return true;

            return false;
        }
    }
}
