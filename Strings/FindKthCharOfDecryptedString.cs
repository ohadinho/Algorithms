using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strings
{
    // http://www.geeksforgeeks.org/find-kth-character-of-decrypted-string/
    //  Input: "a2b2c3", k = 5
    //  Output: c
    //  Decrypted string is "aabbccc"

    //  Input : "ab4c2ed3", k = 9
    //  Output : c
    //  Decrypted string is "ababababccededed"

    //  Input: "ab4c12ed3", k = 21
    //  Output: e
    //  Decrypted string is "ababababccccccccccccededed"
    public class FindKthCharOfDecryptedString
    {
        public static string exampleString1 = "a2b2c3";
        public static string exampleString2 = "ab4c2ed3";
        public static string exampleString3 = "ab4c12ed3";

        public static void FindKthCharOfDecryptedStringFunc(string str,int k)
        {
            StringBuilder output = new StringBuilder();
            StringBuilder currentWord = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                char currentChar = str[i];                

                // Accumelating the currentWord until a number is reached
                while (currentChar < '0' || currentChar > '9')
                {
                    currentWord.Append(currentChar);
                    i++;
                    currentChar = str[i];
                }

                // In this loop we append to output the string according to the number of times requested
                int numberOfTimes = (int)Char.GetNumericValue(currentChar);
                for (int j = 0; j < numberOfTimes; j++)
                {
                    output.Append(currentWord.ToString());
                }

                currentWord.Clear();
            }

            Console.WriteLine("Output string: " + output.ToString());
            Console.WriteLine("Char at " + k.ToString() + " position: " + output[k]);
        }
    }
}
