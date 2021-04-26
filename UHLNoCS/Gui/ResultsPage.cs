using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHLNoCS.Models;
using UHLNoCS.Simulation;

namespace UHLNoCS
{
    public partial class MainForm : Form
    {
        public static string ResultFileName = "result.csv";

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
            }
        }

        public void FillResultsTables(int ModelIndex, string[,] ModelResults)
        {
            DataGridView Table = (DataGridView)ModelsResultsPages.TabPages[ModelIndex].Controls[0].Controls[0];
            for (int RowIndex = 0; RowIndex < ModelResults.GetLength(0); RowIndex++)
            {
                string[] RowData = new string[ModelResults.GetLength(1)];
                for (int ColIndex = 0; ColIndex < ModelResults.GetLength(1); ColIndex++)
                {
                    RowData[ColIndex] = ModelResults[RowIndex, ColIndex];
                }
                Table.Rows.Add(RowData);
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
                }
            }
            else
            {
                foreach (DataGridViewRow Row in ModelsStateTable.SelectedRows)
                {
                    string ModelName = (string)Row.Cells[0].Value;
                    Model ConnectedModel = SimulationController.FindModel(ModelName);
                    ResultsToCsv(ConnectedModel);
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

    }
}
