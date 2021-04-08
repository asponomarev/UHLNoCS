using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHLNoCS.Algorithms
{
    public class Dijkstra
    {
        private static int NoParent = -1;

        // Function that implements Dijkstra's
        // single source shortest path
        // algorithm for a graph represented
        // by adjacency matrix
        public static List<List<int>> CreateRouting(int[,] AdjacencyMatrix, int StartVertex)
        {
            int VerticesAmount = AdjacencyMatrix.GetLength(0);

            // shortestDistances[i] will hold the
            // shortest distance from src to i
            int[] ShortestDistances = new int[VerticesAmount];

            // added[i] will true if vertex i is
            // included / in shortest path tree
            // or shortest distance from src to
            // i is finalized
            bool[] Added = new bool[VerticesAmount];

            // Initialize all distances as
            // INFINITE and added[] as false
            for (int VertexIndex = 0; VertexIndex < VerticesAmount; VertexIndex++)
            {
                ShortestDistances[VertexIndex] = int.MaxValue;
                Added[VertexIndex] = false;
            }

            // Distance of source vertex from
            // itself is always 0
            ShortestDistances[StartVertex] = 0;

            // Parent array to store shortest
            // path tree
            int[] Parents = new int[VerticesAmount];

            // The starting vertex does not
            // have a parent
            Parents[StartVertex] = NoParent;

            // Find shortest path for all
            // vertices
            for (int Vertex = 1; Vertex < VerticesAmount; Vertex++)
            {
                // Pick the minimum distance vertex
                // from the set of vertices not yet
                // processed. nearestVertex is
                // always equal to startNode in
                // first iteration.
                int NearestVertex = -1;
                int ShortestDistance = int.MaxValue;
                for (int VertexIndex = 0; VertexIndex < VerticesAmount; VertexIndex++)
                {
                    if (!Added[VertexIndex] && ShortestDistances[VertexIndex] < ShortestDistance)
                    {
                        NearestVertex = VertexIndex;
                        ShortestDistance = ShortestDistances[VertexIndex];
                    }
                }

                // Mark the picked vertex as
                // processed
                Added[NearestVertex] = true;

                // Update dist value of the
                // adjacent vertices of the
                // picked vertex.
                for (int VertexIndex = 0; VertexIndex < VerticesAmount; VertexIndex++)
                {
                    int EdgeDistance = AdjacencyMatrix[NearestVertex, VertexIndex];

                    if (EdgeDistance > 0 && ((ShortestDistance + EdgeDistance) < ShortestDistances[VertexIndex]))
                    {
                        Parents[VertexIndex] = NearestVertex;
                        ShortestDistances[VertexIndex] = ShortestDistance + EdgeDistance;
                    }
                }
            }

            return GetPathsForVertex(StartVertex, ShortestDistances, Parents);
        }

        // A utility function to print
        // the constructed distances
        // array and shortest paths
        private static List<List<int>> GetPathsForVertex(int StartVertex, int[] Distances, int[] Parents)
        {
            int VerticesAmount = Distances.Length;
            Console.Write("Vertex\tDistance\tPath");
            List<List<int>> pathForNode = new List<List<int>>();
            for (int VertexIndex = 0; VertexIndex < VerticesAmount; VertexIndex++)
            {
                List<int> path = new List<int>();
                if (VertexIndex != StartVertex)
                {

                    Console.Write("\n" + StartVertex + " -> ");
                    Console.Write(VertexIndex + " \t\t ");
                    Console.Write(Distances[VertexIndex] + "\t\t");
                    PrintPath(VertexIndex, Parents, path);

                }
                pathForNode.Add(path);
            }
            Console.WriteLine();
            return pathForNode;
        }

        // Function to print shortest path
        // from source to currentVertex
        // using parents array
        private static void PrintPath(int CurrentVertex, int[] Parents, List<int> Path)
        {

            // Base case : Source node has
            // been processed
            if (CurrentVertex == NoParent)
            {
                return;
            }
            PrintPath(Parents[CurrentVertex], Parents, Path);
            Path.Add(CurrentVertex);
            Console.Write(CurrentVertex + " ");
        }

        public static int[,] FillRouting(int CurrentNode, int[,] Routing, List<List<int>> PathForNode, int[,] Netlist)
        {
            int[,] FullRouting = Routing;
            for (int Vertex = 0; Vertex < PathForNode.Count; Vertex++)
            {
                if (PathForNode[Vertex].Count > 0)
                {
                    int X1 = PathForNode[Vertex][0];
                    int X2 = PathForNode[Vertex][1];
                    int Port = FindPort(Netlist, X1, X2);
                    FullRouting[CurrentNode, Vertex] = Port;
                }
            }
            return FullRouting;
        }

        private static int FindPort(int[,] Netlist, int Sourse, int Target)
        {
            int Port = -1;
            for (int PortAmount = 0; PortAmount < 4; PortAmount++)
            {
                if (Netlist[Sourse, PortAmount] == Target)
                {
                    Port = PortAmount;
                }
            }
            return Port;
        }

        public static int[] ShiftRight(int[] Row)
        {
            int[] NewRow = new int[Row.Length];
            int Last = Row[Row.Length - 1];  // save off first element

            // shift right
            for (int Index = Row.Length - 2; Index >= 0; Index--)
                NewRow[Index + 1] = Row[Index];

            // wrap last element into first slot
            NewRow[0] = Last;
            return NewRow;
        }

    }
}
