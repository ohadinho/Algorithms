using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Parenthesis
    {
        public const string OKTest1 = "{[sda{{aa}}]}()";
        public const string OKTest2 = "(())([aa+s{s5}])";
        public const string FAILTest1 = "(()]]]";
        public const string FAILTest2 = "((";

        public static bool IsValid(string exp)
        {
            // Open parenthesis stack
            Stack<char> openingsStack = new Stack<char>();
            // Key - Closing parenthesis, Value - Opening parenthesis
            Dictionary<char, char> closeOpenDic = new Dictionary<char, char>();
            closeOpenDic.Add(')', '(');
            closeOpenDic.Add(']', '[');
            closeOpenDic.Add('}', '{');

            HashSet<char> openingsHash = new HashSet<char>();
            openingsHash.Add('(');
            openingsHash.Add('[');
            openingsHash.Add('{');

            for (int i = 0; i < exp.Length; i++)
            {
                char currentChar = exp[i];
                // If it's an opening parenthesis
                if (openingsHash.Contains(currentChar))
                    openingsStack.Push(currentChar);
                else
                {
                    // If it's an closing parenthesis
                    if (closeOpenDic.ContainsKey(currentChar))
                    {
                        // If stack is empty then the closing doesn't have any opening ==> expression isn't valid
                        if (openingsStack.Count == 0)
                            return false;

                        char topStackChar = openingsStack.Pop();
                        if (closeOpenDic[currentChar] != topStackChar)
                            return false;
                    }
                }
            }

            if (openingsStack.Count > 0)
                return false;


            return true;
        }
    }
}
