using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using UHLNoCS.Models;
using UHLNoCS.Simulation;
using UHLNoCS.Topologies;

namespace UHLNoCS
{
    public partial class MainForm : Form
    {
        public static string ResultFileName = "result.csv";
        public static string ResultGraphFilename = "result.png";

        public void ClearResultsTables()
        {
            foreach (TabPage Page in ModelsResultsPages.TabPages)
            {
                DataGridView Table = (DataGridView)Page.Controls[0].Controls[0];
                int RowsAmount = Table.Rows.Count;
                for (int RowIndex = RowsAmount - 1; RowIndex >= 0; RowIndex--)
                {
                    Table.Rows.RemoveAt(RowIndex);
                }

                Chart Graph = (Chart)Page.Controls[0].Controls[1];
                Graph.Series[0].Points.Clear();
            }
        }

        public void FillResultsTables(int ModelIndex, string[,] ModelResults)
        {
            DataGridView Table = (DataGridView)ModelsResultsPages.TabPages[ModelIndex].Controls[0].Controls[0];
            Chart Graph = (Chart)ModelsResultsPages.TabPages[ModelIndex].Controls[0].Controls[1];

            for (int RowIndex = 0; RowIndex < ModelResults.GetLength(0); RowIndex++)
            {
                string[] RowData = new string[ModelResults.GetLength(1)];
                for (int ColIndex = 0; ColIndex < ModelResults.GetLength(1); ColIndex++)
                {
                    RowData[ColIndex] = ModelResults[RowIndex, ColIndex];
                }
                Table.Rows.Add(RowData);
            }                  
            
            if (SimulationController.Models[ModelIndex].GetType() == ModelsTypes.UOCNS)
            {
                int UocnsXCol = 6;
                int UocnsYCol = 10;

                string[] Xs = new string[Table.RowCount];
                string[] Ys = new string[Table.RowCount];

                for (int Row = 0; Row < Table.RowCount; Row++)
                {
                    Xs[Row] = Table.Rows[Row].Cells[UocnsXCol].Value.ToString();
                    Ys[Row] = Table.Rows[Row].Cells[UocnsYCol].Value.ToString();
                }

                double[] UocnsGraphX = Common.StringToDouble(Xs);
                double[] UocnsGraphY = Common.StringToDouble(Ys);

                string Topology = ((UOCNS)SimulationController.Models[ModelIndex]).GetTopology();
                int Vertices = 0;
                if (Topology == TopologiesTypes.Mesh || Topology == TopologiesTypes.Torus)
                {
                    int Height = int.Parse(((UOCNS)SimulationController.Models[ModelIndex]).GetTopologyArguments()[0]);
                    int Width = int.Parse(((UOCNS)SimulationController.Models[ModelIndex]).GetTopologyArguments()[1]);
                    Vertices = Height * Width;
                }
                else if (Topology == TopologiesTypes.Circulant || Topology == TopologiesTypes.OptimalCirculant)
                {
                    Vertices = int.Parse(((UOCNS)SimulationController.Models[ModelIndex]).GetTopologyArguments()[0]);
                }

                for (int Index = 0; Index < UocnsGraphY.Length; Index++)
                {
                    Graph.Series[0].Points.AddXY(UocnsGraphX[Index] * Vertices, UocnsGraphY[Index] * Vertices);
                }
                
                Graph.ChartAreas[0].AxisX.Maximum = Math.Round(UocnsGraphX.Max() * Vertices, 3);
                Graph.ChartAreas[0].AxisX.Interval = Math.Round(Graph.ChartAreas[0].AxisX.Maximum / 19.0, 3);
                Graph.ChartAreas[0].AxisX.Maximum += Graph.ChartAreas[0].AxisX.Interval;

                Graph.ChartAreas[0].AxisY.Maximum = Math.Round(UocnsGraphY.Max() * Vertices, 3);
                Graph.ChartAreas[0].AxisY.Interval = Math.Round(Graph.ChartAreas[0].AxisY.Maximum / 19.0, 3);
                Graph.ChartAreas[0].AxisY.Maximum += Graph.ChartAreas[0].AxisY.Interval;
            }
            else if (SimulationController.Models[ModelIndex].GetType() == ModelsTypes.Booksim)
            {
                int IterationsAmount = int.Parse(((Booksim)SimulationController.Models[ModelIndex]).GetIterationsAmount());
                double StartInjectionRate = double.Parse(((Booksim)SimulationController.Models[ModelIndex]).GetInjectionRate(), CultureInfo.InvariantCulture);

                double[] BooksimGraphX = new double[IterationsAmount];
                for (int Iteration = 0; Iteration < IterationsAmount; Iteration++)
                {
                    BooksimGraphX[Iteration] = (Iteration + 1) * StartInjectionRate;
                }

                string Topology = ((Booksim)SimulationController.Models[ModelIndex]).GetTopology();
                int Vertices = 1;
                if (Topology == Booksim.Topologies[1] || Topology == Booksim.Topologies[3])
                {
                    int K = int.Parse(((Booksim)SimulationController.Models[ModelIndex]).GetTopologyArguments()[0]);
                    int N = int.Parse(((Booksim)SimulationController.Models[ModelIndex]).GetTopologyArguments()[1]);
                    for (int Dim = 0; Dim < N; Dim++)
                    {
                        Vertices *= K;
                    }
                }

                int BooksimYCol = 7;
                string[] Ys = new string[Table.RowCount];
                for (int Row = 0; Row < Table.RowCount; Row++)
                {
                    Ys[Row] = Table.Rows[Row].Cells[BooksimYCol].Value.ToString();
                }
                double[] BooksimGraphY = Common.StringToDouble(Ys);

                for (int Index = 0; Index < BooksimGraphY.Length; Index++)
                {
                    Graph.Series[0].Points.AddXY(BooksimGraphX[Index] * Vertices, BooksimGraphY[Index] * Vertices);
                }

                Graph.ChartAreas[0].AxisX.Maximum = Math.Round(BooksimGraphX.Max() * Vertices, 3);
                Graph.ChartAreas[0].AxisX.Interval = Math.Round(Graph.ChartAreas[0].AxisX.Maximum / 19.0, 3);
                Graph.ChartAreas[0].AxisX.Maximum += Graph.ChartAreas[0].AxisX.Interval;

                Graph.ChartAreas[0].AxisY.Maximum = Math.Round(BooksimGraphY.Max() * Vertices, 3);
                Graph.ChartAreas[0].AxisY.Interval = Math.Round(Graph.ChartAreas[0].AxisY.Maximum / 19.0, 3);
                Graph.ChartAreas[0].AxisY.Maximum += Graph.ChartAreas[0].AxisY.Interval;
            }
            if (SimulationController.Models[ModelIndex].GetType() == ModelsTypes.Newxim)
            {
                int NewximXCol = 3;
                int NewximYCol = 5;

                string[] Xs = new string[Table.RowCount];
                string[] Ys = new string[Table.RowCount];

                for (int Row = 0; Row < Table.RowCount; Row++)
                {
                    Xs[Row] = Table.Rows[Row].Cells[NewximXCol].Value.ToString();
                    Ys[Row] = Table.Rows[Row].Cells[NewximYCol].Value.ToString();
                }

                double[] NewximGraphX = Common.StringToDouble(Xs);
                double[] NewximGraphY = Common.StringToDouble(Ys);

                for (int Index = 0; Index < NewximGraphY.Length; Index++)
                {
                    Graph.Series[0].Points.AddXY(NewximGraphX[Index], NewximGraphY[Index]);
                }

                Graph.ChartAreas[0].AxisX.Maximum = Math.Round(NewximGraphX.Max(), 3);
                Graph.ChartAreas[0].AxisX.Interval = Math.Round(Graph.ChartAreas[0].AxisX.Maximum / 19.0, 3);
                Graph.ChartAreas[0].AxisX.Maximum += Graph.ChartAreas[0].AxisX.Interval;

                Graph.ChartAreas[0].AxisY.Maximum = Math.Round(NewximGraphY.Max(), 3);
                Graph.ChartAreas[0].AxisY.Interval = Math.Round(Graph.ChartAreas[0].AxisY.Maximum / 19.0, 3);
                Graph.ChartAreas[0].AxisY.Maximum += Graph.ChartAreas[0].AxisY.Interval;
            }

        }

