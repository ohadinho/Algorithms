using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class MaxLettersInWords
    {
        public static string[] wordsExample = new string[] { "amsterdam", "aaa", "abacadabra", "asdfasdfasdfa" };
        public static char[] charsOfWordExample = new char[] { 'a', 'b', 'c' };

        public static void FindMaxLettersInWords(string[] words,char[] charsOfWord)
        {
            // Key - Word, Value - Count Letters
            Dictionary<string, int> wordCharsCountDic = new Dictionary<string, int>();
            HashSet<char> charsHash = new HashSet<char>();

            foreach (char c in charsOfWord)
                charsHash.Add(c);

            foreach (string word in words)
                wordCharsCountDic.Add(word, 0);

            foreach (string word in words)
            {
                // for every char in current word
                foreach (char currentCharOfWord in word)
                {
                    // If the charsHash has the current char of the word
                    if (charsHash.Contains(currentCharOfWord))
                        // Increase the char count of that word by 1
                        wordCharsCountDic[word]++;
                }
            }

            int max = wordCharsCountDic.Max(x => x.Value);
            KeyValuePair<string, int> maxWord = wordCharsCountDic.Where(x => x.Value == max).First();
        }
    }
}
