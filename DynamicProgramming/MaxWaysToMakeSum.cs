using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    //http://prismoskills.appspot.com/lessons/Dynamic_Programming/Chapter_03_-_Max_ways_in_which_coins_can_make_a_sum.jsp
    class MaxWaysToMakeSum
    {
        public static void MaxWays(int targetSum, int[] coins)
        {            
            // Lookup to store solutions for all sums from
            // 0 to targetSum.
            int[] sums = new int[targetSum + 1];

            // Used to indicate that a solution exists when
            // a coin equal to current sum is used.
            // i.e. sums[sumK-coin] should return 1 when sumK equals coin
            sums[0] = 1;

            // Pick all coins one by one and update the lookup 'sums'
            // to indicate the effect of introducing that coin
            foreach (int coin in coins)
            {
                // For sums less than current coin value, there would be
                // no effect of introducing this coin, hence we begin from  
                // the sum atleast equal in value to current coin
                // כל פעם שמגיעים לגודל המטבע הנוכחי, אז בעצם נוספות עוד אפשרויות
                for (int sumK = coin; sumK <= targetSum; sumK++)
                    sums[sumK] =
                        sums[sumK] + // current coin is not used
                        sums[sumK - coin]; // current coin is used                
            }

            Console.WriteLine("Maximum no of ways = " + sums[targetSum]);
        }

        
        public static void Test()
        {
            MaxWays(10, new int[] { 1, 2 });
            MaxWays(10, new int[] { 1, 2, 3 });
            MaxWays(10, new int[] { 1, 3, 5 });
            MaxWays(10, new int[] { 1, 4, 7 });
        }

    }
}
