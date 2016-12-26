using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Others
{
    class Fibonacci
    {
        public static int Loop(int n)
        {
            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            int firstNum = 0;
            int sum = 1;

            for(int i=2;i<=n;i++)
            {
                int temp = sum;
                sum = sum + firstNum;
                firstNum = temp; 
            }

            return sum;
        }

        public static int Recursion(int n)
        {
            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            return Recursion(n - 1) + Recursion(n - 2);
        }
    }
}
