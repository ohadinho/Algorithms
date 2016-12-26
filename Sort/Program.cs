using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10] { 9, 2, 0, 11, 16, 2, 8, 0, -5, 10 };
            MergeSortClass.MergeSort(numbers, 0, numbers.Length - 1); // O(nlogn)
            BubbleSortClass.BubbleSort(numbers); // O(n^2)
        }
    }
}
