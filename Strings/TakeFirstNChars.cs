using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strings
{
    public class TakeFirstNChars
    {
        public static string exampleInput = "Featuring stylish rooms and moorings for recreation boats, Room Mate Aitana is a designer hotel built in 2013 on an island in the IJ River in Amsterdam.";
        public static int exampleN = 30;

        // "Smart substring" 
        // Write a function that takes maximum N characters from a string but without cutting the words. 
    
        // For example: 
        // "Featuring stylish rooms and moorings for recreation boats, Room Mate Aitana 
        // is a designer hotel built in 2013 on an island in the IJ River in Amsterdam." 

        // Output:
        // "Featuring stylish rooms and moorings"
        public static string TakeFirstNCharsFunc(string input, int N)
        {
            StringBuilder output = new StringBuilder();
            StringBuilder word = new StringBuilder();
            int i = 0;

            // If the input length is lower than the number of chars needed for output
            // Input: 
            // input = "hello world"
            // N = 30
            // return value = "hello world"
            if (input.Length < N)
                return input;

            // Continue if (i < N) AND we're not in the middle of a word            
            while (i < N || word.Length != 0)
            {
                char currentChar = input[i];                
                word.Append(currentChar);

                if (currentChar == ' ')
                {
                    // If it's a space - we completed a word - then add it to the output
                    output.Append(word);
                    // Prepear for a brand new word
                    word.Clear();
                }

                // Move to next char
                i++;
            }

            return output.ToString();
        }
    }
}
