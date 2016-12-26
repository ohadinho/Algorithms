using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    // http://www.geeksforgeeks.org/greedy-algorithms-set-5-prims-minimum-spanning-tree-mst-2/
    public class Dijkstra
    {
        // A utility function to find the vertex with minimum distance value,
        // from the set of vertices not yet included in shortest path tree
        const int V = 9;

        private static int minDistance(int[] dist, Boolean[] sptSet)
        {
            // Initialize min value
            int min = Int32.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        // A utility function to print the constructed distance array
        private static void printSolution(int[] dist, int[] parent)
        {
            Console.WriteLine("Vertex   Distance from Source  Parent");
            for (int i = 0; i < V; i++)
                Console.WriteLine(i + " \t\t " + dist[i] + " \t\t " + parent[i]);
        }

        // Funtion that implements Dijkstra's single source shortest path
        // algorithm for a graph represented using adjacency matrix
        // representation
        private static void dijkstra(int[,] graph, int src)
        {
            int[] dist = new int[V]; // The output array. dist[i] will hold
                                     // the shortest distance from src to i

            // sptSet[i] will true if vertex i is included in shortest
            // path tree or shortest distance from src to i is finalized
            Boolean[] sptSet = new Boolean[V];

            // Added by Ohad - parent
            int[] parent = new int[V];

            // Initialize all distances as INFINITE and stpSet[] as false
            for (int i = 0; i < V; i++)
            {
                dist[i] = Int32.MaxValue;
                sptSet[i] = false;
            }

            // Distance of source vertex from itself is always 0
            dist[src] = 0;

            // Find shortest path for all vertices
            for (int count = 0; count < V - 1; count++)
            {
                // Pick the minimum distance vertex from the set of vertices
                // not yet processed. u is always equal to src in first
                // iteration.
                int u = minDistance(dist, sptSet);

                // Mark the picked vertex as processed
                sptSet[u] = true;

                // Update dist value of the adjacent vertices of the
                // picked vertex.
                for (int v = 0; v < V; v++)
                {
                    // Update dist[v] only if is not in sptSet, there is an
                    // edge from u to v, and total weight of path from src to
                    // v through u is smaller than current value of dist[v]
                    // PATHS that are not exist doesn't get checked (graph[u,v] != 0)
                    if (!sptSet[v] && graph[u, v] != 0 &&
                            dist[u] != Int32.MaxValue &&
                            dist[u] + graph[u, v] < dist[v])
                    {
                        // Update current shortest distance until now (dist[u] + graph[u,v]) to current vertex (v)
                        dist[v] = dist[u] + graph[u, v];
                        parent[v] = u;
                    }
                }
            }

            // print the constructed distance array
            printSolution(dist, parent);
        }

        public static void Test()
        {
            /* Distance from 0 to 1 is 4.
             * Distance from 1 to 0 is 4.
             * Distance from 1 to 3 is 8.
             * Distance from 1 to 7 is 11 etc.
             * Path from 0 to 4 doesn't exist */
            int[,] graph = new int[,]{
                                      {0, 4, 0, 0, 0, 0, 0, 8, 0},
                                      {4, 0, 8, 0, 0, 0, 0, 11, 0},
                                      {0, 8, 0, 7, 0, 4, 0, 0, 2},
                                      {0, 0, 7, 0, 9, 14, 0, 0, 0},
                                      {0, 0, 0, 9, 0, 10, 0, 0, 0},
                                      {0, 0, 4, 0, 10, 0, 2, 0, 0},
                                      {0, 0, 0, 14, 0, 2, 0, 1, 6},
                                      {8, 11, 0, 0, 0, 0, 1, 0, 7},
                                      {0, 0, 2, 0, 0, 0, 6, 7, 0}
                                     };

            dijkstra(graph, 0);
        }
    }
}
