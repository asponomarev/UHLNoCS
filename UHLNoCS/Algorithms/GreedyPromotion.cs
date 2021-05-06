using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHLNoCS.Algorithms
{
    public class GreedyPromotion
    {       
        /*
	    * Function creates routing table
	    * for mesh net on chip
	    * using GreedyPromotion algorithm.
	    */
        public static int CoordinatesAmount = 4;

        public static int[,,] Coordinates(int X, int Y)
        {
            int[] ACenter = new int[] { 0, 0 };
            int[] BCenter = new int[] { 0, Y - 1 };
            int[] CCenter = new int[] { X - 1, 0 };
            int[] DCenter = new int[] { X - 1, Y - 1 };

            int[,,] CoordTable = new int[X, Y, CoordinatesAmount];

            for (int Row = 0; Row < X; Row++)
            {
                for (int Col = 0; Col < Y; Col++)
                {
                    int A = Math.Max(Math.Abs(Row - ACenter[0]), Math.Abs(Col - ACenter[1]));
                    int B = Math.Max(Math.Abs(Row - BCenter[0]), Math.Abs(Col - BCenter[1]));
                    int C = Math.Max(Math.Abs(Row - CCenter[0]), Math.Abs(Col - CCenter[1]));
                    int D = Math.Max(Math.Abs(Row - DCenter[0]), Math.Abs(Col - DCenter[1]));

                    CoordTable[Row, Col, 0] = A;
                    CoordTable[Row, Col, 1] = B;
                    CoordTable[Row, Col, 2] = C;
                    CoordTable[Row, Col, 3] = D;
                }
            }
            return CoordTable;
        }

        public static int[] GetCoordinates(int[,,] Arr, int Row, int Col)
        {
            int CoordinatesLength = Arr.GetLength(2);
            int[] Coordinates = new int[CoordinatesLength];

            for (int Index = 0; Index < CoordinatesLength; Index++)
            {
                Coordinates[Index] = Arr[Row, Col, Index];
            }

            return Coordinates;
        }

        public static int Scaler(int[] PointI, int[] PointJ, int[] PointK)
        {
            return (PointJ[0] - PointI[0]) * (PointK[0] - PointI[0]) + (PointJ[1] - PointI[1]) * (PointK[1] - PointI[1]) + (PointJ[2] - PointI[2]) * (PointK[2] - PointI[2] + (PointJ[3] - PointI[3]) * (PointK[3] - PointI[3]));
        }

        public static int[] FindXY(int[,,] CoordTable, int[] Point)
        {
            for (int Row = 0; Row < CoordTable.GetLength(0); Row++)
            {
                for (int Col = 0; Col < CoordTable.GetLength(1); Col++)
                {
                    if (Common.Compare(Point, GetCoordinates(CoordTable, Row, Col)))
                    {
                        return new int[] { Row, Col };
                    }
                }
            }
            return new int[] { -1, -1 };
        }

        public static int GetNodeNumber(int[,,] Table, int[] Point)
        {
            int Counter = -1;
            //int[] Elem = { 0, 0, 0, 0};
            for (int I = 0; I < Table.GetLength(0); I++)
            {
                for (int J = 0; J < Table.GetLength(1); J++)
                {
                    Counter += 1;
                    int[] Elem = { Table[I, J, 0], Table[I, J, 1], Table[I, J, 2], Table[I, J, 3] };
                    if (Common.Compare(Elem, Point))
                    {
                        return Counter;
                    }
                }
            }
            return -1;
        }

        public static int[] StepToEndPoint(int Rows, int Cols, int MaxX, int MaxY, int ToPointX, int ToPointY)
        {
            int NextX = MaxX;
            int NextY = MaxY;
            if (MaxX > ToPointX && MaxX - 1 > -1)
            {
                NextX = MaxX - 1;
                //NextY = MaxY;
            }
            else if (MaxX < ToPointX && MaxX + 1 < Rows)
            {
                NextX = MaxX + 1;
                //NextY = MaxY;
            }
            else if (MaxY > ToPointY && MaxY - 1 > -1)
            {
                //NextX = MaxX;
                NextY = MaxY - 1;
            }
            else if (MaxY < ToPointY && MaxY + 1 < Cols)
            {
                //NextX = MaxX;
                NextY = MaxY + 1;
            }
            return new int[] { NextX, NextY };
        }

        public static List<int> FindPath(int[,,] Table, int[] FromPoint, int[] ToPoint)
        {
            int[] Curr = FromPoint;
            List<int[]> Path = new List<int[]>();
            Path.Add(Curr);

            List<int> PathNodes = new List<int>();
            PathNodes.Add(GetNodeNumber(Table, Curr));

            int MaxScaler = -1000;
            int MaxX = -1;
            int MaxY = -1;

            while (!Common.Compare(Curr, ToPoint))
            {
                int[] FromPointXY = FindXY(Table, Curr);
                int[] ToPointXY = FindXY(Table, ToPoint);

                bool NextToPoint = (Math.Abs(FromPointXY[0] - ToPointXY[0]) == 1 && Math.Abs(FromPointXY[1] - ToPointXY[1]) == 0) || (Math.Abs(FromPointXY[0] - ToPointXY[0]) == 0 && Math.Abs(FromPointXY[1] - ToPointXY[1]) == 1);
                if (NextToPoint)
                {
                    Curr = ToPoint;
                    // Curr = Common.GetCoordinates(Table, ToPointXY[0], ToPointXY[1]);
                    Path.Add(Curr);

                    PathNodes.Add(GetNodeNumber(Table, Curr));
                }

                else
                {
                    int ScXM1Y = 0;
                    int ScXP1Y = 0;

                    int ScXYM1 = 0;
                    int ScXYP1 = 0;

                    if (FromPointXY[0] - 1 > -1)
                    {
                        ScXM1Y = Scaler(FromPoint, ToPoint, GetCoordinates(Table, FromPointXY[0] - 1, FromPointXY[1]));
                    }
                    else
                    {
                        ScXM1Y = -1000;
                    }

                    if (FromPointXY[0] + 1 < Table.GetLength(0))
                    {
                        ScXP1Y = Scaler(FromPoint, ToPoint, GetCoordinates(Table, FromPointXY[0] + 1, FromPointXY[1]));
                    }
                    else
                    {
                        ScXP1Y = -1000;
                    }

                    if (FromPointXY[1] - 1 > -1)
                    {
                        ScXYM1 = Scaler(FromPoint, ToPoint, GetCoordinates(Table, FromPointXY[0], FromPointXY[1] - 1));
                    }
                    else
                    {
                        ScXYM1 = -1000;
                    }

                    if (FromPointXY[1] + 1 < Table.GetLength(1))
                    {
                        ScXYP1 = Scaler(FromPoint, ToPoint, GetCoordinates(Table, FromPointXY[0], FromPointXY[1] + 1));
                    }
                    else
                    {
                        ScXYP1 = -1000;
                    }

                    bool F = false;
                    if (ScXM1Y >= MaxScaler && new int[] { ScXM1Y, ScXP1Y, ScXYM1, ScXYP1 }.Max() == ScXM1Y && FromPointXY[0] - 1 > -1)
                    {
                        MaxScaler = ScXM1Y;
                        MaxX = FromPointXY[0] - 1;
                        MaxY = FromPointXY[1];
                        F = true;
                    }
                    else if (ScXP1Y >= MaxScaler && new int[] { ScXM1Y, ScXP1Y, ScXYM1, ScXYP1 }.Max() == ScXP1Y && FromPointXY[0] + 1 < Table.GetLength(0))
                    {
                        MaxScaler = ScXP1Y;
                        MaxX = FromPointXY[0] + 1;
                        MaxY = FromPointXY[1];
                        F = true;
                    }
                    else if (ScXYM1 >= MaxScaler && new int[] { ScXM1Y, ScXP1Y, ScXYM1, ScXYP1 }.Max() == ScXYM1 && FromPointXY[1] - 1 > -1)
                    {
                        MaxScaler = ScXYM1;
                        MaxX = FromPointXY[0];
                        MaxY = FromPointXY[1] - 1;
                        F = true;
                    }
                    else if (ScXYP1 >= MaxScaler && new int[] { ScXM1Y, ScXP1Y, ScXYM1, ScXYP1 }.Max() == ScXYP1 && FromPointXY[1] + 1 < Table.GetLength(1))
                    {
                        MaxScaler = ScXYP1;
                        MaxX = FromPointXY[0];
                        MaxY = FromPointXY[1] + 1;
                        F = true;
                    }

                    if (F)
                    {
                        Curr = new int[] { Table[MaxX, MaxY, 0], Table[MaxX, MaxY, 1], Table[MaxX, MaxY, 2], Table[MaxX, MaxY, 3] };
                        // Curr = Common.GetCoordinates(Table, MaxX, MaxY);
                        Path.Add(Curr);

                        PathNodes.Add(GetNodeNumber(Table, Curr));
                    }

                    if (!F && (Common.Compare(Path.Last(), GetCoordinates(Table, MaxX, MaxY)) || Common.Compare(Path[Path.Count - 2], GetCoordinates(Table, MaxX, MaxY))))
                    {
                        int[] NextXY = StepToEndPoint(Table.GetLength(0), Table.GetLength(0), MaxX, MaxY, ToPointXY[0], ToPointXY[1]);
                        Curr = new int[] { Table[NextXY[0], NextXY[1], 0], Table[NextXY[0], NextXY[1], 1], Table[NextXY[0], NextXY[1], 2], Table[NextXY[0], NextXY[1], 3] };
                        // Curr = Common.GetCoordinates(Table, MaxX, MaxY);
                        Path.Add(Curr);

                        PathNodes.Add(GetNodeNumber(Table, Curr));
                    }

                }

                return PathNodes;
            }
            //return Path;
            return PathNodes;
        }

        public static int[,] CreateRouting(int N, int M, int[,] Netlist)
        {
            int VertexAmount = N * M;
            int[,] Routing = new int[VertexAmount, VertexAmount];

            int[,,] CoordinatesTable = Coordinates(N, M);

            for (int From = 0; From < VertexAmount; From++)
            {
                int FromRow = From / M;
                int FromCol = From % M;
                int[] FromABCD = GetCoordinates(CoordinatesTable, FromRow, FromCol);

                for (int To = 0; To < VertexAmount; To++)
                {
                    if (From == To)
                    {
                        Routing[From, To] = Network.PortNumber;
                    }
                    else
                    {
                        int ToRow = To / M;
                        int ToCol = To % M;
                        int[] ToABCD = GetCoordinates(CoordinatesTable, ToRow, ToCol);

                        int NextVertex = FindPath(CoordinatesTable, FromABCD, ToABCD)[1];
                        /* вывод номера следующего узла в консоль
                        можно вывести в окно на вкладке Simulation Logs, если написать ToLogsTextBox вместо Console.WriteLine
                        Console.WriteLine("From X Y: " + FromRow.ToString() + " " + FromCol.ToString());
                        Console.WriteLine("To X Y: " + ToRow.ToString() + " " + ToCol.ToString());
                        Console.WriteLine("Next vertex: " + NextVertex.ToString() + "\r\n");
                        */
                        int Port = -1;
                        for (int PortNumber = 0; PortNumber < Network.PortNumber; PortNumber++)
                        {
                            if (Netlist[From, PortNumber] == NextVertex)
                            {
                                Port = PortNumber;
                            }
                        }

                        Routing[From, To] = Port;
                    }
                }
            }

            return Routing;
        }

    }
}

