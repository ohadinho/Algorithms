using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class IsValidXML
    {
        public static string exampleString = "<Hello><Second>dasdd</Second></Hello>";

        public static bool IsXMLValid(string str)
        {
            Stack<string> xmlStack = new Stack<string>();

            // Iterate the whole string
            for (int i = 0; i < str.Length - 1; i++)
            {
                // Opening tag
                if (str[i] == '<' && str[i + 1] != '/')
                {
                    StringBuilder openingTag = new StringBuilder();
                    int j = i + 1; // For instance: if we are on '<' in '<Hello>' - then start in the second char 'H' (without '<')

                    while (str[j] != '>')
                    {
                        openingTag.Append(str[j]);
                        j++;
                    }

                    // Push the current opening tag to the stack
                    // For Instance: <Hello> - would push "Hello"              
                    xmlStack.Push(openingTag.ToString());
                    i = j;
                }

                // Closing tag
                if (str[i] == '<' && str[i + 1] == '/')
                {
                    StringBuilder closingTag = new StringBuilder();
                    int j = i + 2; // For instance: if we are on '<' and next char is '/' in '</Hello>' - then start in the second char 'H' (without '</')

                    while (str[j] != '>')
                    {
                        closingTag.Append(str[j]);
                        j++;
                    }

                    // Pop the opening tag value and check whether it equals to the current closing tag value
                    bool isValid = xmlStack.Pop() == closingTag.ToString();

                    if (!isValid)
                        return false;

                    i = j;
                }
            }

            return true;
        }
    }
}
