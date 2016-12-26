using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class CommonLettersInStringsClass
    {
        // Check if all letters in the first array exists in the second, third and fourth.
        public static void CommonLettersInStrings()
        {
            List<string> strList = new List<string>();
            strList.Add("saddacsdas");
            strList.Add("sdadacaaas");
            strList.Add("asdascaaaa");
            strList.Add("acsde");

            // Checks first string with second, if true - second with third and so on
            // #1 Option WITHOUT LINQ
            for (int i = 1; i < strList.Count; i++)
            {
                bool isStringEquals = CheckStringsNoLINQ(strList[i - 1], strList[i]);
                if (!isStringEquals)
                    break;
            }

            // #2 Option WITH SINGLE LINE HashSet
            for (int i = 1; i < strList.Count; i++)
            {
                bool isStringEqualsOneLine = new HashSet<char>(strList[i - 1]).SetEquals(strList[i]);
                if (!isStringEqualsOneLine)
                    break;
            }

            // #3 Option WITH LINQ

            // create tuples
            var pairs = strList.Zip(strList.Skip(1), Tuple.Create);

            // check if all are true
            var result = pairs.All(p => CheckStringsNoLINQ(p.Item1, p.Item2));
        }

        public static bool CheckStringsNoLINQ(string prev, string current)
        {
            HashSet<char> hLettersPrev = LettersFromString(prev);
            HashSet<char> hLettersCurrent = LettersFromString(current);

            if (hLettersPrev.Count != hLettersCurrent.Count)
                return false;

            foreach (char ch in hLettersPrev)
            {
                if (!hLettersCurrent.Contains(ch))
                    return false;
            }

            return true;
        }

        public static HashSet<char> LettersFromString(string str)
        {
            HashSet<char> hLetters = new HashSet<char>();

            for (int i = 0; i < str.Count(); i++)
            {
                char currentChar = str[i];
                if (!hLetters.Contains(currentChar))
                    hLetters.Add(currentChar);
            }

            return hLetters;
        }
    }
}
