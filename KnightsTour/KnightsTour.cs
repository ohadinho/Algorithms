using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsTour
{
    class KnightsTour
    {
        public static int[,] exampleMat = new int[,]
        { 
            { -1, -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1, -1 }
        };

        public static int[,] directions = new int[,] { { 2, 1 }, 
                                                       { 1, 2 }, 
                                                       { -1, 2 }, 
                                                       { -2, 1 }, 
                                                       { -2, -1 },
                                                       { -1, -2 }, 
                                                       { 1, -2 }, 
                                                       { 2, -1 } };

        public static void KnightsTourExec(int[,] mat)
        {
            mat[0, 0] = 0;

            FindRoute(0, 0, mat);
            PrintMatrix(mat);
        }

        private static bool FindRoute(int currentX,int currentY, int[,] mat)
        {
            // If number of steps is 63 - then we actually filled the board
            if (mat[currentX, currentY] == 63)
                return true;

            // Trying each direction
            for (int i = 0; i < directions.GetLength(0); i++)
            {
                int moveToX = currentX + directions[i, 0];
                int moveToY = currentY + directions[i, 1];
                bool isInMat = moveToX >= 0 && moveToX < mat.GetLength(0) && moveToY >= 0 && moveToY < mat.GetLength(1);                
                
                // If it's not possible to move to that direction - continue to next direction
                if(!isInMat || mat[moveToX, moveToY] != -1)
                    continue;
                
                // Move to cell = (Previous cell value + 1)
                mat[moveToX,moveToY] = mat[currentX,currentY] + 1;
                if (FindRoute(moveToX, moveToY, mat))
                {
                    return true;
                }
                else
                {
                    // If route wasn't found - backtrack (set to -1) and continue to next direction (next iteration of the loop)
                    mat[moveToX, moveToY] = -1;
                }
                
            }

            return false;
        }


        /// <summary>
        /// Prints a matrix
        /// </summary>
        /// <param name="mat"></param>
        private static void PrintMatrix(int[,] mat)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] == 0)
                        Console.Write(mat[i, j] + "  ");
                    else
                        Console.Write(mat[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
