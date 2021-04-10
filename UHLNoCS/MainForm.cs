using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHLNoCS.Models;
using UHLNoCS.Topologies;

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

        private void TestButton_Click(object sender, EventArgs e)
        {
            //DateTime TestStart = DateTime.Now;

            ToLogsTextBox("Models creation started");

            string[] args1 = new string[2] { "3", "2" };
            string[] algs1 = new string[1] { "10" };
            UOCNS Uocns1 = new UOCNS(ModelsTypes.UOCNS, "UOCNS1", "C:\\Users\\Lenovo\\Desktop\\VKR\\UOCNS\\jar\\UOCNS.jar",
                                    Directory.GetCurrentDirectory().ToString() + "\\test1", true,
                                    Directory.GetCurrentDirectory().ToString() + "\\test1\\config.xml",
                                    TopologiesTypes.Mesh, args1, "ROU", algs1, UOCNS.DefaultFifoSize, UOCNS.DefaultFifoCount,
                                    UOCNS.DefaultFlitSize, UOCNS.DefaultPacketSizeAvg, UOCNS.DefaultPacketSizeIsFixed,
                                    UOCNS.DefaultPacketPeriodAvg, UOCNS.DefaultCountRun, UOCNS.DefaultCountPacketRx,
                                    UOCNS.DefaultCountPacketRxWarmUp, UOCNS.DefaultIsModeGALS);

            string[] args2 = new string[2] { "2", "3" };
            string[] algs2 = new string[1] { "10" };
            UOCNS Uocns2 = new UOCNS(ModelsTypes.UOCNS, "UOCNS2", "C:\\Users\\Lenovo\\Desktop\\VKR\\UOCNS\\jar\\UOCNS.jar",
                                    Directory.GetCurrentDirectory().ToString() + "\\test2", true,
                                    Directory.GetCurrentDirectory().ToString() + "\\test2\\config.xml",
                                    TopologiesTypes.Mesh, args2, "ROU", algs2, UOCNS.DefaultFifoSize, UOCNS.DefaultFifoCount,
                                    UOCNS.DefaultFlitSize, UOCNS.DefaultPacketSizeAvg, UOCNS.DefaultPacketSizeIsFixed,
                                    UOCNS.DefaultPacketPeriodAvg, UOCNS.DefaultCountRun, UOCNS.DefaultCountPacketRx,
                                    UOCNS.DefaultCountPacketRxWarmUp, UOCNS.DefaultIsModeGALS);

            ToLogsTextBox("Models creation finished");

            Thread TestThread1 = new Thread(TestThreadTask);
            TestThread1.IsBackground = true;
            TestThread1.Start(Uocns1);

            Thread TestThread2 = new Thread(TestThreadTask);
            TestThread2.IsBackground = true;
            TestThread2.Start(Uocns2);

            while (TestThread1.IsAlive && TestThread2.IsAlive)
            {
                Thread.Sleep(100);
            }

            //DateTime TestEnd = DateTime.Now;
            //ToLogsTextBox((TestEnd - TestStart).ToString());
        }

        public void TestThreadTask(object Model)
        {
            UOCNS Uocns = (UOCNS)Model;

            ToLogsTextBox(Uocns.GetName() + " Simulation thread started");
            
            ToLogsTextBox(Uocns.GetName() + " Preparation for simulation started");
            Uocns.PrepareForSimulation();
            ToLogsTextBox(Uocns.GetName() + " Preparation for simulation finished");

            Process Proc = new Process();
            Proc.StartInfo.FileName = Uocns.GetExecutableFilePath();
            Proc.StartInfo.Arguments = Uocns.GetConfigFilePath() + " " + Uocns.GetResultsDirectoryPath();
            Proc.StartInfo.CreateNoWindow = true;

            Proc.Start();
            ToLogsTextBox(Uocns.GetName() + " Simulation process started");

            Proc.WaitForExit();
            int ExitCode = Proc.ExitCode;
            ToLogsTextBox(Uocns.GetName() + " Simulation process finished with exit code " + ExitCode.ToString());

            Proc.Close();

            ToLogsTextBox(Uocns.GetName() + " Simulation thread finished");
        }

    }
}
