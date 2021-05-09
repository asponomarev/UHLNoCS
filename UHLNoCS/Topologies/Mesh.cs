using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHLNoCS.Algorithms;

namespace UHLNoCS.Topologies
{
    // class represents Mesh NoC topology
    public class Mesh : Network
    {
        // fields
        protected int N;  // rows
        protected int M;  // columns
        public int Vertices;  // total amount of vertices

        // constructor
        public Mesh(int NewN, int NewM)
        {
            N = NewN;
            M = NewM;
            Vertices = NewN * NewM;
        }

        // get and set methods for field NewNetlist
        protected void SetNetlist(int[,] NewNetlist)
        {
            Netlist = NewNetlist;
        }

        public int[,] GetNetlist()
        {
            return Netlist;
        }

        // get and set methods for field Routing
        protected void SetRouting(int[,] NewRouting)
        {
            Routing = NewRouting;
        }

        public int[,] GetRouting()
        {
            return Routing;
        }

        // method for creating netlist
        public void CreateNetlist()
        {
            List<int> LeftList, RightList, UpList, DownList;

            // left
            LeftList = new List<int>();
            for (int Id = M; Id < M * (N - 1); Id += M)
            {
                LeftList.Add(Id);
            }

            // right
            RightList = new List<int>();
            for (int Id = 2 * M - 1; Id < Vertices - 1; Id += M)
            {
                RightList.Add(Id);
            }

            // up
            UpList = new List<int>();
            for (int Id = 1; Id < M - 1; Id++)
            {
                UpList.Add(Id);
            }

            // down
            DownList = new List<int>();
            for (int Id = M * (N - 1) + 1; Id < Vertices - 1; Id++)
            {
                DownList.Add(Id);
            }

            int[,] NewNetlist = new int[Vertices, PortNumber];

            for (int Id = 0; Id < Vertices; Id++)
            {
                int zero = Id - 1;
                int one = Id + M;
                int two = Id + 1;
                int three = Id - M;
                int disconnect = -1;

                if (Id == 0)
                {
                    NewNetlist[Id, 0] = disconnect;
                    NewNetlist[Id, 1] = one;
                    NewNetlist[Id, 2] = two;
                    NewNetlist[Id, 3] = disconnect;
                }
                else if (Id == M - 1)
                {
                    NewNetlist[Id, 0] = zero;
                    NewNetlist[Id, 1] = one;
                    NewNetlist[Id, 2] = disconnect;
                    NewNetlist[Id, 3] = disconnect;
                }
                else if (Id == M * (N - 1))
                {
                    NewNetlist[Id, 0] = disconnect;
                    NewNetlist[Id, 1] = disconnect;
                    NewNetlist[Id, 2] = two;
                    NewNetlist[Id, 3] = three;
                }
                else if (Id == Vertices - 1)
                {
                    NewNetlist[Id, 0] = zero;
                    NewNetlist[Id, 1] = disconnect;
                    NewNetlist[Id, 2] = disconnect;
                    NewNetlist[Id, 3] = three;
                }
                else if (LeftList.Contains(Id))
                {
                    NewNetlist[Id, 0] = disconnect;
                    NewNetlist[Id, 3] = three;
                    NewNetlist[Id, 2] = two;
                    NewNetlist[Id, 1] = one;
                }
                else if (UpList.Contains(Id))
                {
                    NewNetlist[Id, 0] = zero;
                    NewNetlist[Id, 1] = one;
                    NewNetlist[Id, 2] = two;
                    NewNetlist[Id, 3] = disconnect;
                }
                else if (RightList.Contains(Id))
                {
                    NewNetlist[Id, 0] = zero;
                    NewNetlist[Id, 1] = one;
                    NewNetlist[Id, 2] = disconnect;
                    NewNetlist[Id, 3] = three;
                }
                else if (DownList.Contains(Id))
                {
                    NewNetlist[Id, 0] = zero;
                    NewNetlist[Id, 1] = disconnect;
                    NewNetlist[Id, 2] = two;
                    NewNetlist[Id, 3] = three;
                }
                else
                {
                    NewNetlist[Id, 0] = zero;
                    NewNetlist[Id, 1] = one;
                    NewNetlist[Id, 2] = two;
                    NewNetlist[Id, 3] = three;
                }
            }

            SetNetlist(NewNetlist);
        }

        // method for creating routing
        public void CreateRouting(string Algorithm)
        {
            int[,] NewRouting = new int[Vertices, Vertices];

            if (Algorithm == AlgorithmsTypes.MeshYX)
            {
                int CurrentRow, TargetRow;
                for (int Row = 0; Row < Vertices; Row++)
                {
                    for (int Col = 0; Col < Vertices; Col++)
                    {
                        CurrentRow = Row / M;
                        TargetRow = Col / M;
                        if (Row < Col)
                        {
                            if (CurrentRow < TargetRow)
                            {
                                NewRouting[Row, Col] = 1;
                            }
                            else
                            {
                                NewRouting[Row, Col] = 2;
                            }
                        }
                        else if (Row > Col)
                        {
                            if (CurrentRow > TargetRow)
                            {
                                NewRouting[Row, Col] = 3;
                            }
                            else
                            {
                                NewRouting[Row, Col] = 0;
                            }
                        }
                        else
                        {
                            NewRouting[Row, Col] = 4;
                        }
                    }
                }
            }
            else if (Algorithm == AlgorithmsTypes.GreedyPromotion)
            {
                NewRouting = GreedyPromotion.CreateRouting(N, M, Netlist);
            }


            SetRouting(NewRouting);
        }

    }
}
