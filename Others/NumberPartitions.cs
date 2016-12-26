using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Others
{
    class NumberPartitions
    {
        // Writes all way to partition a number.
        // For instance: 5
        // 5 0
        // 4 1
        // 3 2
        // 3 1 1
        // 2 2 1
        // 2 1 1 1
        // 1 1 1 1 1
        public static void NumberPartitionsExec(int target, int max, string suffix)
        {
            if (target == 0)
                Console.WriteLine(suffix);
            else
            {
                for (int i = 1; i <= max && i <= target; i++)
                    NumberPartitionsExec(target - i, i, i + " " + suffix);
            }
        }
    }
}
