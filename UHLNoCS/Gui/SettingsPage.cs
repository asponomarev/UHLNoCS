using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHLNoCS.Models;
using UHLNoCS.Simulation;

namespace UHLNoCS
{
    public partial class MainForm : Form
    {
        public static string SimulationFolderName = "simulations";

        private void ModelAddButton_Click(object sender, EventArgs e)
        {
            TabPage ModelPage = new TabPage();
            ModelPage.Name = ModelPageName;
            ModelPage.Text = "NewModel";
            //{     
                FlowLayoutPanel ModelPageLayoutPanel = new FlowLayoutPanel();
                ModelPageLayoutPanel.Name = ModelPageLayoutPanelName;
                ModelPageLayoutPanel.FlowDirection = FlowDirection.TopDown;
                ModelPageLayoutPanel.AutoSize = true;
                //{
                    FlowLayoutPanel ModelTypeLayoutPanel = new FlowLayoutPanel();
                    ModelTypeLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    ModelTypeLayoutPanel.AutoSize = true;
                    //{
                        Label ModelTypeLabel = new Label();
                        ModelTypeLabel.Text = "Model type";
                        ModelTypeLabel.TextAlign = ContentAlignment.MiddleCenter;
                        ModelTypeLabel.Size = new Size(150, 25);

                        ComboBox ModelTypeComboBox = new ComboBox();
                        ModelTypeComboBox.Name = ModelTypeComboBoxName;
                        ModelTypeComboBox.Items.AddRange(ModelsTypes.All);
                        ModelTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        ModelTypeComboBox.Size = new Size(100, 25);
                        ModelTypeComboBox.SelectedIndexChanged += ModelTypeComboBox_SelectedIndexChanged;
                    //}
                    ModelTypeLayoutPanel.Controls.AddRange(new Control[] { ModelTypeLabel, ModelTypeComboBox });

                    FlowLayoutPanel ModelNameLayoutPanel = new FlowLayoutPanel();
                    ModelNameLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    ModelNameLayoutPanel.AutoSize = true;
                    //{
                        Label ModelNameLabel = new Label();
                        ModelNameLabel.Text = "Model name";
                        ModelNameLabel.TextAlign = ContentAlignment.MiddleCenter;
                        ModelNameLabel.Size = new Size(150, 25);

                        TextBox ModelNameTextBox = new TextBox();
                        ModelNameTextBox.Name = ModelNameTextBoxName;
                        ModelNameTextBox.Text = "NewModel";
                        ModelNameTextBox.Size = new Size(150, 25);
                    //}
                    ModelNameLayoutPanel.Controls.AddRange(new Control[] { ModelNameLabel, ModelNameTextBox });

                    FlowLayoutPanel ModelExeLayoutPanel = new FlowLayoutPanel();
                    ModelExeLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    ModelExeLayoutPanel.AutoSize = true;
                    //{
                        Label ModelExeLabel = new Label();
                        ModelExeLabel.Text = "Model executable file path";
                        ModelExeLabel.TextAlign = ContentAlignment.MiddleCenter;
                        ModelExeLabel.Size = new Size(150, 25);

                        TextBox ModelExeTextBox = new TextBox();
                        ModelExeTextBox.DoubleClick += ModelExeTextBox_DoubleClick;
                        ModelExeTextBox.Name = ModelExeTextBoxName;
                        ModelExeTextBox.Text = "Double-click to select";
                        ModelExeTextBox.Size = new Size(500, 25);
                        ModelExeTextBox.ReadOnly = true;
                    //}
                    ModelExeLayoutPanel.Controls.AddRange(new Control[] { ModelExeLabel, ModelExeTextBox });

                    FlowLayoutPanel ModelResLayoutPanel = new FlowLayoutPanel();
                    ModelResLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    ModelResLayoutPanel.AutoSize = true;
                    //{
                        Label ModelResLabel = new Label();
                        ModelResLabel.Text = "Model results directory path";
                        ModelResLabel.TextAlign = ContentAlignment.MiddleCenter;
                        ModelResLabel.Size = new Size(150, 25);

                        TextBox ModelResTextBox = new TextBox();
                        ModelResTextBox.DoubleClick += ModelResTextBox_DoubleClick;
                        ModelResTextBox.Name = ModelResTextBoxName;
                        ModelResTextBox.Text = "Will be set automatically";
                        ModelResTextBox.Size = new Size(600, 25);
                        ModelResTextBox.Enabled = false;
                        ModelResTextBox.ReadOnly = true;

                        CheckBox ModelResCheckBox = new CheckBox();
                        ModelResCheckBox.Name = ModelResCheckBoxName;
                        ModelResCheckBox.Text = "Select directory automatically (recommended)";
                        ModelResCheckBox.Size = new Size(300, 25);
                        ModelResCheckBox.Checked = true;
                        ModelResCheckBox.CheckedChanged += ModelResCheckBox_CheckedChanged;
                    //}
                    ModelResLayoutPanel.Controls.AddRange(new Control[] { ModelResLabel, ModelResTextBox, ModelResCheckBox });
                //}
                ModelPageLayoutPanel.Controls.AddRange(new Control[] { ModelTypeLayoutPanel, ModelNameLayoutPanel,
                                                                       ModelExeLayoutPanel, ModelResLayoutPanel });
            //}
            ModelPage.Controls.Add(ModelPageLayoutPanel);

            Pages.TabPages.Add(ModelPage);
            Pages.SelectedIndex = Pages.TabCount - 1;

            ModelAddButton.Enabled = false;
        }

