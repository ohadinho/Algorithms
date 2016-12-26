using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strings
{
    public class SortByLastLetter
    {
        public static string[] exampleWords = { "Selena", "Luis", "Hector", "Emmanuel", "Amish" };

        //Given a list/array of names(String) sort them such that each name is followed by a name which starts with the last character of the previous name. 
        //# input 
        //[ "Selena", "Luis", "Hector", "Emmanuel", "Amish" ] 
        //
        //# output: 
        //[ "Emmanuel", "Luis", "Selena", "Amish", "Hector" ]
        public static void SortByLastChar(string[] words)
        {
            Dictionary<char, string> startLetters = new Dictionary<char, string>();
            Dictionary<char, string> endLetters = new Dictionary<char, string>();

            words = words.Select(s => s.ToLowerInvariant()).ToArray();
            // Creating two dictionaries of startLetters and endLetters
            // startLetters Dictionary
            // S, Selena
            // L, Luis
            // H, Hector
            //E, Emmanuel
            //A, Amish

            // endLetters Dictionary
            //A, Selena
            //S, Luis
            //R, Hector
            //L, Emmanuel
            //H, Amish
            foreach (string word in words)
            {
                char firstChar = word[0];
                char lastChar = word[word.Length - 1];

                if (!startLetters.ContainsKey(word[0]))
                    startLetters.Add(firstChar, word);

                if (!endLetters.ContainsKey(lastChar))
                    endLetters.Add(lastChar, word);
            }

            string[] output = new string[words.Length];
            // Checking which is the last word and placing it in output last cell            
            foreach (string word in words)
            {
                // Taking the last char of each word and searching if it's found in the startLetters dictionary
                char lastChar = word[word.Length - 1];
                if (!startLetters.ContainsKey(lastChar))
                {
                    output[output.Length - 1] = word;
                    break;
                }
            }

            // Going from the last to the first.
            // Getting the first charachter of the last, find its word by the endLetters
            // For instance:
            // Hector
            // We go for 'H' in the keys of endLetters dictionary and finding 'Amish'
            for (int i = output.Length - 1; i > 0; i--)
            {
                char firstCharOfCurrentWord = output[i][0];
                output[i - 1] = endLetters[firstCharOfCurrentWord];
            }
        }
    }
}
