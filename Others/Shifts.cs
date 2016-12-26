using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Others
{
    public class Shifts
    {
        public static void ShiftRight(int number, int moves)
        {
            string strNumber = number.ToString();
            StringBuilder strNewNumber = new StringBuilder(strNumber);

            for (int i = 0; i < strNumber.Length; i++)
            {
                strNewNumber[(i + moves) % (strNumber.Length)] = strNumber[i];
            }
        }

        public static void ShiftLeft(int number, int moves)
        {
            string strNumber = number.ToString();
            StringBuilder strNewNumber = new StringBuilder(strNumber);

            for (int i = 0; i < strNumber.Length; i++)
            {
                strNewNumber[(i - moves + strNewNumber.Length) % (strNumber.Length)] = strNumber[i];
            }
        }
    }
}
