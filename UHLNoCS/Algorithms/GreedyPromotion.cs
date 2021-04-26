using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHLNoCS.Algorithms
{
    public class GreedyPromotion
    {
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

        public static int GetNodeNumber(int Rows, int Cols, int Row, int Col)
        {
            int Counter = -1;
            for (int I = 0; I < Rows; I++)
            {
                for (int J = 0; J < Cols; J++)
                {
                    Counter += 1;
                    if (I == Row && J == Col)
                    {
                        return Counter;
                    }
                }
            }
            return -1;
        }
        
        public static List<int> FindPath(int[,,] Table, int[] FromPoint, int[] ToPoint)
        {
            int[] Curr = FromPoint;
            List<int> Path = new List<int>();

            int MaxScaler = 0;
            int MaxX = -1;
            int MaxY = -1;

            while (!Common.Compare(Curr, ToPoint))
            {
                int[] FromPointXY = FindXY(Table, Curr);
                int[] ToPointXY = FindXY(Table, ToPoint);

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
                    ScXM1Y = -1;
                }

                if (FromPointXY[0] + 1 < Table.GetLength(0))
                {
                    ScXP1Y = Scaler(FromPoint, ToPoint, GetCoordinates(Table, FromPointXY[0] + 1, FromPointXY[1]));
                }
                else
                {
                    ScXP1Y = -1;
                }

                if (FromPointXY[1] - 1 > -1)
                {
                    ScXYM1 = Scaler(FromPoint, ToPoint, GetCoordinates(Table, FromPointXY[0], FromPointXY[1] - 1));
                }
                else
                {
                    ScXYM1 = -1;
                }

                if (FromPointXY[1] + 1 < Table.GetLength(1))
                {
                    ScXYP1 = Scaler(FromPoint, ToPoint, GetCoordinates(Table, FromPointXY[0], FromPointXY[1] + 1));
                }
                else
                {
                    ScXYP1 = -1;
                }

                if (ScXM1Y > MaxScaler && new int[] { ScXM1Y, ScXP1Y, ScXYM1, ScXYP1 }.Max() == ScXM1Y)
                {
                    MaxScaler = ScXM1Y;
                    MaxX = FromPointXY[0] - 1;
                    MaxY = FromPointXY[1];
                }
                else if (ScXP1Y > MaxScaler && new int[] { ScXM1Y, ScXP1Y, ScXYM1, ScXYP1 }.Max() == ScXP1Y)
                {
                    MaxScaler = ScXP1Y;
                    MaxX = FromPointXY[0] + 1;
                    MaxY = FromPointXY[1];
                }
                else if (ScXYM1 > MaxScaler && new int[] { ScXM1Y, ScXP1Y, ScXYM1, ScXYP1 }.Max() == ScXYM1)
                {
                    MaxScaler = ScXYM1;
                    MaxX = FromPointXY[0];
                    MaxY = FromPointXY[1] - 1;
                }
                else
                {
                    MaxScaler = ScXYP1;
                    MaxX = FromPointXY[0];
                    MaxY = FromPointXY[1] + 1;
                }

                Console.WriteLine("From X  Y: " + FromPointXY[0].ToString() + "  " + FromPointXY[1].ToString());
                Console.WriteLine("To X  Y: " + ToPointXY[0].ToString() + "  " + ToPointXY[1].ToString());
                Console.WriteLine("ScXM1Y  ScXP1Y  ScXYM1  ScXYP1: " + ScXM1Y.ToString() + "  " + ScXP1Y.ToString() + "  " + ScXYM1.ToString() + "  " + ScXYP1.ToString());
                Console.WriteLine("MaxScaler  MaxX  MaxY: " + MaxScaler.ToString() + "  " + MaxX.ToString() + "  " + MaxY.ToString());
                Curr = GetCoordinates(Table, MaxX, MaxY);
                Console.WriteLine("OK\r\n");
 
                Path.Add(GetNodeNumber(Table.GetLength(0), Table.GetLength(1), MaxX, MaxY));
            }

            return Path;
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

                        int NextVertex = FindPath(CoordinatesTable, FromABCD, ToABCD)[0];

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

