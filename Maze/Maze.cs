using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze
{
    // http://stackoverflow.com/questions/16366448/maze-solving-with-breadth-first-search
    // http://www.c-sharpcorner.com/article/generating-maze-using-C-Sharp-and-net/
    // http://www.migapro.com/depth-first-search/
    public class MazeClass
    {        
        public static int[,] exampleMat = new int[,] {
            {0,0,0,0,0,0,0,0,0},
            {-1,-1,-1,0,0,0,0,0,0},
            {0,0,0,-1,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,Int32.MaxValue},
        };

        public class Point
        {
            public int X;
            public int Y;
        }

        public static void GetPathBFSQueue(int[,] mat)
        {
            Queue<Point> q = new Queue<Point>();
            q.Enqueue(new Point() { X = 0, Y = 0 });
            Point current = null;
            // We stepped over the first cell
            mat[0, 0] = 1;

            while (q.Count > 0)
            {
                current = q.Dequeue();

                // If destination found
                if (mat[current.X, current.Y] == Int32.MaxValue)
                {
                    break;
                }
                else
                {
                    PrintMatrix(mat);

                    // Check if this point can be visited (1. Inside array boundaries, 2. Not been visited yet, 3. Not a wall)
                    // UP
                    Point moveTo = new Point() { X = current.X - 1, Y = current.Y };
                    if (IsAvailable(mat,moveTo))
                    {
                        q.Enqueue(moveTo);
                        mat[moveTo.X, moveTo.Y] = mat[current.X, current.Y] + 1;
                    }

                    // DOWN
                    moveTo = new Point() { X = current.X + 1, Y = current.Y };
                    if (IsAvailable(mat,moveTo))
                    {
                        q.Enqueue(moveTo);
                        mat[moveTo.X, moveTo.Y] = mat[current.X, current.Y] + 1;
                    }

                    // RIGHT
                    moveTo = new Point() { X = current.X, Y = current.Y + 1 };
                    if (IsAvailable(mat,moveTo))
                    {
                        q.Enqueue(moveTo);
                        mat[moveTo.X, moveTo.Y] = mat[current.X, current.Y] + 1;
                    }

                    // LEFT
                    moveTo = new Point() { X = current.X, Y = current.Y - 1 };
                    if (IsAvailable(mat,moveTo))
                    {
                        q.Enqueue(moveTo);
                        mat[moveTo.X, moveTo.Y] = mat[current.X, current.Y] + 1;
                    }
                }
            }

            if (q.Count == 0)
                Console.WriteLine("No path found!!!");
            else
                PrintMatrix(mat);            
        }

        private static bool IsAvailable(int[,] mat, Point p)
        {
            bool isInXBoundaries = p.X >= 0 && p.X < mat.GetLength(0);
            bool isInYBoundaries = p.Y >= 0 && p.Y < mat.GetLength(1);

            // arr[p.X,p.Y] == 0   ==> We didn't visit this cell
            bool isAvailable = isInXBoundaries && isInYBoundaries && mat[p.X, p.Y] == 0;

            return isAvailable;
        }

        public static int[,] Generate(int n)
        {
            int[,] mat = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    mat[i, j] = -1;

            int totalCells = (n - 1) * (n - 1);
            int visitedCells = 0;
            Point currentCell = new Point() { X = 5, Y = 7 };
            Stack<Point> cellStack = new Stack<Point>();
            cellStack.Push(currentCell);

            while (cellStack.Count > 0)
            {
                // get a list of the neighboring cells with all 4 walls intact
                List<Point> adjacentCells = GetNeighborsWithWalls(mat, currentCell);

                mat[currentCell.X, currentCell.Y] = 0;

                // test if a cell like this exists
                if (adjacentCells.Count > 0)
                {
                    // yes, choose one of them, and knock down the wall between it and the current cell
                    int randomCell = new Random().Next(0, adjacentCells.Count);
                    Point theCell = ((Point)adjacentCells[randomCell]);
                    KnockDownWall(mat, currentCell, theCell);
                    PrintMatrix(mat);
                    cellStack.Push(currentCell); // push the current cell onto the stack
                    currentCell = theCell; // make the random neighbor the new current cell 
                    visitedCells += 2; // increment the # of cells visited                    
                }
                else // No adjacent cells that haven't been visited, go back to the previous cell
                {
                    if (cellStack.Count > 0)
                        currentCell = (Point)cellStack.Pop();
                }
            }

            PrintMatrix(mat);

            return mat;
        }

        /// <summary>
        /// Gets a list of neighbors that has all walls surrounding it
        /// For instance:
        /// -1 -1 -1 -1 -1 -1        
        /// -1 -1 -1  0 -1  0
        /// -1 -1 -1  0 -1  0
        /// -1 -1 -1  0  0  0
        /// -1 -1 -1 -1 -1 -1
        /// -1 -1 -1 -1 -1 -1
        /// -1 -1 -1 -1 -1 -1
        /// 
        /// (3,3) have two neighbors with all walls surrounding: (3,1) , (5,3)
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        private static List<Point> GetNeighborsWithWalls(int[,] mat, Point current)
        {
            Point topNeighbor = new Point() { X = current.X - 2, Y = current.Y };
            Point bottomNeighbor = new Point() { X = current.X + 2, Y = current.Y };
            Point leftNeighbor = new Point() { X = current.X, Y = current.Y - 2 };
            Point rightNeighbor = new Point() { X = current.X, Y = current.Y + 2 };
            List<Point> neighbors = new List<Point>();
            neighbors.Add(topNeighbor);
            neighbors.Add(bottomNeighbor);
            neighbors.Add(rightNeighbor);
            neighbors.Add(leftNeighbor);

            List<Point> wallPoints = new List<Point>();

            foreach (Point p in neighbors)
            {
                Point pTop = new Point() { X = p.X - 1, Y = p.Y };
                bool isInTopBoundaries = pTop.X >= 0 && pTop.X < mat.GetLength(0) && pTop.Y >= 0 && pTop.Y < mat.GetLength(1) && mat[pTop.X, pTop.Y] == -1;

                Point pBottom = new Point() { X = p.X + 1, Y = p.Y };
                bool isInBottomBoundaries = pBottom.X >= 0 && pBottom.X < mat.GetLength(0) && pBottom.Y >= 0 && pBottom.Y < mat.GetLength(1) && mat[pBottom.X, pBottom.Y] == -1;

                Point pLeft = new Point() { X = p.X, Y = p.Y - 1 };
                bool isInLeftBoundaries = pLeft.X >= 0 && pLeft.X < mat.GetLength(0) && pLeft.Y >= 0 && pLeft.Y < mat.GetLength(1) && mat[pLeft.X, pLeft.Y] == -1;

                Point pRight = new Point() { X = p.X, Y = p.Y + 1 };
                bool isInRightBoundaries = pRight.X >= 0 && pRight.X < mat.GetLength(0) && pRight.Y >= 0 && pRight.Y < mat.GetLength(1) && mat[pRight.X, pRight.Y] == -1;

                if (isInTopBoundaries && isInBottomBoundaries && isInLeftBoundaries && isInRightBoundaries)
                    wallPoints.Add(p);
            }

            return wallPoints;
        }

        /// <summary>
        /// Knocks down a wall between current and neighbor
        /// For instance:
        /// -1 -1 -1 -1 -1 -1        
        /// -1 -1 -1  0 -1  0
        /// -1 -1 -1  0 -1  0
        /// -1 -1 -1  0  0  0
        /// -1 -1 -1 -1 -1 -1
        /// -1 -1 -1 -1 -1 -1
        /// -1 -1 -1 -1 -1 -1
        /// 
        /// If current is (3,3) and neighbor is (5,3) - 
        /// Then (4,3) which is -1 changes to 0 (Knocking down the wall)
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="cell1"></param>
        /// <param name="cell2"></param>
        private static void KnockDownWall(int[,] mat, Point current, Point neighbor)
        {
            // Neighbor on bottom
            if (current.X < neighbor.X && current.Y == neighbor.Y)
                mat[current.X + 1, current.Y] = 0;

            // Neighbor on top
            if (current.X > neighbor.X && current.Y == neighbor.Y)
                mat[current.X - 1, current.Y] = 0;

            // Neighbor on left
            if (current.X == neighbor.X && current.Y > neighbor.Y)
                mat[current.X, current.Y - 1] = 0;

            // Neighbor on right
            if (current.X == neighbor.X && current.Y < neighbor.Y)
                mat[current.X, current.Y + 1] = 0;
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
