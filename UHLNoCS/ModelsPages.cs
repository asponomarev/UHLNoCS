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
                        UocnsConfigFileTextBox.Text = "Double-click to select";
                        UocnsConfigFileTextBox.Size = new Size(400, 25);

                        CheckBox UocnsConfigFileCheckBox = new CheckBox();
                        UocnsConfigFileCheckBox.Name = UocnsConfigGenerationRequiredCheckBoxName;
                        UocnsConfigFileCheckBox.Text = "Cofiguration file generation required";
                        UocnsConfigFileCheckBox.Size = new Size(300, 25);
                        UocnsConfigFileCheckBox.CheckedChanged += UocnsConfigFileCheckBox_CheckedChanged; // TODO: implement
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
                        UocnsTopologyComboBox.SelectedIndexChanged += UocnsTopologyComboBox_SelectedIndexChanged; // TODO: implement
                        UocnsTopologyComboBox.Name = UocnsTopologyComboBoxName;
                        UocnsTopologyComboBox.Size = new Size(100, 25);
                        UocnsTopologyComboBox.Items.AddRange(new string[] { TopologiesTypes.Mesh, TopologiesTypes.Torus, TopologiesTypes.Circulant, TopologiesTypes.OptimalCirculant });
                        UocnsTopologyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                        Label UocnsTopologyArgsLabel = new Label();
                        UocnsTopologyArgsLabel.Text = "Topology arguments";
                        UocnsTopologyArgsLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsTopologyArgsLabel.Size = new Size(150, 25);

                        TextBox UocnsTopologyArgsTextBox = new TextBox();
                        UocnsTopologyArgsTextBox.Name = UocnsTopologyArgumentsTextBoxName;
                        UocnsTopologyArgsTextBox.Text = "";
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
                        UocnsAlgorithmComboBox.SelectedIndexChanged += UocnsAlgorithmComboBox_SelectedIndexChanged; // TODO: implement
                        UocnsAlgorithmComboBox.Name = UocnsAlgorithmComboBoxName;
                        UocnsAlgorithmComboBox.Size = new Size(100, 25);
                        UocnsAlgorithmComboBox.Items.AddRange(new string[] { AlgorithmsTypes.Dijkstra, AlgorithmsTypes.PO, AlgorithmsTypes.ROU });
                        UocnsAlgorithmComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                        Label UocnsAlgorithmArgsLabel = new Label();
                        UocnsAlgorithmArgsLabel.Text = "Algorithm arguments";
                        UocnsAlgorithmArgsLabel.TextAlign = ContentAlignment.MiddleCenter;
                        UocnsAlgorithmArgsLabel.Size = new Size(150, 25);

                        TextBox UocnsAlgorithmArgsTextBox = new TextBox();
                        UocnsAlgorithmArgsTextBox.Name = UocnsAlgorithmArgumentsTextBoxName;
                        UocnsAlgorithmArgsTextBox.Text = "";
                        UocnsAlgorithmArgsTextBox.Size = new Size(100, 25);
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

                        Button SaveButton = new Button();
                        SaveButton.Name = ModelSaveButtonName;
                        SaveButton.Text = "Save";
                        SaveButton.Size = new Size(150, 25);
                        SaveButton.Click += SaveButton_Click;

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

        }

        private void UocnsAlgorithmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UocnsTopologyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ModelResCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void CurrentButton_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

    }
}
