using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Others
{
    class BreakNum
    {
        public const int TestNum = 2539;
        public const int TestNum2 = 953829802;

        public static void BreakNumFunc(int num)
        {            
            while(num > 0)
            {
                int digit = num % 10;
                num = num / 10;
                Console.WriteLine(digit);
            }
        }

        public static void JoinNum()
        {
            string str = Console.ReadLine();
            int num = 0; 
            while (!String.IsNullOrEmpty(str))
            {
                int digit = Convert.ToInt32(str);
                num = num * 10 + digit;
                str = Console.ReadLine();
            }

            Console.WriteLine(num);
        }
    }
}
