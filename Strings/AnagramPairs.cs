using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class AnagramPairs
    {
        public static string[] wordsExample = new string[] { "pear", "dirty room", "amleth", "reap", "tinsel", "hamlet", "dormitory", "listen", "silent" };
        //Given this example input:
        //[ "pear","dirty room","amleth","reap","tinsel","hamlet","dormitory","listen","silent" ]

        //The output should be an array-of-arrays (or list-of-lists)

        //[
        // ["pear","reap"],
        // ["dirty room","dormitory"],
        // ["amleth","hamlet"],
        // ["tinsel","listen","silent"]
        //]  
        public static void FindAnagramPairs(string[] words)
        {           
            // Key - Sorted Word, Value - Index in the original words array
            Dictionary<string, List<int>> dicWords = new Dictionary<string, List<int>>();

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                string sortedWord = new string(word.OrderBy(c => c).ToArray());

                if (!dicWords.ContainsKey(sortedWord))
                    dicWords.Add(sortedWord, new List<int>());

                dicWords[sortedWord].Add(i);
            }

            foreach (KeyValuePair<string, List<int>> kp in dicWords)
            {
                // If there is at least 2 matching words
                if (kp.Value.Count >= 2)
                {
                    Console.Write("[ ");

                    foreach (int index in kp.Value)
                    {
                        Console.Write(words[index] + ", ");
                    }

                    Console.Write("]");
                    Console.WriteLine();
                }
            }
        }
    }
}