        private void SimulationNameButton_Click(object sender, EventArgs e)
        {
            string NewSimulationName = SimulationNameTextBox.Text;

            bool Valid = Common.IsNameValid(NewSimulationName);
            if (!Valid)
            {
                MessageBox.Show("Invalid simulation name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string OldSimulationName = SimulationController.SimulationName;           

            foreach (Model ConnectedModel in SimulationController.Models)
            {
                string OldResPath = ConnectedModel.GetResultsDirectoryPath();
                string NewResPath = OldResPath.Replace(OldSimulationName, NewSimulationName);
                ConnectedModel.SetResultsDirectoryPath(NewResPath);

                string ModelName = ConnectedModel.GetName();
                TextBox ResPathTextBox = (TextBox)Pages.Controls.Find(ModelResTextBoxName + ModelName, true)[0];
                ResPathTextBox.Text = ResPathTextBox.Text.Replace(OldSimulationName, NewSimulationName);

                if (ConnectedModel.GetType() == ModelsTypes.UOCNS)
                {
                    string OldConfigPath = ((UOCNS)ConnectedModel).GetConfigFilePath();
                    string NewConfigPath = OldConfigPath.Replace(OldSimulationName, NewSimulationName);
                    ((UOCNS)ConnectedModel).SetConfigFilePath(NewConfigPath);

                    TextBox ConfigPathTextBox = (TextBox)Pages.Controls.Find(UocnsConfigFilePathTextBoxName + ModelName, true)[0];
                    ConfigPathTextBox.Text = ConfigPathTextBox.Text.Replace(OldSimulationName, NewSimulationName);
                }
                else if (ConnectedModel.GetType() == ModelsTypes.Booksim)
                {
                    string OldConfigPath = ((Booksim)ConnectedModel).GetConfigFilePath();
                    string NewConfigPath = OldConfigPath.Replace(OldSimulationName, NewSimulationName);
                    ((Booksim)ConnectedModel).SetConfigFilePath(NewConfigPath);

                    TextBox ConfigPathTextBox = (TextBox)Pages.Controls.Find(BooksimConfigFilePathTextBoxName + ModelName, true)[0];
                    ConfigPathTextBox.Text = ConfigPathTextBox.Text.Replace(OldSimulationName, NewSimulationName);
                }
                else if (ConnectedModel.GetType() == ModelsTypes.Newxim)
                {
                    string OldConfigPath = ((Newxim)ConnectedModel).GetConfigFilePath();
                    string NewConfigPath = OldConfigPath.Replace(OldSimulationName, NewSimulationName);
                    ((Newxim)ConnectedModel).SetConfigFilePath(NewConfigPath);

                    TextBox ConfigPathTextBox = (TextBox)Pages.Controls.Find(NewximConfigFilePathTextBoxName + ModelName, true)[0];
                    ConfigPathTextBox.Text = ConfigPathTextBox.Text.Replace(OldSimulationName, NewSimulationName);
                }
            }

            SimulationController.SimulationName = NewSimulationName;
        }

        private void SimulationStateTable_SelectionChanged(object sender, EventArgs e)
        {
            SimulationStateTable.ClearSelection();
        }

        private void DeleteModelButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in ModelsStateTable.SelectedRows)
            {
                string ModelName = (string)Row.Cells[0].Value;

                int ModelIndex = SimulationController.FindModelIndex(ModelName);
                ModelsResultsPages.TabPages.RemoveAt(ModelIndex);

                TabPage ModelPage = (TabPage)Pages.Controls.Find(ModelPageName + ModelName, true)[0];
                Pages.Controls.Remove(ModelPage);

                SimulationController.DeleteModel(ModelName);

                SimulationController.ModelsStates.RemoveAt(ModelIndex);
                ModelsStateTable.Rows.RemoveAt(ModelIndex);                
            }

            if (SimulationController.Models.Count == 0)
            {
                DeleteModelButton.Enabled = false;
                StartSimulationButton.Enabled = false;
            }

            ModelsStateTable.ClearSelection();
        }

