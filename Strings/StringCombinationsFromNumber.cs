using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strings
{
    public class StringCombinationsFromNumber
    {
        // vector to store input number
        public static List<int> exampleInput = new List<int> { 1, 2, 1 };
        // vector to store the mappings
        public static char[][] exampleTable = new char[][] { new char[3] { 'A', 'B', 'C' }, new char[3] { 'D', 'E', 'F' }, new char[3] { 'G', 'H', 'I' } };
        // http://www.geeksforgeeks.org/find-strings-formed-characters-mapped-digits-number/
        // For instance:
        // Hash:
        // 1 -> ['A', 'B', 'C']
        // 2 -> ['D', 'E', 'F']
        // 3 -> ['G', 'H', 'I']
        // 4 -> ['J', 'K', 'L']
        // 5 -> ['M', 'N', 'O']
        // 6 -> ['P', 'Q', 'R']
        // 7 -> ['S', 'T', 'U']
        // 8 -> ['V', 'W', 'X']
        // 9 -> ['Y', 'Z'] 

        // Input : 121
        // Output : ADA BDB CDC AEA BEB CEC AFA BFB CFC
        //
        // Input : 22
        // Output : DD EE FF
        public static List<string> AllStringsFromNumber(List<int> input, char[][] table)
        {
            List<string> output = new List<string>(), temp = new List<string>();

            // stores index of first occurrence
            // of the digits in input
            // So for instance if I have 121:
            // When encounter the first '1'
            // I add to mp:
            // '1', 0 (index of first occurence)
            // When I reach the last '1' I already have in output:
            // AD
            // AE
            // AF
            // BD
            // BE
            // BF
            // CD
            // CE
            // CF
            // And when iterating the output we go to the index first occurence of '1' : 0 and take the letter from there
            Dictionary<int, int> mp = new Dictionary<int, int>();

            // maintains index of current digit considered
            int index = 0;

            // for each digit
            foreach (int d in input)
            {
                // store index of first occurrence
                // of the digit in the map
                if (!mp.ContainsKey(d))
                    mp[d] = index;

                // clear vector contents for future use
                temp.Clear();

                // do for each character thats maps to the digit
                for (int i = 0; i < table[d - 1].Length; i++)
                {
                    char s;
                    // for first digit, simply push all its
                    // mapped characters in the output list
                    if (index == 0)
                    {
                        output.Add(table[d - 1][i].ToString());
                    }

                    // from second digit onwards
                    if (index > 0)
                    {
                        // for each string in output list
                        // append already chosen character OR new character to it.
                        for (int j = 0; j < output.Count; j++)
                        {
                            string str = output[j];

                            int firstOccurenceOfCurrentDigit = mp[d];
                            // If this is not the first occurence of the digit                            
                            if (firstOccurenceOfCurrentDigit != index)
                            {
                                // take the char from the first occurence position
                                s = str[firstOccurenceOfCurrentDigit];
                            }
                            else // If it's the digit first occurence - pull it from the char table
                            {
                                s = table[d - 1][i];
                            }

                            // Adds current digit to current string from output
                            str = str + s;

                            // store strings formed by current digit
                            temp.Add(str);
                        }

                        // nothing more needed to be done if this
                        // is not the first occurrence of the digit
                        if (mp[d] != index)
                            break;
                    }
                }

                // replace contents of output list with temp list
                if (index > 0)
                    output = new List<string>(temp);
                index++;
            }

            return output;
        }
    }
}