        private void ExportResultsButton_Click(object sender, EventArgs e)
        {
            if (SimulationController.SimulationState[3] != State.Finished)
            {
                MessageBox.Show("It is possible to export results only after the end of a simulation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ModelsStateTable.SelectedRows.Count == 0)
            {
                foreach (Model ConnectedModel in SimulationController.Models)
                {
                    ResultsToCsv(ConnectedModel);

                    int ModelIndex = SimulationController.FindModelIndex(ConnectedModel.GetName());
                    Chart Graph = (Chart)ModelsResultsPages.TabPages[ModelIndex].Controls[0].Controls[1];
                    Graph.SaveImage(ConnectedModel.GetResultsDirectoryPath() + "\\" + ResultGraphFilename, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            else
            {
                foreach (DataGridViewRow Row in ModelsStateTable.SelectedRows)
                {
                    string ModelName = (string)Row.Cells[0].Value;
                    Model ConnectedModel = SimulationController.FindModel(ModelName);
                    ResultsToCsv(ConnectedModel);

                    int ModelIndex = SimulationController.FindModelIndex(ConnectedModel.GetName());
                    Chart Graph = (Chart)ModelsResultsPages.TabPages[ModelIndex].Controls[0].Controls[1];
                    Graph.SaveImage(ConnectedModel.GetResultsDirectoryPath() + "\\" + ResultGraphFilename, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }

        private void ResultsToCsv(Model ConnectedModel)
        {
            int ModelIndex = SimulationController.FindModelIndex(ConnectedModel.GetName());
            DataGridView Table = (DataGridView)ModelsResultsPages.TabPages[ModelIndex].Controls[0].Controls[0];

            string[] Result = new string[Table.RowCount + 1];

            string HeaderString = "";
            for (int ColIndex = 0; ColIndex < Table.ColumnCount; ColIndex++)
            {
                HeaderString += Table.Columns[ColIndex].HeaderText;
                if (ColIndex != Table.ColumnCount - 1)
                {
                    HeaderString += ",";
                }
            }
            Result[0] = HeaderString;

            for (int RowIndex = 0; RowIndex < Table.RowCount; RowIndex++)
            {
                string RowString = "";
                for (int ColIndex = 0; ColIndex < Table.ColumnCount; ColIndex++)
                {
                    RowString += (string)Table.Rows[RowIndex].Cells[ColIndex].Value;
                    if (ColIndex != Table.ColumnCount - 1)
                    {
                        RowString += ",";
                    }                   
                }

                Result[RowIndex + 1] = RowString;
            }

            File.WriteAllLines(ConnectedModel.GetResultsDirectoryPath() + "\\" + ResultFileName, Result);
        }

        private void TablesGraphsButton_Click(object sender, EventArgs e)
        {
            if (TablesGraphsButton.Text == "Show graphs")
            {
                TablesGraphsButton.Text = "Show tables";
                foreach (TabPage ModelResultsPage in ModelsResultsPages.TabPages)
                {
                    ((DataGridView)ModelResultsPage.Controls[0].Controls[0]).Visible = false;
                    ((Chart)ModelResultsPage.Controls[0].Controls[1]).Visible = true;
                }
            }
            else
            {
                TablesGraphsButton.Text = "Show graphs";
                foreach (TabPage ModelResultsPage in ModelsResultsPages.TabPages)
                {
                    ((DataGridView)ModelResultsPage.Controls[0].Controls[0]).Visible = true;
                    ((Chart)ModelResultsPage.Controls[0].Controls[1]).Visible = false;
                }
            }
        }

    }
}
