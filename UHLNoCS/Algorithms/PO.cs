using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHLNoCS.Algorithms
{
    public class PO
    {
         /*
	     * Function creates routing table
	     * for circulant net on chip
	     * using PO algorithm.
	     */
        public static int[,] CreateRouting(int[,] Netlist,
                                            int VertexAmount,
                                            int S1,
                                            int S2)
        {
            int PortAmount = Network.PortNumber;
            int[,] Routing = new int[VertexAmount, VertexAmount];

            // for each source
            for (int From = 0; From < VertexAmount; From++)
            {
                // for each destination
                for (int To = 0; To < VertexAmount; To++)
                {
                    // from vertex to itself
                    if (From == To)
                    {
                        Routing[From, To] = PortAmount;
                    }
                    // from vertex to another vertex
                    else
                    {
                        // next vertex index
                        int NextVertex = -1;

                        int S = To - From;

                        if (S < 0)
                        {
                            S = S + VertexAmount;
                        }

                        // going clockwise
                        if (S <= VertexAmount / 2.0)
                        {
                            // big step
                            if (S >= S2)
                            {
                                NextVertex = (S2 + From) % VertexAmount;
                            }
                            // small step
                            else
                            {
                                NextVertex = (S1 + From) % VertexAmount;
                            }
                        }
                        // going counterclockwise
                        else
                        {
                            S = VertexAmount - S;
                            // big step
                            if (S >= S2)
                            {
                                NextVertex = (VertexAmount - S2 + From) % VertexAmount;
                            }
                            // small step
                            else
                            {
                                NextVertex = (VertexAmount - S1 + From) % VertexAmount;
                            }
                        }

                        // source port connected with NextVertex
                        int Port = -1;
                        for (int P = 0; P < PortAmount; P++)
                        {
                            if (Netlist[From, P] == NextVertex)
                            {
                                Port = P;
                            }
                        }

                        // fill Routing
                        Routing[From, To] = Port;
                    }
                }
            }

            return Routing;
        }
    }
}
