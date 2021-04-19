using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHLNoCS.Algorithms;
using UHLNoCS.Models;
using UHLNoCS.Simulation;
using UHLNoCS.Topologies;

namespace UHLNoCS
{
    public partial class MainForm : Form
    {
        public static string ModelPageName = "ModelPage_";
        public static string ModelPageLayoutPanelName = "ModelPageLayoutPanel_";
        public static string ModelTypeComboBoxName = "ModelTypeComboBox_";
        public static string ModelNameTextBoxName = "ModelNameTextBox_";
        public static string ModelExeTextBoxName = "ModelExeTextBox_";
        public static string ModelResTextBoxName = "ModelResTextBox_";
        public static string ModelResCheckBoxName = "ModelResCheckBox_";

        public static string UocnsConfigGenerationRequiredCheckBoxName = "UocnsConfigGenerationRequiredCheckBox_";
        public static string UocnsConfigFilePathTextBoxName = "UocnsConfigFilePathTextBox_";
        public static string UocnsTopologyComboBoxName = "UocnsTopologyComboBox_";
        public static string UocnsTopologyArgumentsTextBoxName = "UocnsTopologyArgumentsTextBox_";
        public static string UocnsAlgorithmComboBoxName = "UocnsAlgorithmComboBox_";
        public static string UocnsAlgorithmArgumentsTextBoxName = "UocnsAlgorithmArgumentsTextBox_";
        public static string UocnsFifoSizeTextBoxName = "UocnsFifoSizeTextBox_";
        public static string UocnsFifoCountTextBoxName = "UocnsFifoCountTextBox_";
        public static string UocnsFlitSizeTextBoxName = "UocnsFlitSizeTextBox_";
        public static string UocnsPacketSizeAvgTextBoxName = "UocnsPacketSizeAvgTextBox_";
        public static string UocnsPacketSizeIsFixedComboBoxName = "UocnsPacketSizeIsFixedComboBox_";
        public static string UocnsPacketPeriodAvgTextBoxName = "UocnsPacketPeriodAvgTextBox_";
        public static string UocnsCountRunTextBoxName = "UocnsCountRunTextBox_";
        public static string UocnsCountPacketRxTextBoxName = "UocnsCountPacketRxTextBox_";
        public static string UocnsCountPacketRxWarmUpTextBoxName = "UocnsCountPacketRxWarmUpTextBox_";
        public static string UocnsIsModeGALSComboBoxName = "UocnsIsModeGALSComboBox_";

        public static string ModelAddButtonName = "ModelAddButton_";
        public static string ModelSaveButtonName = "ModelSaveButton_";
        public static string ModelCurrentButtonName = "ModelCurrentButton_";
        public static string ModelDeleteButtonName = "ModelDeleteButton_";

        private void ModelTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((ComboBox)Pages.Controls.Find(((ComboBox)sender).Name, true)[0]).Enabled = false;

