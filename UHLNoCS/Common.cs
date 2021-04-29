using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UHLNoCS
{
    class Common
    {
        public static string MatrixToString(int[,] Matrix)
        {
            string Result = "\r\n";

            int Rows = Matrix.GetLength(0);
            int Cols = Matrix.GetLength(1);

            for (int Row = 0; Row < Rows; Row++)
            {
                for (int Col = 0; Col < Cols; Col++)
                {
                    Result += Matrix[Row, Col].ToString();
                    if (Col != Cols - 1)
                    {
                        Result += " ";
                    }
                }
                Result += "\r\n";
            }

            return Result;
        }

        public static string GetModelName(string ControlName)
        {
            string Result = "";

            int DelimeterIndex = ControlName.IndexOf('_');
            if (DelimeterIndex != ControlName.Length - 1)
            {
                Result = ControlName.Substring(DelimeterIndex + 1);
            }

            return Result;
        }

        public static string Concatenate(string[] Strings)
        {
            string Result = "";

            for (int Index = 0; Index < Strings.Length; Index++)
            {
                Result += Strings[Index];
                if (Index != Strings.Length - 1)
                {
                    Result += " ";
                }
            }

            return Result;
        }

        public static bool IsNameValid(string Name)
        {
            char[] InvalidSymbols = new char[] { '<', '>', ':', '"', '\\', '/', '|', '*', '?' };
            string[] InvalidNames = new string[] { "CON", "PRN", "AUX", "NUL",
                                                   "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
                                                   "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"};

            if (Name == "") return false;
            if (Name.EndsWith(".")) return false;
            if (Name.EndsWith(" ")) return false;

            foreach (char InvalidSymbol in InvalidSymbols)
            {
                if (Name.Contains(InvalidSymbol))
                    return false;
            }

            foreach (string InvalidName in InvalidNames)
            {
                if (Name.ToUpper() == InvalidName)
                    return false;
            }

            return true;
        }

        public static string ExtractValue(string HtmlString)
        {
            int IndexBefore = HtmlString.IndexOf('>');
            int IndexAfter = HtmlString.IndexOf('<', IndexBefore);
            string Value = HtmlString.Substring(IndexBefore + 1, IndexAfter - IndexBefore - 1);
            if (Value.Contains(','))
            {
                Value = Value.Replace(',', '.');
            }

            return Value;
        }

        public static bool Compare(int[] Arr1, int[] Arr2)
        {
            for (int Index = 0; Index < Arr1.Length; Index++)
            {
                if (Arr1[Index] != Arr2[Index])
                    return false;
            }
            return true;
        }

        public static double[] StringToDouble(string[] Values)
        {
            double[] Result = new double[Values.Length];

            for (int Index = 0; Index < Values.Length; Index++)
            {
                Result[Index] = Double.Parse(Values[Index], CultureInfo.InvariantCulture);
            }

            return Result;
        }

    }

}
