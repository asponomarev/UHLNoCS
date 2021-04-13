using System;
using System.Collections.Generic;
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

        /*  старый код работы с новым процессом
        Process Proc = new Process();
            Proc.StartInfo.FileName = ProgramPath;
            Proc.StartInfo.Arguments = ProgramArguments;
            Proc.StartInfo.CreateNoWindow = true;

            try
            {
                bool StartedOk = Proc.Start();
                if (StartedOk)
                {
                    ToLogsTextBox(DateTime.Now.ToString());
                    ToLogsTextBox("Process started");
                    ToLogsTextBox(ProgramPath);
                    ToLogsTextBox(ProgramArguments);

                    Proc.WaitForExit();
                    int ExitCode = Proc.ExitCode;

                    ToLogsTextBox("Process finished with exit code " + ExitCode.ToString());

                    Proc.Close();
                    //
                    string ResultPath = Directory.GetCurrentDirectory() + "\\results";
                    string[] TmpDirs = Directory.GetDirectories(ResultPath);

                    string LastDirName = "";
                    DateTime LastDateTime = DateTime.MinValue;

                    foreach (string Dir in TmpDirs)
                    {
                        if (Directory.GetLastWriteTime(Dir) > LastDateTime)
                        {
                            LastDirName = Dir;
                            LastDateTime = Directory.GetLastWriteTime(Dir);
                        }
                    }
                    //
                    string[] TmpFiles = Directory.GetFiles(LastDirName);

                    string LastFileName = "";
                    LastDateTime = DateTime.MinValue;

                    foreach (string FileName in TmpFiles)
                    {
                        if (File.GetLastWriteTime(FileName) > LastDateTime && FileName.EndsWith(".html"))
                        {
                            LastFileName = FileName;
                            LastDateTime = File.GetLastWriteTime(FileName);
                        }
                    };
                    //
                    ResultsWebBrowser.Navigate(LastFileName);

                    string Text = ResultsWebBrowser.DocumentText;

                    Encoding utf8 = Encoding.GetEncoding("UTF-8");
                    Encoding win1251 = Encoding.GetEncoding("Windows-1251");

                    byte[] utf8Bytes = win1251.GetBytes(Text);
                    byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);

                    ResultsWebBrowser.DocumentText = Text;
                    ResultsWebBrowser.Refresh();
                }
                else
                {
                    ToLogsTextBox("Process start failed");
                }
            }
            catch (Exception Ex)
            {
                ToLogsTextBox("Error in process");
                ToLogsTextBox(Ex.Message);
            }
        */
    }

}
