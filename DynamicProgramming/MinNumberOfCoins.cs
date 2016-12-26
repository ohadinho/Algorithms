using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicProgramming
{
    public class MinNumberOfCoins
    {
        public static int amountExample1 = 30;
        public static int[] coinTypesExample1 = new int[] { 1, 2, 10, 50 };
        public static int amountExample2 = 11;
        public static int[] coinTypesExample2 = new int[] { 1, 5, 6, 9 };

        // http://www.geeksforgeeks.org/find-minimum-number-of-coins-that-make-a-change/
        // For instance:
        // Input: coins[] = {5, 10, 25}, V = 30
        // Output: 25,5
        // Input: coins[] = {1, 5, 6, 9}, V = 11
        // Output: 6,5
        // 
        // Returns: Dictionary - Key - coin, Value - Number of times used
        private static Dictionary<int,int> NumberOfCoinsForAmount(int amount, int[] coinTypes)
        {
            int currentCoinIndex = coinTypes.Length - 1;
            int currentCoin = -1;
            Dictionary<int, int> coinsUsed = new Dictionary<int, int>();

            // If amount == 0 we're done
            while (amount > 0)
            {
                // Getting the current coin value
                currentCoin = coinTypes[currentCoinIndex];
                if (amount >= currentCoin)
                {
                    // Decreasing total amount by value of current coin - That's how we "use" that coin
                    // For instance:
                    // amount: 11
                    // current coin: 6
                    // amount is now equals 5 (we used the coin: 11 - 6 = 5)
                    amount = amount - currentCoin;

                    // Save this coin in dictionary if it's not there
                    if(!coinsUsed.ContainsKey(currentCoin))
                        coinsUsed.Add(currentCoin,0);
                    
                    // Inc number of usage in this coin by 1
                    coinsUsed[currentCoin]++;
                }
                else
                {
                    // In case the amount is less the current coin value - then we cannot use this coin.
                    // For instance: 
                    // amount: 6
                    // current coin: 9
                    // array: {1, 5, 6, 9}
                    // We need to proceed to the next coin option in the array which is 6
                    currentCoinIndex--;
                }
            }
            
            return coinsUsed;
        }

        public static void MinCoinsForAmount(int amount, int[] coinTypes)
        {
            int minCoins = Int32.MaxValue;
            Dictionary<int, int> minCoinsUsed = new Dictionary<int, int>();

            // For array: { 1, 5, 6, 9 }
            // We would check:
            // { 1, 5, 6, 9 }
            // { 1, 5, 6 }
            // { 1, 5 }
            // { 1 }
            // Because for instance amount = 11 there are few combinations:
            // 9 + 1 + 1
            // 6 + 5
            // 5 + 5 + 1
            // 1 + 1 + ... + 1
            // So we need to get the least coins used: 5 + 6 !
            for (int i = 0; i < coinTypes.Length; i++)
            {
                Dictionary<int, int> currentCoinsUsed = NumberOfCoinsForAmount(amount, coinTypes.Take(coinTypes.Length - i).ToArray<int>());
                int sumCoinsUsed = currentCoinsUsed.Values.Sum();
                if (sumCoinsUsed < minCoins)
                {
                    minCoinsUsed = currentCoinsUsed;
                }
            }

            foreach (KeyValuePair<int, int> coin in minCoinsUsed)
            {
                Console.WriteLine("Coin: " + coin.Key + ", Times Used: " + coin.Value);
            }
        }
    }
}
