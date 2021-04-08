using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHLNoCS.Topologies;

namespace UHLNoCS
{
    public partial class MainForm : Form
    {
        public static string CurrentTopology;

        public static string CurrentTopologyArgument1;
        public static string CurrentTopologyArgument2;
        public static string CurrentTopologyArgument3;

        public static string CurrentAlgorithm;

        public static string CurrentAlgorithmArgument;

        public static string CurrentXmlPath;

        public static string TopologyDescription;
        public static string TopologyNetlist;
        public static string TopologyRouting;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ResetParameters();
        }

        private void StartSimulationButton_Click(object sender, EventArgs e)
        {
            ResetParameters();
            LogsTextBox.Clear();

            string ProgramPath = ProgramPathTextBox.Text;
            PrepareArguments(ProgramArgumentsTextBox.Text);
            string ProgramArguments = CurrentXmlPath;

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
        }

        private void ProgramPathTextBox_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog Dialog = new OpenFileDialog())
            {
                Dialog.InitialDirectory = Directory.GetCurrentDirectory();

                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    string Path = Dialog.FileName;
                    ProgramPathTextBox.Text = Path;
                }
            }
        }

        private void ToLogsTextBox(string Text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => LogsTextBox.Text += Text + "\r\n"));
            }
            else
            {
                LogsTextBox.Text += Text + "\r\n";
            }
        }

        private void ProgramArgumentsTextBox_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog Dialog = new OpenFileDialog())
            {
                Dialog.InitialDirectory = Directory.GetCurrentDirectory();

                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    string Path = Dialog.FileName;
                    ProgramArgumentsTextBox.Text = Path;
                }
            }
        }

        private void PrepareArguments(string RawArguments)
        {
            string[] RawArgumentsParts = RawArguments.Split();

            if (RawArgumentsParts.Length == 1)
            {
                CurrentXmlPath = RawArgumentsParts[0];
            }
            else
            {
                CurrentTopology = RawArgumentsParts[0];

                if (CurrentTopology == Common.TopologyMesh)
                {
                    CurrentTopologyArgument1 = RawArgumentsParts[1];
                    CurrentTopologyArgument2 = RawArgumentsParts[2];

                    Mesh NewMesh = new Mesh(Int32.Parse(CurrentTopologyArgument1), Int32.Parse(CurrentTopologyArgument2));
                    NewMesh.CreateNetlist();
                    NewMesh.CreateRouting();

                    TopologyNetlist = MatrixToString(NewMesh.GetNetlist());
                    TopologyRouting = MatrixToString(NewMesh.GetRouting());
                    TopologyDescription = CurrentTopology + "-(" + CurrentTopologyArgument1 + ", " + CurrentTopologyArgument2 + ")";

                    Common.CreateXml(CurrentXmlPath, TopologyDescription, TopologyNetlist, TopologyRouting);
                }

                if (CurrentTopology == Common.TopologyTorus)
                {
                    CurrentTopologyArgument1 = RawArgumentsParts[1];
                    CurrentTopologyArgument2 = RawArgumentsParts[2];

                    Torus NewTorus = new Torus(Int32.Parse(CurrentTopologyArgument1), Int32.Parse(CurrentTopologyArgument2));
                    NewTorus.CreateNetlist();
                    NewTorus.CreateRouting();

                    TopologyNetlist = MatrixToString(NewTorus.GetNetlist());
                    TopologyRouting = MatrixToString(NewTorus.GetRouting());
                    TopologyDescription = CurrentTopology + "-(" + CurrentTopologyArgument1 + ", " + CurrentTopologyArgument2 + ")";

                    Common.CreateXml(CurrentXmlPath, TopologyDescription, TopologyNetlist, TopologyRouting);
                }

                if (CurrentTopology == Common.TopologyCirculant)
                {
                    CurrentTopologyArgument1 = RawArgumentsParts[1];
                    CurrentTopologyArgument2 = RawArgumentsParts[2];
                    CurrentTopologyArgument3 = RawArgumentsParts[3];

                    if (RawArgumentsParts.Length == 4)
                    {
                        CurrentAlgorithm = Common.AlgorithmDijkstra;
                    }
                    else
                    {
                        CurrentAlgorithm = RawArgumentsParts[4];
                        if (CurrentAlgorithm == Common.AlgorithmROU)
                        {
                            if (RawArgumentsParts.Length == 5)
                            {
                                CurrentAlgorithmArgument = "10";
                            }
                            else
                            {
                                CurrentAlgorithmArgument = RawArgumentsParts[5];
                            }
                        }
                    }

                    Circulant NewCirculant = new Circulant(Int32.Parse(CurrentTopologyArgument1), Int32.Parse(CurrentTopologyArgument2), Int32.Parse(CurrentTopologyArgument3));
                    NewCirculant.CreateNetlist();
                    NewCirculant.CreateRouting(NewCirculant.AdjacencyMatrix(NewCirculant.GetNetlist(), Int32.Parse(CurrentTopologyArgument1)), NewCirculant.GetNetlist());

                    TopologyNetlist = MatrixToString(NewCirculant.GetNetlist());
                    TopologyRouting = MatrixToString(NewCirculant.GetRouting());
                    TopologyDescription = CurrentTopology + "-(" + CurrentTopologyArgument1 + ", " + CurrentTopologyArgument2 + ", " + CurrentTopologyArgument3 + ")";

                    Common.CreateXml(CurrentXmlPath, TopologyDescription, TopologyNetlist, TopologyRouting);
                }

                if (CurrentTopology == Common.TopologyOptimalCirculant)
                {
                    CurrentTopologyArgument1 = RawArgumentsParts[1];

                    if (RawArgumentsParts.Length == 2)
                    {
                        CurrentAlgorithm = Common.AlgorithmDijkstra;
                    }
                    else
                    {
                        CurrentAlgorithm = RawArgumentsParts[2];
                        if (CurrentAlgorithm == Common.AlgorithmROU)
                        {
                            if (RawArgumentsParts.Length == 3)
                            {
                                CurrentAlgorithmArgument = "10";
                            }
                            else
                            {
                                CurrentAlgorithmArgument = RawArgumentsParts[4];
                            }
                        }
                    }

                    Circulant NewCirculant = new Circulant(Int32.Parse(CurrentTopologyArgument1));
                    NewCirculant.CreateNetlist();
                    NewCirculant.CreateRouting(NewCirculant.AdjacencyMatrix(NewCirculant.GetNetlist(), Int32.Parse(CurrentTopologyArgument1)), NewCirculant.GetNetlist());

                    TopologyNetlist = MatrixToString(NewCirculant.GetNetlist());
                    TopologyRouting = MatrixToString(NewCirculant.GetRouting());
                    TopologyDescription = CurrentTopology + "-(" + CurrentTopologyArgument1 + ", " + NewCirculant.S1.ToString() + ", " + NewCirculant.S2.ToString() + ")";

                    Common.CreateXml(CurrentXmlPath, TopologyDescription, TopologyNetlist, TopologyRouting);
                }

            }
        }

        private string MatrixToString(int[,] Matrix)
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

        private void ResetParameters()
        {
            CurrentTopology = "";

            CurrentTopologyArgument1 = "";
            CurrentTopologyArgument2 = "";
            CurrentTopologyArgument3 = "";

            CurrentAlgorithm = "";

            CurrentAlgorithmArgument = "";

            CurrentXmlPath = Directory.GetCurrentDirectory() + "\\results\\LastSimulation\\config.xml";

            TopologyDescription = "";
            TopologyNetlist = "";
            TopologyRouting = "";
        }

    }
}
