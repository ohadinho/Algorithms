using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class RootInArray
    {
        public static double[] squareRootsExample = new double[] { 3, 1, 4, 5, 19, 6 };
        public static int[] numbersExample = new int[] { 14, 9, 22, 36, 8, 0, 64, 25 };

        // Some elements in the second array are squares. 
        // Print elements that have a square root existing in the first array. 
        public static void FindRootInArray(double[] squareRoots, int[] numbers)
        {
            HashSet<double> squareRootsHash = new HashSet<double>();

            // Adding root to hashmap in order to get them with O(1) complexity
            foreach (double root in squareRoots)
            {
                if (!squareRootsHash.Contains(root))
                    squareRootsHash.Add(root);
            }

            // Calculating root for each number in the second array, and check if that value exists in squareRootsHash HashSet
            foreach (double num in numbers)
            {
                double root = Math.Sqrt(num);

                if (squareRootsHash.Contains(root))
                    Console.WriteLine(num);
            }
        }
    }
}