            string ModelType = ((ComboBox)Pages.Controls.Find(((ComboBox)sender).Name, true)[0]).Text;
            if (ModelType == ModelsTypes.UOCNS)
            {
                FlowLayoutPanel ModelPageLayoutPanel = (FlowLayoutPanel)Pages.Controls.Find(ModelPageLayoutPanelName, true)[0];
                //{
                    FlowLayoutPanel UocnsConfigFileLayoutPanel = new FlowLayoutPanel();
                    UocnsConfigFileLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    UocnsConfigFileLayoutPanel.AutoSize = true;
                    UocnsConfigFileLayoutPanel.Margin = new Padding(3, 13, 3, 3);
                    //{
                        Label UocnsConfigFileLabel = new Label();
                        UocnsConfigFileLabel.Text = "Configuration file path";
                        UocnsConfigFileLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsConfigFileLabel.Size = new Size(150, 25);

                        TextBox UocnsConfigFileTextBox = new TextBox();
                        UocnsConfigFileTextBox.DoubleClick += ModelExeTextBox_DoubleClick;
                        UocnsConfigFileTextBox.Name = UocnsConfigFilePathTextBoxName;
                        UocnsConfigFileTextBox.Text = "Will be set automatically";
                        UocnsConfigFileTextBox.Size = new Size(600, 25);
                        UocnsConfigFileTextBox.ReadOnly = true;
                        UocnsConfigFileTextBox.Enabled = false;

                        CheckBox UocnsConfigFileCheckBox = new CheckBox();
                        UocnsConfigFileCheckBox.Name = UocnsConfigGenerationRequiredCheckBoxName;
                        UocnsConfigFileCheckBox.Text = "Cofiguration file generation required";
                        UocnsConfigFileCheckBox.Size = new Size(300, 25);
                        UocnsConfigFileCheckBox.Checked = true;
                        UocnsConfigFileCheckBox.CheckedChanged += UocnsConfigFileCheckBox_CheckedChanged;
                    //}
                    UocnsConfigFileLayoutPanel.Controls.AddRange(new Control[] { UocnsConfigFileLabel, UocnsConfigFileTextBox, UocnsConfigFileCheckBox });

                    FlowLayoutPanel UocnsTopologyLayoutPanel = new FlowLayoutPanel();
                    UocnsTopologyLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    UocnsTopologyLayoutPanel.AutoSize = true;
                    //{
                        Label UocnsTopologyLabel = new Label();
                        UocnsTopologyLabel.Text = "NoC topology";
                        UocnsTopologyLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsTopologyLabel.Size = new Size(150, 25);

                        ComboBox UocnsTopologyComboBox = new ComboBox();
                        UocnsTopologyComboBox.Name = UocnsTopologyComboBoxName;
                        UocnsTopologyComboBox.Size = new Size(100, 25);
                        UocnsTopologyComboBox.Items.AddRange(new string[] { TopologiesTypes.Mesh, TopologiesTypes.Torus, TopologiesTypes.Circulant, TopologiesTypes.OptimalCirculant });
                        UocnsTopologyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        UocnsTopologyComboBox.SelectedIndex = 0;
                        UocnsTopologyComboBox.SelectedIndexChanged += UocnsTopologyComboBox_SelectedIndexChanged;

                        Label UocnsTopologyArgsLabel = new Label();
                        UocnsTopologyArgsLabel.Text = "Topology arguments";
                        UocnsTopologyArgsLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsTopologyArgsLabel.Size = new Size(150, 25);

                        TextBox UocnsTopologyArgsTextBox = new TextBox();
                        UocnsTopologyArgsTextBox.Name = UocnsTopologyArgumentsTextBoxName;
                        UocnsTopologyArgsTextBox.Text = "2 2";
                        UocnsTopologyArgsTextBox.Size = new Size(100, 25);
                    //}
                    UocnsTopologyLayoutPanel.Controls.AddRange(new Control[] { UocnsTopologyLabel, UocnsTopologyComboBox, UocnsTopologyArgsLabel, UocnsTopologyArgsTextBox });

                    FlowLayoutPanel UocnsAlgorithmLayoutPanel = new FlowLayoutPanel();
                    UocnsAlgorithmLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    UocnsAlgorithmLayoutPanel.AutoSize = true;
                    //{
                        Label UocnsAlgorithmLabel = new Label();
                        UocnsAlgorithmLabel.Text = "Routing algorithm";
                        UocnsAlgorithmLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsAlgorithmLabel.Size = new Size(150, 25);

                        ComboBox UocnsAlgorithmComboBox = new ComboBox();
                        UocnsAlgorithmComboBox.Name = UocnsAlgorithmComboBoxName;
                        UocnsAlgorithmComboBox.Size = new Size(100, 25);
                        UocnsAlgorithmComboBox.Items.AddRange(new string[] { AlgorithmsTypes.Dijkstra, AlgorithmsTypes.PO, AlgorithmsTypes.ROU });
                        UocnsAlgorithmComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        UocnsAlgorithmComboBox.Enabled = false;
                        UocnsAlgorithmComboBox.SelectedIndexChanged += UocnsAlgorithmComboBox_SelectedIndexChanged;

                        Label UocnsAlgorithmArgsLabel = new Label();
                        UocnsAlgorithmArgsLabel.Text = "Algorithm arguments";
                        UocnsAlgorithmArgsLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsAlgorithmArgsLabel.Size = new Size(150, 25);

                        TextBox UocnsAlgorithmArgsTextBox = new TextBox();
                        UocnsAlgorithmArgsTextBox.Name = UocnsAlgorithmArgumentsTextBoxName;
                        UocnsAlgorithmArgsTextBox.Text = "";
                        UocnsAlgorithmArgsTextBox.Size = new Size(100, 25);
                        UocnsAlgorithmArgsTextBox.Enabled = false;
                    //}
                    UocnsAlgorithmLayoutPanel.Controls.AddRange(new Control[] { UocnsAlgorithmLabel, UocnsAlgorithmComboBox, UocnsAlgorithmArgsLabel, UocnsAlgorithmArgsTextBox });

                    FlowLayoutPanel UocnsFifoLayoutPanel = new FlowLayoutPanel();
                    UocnsFifoLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    UocnsFifoLayoutPanel.AutoSize = true;
                    UocnsFifoLayoutPanel.Margin = new Padding(3, 13, 3, 3);
                    //{
                        Label UocnsFifoSizeLabel = new Label();
                        UocnsFifoSizeLabel.Text = "FifoSize";
                        UocnsFifoSizeLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsFifoSizeLabel.Size = new Size(150, 25);

                        TextBox UocnsFifoSizeTextBox = new TextBox();
                        UocnsFifoSizeTextBox.Name = UocnsFifoSizeTextBoxName;
                        UocnsFifoSizeTextBox.Text = UOCNS.DefaultFifoSize;
                        UocnsFifoSizeTextBox.Size = new Size(100, 25);

                        Label UocnsFifoCountLabel = new Label();
                        UocnsFifoCountLabel.Text = "FifoCount";
                        UocnsFifoCountLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsFifoCountLabel.Size = new Size(150, 25);

                        TextBox UocnsFifoCountTextBox = new TextBox();
                        UocnsFifoCountTextBox.Name = UocnsFifoCountTextBoxName;
                        UocnsFifoCountTextBox.Text = UOCNS.DefaultFifoCount;
                        UocnsFifoCountTextBox.Size = new Size(100, 25);
                    //}
                    UocnsFifoLayoutPanel.Controls.AddRange(new Control[] { UocnsFifoSizeLabel, UocnsFifoSizeTextBox, UocnsFifoCountLabel, UocnsFifoCountTextBox });

                    FlowLayoutPanel UocnsFlitLayoutPanel = new FlowLayoutPanel();
                    UocnsFlitLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    UocnsFlitLayoutPanel.AutoSize = true;
                    //{
                        Label UocnsFlitSizeLabel = new Label();
                        UocnsFlitSizeLabel.Text = "FlitSize";
                        UocnsFlitSizeLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsFlitSizeLabel.Size = new Size(150, 25);

                        TextBox UocnsFlitSizeTextBox = new TextBox();
                        UocnsFlitSizeTextBox.Name = UocnsFlitSizeTextBoxName;
                        UocnsFlitSizeTextBox.Text = UOCNS.DefaultFlitSize;
                        UocnsFlitSizeTextBox.Size = new Size(100, 25);
                    //}
                    UocnsFlitLayoutPanel.Controls.AddRange(new Control[] { UocnsFlitSizeLabel, UocnsFlitSizeTextBox });

                    FlowLayoutPanel UocnsPacketLayoutPanel = new FlowLayoutPanel();
                    UocnsPacketLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    UocnsPacketLayoutPanel.AutoSize = true;
                    //{
                        Label UocnsPacketSizeAvgLabel = new Label();
                        UocnsPacketSizeAvgLabel.Text = "PacketSizeAvg";
                        UocnsPacketSizeAvgLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsPacketSizeAvgLabel.Size = new Size(150, 25);

                        TextBox UocnsPacketSizeAvgTextBox = new TextBox();
                        UocnsPacketSizeAvgTextBox.Name = UocnsPacketSizeAvgTextBoxName;
                        UocnsPacketSizeAvgTextBox.Text = UOCNS.DefaultPacketSizeAvg;
                        UocnsPacketSizeAvgTextBox.Size = new Size(100, 25);        

                        Label UocnsPacketSizeIsFixedLabel = new Label();
                        UocnsPacketSizeIsFixedLabel.Text = "PacketSizeIsFixed";
                        UocnsPacketSizeIsFixedLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsPacketSizeIsFixedLabel.Size = new Size(150, 25);

                        ComboBox UocnsPacketSizeIsFixedComboBox = new ComboBox();
                        UocnsPacketSizeIsFixedComboBox.Name = UocnsPacketSizeIsFixedComboBoxName;
                        UocnsPacketSizeIsFixedComboBox.Size = new Size(100, 25);
                        UocnsPacketSizeIsFixedComboBox.Items.AddRange(new string[] { "true", "false" });
                        UocnsPacketSizeIsFixedComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        UocnsPacketSizeIsFixedComboBox.SelectedIndex = 0;

                        Label UocnsPacketPeriodAvgLabel = new Label();
                        UocnsPacketPeriodAvgLabel.Text = "PacketPeriodAvg";
                        UocnsPacketPeriodAvgLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsPacketPeriodAvgLabel.Size = new Size(150, 25);

                        TextBox UocnsPacketPeriodAvgTextBox = new TextBox();
                        UocnsPacketPeriodAvgTextBox.Name = UocnsPacketPeriodAvgTextBoxName;
                        UocnsPacketPeriodAvgTextBox.Text = UOCNS.DefaultPacketPeriodAvg;
                        UocnsPacketPeriodAvgTextBox.Size = new Size(100, 25);
                    //}
                    UocnsPacketLayoutPanel.Controls.AddRange(new Control[] { UocnsPacketSizeAvgLabel, UocnsPacketSizeAvgTextBox, UocnsPacketSizeIsFixedLabel,
                                                                                UocnsPacketSizeIsFixedComboBox, UocnsPacketPeriodAvgLabel, UocnsPacketPeriodAvgTextBox});

                    FlowLayoutPanel UocnsCountRunLayoutPanel = new FlowLayoutPanel();
                    UocnsCountRunLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    UocnsCountRunLayoutPanel.AutoSize = true;
                    //{
                        Label UocnsCountRunLabel = new Label();
                        UocnsCountRunLabel.Text = "CountRun";
                        UocnsCountRunLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsCountRunLabel.Size = new Size(150, 25);

                        TextBox UocnsCountRunTextBox = new TextBox();
                        UocnsCountRunTextBox.Name = UocnsCountRunTextBoxName;
                        UocnsCountRunTextBox.Text = UOCNS.DefaultCountRun;
                        UocnsCountRunTextBox.Size = new Size(100, 25);
                    //}
                    UocnsCountRunLayoutPanel.Controls.AddRange(new Control[] { UocnsCountRunLabel, UocnsCountRunTextBox });

                    FlowLayoutPanel UocnsRxLayoutPanel = new FlowLayoutPanel();
                    UocnsRxLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    UocnsRxLayoutPanel.AutoSize = true;
                    //{
                        Label UocnsRxLabel = new Label();
                        UocnsRxLabel.Text = "CountPacketRx";
                        UocnsRxLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsRxLabel.Size = new Size(150, 25);

                        TextBox UocnsRxTextBox = new TextBox();
                        UocnsRxTextBox.Name = UocnsCountPacketRxTextBoxName;
                        UocnsRxTextBox.Text = UOCNS.DefaultCountPacketRx;
                        UocnsRxTextBox.Size = new Size(100, 25);

                        Label UocnsRxWarmUpLabel = new Label();
                        UocnsRxWarmUpLabel.Text = "CountPacketRxWarmUp";
                        UocnsRxWarmUpLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsRxWarmUpLabel.Size = new Size(150, 25);

                        TextBox UocnsRxWarmUpTextBox = new TextBox();
                        UocnsRxWarmUpTextBox.Name = UocnsCountPacketRxWarmUpTextBoxName;
                        UocnsRxWarmUpTextBox.Text = UOCNS.DefaultCountPacketRxWarmUp;
                        UocnsRxWarmUpTextBox.Size = new Size(100, 25);
                    //}
                    UocnsRxLayoutPanel.Controls.AddRange(new Control[] { UocnsRxLabel, UocnsRxTextBox, UocnsRxWarmUpLabel, UocnsRxWarmUpTextBox });

                    FlowLayoutPanel UocnsGALSLayoutPanel = new FlowLayoutPanel();
                    UocnsGALSLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    UocnsGALSLayoutPanel.AutoSize = true;
                    //{
                        Label UocnsGALSLabel = new Label();
                        UocnsGALSLabel.Text = "IsModeGALS";
                        UocnsGALSLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsGALSLabel.Size = new Size(150, 25);

                        ComboBox UocnsGALSComboBox = new ComboBox();
                        UocnsGALSComboBox.Name = UocnsIsModeGALSComboBoxName;
                        UocnsGALSComboBox.Size = new Size(100, 25);
                        UocnsGALSComboBox.Items.AddRange(new string[] { "true", "false" });
                        UocnsGALSComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        UocnsGALSComboBox.SelectedIndex = 1;
                    //}
                    UocnsGALSLayoutPanel.Controls.AddRange(new Control[] { UocnsGALSLabel, UocnsGALSComboBox });

                    FlowLayoutPanel ButtonsLayoutPanel = new FlowLayoutPanel();
                    ButtonsLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    ButtonsLayoutPanel.AutoSize = true;
                    ButtonsLayoutPanel.Margin = new Padding(3, 13, 3, 3);
                    //{
                        Button AddButton = new Button();
                        AddButton.Name = ModelAddButtonName;
                        AddButton.Text = "Add";
                        AddButton.Size = new Size(150, 25);
                        AddButton.Click += AddButton_Click;

                        Button CurrentButton = new Button();
                        CurrentButton.Name = ModelCurrentButtonName;
                        CurrentButton.Text = "Current";
                        CurrentButton.Size = new Size(150, 25);
                        CurrentButton.Click += CurrentButton_Click;
                        CurrentButton.Enabled = false;

                        Button SaveButton = new Button();
                        SaveButton.Name = ModelSaveButtonName;
                        SaveButton.Text = "Save";
                        SaveButton.Size = new Size(150, 25);
                        SaveButton.Click += SaveButton_Click;
                        SaveButton.Enabled = false;

                        Button DeleteButton = new Button();
                        DeleteButton.Name = ModelDeleteButtonName;
                        DeleteButton.Text = "Delete";
                        DeleteButton.Size = new Size(150, 25);
                        DeleteButton.Click += DeleteButton_Click;
                    //}
                    ButtonsLayoutPanel.Controls.AddRange(new Control[] { AddButton, CurrentButton, SaveButton, DeleteButton});

                //}
                ModelPageLayoutPanel.Controls.AddRange(new Control[] { UocnsConfigFileLayoutPanel, UocnsTopologyLayoutPanel, UocnsAlgorithmLayoutPanel,
                                                                       UocnsFifoLayoutPanel, UocnsFlitLayoutPanel, UocnsPacketLayoutPanel,
                                                                       UocnsCountRunLayoutPanel, UocnsRxLayoutPanel, UocnsGALSLayoutPanel,
                                                                       ButtonsLayoutPanel});
            }
        }

