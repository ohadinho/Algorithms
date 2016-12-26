using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strings
{
    // http://www.geeksforgeeks.org/find-possible-words-phone-digits/
    // For array: { "abc", "def", "ghi" }
    // Print: adg adh adi aeg aeh aei afg afh afi bdg bdh bdi beg beh bei bfg bfh bfi cdg cdh cdi ceg ceh cei cfg cfh cfi
    public class FindStringsCombinations
    {
        public static string[] exampleStringsArray = { "abc", "def", "ghi" };

        public static void FindStringsCombinationsRecursive(string[] stringArr)
        {
            List<string> outputs = new List<string>();
            FindStringsCombinationsRecursiveUtil(stringArr, 0, new StringBuilder(), outputs);
            outputs.ForEach(item => Console.Write(item + " "));
        }

        private static void FindStringsCombinationsRecursiveUtil(string[] stringArr,int currentStringIndex,StringBuilder currentOutput, List<string> outputs)
        {
            // after we have been in the last string inside string array
            if (stringArr.Length == currentStringIndex)
            {
                // add the computed output to outputs list
                outputs.Add(currentOutput.ToString());
                return;
            }

            // For each letter in current string (current string is stringArr[currentStringIndex])
            for (int i = 0; i < stringArr[currentStringIndex].Length; i++)
            {
                // Append current letter from current string to currentOutput
                // For instance:
                // We are on 'e' in the 'def', and currentOutput is 'a'
                // After appending the currentOutput is: 'ae'
                currentOutput.Append(stringArr[currentStringIndex][i]);
                
                // Move to the next string in the string array
                // For instance:
                // Move from "def" to "ghf" (by adding 1 to currentStringIndex)
                FindStringsCombinationsRecursiveUtil(stringArr, currentStringIndex + 1, currentOutput, outputs);
                
                // Remove the char appended because we want to append the next one (in the next loop iteration)
                currentOutput.Remove(currentOutput.Length - 1, 1);
            }
        }

        public static void FindStringsCombinationsIterative(string[] stringArr)
        {
            List<string> outputs = new List<string>(), tempOutputs = new List<string>();
            StringBuilder currentOutput = new StringBuilder();
            int index = 0;

            foreach (string word in stringArr)
            {
                tempOutputs.Clear();
                // For each char in word
                for (int i = 0; i < word.Length; i++)
                {
                    // If it's a new output word
                    if (index == 0)
                    {
                        outputs.Add(word[i].ToString());
                    }

                    if (index > 0)
                    {
                        // for each final output
                        for (int j = 0; j < outputs.Count; j++)
                        {
                            char currentLetter = word[i];
                            tempOutputs.Add(outputs[j] + currentLetter);
                        }
                    }
                }


                // replace contents of output list with temp list
                if (index > 0)
                    outputs = new List<string>(tempOutputs);
                index++;
            }
        }
    }
}
