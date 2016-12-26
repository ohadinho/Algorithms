using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Parenthesis.IsValid(Parenthesis.OKTest1));
            Console.WriteLine(Parenthesis.IsValid(Parenthesis.OKTest2));
            Console.WriteLine(Parenthesis.IsValid(Parenthesis.FAILTest1));
            Console.WriteLine(Parenthesis.IsValid(Parenthesis.FAILTest2));

            //   string inputCount = Console.ReadLine();
            // Partitions(6, 6, String.Empty);

            // Anagram.Test();

            // Console.WriteLine(PartialAnagram.IsPartialAnagram("booking","bing")); // True
            // Console.WriteLine(PartialAnagram.IsPartialAnagram("booking", "bbing")); // False
            // Console.WriteLine(PartialAnagram.IsPartialAnagram("booking", "sing")); // False

            AnagramPairs.FindAnagramPairs(AnagramPairs.wordsExample);

            MaxLettersInWords.FindMaxLettersInWords(MaxLettersInWords.wordsExample, MaxLettersInWords.charsOfWordExample);

            Substring.SimpleSubstring(Substring.exampleStr, Substring.exampleToFind);
        }
    }
}
