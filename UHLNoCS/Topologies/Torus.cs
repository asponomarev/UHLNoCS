using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHLNoCS.Topologies
{
    // class represents Torus NoC topology
    public class Torus : Mesh
    {
        // constructor
        public Torus(int NewN, int NewM) : base(NewN, NewM)
        {

        }

        // method for creating netlist
        public new void CreateNetlist()
        {
            List<int> LeftList, RightList, UpList, DownList;

            //left
            LeftList = new List<int>();
            for (int Id = M; Id < M * (N - 1); Id += M)
            {
                LeftList.Add(Id);
            }

            //right
            RightList = new List<int>();
            for (int Id = 2 * M - 1; Id < Vertices - 1; Id += M)
            {
                RightList.Add(Id);
            }

            //up
            UpList = new List<int>();
            for (int Id = 1; Id < M - 1; Id++)
            {
                UpList.Add(Id);
            }

            //down
            DownList = new List<int>();
            for (int Id = M * (N - 1) + 1; Id < Vertices - 1; Id++)
            {
                DownList.Add(Id);
            }
            
            int[,] NewNetlist = new int[Vertices, PortNumber];

            for (int Id = 0; Id < Vertices; Id++)
            {
                int Zero = Id - 1;
                int One = Id + M;
                int Two = Id + 1;
                int Three = Id - M;
                
                int ResidualZero = Id + (M - 1);
                int ResidualOne = Id - M * (N - 1);
                int ResidualTwo = Id - (M - 1);
                int ResidualThree = Id + M * (N - 1);

                if (Id == 0)
                {
                    NewNetlist[Id, 0] = ResidualZero;
                    NewNetlist[Id, 1] = One;
                    NewNetlist[Id, 2] = Two;
                    NewNetlist[Id, 3] = ResidualThree;
                }
                else if (Id == M - 1)
                {
                    NewNetlist[Id, 0] = Zero;
                    NewNetlist[Id, 1] = One;
                    NewNetlist[Id, 2] = ResidualTwo;
                    NewNetlist[Id, 3] = ResidualThree;
                }
                else if (Id == M * (N - 1))
                {
                    NewNetlist[Id, 0] = ResidualZero;
                    NewNetlist[Id, 1] = ResidualOne;
                    NewNetlist[Id, 2] = Two;
                    NewNetlist[Id, 3] = Three;
                }
                else if (Id == Vertices - 1)
                {
                    NewNetlist[Id, 0] = Zero;
                    NewNetlist[Id, 1] = ResidualOne;
                    NewNetlist[Id, 2] = ResidualTwo;
                    NewNetlist[Id, 3] = Three;
                }
                else if (LeftList.Contains(Id))
                {
                    NewNetlist[Id, 0] = ResidualZero;
                    NewNetlist[Id, 3] = Three;
                    NewNetlist[Id, 2] = Two;
                    NewNetlist[Id, 1] = One;
                }
                else if (UpList.Contains(Id))
                {
                    NewNetlist[Id, 0] = Zero;
                    NewNetlist[Id, 1] = One;
                    NewNetlist[Id, 2] = Two;
                    NewNetlist[Id, 3] = ResidualThree;
                }
                else if (RightList.Contains(Id))
                {
                    NewNetlist[Id, 0] = Zero;
                    NewNetlist[Id, 1] = One;
                    NewNetlist[Id, 2] = ResidualTwo;
                    NewNetlist[Id, 3] = Three;
                }
                else if (DownList.Contains(Id))
                {
                    NewNetlist[Id, 0] = Zero;
                    NewNetlist[Id, 1] = ResidualOne;
                    NewNetlist[Id, 2] = Two;
                    NewNetlist[Id, 3] = Three;
                }
                else
                {
                    NewNetlist[Id, 0] = Zero;
                    NewNetlist[Id, 1] = One;
                    NewNetlist[Id, 2] = Two;
                    NewNetlist[Id, 3] = Three;
                }
            }

            SetNetlist(NewNetlist);
        }

        // method for creating routing
        public new void CreateRouting()
        {
            int[,] NewRouting = new int[Vertices, Vertices];
            int CurrentRow, TargetRow, CurrentCol, TargetCol;
            for (int Row = 0; Row < Vertices; Row++)
            {
                for (int Col = 0; Col < Vertices; Col++)
                {
                    CurrentRow = Row / M;
                    TargetRow = Col / M;
                    CurrentCol = Row % M;
                    TargetCol = Col % M;

                    if (Row < Col)
                    {
                        if (CurrentRow < TargetRow)
                        {
                            if (NumInterval(CurrentRow, TargetRow, N) >= NumInterval(TargetRow, CurrentRow, N))
                            {
                                NewRouting[Row, Col] = 3;
                            }
                            else
                            {
                                NewRouting[Row, Col] = 1;
                            }

                        }
                        else
                        {
                            if (NumInterval(CurrentCol, TargetCol, M) >= NumInterval(TargetCol, CurrentCol, M))
                            {
                                NewRouting[Row, Col] = 0;
                            }
                            else
                            {
                                NewRouting[Row, Col] = 2;
                            }

                        }
                    }
                    else if (Row > Col)
                    {
                        if (CurrentRow > TargetRow)
                        {
                            if (NumInterval(CurrentRow, TargetRow, N) > NumInterval(TargetRow, CurrentRow, N))
                            {
                                NewRouting[Row, Col] = 3;
                            }
                            else
                            {
                                NewRouting[Row, Col] = 1;
                            }

                        }
                        else
                        {
                            if (NumInterval(CurrentCol, TargetCol, M) > NumInterval(TargetCol, CurrentCol, M))
                            {
                                NewRouting[Row, Col] = 0;
                            }
                            else
                            {
                                NewRouting[Row, Col] = 2;
                            }
                        }
                    }
                    else
                    {
                        NewRouting[Row, Col] = 4;
                    }
                }
            }
            SetRouting(NewRouting);
        }

        // auxiliary method for creating routing
        private int NumInterval(int Start, int End, int Max)
        {
            int Interval;
            if (Start <= End)
            {
                Interval = End - Start;
            }
            else
            {
                Interval = Max - Start + End;
            }
            return Interval;
        }
    }
}
