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

namespace UHLNoCS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void StartSimulationButton_Click(object sender, EventArgs e)
        {
            LogsTextBox.Clear();

            string ProgramPath = ProgramPathTextBox.Text;
            string ProgramArguments = ProgramArgumentsTextBox.Text;

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

    }
}
