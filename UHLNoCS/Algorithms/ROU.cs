using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHLNoCS.Algorithms
{
    public class ROU
    {
        /*
	    * Function creates routing table
	    * for circulant net on chip
	    * using ROU algorithm.
	    */
        public static int[,] CreateRouting(int[,] Netlist,
                                            int VertexAmount,
                                            int IterAmount,
                                            int S1,
                                            int S2)
        {
            int PortAmount = Network.PortNumber;
            int[,] Routing = new int[VertexAmount, VertexAmount];

            //for each source
            for (int From = 0; From < VertexAmount; From++)
            {
                // for each destination
                for (int To = 0; To < VertexAmount; To++)
                {
                    // from vertex To itself
                    if (From == To)
                    {
                        Routing[From, To] = PortAmount;
                    }
                    // from vertex To another vertex
                    else
                    {
                        // next vertex index
                        int NextVertex = -1;
                        NextVertex = FindNext(From, To, IterAmount, VertexAmount, S1, S2);

                        // source port connected with nextVertex
                        int Port = -1;
                        for (int P = 0; P < PortAmount; P++)
                        {
                            if (Netlist[From, P] == NextVertex)
                            {
                                Port = P;
                            }
                        }

                        // fill routing
                        Routing[From, To] = Port;
                    }
                }
            }

            return Routing;
        }

        /*
        * Function finds next vertex on route.
        */
        public static int FindNext(int Src, int Dst, int Iters, int Vertices, int S1, int S2)
        {
            int Next = -1;

            if (Src > Dst)
            {
                Next = Src - StepCicles(Dst, Src, Iters, Vertices, S1, S2);
            }
            else
            {
                Next = Src + StepCicles(Src, Dst, Iters, Vertices, S1, S2);
            }

            if (Next >= Vertices)
            {
                Next = Next - Vertices;
            }
            else
            {
                if (Next < 0)
                {
                    Next = Next + Vertices;
                }
            }

            return Next;
        }

        /*
        * Function finds next step.
        */
        public static int StepCicles(int Src, int Dst, int Iters, int Vertices, int S1, int S2)
        {
            int BestWayR = 0;
            int StepR = 0;
            int BestWayL = 0;
            int StepL = 0;

            int S = Dst - Src;

            int R1 = S / S2 + S % S2;
            int R2 = S / S2 - S % S2 + S2 + 1;

            if (S % S2 == 0)
            {
                BestWayR = R1;
                StepR = S2;
            }
            else
            {
                if (R1 < R2)
                {
                    BestWayR = R1;
                    StepR = S1;
                }
                else
                {
                    BestWayR = R2;
                    StepR = S2;
                }
            }

            if (Iters > 0)
            {
                for (int i = 1; i < Iters + 1; i++)
                {
                    int Ri1 = (S + Vertices * i) / S2 + (S + Vertices * i) % S2;
                    int Ri2 = (S + Vertices * i) / S2 - (S + Vertices * i) % S2 + S2 + 1;
                    if (Ri1 < BestWayR)
                    {
                        BestWayR = Ri1;
                        StepR = S2;
                    }
                    if (Ri2 < BestWayR)
                    {
                        BestWayR = Ri2;
                        StepR = S2;
                    }
                }
            }

            S = Src - Dst + Vertices;
            int L1 = S / S2 + S % S2;
            int L2 = S / S2 - S % S2 + S2 + 1;

            if (S % S2 == 0)
            {
                BestWayL = L1;
                StepL = -S2;
            }
            else
            {
                if (L1 < L2)
                {
                    BestWayL = L1;
                    StepL = -S1;
                }
                else
                {
                    BestWayL = L2;
                    StepL = -S2;
                }
            }

            if (Iters > 0)
            {
                for (int I = 1; I < Iters + 1; I++)
                {
                    int Ri1 = (S + Vertices * I) / S2 + (S + Vertices * I) % S2;
                    int Ri2 = (S + Vertices * I) / S2 - (S + Vertices * I) % S2 + S2 + 1;
                    if (Ri1 < BestWayL)
                    {
                        BestWayL = Ri1;
                        StepL = -S2;
                    }
                    if (Ri2 < BestWayL)
                    {
                        BestWayL = Ri2;
                        StepL = -S2;
                    }
                }
            }

            if (BestWayR < BestWayL)
            {
                return StepR;
            }
            else
            {
                return StepL;
            }
        }
    }
}
