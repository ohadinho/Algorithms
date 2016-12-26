using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            MazeClass.Generate(21);
            MazeClass.GetPathBFSQueue(MazeClass.exampleMat);
        }
    }
}
