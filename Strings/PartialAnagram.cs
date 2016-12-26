using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class PartialAnagram
    {
        // Check if partial anagram:
        // For example: "booking", "oking" - true
        // "booking", "okinga" - false
        public static bool IsPartialAnagram(string word, string part)
        {
            // Key - char from word, Value - count in word
            Dictionary<char, int> dicWordCharCount = new Dictionary<char, int>();

            foreach (char ch in word)
            {
                if (!dicWordCharCount.ContainsKey(ch))
                    dicWordCharCount.Add(ch, 0);

                dicWordCharCount[ch]++;
            }

            // Key - char from part, Value - count in part
            Dictionary<char, int> dicPartCharCount = new Dictionary<char, int>();

            foreach (char ch in part)
            {
                if (!dicPartCharCount.ContainsKey(ch))
                    dicPartCharCount.Add(ch, 0);

                dicPartCharCount[ch]++;
            }

            foreach (KeyValuePair<char, int> kp in dicPartCharCount)
            {
                // If the word dictionary doesn't have current letter from part dictionary
                // OR
                // current char count in word dictionary occurs less times then in part dictionary
                if (!dicWordCharCount.ContainsKey(kp.Key) || dicWordCharCount[kp.Key] < dicPartCharCount[kp.Key])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