        private void StartSimulationButton_Click(object sender, EventArgs e)
        {
            // Starting ControllerThread
            SimulationController.ControllerThread = new Thread(ControllerThreadTask);
            SimulationController.ControllerThread.IsBackground = true;
            SimulationController.ControllerThread.Start();
        }       

        private void NewSimulationButton_Click(object sender, EventArgs e)
        {
            SimulationController.ToNewSimulation();           
            UpdateTablesStates();
            ClearResultsTables();

            SimulationNameButton.Enabled = true;
            StartSimulationButton.Enabled = true;
            NewSimulationButton.Enabled = false;
            ModelAddButton.Enabled = true;
            DeleteModelButton.Enabled = true;

            LogsTextBox.Clear();
        }

        private void StopSimulationButton_Click(object sender, EventArgs e)
        {
            int NumErrors = 0;

            foreach (Process ModelProcess in SimulationController.ModelsProcesses)
            {
                try
                {
                    if (!ModelProcess.HasExited)
                    {
                        ModelProcess.Kill();
                    }
                }
                catch (Exception KillException)
                {
                    ToLogsTextBox("Process kill error: " + KillException.Message);
                    NumErrors++;
                }               
            }

            if (NumErrors != 0)
            { 
                MessageBox.Show(NumErrors.ToString() + " errors occured at attempt to stop simulation process", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void StopModelButton_Click(object sender, EventArgs e)
        {
            int NumErrors = 0;

            foreach (DataGridViewRow Row in ModelsStateTable.SelectedRows)
            {
                string ModelName = (string)Row.Cells[0].Value;
                int ModelIndex = SimulationController.FindModelIndex(ModelName);

                try
                {
                    if (!SimulationController.ModelsProcesses[ModelIndex].HasExited)
                    {
                        SimulationController.ModelsProcesses[ModelIndex].Kill();
                    }
                }
                catch (Exception KillException)
                {
                    ToLogsTextBox("Process kill error: " + KillException.Message);
                    NumErrors++;
                }
            }

            if (NumErrors != 0)
            {
                MessageBox.Show(NumErrors.ToString() + " errors occured at attempt to stop model(s) simulation process", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ModelsStateTable.ClearSelection();
        }

    }
}
