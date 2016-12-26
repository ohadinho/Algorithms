using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class IndexArray
    {
        // סדר את המערך שתקבל לפי סדר האינדקסים במערך נוסף שתקבל.
        //לדוגמא: קלט: מערך: [10,11,12] , מערך אינדקסים: [1,0,2]. פלט: [11,10,12]ך.
        public static void ArrangeIndexArray()
        {
            const int inputLen = 3;
            const int indexLen = 3;
            const int outputLen = 3;

            int[] input = new int[inputLen] { 10, 11, 12 };
            int[] index = new int[indexLen] { 1, 0, 2 };
            int[] output = new int[outputLen];

            int currentInput, currentIndex;
            for (int i = 0; i < input.Length; i++)
            {
                currentInput = input[i];
                currentIndex = index[i];
                output[currentIndex] = currentInput;
            }

            Console.WriteLine("The output num: ");
            for (int j = 0; j < output.Length; j++)
            {
                Console.Write(output[j] + ", ");
            }

            Console.ReadLine();
        }
    }
}