        private void ModelExeTextBox_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog Dialog = new OpenFileDialog())
            {
                Dialog.InitialDirectory = Directory.GetCurrentDirectory();

                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    ((TextBox)Pages.Controls.Find(((TextBox)sender).Name, true)[0]).Text = Dialog.FileName;
                }
            }
        }

        private void ModelResTextBox_DoubleClick(object sender, EventArgs e)
        {
            using (FolderBrowserDialog Dialog = new FolderBrowserDialog())
            {
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    ((TextBox)Pages.Controls.Find(((TextBox)sender).Name, true)[0]).Text = Dialog.SelectedPath;
                }
            }
        }

        private void UocnsConfigFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            string ModelName = Common.GetModelName(((CheckBox)sender).Name);
            TextBox UocnsConfigFileTextBox = (TextBox)Pages.Controls.Find(UocnsConfigFilePathTextBoxName + ModelName, true)[0];

            if (((CheckBox)Pages.Controls.Find(UocnsConfigGenerationRequiredCheckBoxName + ModelName, true)[0]).Checked)
            {
                if (ModelName == "")
                {
                    UocnsConfigFileTextBox.Text = "Will be set automatically";
                }
                else
                {
                    UocnsConfigFileTextBox.Text = ((UOCNS)SimulationController.FindModel(ModelName)).GetConfigFilePath();
                }
                UocnsConfigFileTextBox.Enabled = false;

                ((ComboBox)Pages.Controls.Find(UocnsTopologyComboBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(UocnsTopologyArgumentsTextBoxName + ModelName, true)[0]).Enabled = true;
                ((ComboBox)Pages.Controls.Find(UocnsAlgorithmComboBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(UocnsAlgorithmArgumentsTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(UocnsFifoSizeTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(UocnsFifoCountTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(UocnsFlitSizeTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(UocnsPacketSizeAvgTextBoxName + ModelName, true)[0]).Enabled = true;
                ((ComboBox)Pages.Controls.Find(UocnsPacketSizeIsFixedComboBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(UocnsPacketPeriodAvgTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(UocnsCountRunTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(UocnsCountPacketRxTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(UocnsCountPacketRxWarmUpTextBoxName + ModelName, true)[0]).Enabled = true;
                ((ComboBox)Pages.Controls.Find(UocnsIsModeGALSComboBoxName + ModelName, true)[0]).Enabled = true;

                UocnsAlgorithmComboBox_SelectedIndexChanged((ComboBox)Pages.Controls.Find(UocnsAlgorithmComboBoxName + ModelName, true)[0], new EventArgs());
                UocnsTopologyComboBox_SelectedIndexChanged((ComboBox)Pages.Controls.Find(UocnsTopologyComboBoxName + ModelName, true)[0], new EventArgs());
            }
            else
            {
                UocnsConfigFileTextBox.Text = "Double-click to select";
                UocnsConfigFileTextBox.Enabled = true;

                ((ComboBox)Pages.Controls.Find(UocnsTopologyComboBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(UocnsTopologyArgumentsTextBoxName + ModelName, true)[0]).Enabled = false;
                ((ComboBox)Pages.Controls.Find(UocnsAlgorithmComboBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(UocnsAlgorithmArgumentsTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(UocnsFifoSizeTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(UocnsFifoCountTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(UocnsFlitSizeTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(UocnsPacketSizeAvgTextBoxName + ModelName, true)[0]).Enabled = false;
                ((ComboBox)Pages.Controls.Find(UocnsPacketSizeIsFixedComboBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(UocnsPacketPeriodAvgTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(UocnsCountRunTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(UocnsCountPacketRxTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(UocnsCountPacketRxWarmUpTextBoxName + ModelName, true)[0]).Enabled = false;
                ((ComboBox)Pages.Controls.Find(UocnsIsModeGALSComboBoxName + ModelName, true)[0]).Enabled = false;
            }
        }

        private void UocnsAlgorithmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ModelName = Common.GetModelName(((ComboBox)sender).Name);
            TextBox UocnsAlgorithmArgumentsTextBox = (TextBox)Pages.Controls.Find(UocnsAlgorithmArgumentsTextBoxName + ModelName, true)[0];

            if (((ComboBox)Pages.Controls.Find(UocnsAlgorithmComboBoxName + ModelName, true)[0]).Text == AlgorithmsTypes.ROU)
            {
                UocnsAlgorithmArgumentsTextBox.Enabled = true;
                UocnsAlgorithmArgumentsTextBox.Text = "10";
            }
            else
            {
                UocnsAlgorithmArgumentsTextBox.Enabled = false;
                UocnsAlgorithmArgumentsTextBox.Text = "";
            }
        }

        private void UocnsTopologyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ModelName = Common.GetModelName(((ComboBox)sender).Name);
            string Topology = ((ComboBox)Pages.Controls.Find(UocnsTopologyComboBoxName + ModelName, true)[0]).Text;

            if (Topology == TopologiesTypes.Circulant || Topology == TopologiesTypes.OptimalCirculant)
            {
                ((ComboBox)Pages.Controls.Find(UocnsAlgorithmComboBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(UocnsAlgorithmArgumentsTextBoxName + ModelName, true)[0]).Enabled = true;

                UocnsAlgorithmComboBox_SelectedIndexChanged((ComboBox)Pages.Controls.Find(UocnsAlgorithmComboBoxName + ModelName, true)[0], new EventArgs());
            }
            else
            {
                ((ComboBox)Pages.Controls.Find(UocnsAlgorithmComboBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(UocnsAlgorithmArgumentsTextBoxName + ModelName, true)[0]).Enabled = false;
            }
        }

        private void ModelResCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            string ModelName = Common.GetModelName(((CheckBox)sender).Name);
            TextBox ModelResTextBox = (TextBox)Pages.Controls.Find(ModelResTextBoxName + ModelName, true)[0];

            if (((CheckBox)Pages.Controls.Find(ModelResCheckBoxName + ModelName, true)[0]).Checked)
            {
                if (ModelName == "")
                {
                    ModelResTextBox.Text = "Will be set automatically";
                }
                else
                {
                    ModelResTextBox.Text = SimulationController.FindModel(ModelName).GetResultsDirectoryPath();
                }
                ModelResTextBox.Enabled = false;
            }
            else
            {
                ModelResTextBox.Text = "Double-click to select";
                ModelResTextBox.Enabled = true;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            TextBox ModelNameTextBox = (TextBox)Pages.Controls.Find(ModelNameTextBoxName, true)[0];
            string ModelName = ModelNameTextBox.Text;            
           
            int AlreadyExists = SimulationController.FindModelIndex(ModelName);
            if (AlreadyExists != -1)
            {
                MessageBox.Show("Model names may not be equal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool Valid = Common.IsNameValid(ModelName);
            if (!Valid)
            {
                MessageBox.Show("Invalid model name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ModelNameTextBox.Name += ModelName;
            ModelNameTextBox.Enabled = false;

            TabPage ModelPage = (TabPage)Pages.Controls.Find(ModelPageName, true)[0];
            ModelPage.Name += ModelName;
            ModelPage.Text = ModelName;

            FlowLayoutPanel ModelPageLayoutPanel = (FlowLayoutPanel)ModelPage.Controls.Find(ModelPageLayoutPanelName, true)[0];
            ModelPageLayoutPanel.Name += ModelName;

            ComboBox ModelTypeComboBox = (ComboBox)ModelPage.Controls.Find(ModelTypeComboBoxName, true)[0];
            string ModelType = ModelTypeComboBox.Text;
            ModelTypeComboBox.Name += ModelName;

            TextBox ModelExeTextBox = (TextBox)ModelPage.Controls.Find(ModelExeTextBoxName, true)[0];
            string ModelExePath = ModelExeTextBox.Text;
            ModelExeTextBox.Name += ModelName;

            CheckBox ModelResCheckBox = (CheckBox)ModelPage.Controls.Find(ModelResCheckBoxName, true)[0];
            ModelResCheckBox.Name += ModelName;

            TextBox ModelResTextBox = (TextBox)ModelPage.Controls.Find(ModelResTextBoxName, true)[0];
            ModelResTextBox.Name += ModelName;
            string ModelResPath = "";
            if (ModelResCheckBox.Checked)
            {
                ModelResPath = Directory.GetCurrentDirectory().ToString() + "\\" + SimulationFolderName + "\\" +
                               SimulationController.SimulationName + "\\" + ModelName;
                ModelResTextBox.Text = ModelResPath;
            }
            else
            {
                ModelResPath = ModelResTextBox.Text;
            }

            if (ModelType == ModelsTypes.UOCNS)
            {
                CheckBox UocnsConfigCheckBox = (CheckBox)ModelPage.Controls.Find(UocnsConfigGenerationRequiredCheckBoxName, true)[0];
                UocnsConfigCheckBox.Name += ModelName;

                TextBox UocnsConfigTextBox = (TextBox)ModelPage.Controls.Find(UocnsConfigFilePathTextBoxName, true)[0];
                UocnsConfigTextBox.Name += ModelName;
                string UocnsConfigPath = "";
                if (UocnsConfigCheckBox.Checked)
                {
                    UocnsConfigPath = ModelResPath + "\\" + UOCNS.DefaultConfigFileName;
                    UocnsConfigTextBox.Text = UocnsConfigPath;
                }
                else
                {
                    UocnsConfigPath = UocnsConfigTextBox.Text;
                }

                ComboBox UocnsTopologyComboBox = (ComboBox)ModelPage.Controls.Find(UocnsTopologyComboBoxName, true)[0];
                string UocnsTopology = UocnsTopologyComboBox.Text;
                UocnsTopologyComboBox.Name += ModelName;

                TextBox UocnsTopologyArgsTextBox = (TextBox)ModelPage.Controls.Find(UocnsTopologyArgumentsTextBoxName, true)[0];
                string[] UocnsTopologyArgs = UocnsTopologyArgsTextBox.Text.Split();
                UocnsTopologyArgsTextBox.Name += ModelName;

                ComboBox UocnsAlgorithmComboBox = (ComboBox)ModelPage.Controls.Find(UocnsAlgorithmComboBoxName, true)[0];
                string UocnsAlgorithm = UocnsAlgorithmComboBox.Text;
                UocnsAlgorithmComboBox.Name += ModelName;

                TextBox UocnsAlgorithmArgsTextBox = (TextBox)ModelPage.Controls.Find(UocnsAlgorithmArgumentsTextBoxName, true)[0];
                string[] UocnsAlgorithmArgs = UocnsAlgorithmArgsTextBox.Text.Split();
                UocnsAlgorithmArgsTextBox.Name += ModelName;

                TextBox UocnsFifoSizeTextBox = (TextBox)ModelPage.Controls.Find(UocnsFifoSizeTextBoxName, true)[0];
                string UocnsFifoSize = UocnsFifoSizeTextBox.Text;
                UocnsFifoSizeTextBox.Name += ModelName;

                TextBox UocnsFifoCountTextBox = (TextBox)ModelPage.Controls.Find(UocnsFifoCountTextBoxName, true)[0];
                string UocnsFifoCount = UocnsFifoCountTextBox.Text;
                UocnsFifoCountTextBox.Name += ModelName;

                TextBox UocnsFlitSizeTextBox = (TextBox)ModelPage.Controls.Find(UocnsFlitSizeTextBoxName, true)[0];
                string UocnsFlitSize = UocnsFlitSizeTextBox.Text;
                UocnsFlitSizeTextBox.Name += ModelName;

                TextBox UocnsPacketSizeAvgTextBox = (TextBox)ModelPage.Controls.Find(UocnsPacketSizeAvgTextBoxName, true)[0];
                string UocnsPacketSizeAvg = UocnsPacketSizeAvgTextBox.Text;
                UocnsPacketSizeAvgTextBox.Name += ModelName;

                ComboBox UocnsPacketSizeIsFixedComboBox = (ComboBox)ModelPage.Controls.Find(UocnsPacketSizeIsFixedComboBoxName, true)[0];
                string UocnsPacketSizeIsFixed = UocnsPacketSizeIsFixedComboBox.Text;
                UocnsPacketSizeIsFixedComboBox.Name += ModelName;

                TextBox UocnsPacketPeriodAvgTextBox = (TextBox)ModelPage.Controls.Find(UocnsPacketPeriodAvgTextBoxName, true)[0];
                string UocnsPacketPeriodAvg = UocnsPacketPeriodAvgTextBox.Text;
                UocnsPacketPeriodAvgTextBox.Name += ModelName;

                TextBox UocnsCountRunTextBox = (TextBox)ModelPage.Controls.Find(UocnsCountRunTextBoxName, true)[0];
                string UocnsCountRun = UocnsCountRunTextBox.Text;
                UocnsCountRunTextBox.Name += ModelName;

                TextBox UocnsCountPacketRxTextBox = (TextBox)ModelPage.Controls.Find(UocnsCountPacketRxTextBoxName, true)[0];
                string UocnsCountPacketRx = UocnsCountPacketRxTextBox.Text;
                UocnsCountPacketRxTextBox.Name += ModelName;

                TextBox UocnsCountPacketRxWarmUpTextBox = (TextBox)ModelPage.Controls.Find(UocnsCountPacketRxWarmUpTextBoxName, true)[0];
                string UocnsCountPacketRxWarmUp = UocnsCountPacketRxWarmUpTextBox.Text;
                UocnsCountPacketRxWarmUpTextBox.Name += ModelName;

                ComboBox UocnsIsModeGALSComboBox = (ComboBox)ModelPage.Controls.Find(UocnsIsModeGALSComboBoxName, true)[0];
                string UocnsIsModeGALS = UocnsIsModeGALSComboBox.Text;
                UocnsIsModeGALSComboBox.Name += ModelName;

                UOCNS Uocns = new UOCNS(ModelType, ModelName, ModelExePath, ModelResPath,
                                        UocnsConfigCheckBox.Checked, UocnsConfigPath,
                                        UocnsTopology, UocnsTopologyArgs, UocnsAlgorithm, UocnsAlgorithmArgs,
                                        UocnsFifoSize, UocnsFifoCount, UocnsFlitSize, UocnsPacketSizeAvg,
                                        UocnsPacketSizeIsFixed, UocnsPacketPeriodAvg, UocnsCountRun,
                                        UocnsCountPacketRx, UocnsCountPacketRxWarmUp, UocnsIsModeGALS);

                SimulationController.Models.Add(Uocns);
            }

            Button AddButton = (Button)ModelPage.Controls.Find(ModelAddButtonName, true)[0];
            AddButton.Name += ModelName;
            AddButton.Enabled = false;

            Button CurrentButton = (Button)ModelPage.Controls.Find(ModelCurrentButtonName, true)[0];
            CurrentButton.Name += ModelName;
            CurrentButton.Enabled = true;

            Button SaveButton = (Button)ModelPage.Controls.Find(ModelSaveButtonName, true)[0];
            SaveButton.Name += ModelName;
            SaveButton.Enabled = true;

            Button DeleteButton = (Button)ModelPage.Controls.Find(ModelDeleteButtonName, true)[0];
            DeleteButton.Name += ModelName;

            ModelAddButton.Enabled = true;
            DeleteModelButton.Enabled = true;
            StartSimulationButton.Enabled = true;

            string[] ModelState = new string[4] { ModelName, State.NoState, State.NoState, State.NoState};
            ModelsStateTable.Rows.Add(ModelState);
            ModelsStateTable.ClearSelection();
            SimulationController.ModelsStates.Add(ModelState);
          
            TabPage ModelResultsPage = new TabPage();
            ModelResultsPage.Text = ModelName;
            ModelsResultsPages.TabPages.Add(ModelResultsPage);

            ModelResultsTable TableControl = new ModelResultsTable();
            ModelResultsPage.Controls.Add(TableControl);
        }

        private void CurrentButton_Click(object sender, EventArgs e)
        {
            string ModelName = Common.GetModelName(((Button)sender).Name);
            Model ConnectedModel = SimulationController.FindModel(ModelName);

            TabPage ModelPage = (TabPage)Pages.Controls.Find(ModelPageName + ModelName, true)[0];

            ((TextBox)ModelPage.Controls.Find(ModelExeTextBoxName + ModelName, true)[0]).Text = ConnectedModel.GetExecutableFilePath();
            ((TextBox)ModelPage.Controls.Find(ModelResTextBoxName + ModelName, true)[0]).Text = ConnectedModel.GetResultsDirectoryPath();

            if (ConnectedModel.GetType() == ModelsTypes.UOCNS)
            {
                UOCNS Uocns = (UOCNS)ConnectedModel;
                ((TextBox)ModelPage.Controls.Find(UocnsConfigFilePathTextBoxName + ModelName, true)[0]).Text = Uocns.GetConfigFilePath();
                ((CheckBox)ModelPage.Controls.Find(UocnsConfigGenerationRequiredCheckBoxName + ModelName, true)[0]).Checked = Uocns.GetConfigGenerationRequired();
                ((ComboBox)ModelPage.Controls.Find(UocnsTopologyComboBoxName + ModelName, true)[0]).Text = Uocns.GetTopology();
                ((TextBox)ModelPage.Controls.Find(UocnsTopologyArgumentsTextBoxName + ModelName, true)[0]).Text = Common.Concatenate(Uocns.GetTopologyArguments());
                ((ComboBox)ModelPage.Controls.Find(UocnsAlgorithmComboBoxName + ModelName, true)[0]).Text = Uocns.GetAlgorithm();
                ((TextBox)ModelPage.Controls.Find(UocnsAlgorithmArgumentsTextBoxName + ModelName, true)[0]).Text = Common.Concatenate(Uocns.GetAlgorithmArguments());
                ((TextBox)ModelPage.Controls.Find(UocnsFifoSizeTextBoxName + ModelName, true)[0]).Text = Uocns.GetFifoSize();
                ((TextBox)ModelPage.Controls.Find(UocnsFifoCountTextBoxName + ModelName, true)[0]).Text = Uocns.GetFifoCount();
                ((TextBox)ModelPage.Controls.Find(UocnsFlitSizeTextBoxName + ModelName, true)[0]).Text = Uocns.GetFlitSize();
                ((TextBox)ModelPage.Controls.Find(UocnsPacketSizeAvgTextBoxName + ModelName, true)[0]).Text = Uocns.GetPacketSizeAvg();
                ((ComboBox)ModelPage.Controls.Find(UocnsPacketSizeIsFixedComboBoxName + ModelName, true)[0]).Text = Uocns.GetPacketSizeIsFixed();
                ((TextBox)ModelPage.Controls.Find(UocnsPacketPeriodAvgTextBoxName + ModelName, true)[0]).Text = Uocns.GetPacketPeriodAvg();
                ((TextBox)ModelPage.Controls.Find(UocnsCountRunTextBoxName + ModelName, true)[0]).Text = Uocns.GetCountRun();
                ((TextBox)ModelPage.Controls.Find(UocnsCountPacketRxTextBoxName + ModelName, true)[0]).Text = Uocns.GetCountPacketRx();
                ((TextBox)ModelPage.Controls.Find(UocnsCountPacketRxWarmUpTextBoxName + ModelName, true)[0]).Text = Uocns.GetCountPacketRxWarmUp();
                ((ComboBox)ModelPage.Controls.Find(UocnsIsModeGALSComboBoxName + ModelName, true)[0]).Text = Uocns.GetIsModeGALS();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (SimulationController.SimulationState[0] != State.InProgress)
            {
                MessageBox.Show("It is possible to change model parameters only in ADDING MODELS simulation state", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ModelName = Common.GetModelName(((Button)sender).Name);
            int ModelIndex = SimulationController.FindModelIndex(ModelName);

            TabPage ModelPage = (TabPage)Pages.Controls.Find(ModelPageName + ModelName, true)[0];

            SimulationController.Models[ModelIndex].SetExecutableFilePath(((TextBox)ModelPage.Controls.Find(ModelExeTextBoxName + ModelName, true)[0]).Text);
            SimulationController.Models[ModelIndex].SetResultsDirectoryPath(((TextBox)ModelPage.Controls.Find(ModelResTextBoxName + ModelName, true)[0]).Text);

            if (SimulationController.Models[ModelIndex].GetType() == ModelsTypes.UOCNS)
            {
                ((UOCNS)SimulationController.Models[ModelIndex]).SetConfigFilePath(((TextBox)ModelPage.Controls.Find(UocnsConfigFilePathTextBoxName + ModelName, true)[0]).Text);
                ((UOCNS)SimulationController.Models[ModelIndex]).SetConfigGenerationRequired(((CheckBox)ModelPage.Controls.Find(UocnsConfigGenerationRequiredCheckBoxName + ModelName, true)[0]).Checked);
                ((UOCNS)SimulationController.Models[ModelIndex]).SetTopology(((ComboBox)ModelPage.Controls.Find(UocnsTopologyComboBoxName + ModelName, true)[0]).Text);
                ((UOCNS)SimulationController.Models[ModelIndex]).SetTopologyArguments(((TextBox)ModelPage.Controls.Find(UocnsTopologyArgumentsTextBoxName + ModelName, true)[0]).Text.Split());
                ((UOCNS)SimulationController.Models[ModelIndex]).SetAlgorithm(((ComboBox)ModelPage.Controls.Find(UocnsAlgorithmComboBoxName + ModelName, true)[0]).Text);
                ((UOCNS)SimulationController.Models[ModelIndex]).SetAlgorithmArguments(((TextBox)ModelPage.Controls.Find(UocnsAlgorithmArgumentsTextBoxName + ModelName, true)[0]).Text.Split());
                ((UOCNS)SimulationController.Models[ModelIndex]).SetFifoSize(((TextBox)ModelPage.Controls.Find(UocnsFifoSizeTextBoxName + ModelName, true)[0]).Text);
                ((UOCNS)SimulationController.Models[ModelIndex]).SetFifoCount(((TextBox)ModelPage.Controls.Find(UocnsFifoCountTextBoxName + ModelName, true)[0]).Text);
                ((UOCNS)SimulationController.Models[ModelIndex]).SetFlitSize(((TextBox)ModelPage.Controls.Find(UocnsFlitSizeTextBoxName + ModelName, true)[0]).Text);
                ((UOCNS)SimulationController.Models[ModelIndex]).SetPacketSizeAvg(((TextBox)ModelPage.Controls.Find(UocnsPacketSizeAvgTextBoxName + ModelName, true)[0]).Text);
                ((UOCNS)SimulationController.Models[ModelIndex]).SetPacketSizeIsFixed(((ComboBox)ModelPage.Controls.Find(UocnsPacketSizeIsFixedComboBoxName + ModelName, true)[0]).Text);
                ((UOCNS)SimulationController.Models[ModelIndex]).SetPacketPeriodAvg(((TextBox)ModelPage.Controls.Find(UocnsPacketPeriodAvgTextBoxName + ModelName, true)[0]).Text);
                ((UOCNS)SimulationController.Models[ModelIndex]).SetCountRun(((TextBox)ModelPage.Controls.Find(UocnsCountRunTextBoxName + ModelName, true)[0]).Text);
                ((UOCNS)SimulationController.Models[ModelIndex]).SetCountPacketRx(((TextBox)ModelPage.Controls.Find(UocnsCountPacketRxTextBoxName + ModelName, true)[0]).Text);
                ((UOCNS)SimulationController.Models[ModelIndex]).SetCountPacketRxWarmUp(((TextBox)ModelPage.Controls.Find(UocnsCountPacketRxWarmUpTextBoxName + ModelName, true)[0]).Text);
                ((UOCNS)SimulationController.Models[ModelIndex]).SetIsModeGALS(((ComboBox)ModelPage.Controls.Find(UocnsIsModeGALSComboBoxName + ModelName, true)[0]).Text);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (SimulationController.SimulationState[0] != State.InProgress)
            {
                MessageBox.Show("It is possible to delete model only in ADDING MODELS simulation state", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Pages.SelectedIndex = 0;

            string ModelName = Common.GetModelName(((Button)sender).Name);

            if (ModelName != "")
            {
                int ModelIndex = SimulationController.FindModelIndex(ModelName);
                SimulationController.ModelsStates.RemoveAt(ModelIndex);
                ModelsStateTable.Rows.RemoveAt(ModelIndex);
                ModelsStateTable.ClearSelection();
                ModelsResultsPages.TabPages.RemoveAt(ModelIndex);
            }

            TabPage ModelPage = (TabPage)Pages.Controls.Find(ModelPageName + ModelName, true)[0];
            Pages.Controls.Remove(ModelPage);

            SimulationController.DeleteModel(ModelName);

            ModelAddButton.Enabled = true;
            if (SimulationController.Models.Count == 0)
            {
                DeleteModelButton.Enabled = false;
                StartSimulationButton.Enabled = false;
            }
        }

    }
}
