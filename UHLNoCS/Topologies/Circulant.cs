using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHLNoCS.Algorithms;

namespace UHLNoCS.Topologies
{
    public class Circulant : Network
    {
        // fields
        public int K;  // vertices amount
        public int S1, S2;  // steps
        // public static int K = 7;

        // optimal circulant constructor
        public Circulant(int NewK)
        {
            K = NewK;
            int NewS1 = (int)Math.Round((Math.Sqrt(2 * NewK - 1) - 1) / 2);
            S1 = NewS1;
            S2 = NewS1 + 1;

        }

        // circulant constructor
        public Circulant(int NewK, int NewS1, int NewS2)
        {
            K = NewK;
            S1 = NewS1;
            S2 = NewS2;
        }

        // set methods for netlist and routing
        private void SetNetlist(int[,] NewNetlist)
        {
            Netlist = NewNetlist;
        }

        private void SetRouting(int[,] NewRouting)
        {
            Routing = NewRouting;
        }

        // get methods for netlist and routing
        public int[,] GetNetlist()
        {
            return Netlist;
        }

        public int[,] GetRouting()
        {
            return Routing;
        }

        public void CreateNetlist()
        {
            int[,] NewNetlist = new int[K, Network.PortNumber];

            for (int Id = 0; Id < K; Id++)
            {
                int Zero, One, ZeroPlus, OnePlus;
 
                Zero = Id + S1;
                One = Id + S2;
                OnePlus = One - K;
                ZeroPlus = Zero - K;
                if ((Id + S1) > (K - 1))
                {
                    NewNetlist[Id, 0] = ZeroPlus;
                    NewNetlist[Id, 1] = OnePlus;
                    NewNetlist[ZeroPlus, 3] = Id;
                    NewNetlist[OnePlus, 2] = Id;

                }
                else if ((Id + S2) > (K - 1))
                {
                    NewNetlist[Id, 0] = Zero;
                    NewNetlist[Id, 1] = OnePlus;
                    NewNetlist[Zero, 3] = Id;
                    NewNetlist[OnePlus, 2] = Id;

                }
                else
                {
                    NewNetlist[Id, 0] = Zero;
                    NewNetlist[Id, 1] = One;
                    NewNetlist[Zero, 3] = Id;
                    NewNetlist[One, 2] = Id;
                }
            }

            SetNetlist(NewNetlist);
        }

        public void CreateRouting(int[,] AdjacencyMatrix, int[,] Netlist, string Algorithm, string[] AlgorithmArguments)
        {
            int[,] Routing = new int[K, K];

            if (Algorithm == AlgorithmsTypes.Dijkstra)
            {
                for (int Vertex = 0; Vertex < K; Vertex++)
                {
                    Routing[Vertex, Vertex] = 4;
                }

                List<List<int>> PathForNode;
                PathForNode = Dijkstra.CreateRouting(AdjacencyMatrix, 0);
                Routing = Dijkstra.FillRouting(0, Routing, PathForNode, Netlist);
                for (int Vertex = 1; Vertex < K; Vertex++)
                {
                    int[] PreviousRow = new int[K];
                    for (int Element = 0; Element < K; Element++)
                    {
                        PreviousRow[Element] = Routing[Vertex - 1, Element];
                    }

                    int[] ShiftedRow = Dijkstra.ShiftRight(PreviousRow);
                    for (int Element = 0; Element < K; Element++)
                    {
                        Routing[Vertex, Element] = ShiftedRow[Element];
                    }
                }
            }
            else
            {
                if (Algorithm == AlgorithmsTypes.PO)
                {
                    Routing = PO.CreateRouting(Netlist, K, S1, S2);
                }
                else
                {
                    if (Algorithm == AlgorithmsTypes.ROU)
                    {
                        int Iters = Int32.Parse(AlgorithmArguments[0]);
                        Routing = ROU.CreateRouting(Netlist, K, Iters, S1, S2);
                    }
                    else
                    {
                        if (Algorithm == AlgorithmsTypes.GreedyPromotion)
                        {
                            Routing = GreedyPromotion.CreateRouting(K, S1, S2, Netlist);
                        }
                    }
                }
            }

            SetRouting(Routing);
        }

        public int[,] AdjacencyMatrix(int[,] Netlist, int K)
        {
            int[,] AdjMtx = new int[K, K];

            for (int Row = 0; Row < K; Row++)
            {
                for (int Col = 0; Col < K; Col++)
                {
                    AdjMtx[Row, Col] = 0;
                }
            }

            for (int Row = 0; Row < K; Row++)
            {
                for (int Col = 0; Col < 4; Col++)
                {
                    AdjMtx[Row, Netlist[Row, Col]] = 1;
                    AdjMtx[Netlist[Row, Col], Row] = 1;
                }
            }

            return AdjMtx;
        }
    }
}
