using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Shift.Right(Shift.ExampleArr, 2);
            Shift.Left(Shift.ExampleArr, 2);

            ComplementryNum.FindComplementryWithDictionary();

            RootInArray.FindRootInArray(RootInArray.squareRootsExample,RootInArray.numbersExample);

            CommonMinimumInArray.FindCommonMinimumInArrays(CommonMinimumInArray.arr1Example, CommonMinimumInArray.arr2Example);

            MostCommonInArrays.FindMostCommonInArrays(MostCommonInArrays.arr1Example, MostCommonInArrays.arr2Example);

            NonDecreasingSubsequences.FindNonDecreasingSubsequences(NonDecreasingSubsequences.numbersExample);

            SortByLastChar.SortByLastCharExec(SortByLastChar.wordsExample);
        }
    }
}
