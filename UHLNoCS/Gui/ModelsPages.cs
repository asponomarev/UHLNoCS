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

        public static string BooksimConfigGenerationRequiredCheckBoxName = "BooksimConfigGenerationRequiredCheckBox_";
        public static string BooksimConfigFilePathTextBoxName = "BooksimConfigFilePathTextBox_";
        public static string BooksimTopologyComboBoxName = "BooksimTopologyComboBox_";
        public static string BooksimTopologyArgumentsTextBoxName = "BooksimTopologyArgumentsTextBox_";
        public static string BooksimAlgorithmComboBoxName = "BooksimAlgorithmComboBox_";
        public static string BooksimVirtualChannelsAmountTextBoxName = "BooksimVirtualChannelsAmountTextBox_";
        public static string BooksimVirtualChannelsSizeTextBoxName = "BooksimVirtualChannelsSizeTextBox_";
        public static string BooksimTrafficTypeComboBoxName = "BooksimTrafficTypeComboBox_";
        public static string BooksimPacketSizeTextBoxName = "BooksimPacketSizeTextBox_";
        public static string BooksimSimulationPeriodLengthTextBoxName = "BooksimSimulationPeriodLengthTextBox_";
        public static string BooksimWarmUpPeriodsAmountTextBoxName = "BooksimWarmUpPeriodsAmountTextBox_";
        public static string BooksimMaxPeriodAmountTextBoxName = "BooksimMaxPeriodAmountTextBox_";
        public static string BooksimSimulationTypeComboBoxName = "BooksimSimulationTypeComboBox_";
        public static string BooksimInjectionRateTextBoxName = "BooksimInjectionRateTextBox_";
        public static string BooksimIterationsAmountTextBoxName = "BooksimIterationsAmountTextBox_";

        public static string NewximConfigGenerationRequiredCheckBoxName = "NewximConfigGenerationRequiredCheckBox_";
        public static string NewximConfigFilePathTextBoxName = "NewximConfigFilePathTextBox_";
        public static string NewximTopologyComboBoxName = "NewximTopologyComboBox_";
        public static string NewximTopologyArgumentsTextBoxName = "NewximTopologyArgumentsTextBox_";
        public static string NewximAlgorithmComboBoxName = "NewximAlgorithmComboBox_";
        public static string NewximTopologyChannelsTextBoxName = "NewximTopologyChannelsTextBox_";
        public static string NewximVirtualChannelsTextBoxName = "NewximVirtualChannelsTextBox_";
        public static string NewximBufferDepthTextBoxName = "NewximBufferDepthTextBox_";
        public static string NewximMinPacketSizeTextBoxName = "NewximMinPacketSizeTextBox_";
        public static string NewximMaxPacketSizeTextBoxName = "NewximMaxPacketSizeTextBox_";
        public static string NewximPacketInjectionRateTextBoxName = "NewximPacketInjectionRateTextBox_";
        public static string NewximSimulationTimeTextBoxName = "NewximSimulationTimeTextBox_";
        public static string NewximWarmUpTimeTextBoxName = "NewximWarmUpTimeTextBox_";
        public static string NewximIterationsAmountTextBoxName = "NewximIterationsAmountTextBox_";

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
                        UocnsAlgorithmComboBox.Items.AddRange(AlgorithmsTypes.MeshAlgotithms);
                        UocnsAlgorithmComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        UocnsAlgorithmComboBox.SelectedIndex = 0;
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
            else if (ModelType == ModelsTypes.Booksim)
            {
                FlowLayoutPanel ModelPageLayoutPanel = (FlowLayoutPanel)Pages.Controls.Find(ModelPageLayoutPanelName, true)[0];
                //{
                    FlowLayoutPanel BooksimConfigFileLayoutPanel = new FlowLayoutPanel();
                    BooksimConfigFileLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    BooksimConfigFileLayoutPanel.AutoSize = true;
                    BooksimConfigFileLayoutPanel.Margin = new Padding(3, 13, 3, 3);
                    //{
                        Label BooksimConfigFileLabel = new Label();
                        BooksimConfigFileLabel.Text = "Configuration file path";
                        BooksimConfigFileLabel.TextAlign = ContentAlignment.MiddleCenter;
                        BooksimConfigFileLabel.Size = new Size(150, 25);

                        TextBox BooksimConfigFileTextBox = new TextBox();
                        BooksimConfigFileTextBox.DoubleClick += ModelExeTextBox_DoubleClick;
                        BooksimConfigFileTextBox.Name = BooksimConfigFilePathTextBoxName;
                        BooksimConfigFileTextBox.Text = "Will be set automatically";
                        BooksimConfigFileTextBox.Size = new Size(600, 25);
                        BooksimConfigFileTextBox.ReadOnly = true;
                        BooksimConfigFileTextBox.Enabled = false;

                        CheckBox BooksimConfigFileCheckBox = new CheckBox();
                        BooksimConfigFileCheckBox.Name = BooksimConfigGenerationRequiredCheckBoxName;
                        BooksimConfigFileCheckBox.Text = "Cofiguration file generation required";
                        BooksimConfigFileCheckBox.Size = new Size(300, 25);
                        BooksimConfigFileCheckBox.Checked = true;
                        BooksimConfigFileCheckBox.CheckedChanged += BooksimConfigFileCheckBox_CheckedChanged;// todo:implement
                    //}
                    BooksimConfigFileLayoutPanel.Controls.AddRange(new Control[] { BooksimConfigFileLabel, BooksimConfigFileTextBox, BooksimConfigFileCheckBox });

                    FlowLayoutPanel BooksimTopologyLayoutPanel = new FlowLayoutPanel();
                    BooksimTopologyLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    BooksimTopologyLayoutPanel.AutoSize = true;
                    //{
                        Label BooksimTopologyLabel = new Label();
                        BooksimTopologyLabel.Text = "NoC topology";
                        BooksimTopologyLabel.TextAlign = ContentAlignment.MiddleCenter;
                        BooksimTopologyLabel.Size = new Size(150, 25);

                        ComboBox BooksimTopologyComboBox = new ComboBox();
                        BooksimTopologyComboBox.Name = BooksimTopologyComboBoxName;
                        BooksimTopologyComboBox.Size = new Size(100, 25);
                        BooksimTopologyComboBox.Items.AddRange(Booksim.Topologies);
                        BooksimTopologyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        BooksimTopologyComboBox.SelectedIndex = Booksim.DefaultTopologyIndex;

                        Label BooksimTopologyArgsLabel = new Label();
                        BooksimTopologyArgsLabel.Text = "Topology arguments";
                        BooksimTopologyArgsLabel.TextAlign = ContentAlignment.MiddleCenter;
                        BooksimTopologyArgsLabel.Size = new Size(150, 25);

                        TextBox BooksimTopologyArgsTextBox = new TextBox();
                        BooksimTopologyArgsTextBox.Name = BooksimTopologyArgumentsTextBoxName;
                        BooksimTopologyArgsTextBox.Text = Booksim.DefaultTopologyArguments;
                        BooksimTopologyArgsTextBox.Size = new Size(100, 25);

                        Label BooksimAlgorithmLabel = new Label();
                        BooksimAlgorithmLabel.Text = "Routing function";
                        BooksimAlgorithmLabel.TextAlign = ContentAlignment.MiddleCenter;
                        BooksimAlgorithmLabel.Size = new Size(150, 25);

                        ComboBox BooksimAlgorithmComboBox = new ComboBox();
                        BooksimAlgorithmComboBox.Name = BooksimAlgorithmComboBoxName;
                        BooksimAlgorithmComboBox.Size = new Size(100, 25);
                        BooksimAlgorithmComboBox.Items.AddRange(Booksim.RoutingFunctions);
                        BooksimAlgorithmComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        BooksimAlgorithmComboBox.SelectedIndex = Booksim.DefaultRoutingFunction;
                    //}
                    BooksimTopologyLayoutPanel.Controls.AddRange(new Control[] { BooksimTopologyLabel, BooksimTopologyComboBox,
                                                                                 BooksimTopologyArgsLabel, BooksimTopologyArgsTextBox,
                                                                                 BooksimAlgorithmLabel, BooksimAlgorithmComboBox});
                   
                    FlowLayoutPanel BooksimFifoLayoutPanel = new FlowLayoutPanel();
                    BooksimFifoLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    BooksimFifoLayoutPanel.AutoSize = true;
                    BooksimFifoLayoutPanel.Margin = new Padding(3, 13, 3, 3);
                    //{
                        Label BooksimFifoSizeLabel = new Label();
                        BooksimFifoSizeLabel.Text = "Virtual channels amount";
                        BooksimFifoSizeLabel.TextAlign = ContentAlignment.MiddleCenter;
                        BooksimFifoSizeLabel.Size = new Size(150, 25);

                        TextBox BooksimFifoSizeTextBox = new TextBox();
                        BooksimFifoSizeTextBox.Name = BooksimVirtualChannelsAmountTextBoxName;
                        BooksimFifoSizeTextBox.Text = Booksim.DefaulVirtualChannelsAmount;
                        BooksimFifoSizeTextBox.Size = new Size(100, 25);

                        Label BooksimFifoCountLabel = new Label();
                        BooksimFifoCountLabel.Text = "Virtual channel buffer size";
                        BooksimFifoCountLabel.TextAlign = ContentAlignment.MiddleCenter;
                        BooksimFifoCountLabel.Size = new Size(150, 25);

                        TextBox BooksimFifoCountTextBox = new TextBox();
                        BooksimFifoCountTextBox.Name = BooksimVirtualChannelsSizeTextBoxName;
                        BooksimFifoCountTextBox.Text = Booksim.DefaultVirtualChannelsBufferSize;
                        BooksimFifoCountTextBox.Size = new Size(100, 25);
                    //}
                    BooksimFifoLayoutPanel.Controls.AddRange(new Control[] { BooksimFifoSizeLabel, BooksimFifoSizeTextBox, BooksimFifoCountLabel, BooksimFifoCountTextBox });

                    FlowLayoutPanel BooksimTrafficLayoutPanel = new FlowLayoutPanel();
                    BooksimTrafficLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    BooksimTrafficLayoutPanel.AutoSize = true;
                    //{

                        Label BooksimTrafficLabel = new Label();
                        BooksimTrafficLabel.Text = "Traffic distribution";
                        BooksimTrafficLabel.TextAlign = ContentAlignment.MiddleCenter;
                        BooksimTrafficLabel.Size = new Size(150, 25);

                        ComboBox BooksimTrafficComboBox = new ComboBox();
                        BooksimTrafficComboBox.Name = BooksimTrafficTypeComboBoxName;
                        BooksimTrafficComboBox.Size = new Size(100, 25);
                        BooksimTrafficComboBox.Items.AddRange(Booksim.TrafficTypes);
                        BooksimTrafficComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        BooksimTrafficComboBox.SelectedIndex = Booksim.DefaultTrafficType;

                        Label BooksimPacketSizeLabel = new Label();
                        BooksimPacketSizeLabel.Text = "Packet size";
                        BooksimPacketSizeLabel.TextAlign = ContentAlignment.MiddleCenter;
                        BooksimPacketSizeLabel.Size = new Size(150, 25);

                        TextBox BooksimPacketSizeTextBox = new TextBox();
                        BooksimPacketSizeTextBox.Name = BooksimPacketSizeTextBoxName;
                        BooksimPacketSizeTextBox.Text = Booksim.DefaultPacketSize;
                        BooksimPacketSizeTextBox.Size = new Size(100, 25);
                    //}
                    BooksimTrafficLayoutPanel.Controls.AddRange(new Control[] { BooksimTrafficLabel, BooksimTrafficComboBox, BooksimPacketSizeLabel, BooksimPacketSizeTextBox });

                    FlowLayoutPanel BooksimPeriodLayoutPanel = new FlowLayoutPanel();
                    BooksimPeriodLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    BooksimPeriodLayoutPanel.AutoSize = true;
                    //{
                        Label BooksimPeriodLabel = new Label();
                        BooksimPeriodLabel.Text = "Simulation period length";
                        BooksimPeriodLabel.TextAlign = ContentAlignment.MiddleCenter;
                        BooksimPeriodLabel.Size = new Size(150, 25);

                        TextBox BooksimPeriodTextBox = new TextBox();
                        BooksimPeriodTextBox.Name = BooksimSimulationPeriodLengthTextBoxName;
                        BooksimPeriodTextBox.Text = Booksim.DefaultSimulationPeriodLength;
                        BooksimPeriodTextBox.Size = new Size(100, 25);        

                        Label BooksimWarmUpLabel = new Label();
                        BooksimWarmUpLabel.Text = "Warm up periods";
                        BooksimWarmUpLabel.TextAlign = ContentAlignment.MiddleCenter;
                        BooksimWarmUpLabel.Size = new Size(150, 25);

                        TextBox BooksimWarmUpTextBox = new TextBox();
                        BooksimWarmUpTextBox.Name = BooksimWarmUpPeriodsAmountTextBoxName;
                        BooksimWarmUpTextBox.Text = Booksim.DefaultWarmUpPeriodsAmount;
                        BooksimWarmUpTextBox.Size = new Size(100, 25);

                        Label BooksimMaxPeriodLabel = new Label();
                        BooksimMaxPeriodLabel.Text = "Max periods";
                        BooksimMaxPeriodLabel.TextAlign = ContentAlignment.MiddleCenter;
                        BooksimMaxPeriodLabel.Size = new Size(150, 25);

                        TextBox BooksimMaxPeriodTextBox = new TextBox();
                        BooksimMaxPeriodTextBox.Name = BooksimMaxPeriodAmountTextBoxName;
                        BooksimMaxPeriodTextBox.Text = Booksim.DefaultMaxPeriodsAmount;
                        BooksimMaxPeriodTextBox.Size = new Size(100, 25);
                    //}
                    BooksimPeriodLayoutPanel.Controls.AddRange(new Control[] { BooksimPeriodLabel, BooksimPeriodTextBox, BooksimWarmUpLabel,
                                                                                BooksimWarmUpTextBox, BooksimMaxPeriodLabel, BooksimMaxPeriodTextBox});

                    FlowLayoutPanel BooksimSimLayoutPanel = new FlowLayoutPanel();
                    BooksimSimLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    BooksimSimLayoutPanel.AutoSize = true;
                    //{
                        Label BooksimSimulationLabel = new Label();
                        BooksimSimulationLabel.Text = "Simulation type";
                        BooksimSimulationLabel.TextAlign = ContentAlignment.MiddleCenter;
                        BooksimSimulationLabel.Size = new Size(150, 25);

                        ComboBox BooksimSimulationComboBox = new ComboBox();
                        BooksimSimulationComboBox.Name = BooksimSimulationTypeComboBoxName;
                        BooksimSimulationComboBox.Size = new Size(100, 25);
                        BooksimSimulationComboBox.Items.AddRange(Booksim.SimulationTypes);
                        BooksimSimulationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        BooksimSimulationComboBox.SelectedIndex = Booksim.DefaultSimulationType;

                        Label BooksimInjectionLabel = new Label();
                        BooksimInjectionLabel.Text = "Flits generation rate";
                        BooksimInjectionLabel.TextAlign = ContentAlignment.MiddleCenter;
                        BooksimInjectionLabel.Size = new Size(150, 25);

                        TextBox BooksimInjectionTextBox = new TextBox();
                        BooksimInjectionTextBox.Name = BooksimInjectionRateTextBoxName;
                        BooksimInjectionTextBox.Text = Booksim.DefaultInjectionRate;
                        BooksimInjectionTextBox.Size = new Size(100, 25);

                        Label BooksimIterationsAmountLabel = new Label();
                        BooksimIterationsAmountLabel.Text = "Simulation iterations amount";
                        BooksimIterationsAmountLabel.TextAlign = ContentAlignment.MiddleCenter;
                        BooksimIterationsAmountLabel.Size = new Size(150, 25);

                        TextBox BooksimIterationsAmountTextBox = new TextBox();
                        BooksimIterationsAmountTextBox.Name = BooksimIterationsAmountTextBoxName;
                        BooksimIterationsAmountTextBox.Text = Booksim.DefaultIterationsAmount;
                        BooksimIterationsAmountTextBox.Size = new Size(100, 25);
                    //}
                    BooksimSimLayoutPanel.Controls.AddRange(new Control[] { BooksimSimulationLabel, BooksimSimulationComboBox, BooksimInjectionLabel, BooksimInjectionTextBox, BooksimIterationsAmountLabel, BooksimIterationsAmountTextBox });                  

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
                ModelPageLayoutPanel.Controls.AddRange(new Control[] { BooksimConfigFileLayoutPanel, BooksimTopologyLayoutPanel, BooksimFifoLayoutPanel,
                                                                       BooksimTrafficLayoutPanel, BooksimPeriodLayoutPanel, BooksimSimLayoutPanel,
                                                                       ButtonsLayoutPanel});
            }
            else if (ModelType == ModelsTypes.Newxim)
            {
                FlowLayoutPanel ModelPageLayoutPanel = (FlowLayoutPanel)Pages.Controls.Find(ModelPageLayoutPanelName, true)[0];
                //{
                    FlowLayoutPanel NewximConfigFileLayoutPanel = new FlowLayoutPanel();
                    NewximConfigFileLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    NewximConfigFileLayoutPanel.AutoSize = true;
                    NewximConfigFileLayoutPanel.Margin = new Padding(3, 13, 3, 3);
                    //{
                        Label NewximConfigFileLabel = new Label();
                        NewximConfigFileLabel.Text = "Configuration file path";
                        NewximConfigFileLabel.TextAlign = ContentAlignment.MiddleCenter;
                        NewximConfigFileLabel.Size = new Size(150, 25);

                        TextBox NewximConfigFileTextBox = new TextBox();
                        NewximConfigFileTextBox.DoubleClick += ModelExeTextBox_DoubleClick;
                        NewximConfigFileTextBox.Name = NewximConfigFilePathTextBoxName;
                        NewximConfigFileTextBox.Text = "Will be set automatically";
                        NewximConfigFileTextBox.Size = new Size(600, 25);
                        NewximConfigFileTextBox.ReadOnly = true;
                        NewximConfigFileTextBox.Enabled = false;

                        CheckBox NewximConfigFileCheckBox = new CheckBox();
                        NewximConfigFileCheckBox.Name = NewximConfigGenerationRequiredCheckBoxName;
                        NewximConfigFileCheckBox.Text = "Cofiguration file generation required";
                        NewximConfigFileCheckBox.Size = new Size(300, 25);
                        NewximConfigFileCheckBox.Checked = true;
                        NewximConfigFileCheckBox.CheckedChanged += NewximConfigFileCheckBox_CheckedChanged;// todo:implement
                    //}
                    NewximConfigFileLayoutPanel.Controls.AddRange(new Control[] { NewximConfigFileLabel, NewximConfigFileTextBox, NewximConfigFileCheckBox });

                    FlowLayoutPanel NewximTopologyLayoutPanel = new FlowLayoutPanel();
                    NewximTopologyLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    NewximTopologyLayoutPanel.AutoSize = true;
                    //{
                        Label NewximTopologyLabel = new Label();
                        NewximTopologyLabel.Text = "NoC topology";
                        NewximTopologyLabel.TextAlign = ContentAlignment.MiddleCenter;
                        NewximTopologyLabel.Size = new Size(150, 25);

                        ComboBox NewximTopologyComboBox = new ComboBox();
                        NewximTopologyComboBox.Name = NewximTopologyComboBoxName;
                        NewximTopologyComboBox.Size = new Size(100, 25);
                        NewximTopologyComboBox.Items.AddRange(Newxim.Topologies);
                        NewximTopologyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        NewximTopologyComboBox.SelectedIndex = Newxim.DefaultTopology;

                        Label NewximTopologyArgsLabel = new Label();
                        NewximTopologyArgsLabel.Text = "Topology arguments";
                        NewximTopologyArgsLabel.TextAlign = ContentAlignment.MiddleCenter;
                        NewximTopologyArgsLabel.Size = new Size(150, 25);

                        TextBox NewximTopologyArgsTextBox = new TextBox();
                        NewximTopologyArgsTextBox.Name = NewximTopologyArgumentsTextBoxName;
                        NewximTopologyArgsTextBox.Text = Newxim.DefaultTopologyArguments;
                        NewximTopologyArgsTextBox.Size = new Size(100, 25);

                        Label NewximAlgorithmLabel = new Label();
                        NewximAlgorithmLabel.Text = "Routing algorithm";
                        NewximAlgorithmLabel.TextAlign = ContentAlignment.MiddleCenter;
                        NewximAlgorithmLabel.Size = new Size(150, 25);

                        ComboBox NewximAlgorithmComboBox = new ComboBox();
                        NewximAlgorithmComboBox.Name = NewximAlgorithmComboBoxName;
                        NewximAlgorithmComboBox.Size = new Size(100, 25);
                        NewximAlgorithmComboBox.Items.AddRange(Newxim.RoutingAlgorithms);
                        NewximAlgorithmComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        NewximAlgorithmComboBox.SelectedIndex = Newxim.DefaultRoutingAlgorithm;
                    //}
                    NewximTopologyLayoutPanel.Controls.AddRange(new Control[] { NewximTopologyLabel, NewximTopologyComboBox,
                                                                                 NewximTopologyArgsLabel, NewximTopologyArgsTextBox,
                                                                                 NewximAlgorithmLabel, NewximAlgorithmComboBox});
                   
                    FlowLayoutPanel NewximChannelsLayoutPanel = new FlowLayoutPanel();
                    NewximChannelsLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    NewximChannelsLayoutPanel.AutoSize = true;
                    NewximChannelsLayoutPanel.Margin = new Padding(3, 13, 3, 3);
                    //{
                        Label NewximTopologyChannelsLabel = new Label();
                        NewximTopologyChannelsLabel.Text = "Physical channels amount";
                        NewximTopologyChannelsLabel.TextAlign = ContentAlignment.MiddleCenter;
                        NewximTopologyChannelsLabel.Size = new Size(150, 25);

                        TextBox NewximTopologyChannelsTextBox = new TextBox();
                        NewximTopologyChannelsTextBox.Name = NewximTopologyChannelsTextBoxName;
                        NewximTopologyChannelsTextBox.Text = Newxim.DefaultTopologyChannels;
                        NewximTopologyChannelsTextBox.Size = new Size(100, 25);

                        Label NewximVirtualChannelsLabel = new Label();
                        NewximVirtualChannelsLabel.Text = "Virtual channels amount";
                        NewximVirtualChannelsLabel.TextAlign = ContentAlignment.MiddleCenter;
                        NewximVirtualChannelsLabel.Size = new Size(150, 25);

                        TextBox NewximVirtualChannelsTextBox = new TextBox();
                        NewximVirtualChannelsTextBox.Name = NewximVirtualChannelsTextBoxName;
                        NewximVirtualChannelsTextBox.Text = Newxim.DefaultVirtualChannels;
                        NewximVirtualChannelsTextBox.Size = new Size(100, 25);

                        Label NewximBufferDepthLabel = new Label();
                        NewximBufferDepthLabel.Text = "Buffers depth";
                        NewximBufferDepthLabel.TextAlign = ContentAlignment.MiddleCenter;
                        NewximBufferDepthLabel.Size = new Size(150, 25);

                        TextBox NewximBufferDepthTextBox = new TextBox();
                        NewximBufferDepthTextBox.Name = NewximBufferDepthTextBoxName;
                        NewximBufferDepthTextBox.Text = Newxim.DefaultBufferDepth;
                        NewximBufferDepthTextBox.Size = new Size(100, 25);
                    //}
                    NewximChannelsLayoutPanel.Controls.AddRange(new Control[] { NewximTopologyChannelsLabel, NewximTopologyChannelsTextBox,
                                                                                NewximVirtualChannelsLabel, NewximVirtualChannelsTextBox,
                                                                                NewximBufferDepthLabel, NewximBufferDepthTextBox});

                    FlowLayoutPanel NewximPacketsLayoutPanel = new FlowLayoutPanel();
                    NewximPacketsLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    NewximPacketsLayoutPanel.AutoSize = true;
                    //{

                        Label NewximMinPacketSizeLabel = new Label();
                        NewximMinPacketSizeLabel.Text = "Min packet size";
                        NewximMinPacketSizeLabel.TextAlign = ContentAlignment.MiddleCenter;
                        NewximMinPacketSizeLabel.Size = new Size(150, 25);

                        TextBox NewximMinPacketSizeTextBox = new TextBox();
                        NewximMinPacketSizeTextBox.Name = NewximMinPacketSizeTextBoxName;
                        NewximMinPacketSizeTextBox.Text = Newxim.DefaultMinPacketSize;
                        NewximMinPacketSizeTextBox.Size = new Size(100, 25);

                        Label NewximMaxPacketSizeLabel = new Label();
                        NewximMaxPacketSizeLabel.Text = "Max packet size";
                        NewximMaxPacketSizeLabel.TextAlign = ContentAlignment.MiddleCenter;
                        NewximMaxPacketSizeLabel.Size = new Size(150, 25);

                        TextBox NewximMaxPacketSizeTextBox = new TextBox();
                        NewximMaxPacketSizeTextBox.Name = NewximMaxPacketSizeTextBoxName;
                        NewximMaxPacketSizeTextBox.Text = Newxim.DefaultMaxPacketSize;
                        NewximMaxPacketSizeTextBox.Size = new Size(100, 25);

                        Label NewximInjectionRateLabel = new Label();
                        NewximInjectionRateLabel.Text = "Flits generation rate";
                        NewximInjectionRateLabel.TextAlign = ContentAlignment.MiddleCenter;
                        NewximInjectionRateLabel.Size = new Size(150, 25);

                        TextBox NewximInjectionRateTextBox = new TextBox();
                        NewximInjectionRateTextBox.Name = NewximPacketInjectionRateTextBoxName;
                        NewximInjectionRateTextBox.Text = Newxim.DefaultPacketInjectionRate;
                        NewximInjectionRateTextBox.Size = new Size(100, 25);
                    //}
                    NewximPacketsLayoutPanel.Controls.AddRange(new Control[] { NewximMinPacketSizeLabel, NewximMinPacketSizeTextBox,
                                                                               NewximMaxPacketSizeLabel, NewximMaxPacketSizeTextBox,
                                                                               NewximInjectionRateLabel, NewximInjectionRateTextBox});

                    FlowLayoutPanel NewximTimesLayoutPanel = new FlowLayoutPanel();
                    NewximTimesLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                    NewximTimesLayoutPanel.AutoSize = true;
                    //{
                        Label NewximSimTimeLabel = new Label();
                        NewximSimTimeLabel.Text = "Simulation cycles amount";
                        NewximSimTimeLabel.TextAlign = ContentAlignment.MiddleCenter;
                        NewximSimTimeLabel.Size = new Size(150, 25);

                        TextBox NewximSimTimeTextBox = new TextBox();
                        NewximSimTimeTextBox.Name = NewximSimulationTimeTextBoxName;
                        NewximSimTimeTextBox.Text = Newxim.DefaultSimulationTime;
                        NewximSimTimeTextBox.Size = new Size(100, 25);        

                        Label NewximWarmUpTimeLabel = new Label();
                        NewximWarmUpTimeLabel.Text = "Warm up cycles amount";
                        NewximWarmUpTimeLabel.TextAlign = ContentAlignment.MiddleCenter;
                        NewximWarmUpTimeLabel.Size = new Size(150, 25);

                        TextBox NewximWarmUpTimeTextBox = new TextBox();
                        NewximWarmUpTimeTextBox.Name = NewximWarmUpTimeTextBoxName;
                        NewximWarmUpTimeTextBox.Text = Newxim.DefaultWarmUpTime;
                        NewximWarmUpTimeTextBox.Size = new Size(100, 25);  

                        Label NewximIterationsAmountLabel = new Label();
                        NewximIterationsAmountLabel.Text = "Simulation iterations amount";
                        NewximIterationsAmountLabel.TextAlign = ContentAlignment.MiddleCenter;
                        NewximIterationsAmountLabel.Size = new Size(150, 25);

                        TextBox NewximIterationsAmountTextBox = new TextBox();
                        NewximIterationsAmountTextBox.Name = NewximIterationsAmountTextBoxName;
                        NewximIterationsAmountTextBox.Text = Newxim.DefaultIterationsAmount;
                        NewximIterationsAmountTextBox.Size = new Size(100, 25);
                    //}
                    NewximTimesLayoutPanel.Controls.AddRange(new Control[] { NewximSimTimeLabel, NewximSimTimeTextBox,
                                                                             NewximWarmUpTimeLabel, NewximWarmUpTimeTextBox,
                                                                             NewximIterationsAmountLabel, NewximIterationsAmountTextBox});
                    
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
                ModelPageLayoutPanel.Controls.AddRange(new Control[] { NewximConfigFileLayoutPanel, NewximTopologyLayoutPanel, NewximChannelsLayoutPanel,
                                                                       NewximPacketsLayoutPanel, NewximTimesLayoutPanel,
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

        private void BooksimConfigFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            string ModelName = Common.GetModelName(((CheckBox)sender).Name);
            TextBox BooksimConfigFileTextBox = (TextBox)Pages.Controls.Find(BooksimConfigFilePathTextBoxName + ModelName, true)[0];

            if (((CheckBox)Pages.Controls.Find(BooksimConfigGenerationRequiredCheckBoxName + ModelName, true)[0]).Checked)
            {
                if (ModelName == "")
                {
                    BooksimConfigFileTextBox.Text = "Will be set automatically";
                }
                else
                {
                    BooksimConfigFileTextBox.Text = ((Booksim)SimulationController.FindModel(ModelName)).GetConfigFilePath();
                }
                BooksimConfigFileTextBox.Enabled = false;

                ((ComboBox)Pages.Controls.Find(BooksimTopologyComboBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(BooksimTopologyArgumentsTextBoxName + ModelName, true)[0]).Enabled = true;
                ((ComboBox)Pages.Controls.Find(BooksimAlgorithmComboBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(BooksimVirtualChannelsAmountTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(BooksimVirtualChannelsSizeTextBoxName + ModelName, true)[0]).Enabled = true;
                ((ComboBox)Pages.Controls.Find(BooksimTrafficTypeComboBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(BooksimPacketSizeTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(BooksimSimulationPeriodLengthTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(BooksimWarmUpPeriodsAmountTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(BooksimMaxPeriodAmountTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(BooksimInjectionRateTextBoxName + ModelName, true)[0]).Enabled = true;
                ((ComboBox)Pages.Controls.Find(BooksimSimulationTypeComboBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(BooksimIterationsAmountTextBoxName + ModelName, true)[0]).Enabled = true;
            }
            else
            {
                BooksimConfigFileTextBox.Text = "Double-click to select";
                BooksimConfigFileTextBox.Enabled = true;

                ((ComboBox)Pages.Controls.Find(BooksimTopologyComboBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(BooksimTopologyArgumentsTextBoxName + ModelName, true)[0]).Enabled = false;
                ((ComboBox)Pages.Controls.Find(BooksimAlgorithmComboBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(BooksimVirtualChannelsAmountTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(BooksimVirtualChannelsSizeTextBoxName + ModelName, true)[0]).Enabled = false;
                ((ComboBox)Pages.Controls.Find(BooksimTrafficTypeComboBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(BooksimPacketSizeTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(BooksimSimulationPeriodLengthTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(BooksimWarmUpPeriodsAmountTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(BooksimMaxPeriodAmountTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(BooksimInjectionRateTextBoxName + ModelName, true)[0]).Enabled = false;
                ((ComboBox)Pages.Controls.Find(BooksimSimulationTypeComboBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(BooksimIterationsAmountTextBoxName + ModelName, true)[0]).Enabled = false;
            }
        }

        private void NewximConfigFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            string ModelName = Common.GetModelName(((CheckBox)sender).Name);
            TextBox NewximConfigFileTextBox = (TextBox)Pages.Controls.Find(NewximConfigFilePathTextBoxName + ModelName, true)[0];

            if (((CheckBox)Pages.Controls.Find(NewximConfigGenerationRequiredCheckBoxName + ModelName, true)[0]).Checked)
            {
                if (ModelName == "")
                {
                    NewximConfigFileTextBox.Text = "Will be set automatically";
                }
                else
                {
                    NewximConfigFileTextBox.Text = ((Newxim)SimulationController.FindModel(ModelName)).GetConfigFilePath();
                }
                NewximConfigFileTextBox.Enabled = false;

                ((ComboBox)Pages.Controls.Find(NewximTopologyComboBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(NewximTopologyArgumentsTextBoxName + ModelName, true)[0]).Enabled = true;
                ((ComboBox)Pages.Controls.Find(NewximAlgorithmComboBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(NewximTopologyChannelsTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(NewximVirtualChannelsTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(NewximBufferDepthTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(NewximMinPacketSizeTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(NewximMaxPacketSizeTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(NewximPacketInjectionRateTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(NewximSimulationTimeTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(NewximWarmUpTimeTextBoxName + ModelName, true)[0]).Enabled = true;
                ((TextBox)Pages.Controls.Find(NewximIterationsAmountTextBoxName + ModelName, true)[0]).Enabled = true;
            }
            else
            {
                NewximConfigFileTextBox.Text = "Double-click to select";
                NewximConfigFileTextBox.Enabled = true;

                ((ComboBox)Pages.Controls.Find(NewximTopologyComboBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(NewximTopologyArgumentsTextBoxName + ModelName, true)[0]).Enabled = false;
                ((ComboBox)Pages.Controls.Find(NewximAlgorithmComboBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(NewximTopologyChannelsTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(NewximVirtualChannelsTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(NewximBufferDepthTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(NewximMinPacketSizeTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(NewximMaxPacketSizeTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(NewximPacketInjectionRateTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(NewximSimulationTimeTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(NewximWarmUpTimeTextBoxName + ModelName, true)[0]).Enabled = false;
                ((TextBox)Pages.Controls.Find(NewximIterationsAmountTextBoxName + ModelName, true)[0]).Enabled = false;
            }
        }

        private void UocnsAlgorithmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ModelName = Common.GetModelName(((ComboBox)sender).Name);

            ComboBox AlgorithmComboBox = (ComboBox)Pages.Controls.Find(UocnsAlgorithmComboBoxName + ModelName, true)[0];
            TextBox AlgorithmArgumentsTextBox = (TextBox)Pages.Controls.Find(UocnsAlgorithmArgumentsTextBoxName + ModelName, true)[0];

            if (AlgorithmComboBox.Text != AlgorithmsTypes.ROU)
            {
                AlgorithmArgumentsTextBox.Enabled = false;
                AlgorithmArgumentsTextBox.Text = "";
            }
            else if (AlgorithmComboBox.Text == AlgorithmsTypes.ROU)
            {
                AlgorithmArgumentsTextBox.Enabled = true;
                AlgorithmArgumentsTextBox.Text = "10";
            }
        }

        private void UocnsTopologyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {          
            string ModelName = Common.GetModelName(((ComboBox)sender).Name);

            ComboBox TopologyComboBox = (ComboBox)Pages.Controls.Find(UocnsTopologyComboBoxName + ModelName, true)[0];
            ComboBox AlgorithmComboBox = (ComboBox)Pages.Controls.Find(UocnsAlgorithmComboBoxName + ModelName, true)[0];
            TextBox AlgorithmArgumentsTextBox = (TextBox)Pages.Controls.Find(UocnsAlgorithmArgumentsTextBoxName + ModelName, true)[0];

            if (TopologyComboBox.Text == TopologiesTypes.Mesh)
            {
                AlgorithmComboBox.Enabled = true;
                AlgorithmComboBox.Items.Clear();
                AlgorithmComboBox.Items.AddRange(AlgorithmsTypes.MeshAlgotithms);
                AlgorithmComboBox.SelectedIndex = 0;

                AlgorithmArgumentsTextBox.Enabled = false;
                AlgorithmArgumentsTextBox.Text = "";
            }
            else if (TopologyComboBox.Text == TopologiesTypes.Torus)
            {
                AlgorithmComboBox.Enabled = false;
                AlgorithmComboBox.Items.Clear();
                AlgorithmComboBox.Items.AddRange(AlgorithmsTypes.TorusAlgorithms);
                AlgorithmComboBox.SelectedIndex = 0;

                AlgorithmArgumentsTextBox.Enabled = false;
                AlgorithmArgumentsTextBox.Text = "";
            }
            else if (TopologyComboBox.Text == TopologiesTypes.Circulant || TopologyComboBox.Text == TopologiesTypes.OptimalCirculant)
            {
                AlgorithmComboBox.Enabled = true;
                AlgorithmComboBox.Items.Clear();
                AlgorithmComboBox.Items.AddRange(AlgorithmsTypes.CirculantAlgorithms);
                AlgorithmComboBox.SelectedIndex = 0;

                AlgorithmArgumentsTextBox.Enabled = false;
                AlgorithmArgumentsTextBox.Text = "";
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
            else if (ModelType == ModelsTypes.Booksim)
            {
                CheckBox BooksimConfigCheckBox = (CheckBox)ModelPage.Controls.Find(BooksimConfigGenerationRequiredCheckBoxName, true)[0];
                BooksimConfigCheckBox.Name += ModelName;

                TextBox BooksimConfigTextBox = (TextBox)ModelPage.Controls.Find(BooksimConfigFilePathTextBoxName, true)[0];
                BooksimConfigTextBox.Name += ModelName;
                string BooksimConfigPath = "";
                if (BooksimConfigCheckBox.Checked)
                {
                    BooksimConfigPath = ModelResPath + "\\" + Booksim.DefaultConfigFileName;
                    BooksimConfigTextBox.Text = BooksimConfigPath;
                }
                else
                {
                    BooksimConfigPath = BooksimConfigTextBox.Text;
                }

                ComboBox BooksimTopologyComboBox = (ComboBox)ModelPage.Controls.Find(BooksimTopologyComboBoxName, true)[0];
                string BooksimTopology = BooksimTopologyComboBox.Text;
                BooksimTopologyComboBox.Name += ModelName;

                TextBox BooksimTopologyArgsTextBox = (TextBox)ModelPage.Controls.Find(BooksimTopologyArgumentsTextBoxName, true)[0];
                string[] BooksimTopologyArgs = BooksimTopologyArgsTextBox.Text.Split();
                BooksimTopologyArgsTextBox.Name += ModelName;

                ComboBox BooksimAlgorithmComboBox = (ComboBox)ModelPage.Controls.Find(BooksimAlgorithmComboBoxName, true)[0];
                string BooksimAlgorithm = BooksimAlgorithmComboBox.Text;
                BooksimAlgorithmComboBox.Name += ModelName;

                TextBox BooksimFifoSizeTextBox = (TextBox)ModelPage.Controls.Find(BooksimVirtualChannelsSizeTextBoxName, true)[0];
                string BooksimVirtualChannelsSize = BooksimFifoSizeTextBox.Text;
                BooksimFifoSizeTextBox.Name += ModelName;

                TextBox BooksimFifoCountTextBox = (TextBox)ModelPage.Controls.Find(BooksimVirtualChannelsAmountTextBoxName, true)[0];
                string BooksimVirtualChannelsAmount = BooksimFifoCountTextBox.Text;
                BooksimFifoCountTextBox.Name += ModelName;

                ComboBox BooksimTrafficTypeComboBox = (ComboBox)ModelPage.Controls.Find(BooksimTrafficTypeComboBoxName, true)[0];
                string BooksimTrafficType = BooksimTrafficTypeComboBox.Text;
                BooksimTrafficTypeComboBox.Name += ModelName;

                TextBox BooksimPacketSizeTextBox = (TextBox)ModelPage.Controls.Find(BooksimPacketSizeTextBoxName, true)[0];
                string BooksimPacketSize = BooksimPacketSizeTextBox.Text;
                BooksimPacketSizeTextBox.Name += ModelName;

                TextBox BooksimSimPeriodTextBox = (TextBox)ModelPage.Controls.Find(BooksimSimulationPeriodLengthTextBoxName, true)[0];
                string BooksimSimPeriodLength = BooksimSimPeriodTextBox.Text;
                BooksimSimPeriodTextBox.Name += ModelName;

                TextBox BooksimWarmUpTextBox = (TextBox)ModelPage.Controls.Find(BooksimWarmUpPeriodsAmountTextBoxName, true)[0];
                string BooksimWarmUpPeriods = BooksimWarmUpTextBox.Text;
                BooksimWarmUpTextBox.Name += ModelName;

                TextBox BooksimMaxPeriodTextBox = (TextBox)ModelPage.Controls.Find(BooksimMaxPeriodAmountTextBoxName, true)[0];
                string BooksimMaxPeriods = BooksimMaxPeriodTextBox.Text;
                BooksimMaxPeriodTextBox.Name += ModelName;

                ComboBox BooksimSimTypeComboBox = (ComboBox)ModelPage.Controls.Find(BooksimSimulationTypeComboBoxName, true)[0];
                string BooksimSimType = BooksimSimTypeComboBox.Text;
                BooksimSimTypeComboBox.Name += ModelName;

                TextBox BooksimInjectionRateTextBox = (TextBox)ModelPage.Controls.Find(BooksimInjectionRateTextBoxName, true)[0];
                string BooksimInjectionRate = BooksimInjectionRateTextBox.Text;
                BooksimInjectionRateTextBox.Name += ModelName;

                TextBox BooksimIterationsAmountTextBox = (TextBox)ModelPage.Controls.Find(BooksimIterationsAmountTextBoxName, true)[0];
                string BooksimIterationsAmount = BooksimIterationsAmountTextBox.Text;
                BooksimIterationsAmountTextBox.Name += ModelName;

                Booksim BookSim = new Booksim(ModelType, ModelName, ModelExePath, ModelResPath,
                                              BooksimConfigCheckBox.Checked, BooksimConfigPath, BooksimTopology, BooksimTopologyArgs,
                                              BooksimAlgorithm, BooksimVirtualChannelsAmount, BooksimVirtualChannelsSize,
                                              BooksimTrafficType, BooksimPacketSize, BooksimSimPeriodLength, BooksimWarmUpPeriods,
                                              BooksimMaxPeriods, BooksimSimType, BooksimInjectionRate, BooksimIterationsAmount);
                                         

                SimulationController.Models.Add(BookSim);
            }
            else if (ModelType == ModelsTypes.Newxim)
            {
                CheckBox NewximConfigCheckBox = (CheckBox)ModelPage.Controls.Find(NewximConfigGenerationRequiredCheckBoxName, true)[0];
                NewximConfigCheckBox.Name += ModelName;

                TextBox NewximConfigTextBox = (TextBox)ModelPage.Controls.Find(NewximConfigFilePathTextBoxName, true)[0];
                NewximConfigTextBox.Name += ModelName;
                string NewximConfigPath = "";
                if (NewximConfigCheckBox.Checked)
                {
                    NewximConfigPath = ModelResPath + "\\" + Newxim.DefaultConfigFileName;
                    NewximConfigTextBox.Text = NewximConfigPath;
                }
                else
                {
                    NewximConfigPath = NewximConfigTextBox.Text;
                }

                ComboBox NewximTopologyComboBox = (ComboBox)ModelPage.Controls.Find(NewximTopologyComboBoxName, true)[0];
                string NewximTopology = NewximTopologyComboBox.Text;
                NewximTopologyComboBox.Name += ModelName;

                TextBox NewximTopologyArgsTextBox = (TextBox)ModelPage.Controls.Find(NewximTopologyArgumentsTextBoxName, true)[0];
                string[] NewximTopologyArgs = NewximTopologyArgsTextBox.Text.Split();
                NewximTopologyArgsTextBox.Name += ModelName;

                ComboBox NewximAlgorithmComboBox = (ComboBox)ModelPage.Controls.Find(NewximAlgorithmComboBoxName, true)[0];
                string NewximAlgorithm = NewximAlgorithmComboBox.Text;
                NewximAlgorithmComboBox.Name += ModelName;

                TextBox NewximTopologyChannelsTextBox = (TextBox)ModelPage.Controls.Find(NewximTopologyChannelsTextBoxName, true)[0];
                string NewximTopologyChannels = NewximTopologyChannelsTextBox.Text;
                NewximTopologyChannelsTextBox.Name += ModelName;

                TextBox NewximVirtualChannelsTextBox = (TextBox)ModelPage.Controls.Find(NewximVirtualChannelsTextBoxName, true)[0];
                string NewximVirtualChannels = NewximVirtualChannelsTextBox.Text;
                NewximVirtualChannelsTextBox.Name += ModelName;

                TextBox NewximBufferDepthTextBox = (TextBox)ModelPage.Controls.Find(NewximBufferDepthTextBoxName, true)[0];
                string NewximBufferDepth = NewximBufferDepthTextBox.Text;
                NewximBufferDepthTextBox.Name += ModelName;

                TextBox NewximMinPacketSizeTextBox = (TextBox)ModelPage.Controls.Find(NewximMinPacketSizeTextBoxName, true)[0];
                string NewximMinPacketSize = NewximMinPacketSizeTextBox.Text;
                NewximMinPacketSizeTextBox.Name += ModelName;

                TextBox NewximMaxPacketSizeTextBox = (TextBox)ModelPage.Controls.Find(NewximMaxPacketSizeTextBoxName, true)[0];
                string NewximMaxPacketSize = NewximMaxPacketSizeTextBox.Text;
                NewximMaxPacketSizeTextBox.Name += ModelName;

                TextBox NewximPacketInjectionRateTextBox = (TextBox)ModelPage.Controls.Find(NewximPacketInjectionRateTextBoxName, true)[0];
                string NewximPacketInjectionRate = NewximPacketInjectionRateTextBox.Text;
                NewximPacketInjectionRateTextBox.Name += ModelName;

                TextBox NewximSimTimeTextBox = (TextBox)ModelPage.Controls.Find(NewximSimulationTimeTextBoxName, true)[0];
                string NewximSimTime = NewximSimTimeTextBox.Text;
                NewximSimTimeTextBox.Name += ModelName;

                TextBox NewximWarmUpTimeTextBox = (TextBox)ModelPage.Controls.Find(NewximWarmUpTimeTextBoxName, true)[0];
                string NewximWarmUpTime = NewximWarmUpTimeTextBox.Text;
                NewximWarmUpTimeTextBox.Name += ModelName;

                TextBox NewximIterationsAmountTextBox = (TextBox)ModelPage.Controls.Find(NewximIterationsAmountTextBoxName, true)[0];
                string NewximIterationsAmount = NewximIterationsAmountTextBox.Text;
                NewximIterationsAmountTextBox.Name += ModelName;

                Newxim NewXim = new Newxim(ModelType, ModelName, ModelExePath, ModelResPath,
                                              NewximConfigCheckBox.Checked, NewximConfigPath, NewximTopology, NewximTopologyArgs,
                                              NewximAlgorithm, NewximTopologyChannels, NewximVirtualChannels, NewximBufferDepth,
                                              NewximMinPacketSize, NewximMaxPacketSize, NewximPacketInjectionRate,
                                              NewximSimTime, NewximWarmUpTime, NewximIterationsAmount);

                SimulationController.Models.Add(NewXim);
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

            if (ModelType == ModelsTypes.UOCNS)
            {
                ModelResultsTable TableControl = new ModelResultsTable();
                ModelResultsPage.Controls.Add(TableControl);
            }
            else if (ModelType == ModelsTypes.Booksim)
            {
                BooksimResultTable TableControl = new BooksimResultTable();
                ModelResultsPage.Controls.Add(TableControl);
            }
            else if (ModelType == ModelsTypes.Newxim)
            {
                NewximResultTable TableControl = new NewximResultTable();
                ModelResultsPage.Controls.Add(TableControl);
            }
            
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
            else if (ConnectedModel.GetType() == ModelsTypes.Booksim)
            {
                Booksim BookSim = (Booksim)ConnectedModel;
                ((TextBox)ModelPage.Controls.Find(BooksimConfigFilePathTextBoxName + ModelName, true)[0]).Text = BookSim.GetConfigFilePath();
                ((CheckBox)ModelPage.Controls.Find(BooksimConfigGenerationRequiredCheckBoxName + ModelName, true)[0]).Checked = BookSim.GetConfigGenerationRequired();
                ((ComboBox)ModelPage.Controls.Find(BooksimTopologyComboBoxName + ModelName, true)[0]).Text = BookSim.GetTopology();
                ((TextBox)ModelPage.Controls.Find(BooksimTopologyArgumentsTextBoxName + ModelName, true)[0]).Text = Common.Concatenate(BookSim.GetTopologyArguments());
                ((ComboBox)ModelPage.Controls.Find(BooksimAlgorithmComboBoxName + ModelName, true)[0]).Text = BookSim.GetRoutingFunction();
                ((TextBox)ModelPage.Controls.Find(BooksimVirtualChannelsSizeTextBoxName + ModelName, true)[0]).Text = BookSim.GetVirtualChannelsBufferSize();
                ((TextBox)ModelPage.Controls.Find(BooksimVirtualChannelsAmountTextBoxName + ModelName, true)[0]).Text = BookSim.GetVirtualChannelsAmount();
                ((ComboBox)ModelPage.Controls.Find(BooksimTrafficTypeComboBoxName + ModelName, true)[0]).Text = BookSim.GetTrafficType();
                ((TextBox)ModelPage.Controls.Find(BooksimPacketSizeTextBoxName + ModelName, true)[0]).Text = BookSim.GetPacketSize();
                ((TextBox)ModelPage.Controls.Find(BooksimSimulationPeriodLengthTextBoxName + ModelName, true)[0]).Text = BookSim.GetSimulationPeriodLength();
                ((TextBox)ModelPage.Controls.Find(BooksimWarmUpPeriodsAmountTextBoxName + ModelName, true)[0]).Text = BookSim.GetWarmUpPeriodsAmount();
                ((TextBox)ModelPage.Controls.Find(BooksimMaxPeriodAmountTextBoxName + ModelName, true)[0]).Text = BookSim.GetMaxPeriodsAmount();
                ((ComboBox)ModelPage.Controls.Find(BooksimSimulationTypeComboBoxName + ModelName, true)[0]).Text = BookSim.GetSimulationType();
                ((TextBox)ModelPage.Controls.Find(BooksimInjectionRateTextBoxName + ModelName, true)[0]).Text = BookSim.GetInjectionRate();
                ((TextBox)ModelPage.Controls.Find(BooksimIterationsAmountTextBoxName + ModelName, true)[0]).Text = BookSim.GetIterationsAmount();
            }
            else if (ConnectedModel.GetType() == ModelsTypes.Newxim)
            {
                Newxim NewXim = (Newxim)ConnectedModel;
                ((TextBox)ModelPage.Controls.Find(NewximConfigFilePathTextBoxName + ModelName, true)[0]).Text = NewXim.GetConfigFilePath();
                ((CheckBox)ModelPage.Controls.Find(NewximConfigGenerationRequiredCheckBoxName + ModelName, true)[0]).Checked = NewXim.GetConfigGenerationRequired();
                ((ComboBox)ModelPage.Controls.Find(NewximTopologyComboBoxName + ModelName, true)[0]).Text = NewXim.GetTopology();
                ((TextBox)ModelPage.Controls.Find(NewximTopologyArgumentsTextBoxName + ModelName, true)[0]).Text = Common.Concatenate(NewXim.GetTopologyArguments());
                ((ComboBox)ModelPage.Controls.Find(NewximAlgorithmComboBoxName + ModelName, true)[0]).Text = NewXim.GetRoutingAlgorithm();
                ((TextBox)ModelPage.Controls.Find(NewximTopologyChannelsTextBoxName + ModelName, true)[0]).Text = NewXim.GetTopologyChannels();
                ((TextBox)ModelPage.Controls.Find(NewximVirtualChannelsTextBoxName + ModelName, true)[0]).Text = NewXim.GetVirtualChannels();
                ((TextBox)ModelPage.Controls.Find(NewximBufferDepthTextBoxName + ModelName, true)[0]).Text = NewXim.GetBufferDepth();
                ((TextBox)ModelPage.Controls.Find(NewximMinPacketSizeTextBoxName + ModelName, true)[0]).Text = NewXim.GetMinPacketSize();
                ((TextBox)ModelPage.Controls.Find(NewximMaxPacketSizeTextBoxName + ModelName, true)[0]).Text = NewXim.GetMaxPacketSize();
                ((TextBox)ModelPage.Controls.Find(NewximPacketInjectionRateTextBoxName + ModelName, true)[0]).Text = NewXim.GetPacketInjectionRate();
                ((TextBox)ModelPage.Controls.Find(NewximSimulationTimeTextBoxName + ModelName, true)[0]).Text = NewXim.GetSimulationTime();
                ((TextBox)ModelPage.Controls.Find(NewximWarmUpTimeTextBoxName + ModelName, true)[0]).Text = NewXim.GetWarmUpTime();
                ((TextBox)ModelPage.Controls.Find(NewximIterationsAmountTextBoxName + ModelName, true)[0]).Text = NewXim.GetIterationsAmount();
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
            else if (SimulationController.Models[ModelIndex].GetType() == ModelsTypes.Booksim)
            {
                ((Booksim)SimulationController.Models[ModelIndex]).SetConfigFilePath(((TextBox)ModelPage.Controls.Find(BooksimConfigFilePathTextBoxName + ModelName, true)[0]).Text);
                ((Booksim)SimulationController.Models[ModelIndex]).SetConfigGenerationRequired(((CheckBox)ModelPage.Controls.Find(BooksimConfigGenerationRequiredCheckBoxName + ModelName, true)[0]).Checked);
                ((Booksim)SimulationController.Models[ModelIndex]).SetTopology(((ComboBox)ModelPage.Controls.Find(BooksimTopologyComboBoxName + ModelName, true)[0]).Text);
                ((Booksim)SimulationController.Models[ModelIndex]).SetTopologyArguments(((TextBox)ModelPage.Controls.Find(BooksimTopologyArgumentsTextBoxName + ModelName, true)[0]).Text.Split());
                ((Booksim)SimulationController.Models[ModelIndex]).SetRoutingFunction(((ComboBox)ModelPage.Controls.Find(BooksimAlgorithmComboBoxName + ModelName, true)[0]).Text);
                ((Booksim)SimulationController.Models[ModelIndex]).SetVirtualChannelsAmount(((TextBox)ModelPage.Controls.Find(BooksimVirtualChannelsAmountTextBoxName + ModelName, true)[0]).Text);
                ((Booksim)SimulationController.Models[ModelIndex]).SetVirtualChannelsBufferSize(((TextBox)ModelPage.Controls.Find(BooksimVirtualChannelsSizeTextBoxName + ModelName, true)[0]).Text);
                ((Booksim)SimulationController.Models[ModelIndex]).SetTrafficType(((ComboBox)ModelPage.Controls.Find(BooksimTrafficTypeComboBoxName + ModelName, true)[0]).Text);
                ((Booksim)SimulationController.Models[ModelIndex]).SetPacketSize(((TextBox)ModelPage.Controls.Find(BooksimPacketSizeTextBoxName + ModelName, true)[0]).Text);
                ((Booksim)SimulationController.Models[ModelIndex]).SetSimulationPeriodLength(((TextBox)ModelPage.Controls.Find(BooksimSimulationPeriodLengthTextBoxName + ModelName, true)[0]).Text);
                ((Booksim)SimulationController.Models[ModelIndex]).SetWarmUpPeriodsAmount(((TextBox)ModelPage.Controls.Find(BooksimWarmUpPeriodsAmountTextBoxName + ModelName, true)[0]).Text);
                ((Booksim)SimulationController.Models[ModelIndex]).SetMaxPeriodsAmount(((TextBox)ModelPage.Controls.Find(BooksimMaxPeriodAmountTextBoxName + ModelName, true)[0]).Text);
                ((Booksim)SimulationController.Models[ModelIndex]).SetSimulationType(((ComboBox)ModelPage.Controls.Find(BooksimSimulationTypeComboBoxName + ModelName, true)[0]).Text);
                ((Booksim)SimulationController.Models[ModelIndex]).SetInjectionRate(((TextBox)ModelPage.Controls.Find(BooksimInjectionRateTextBoxName + ModelName, true)[0]).Text);
                ((Booksim)SimulationController.Models[ModelIndex]).SetIterationsAmount(((TextBox)ModelPage.Controls.Find(BooksimIterationsAmountTextBoxName + ModelName, true)[0]).Text);
            }
            else if (SimulationController.Models[ModelIndex].GetType() == ModelsTypes.Newxim)
            {
                ((Newxim)SimulationController.Models[ModelIndex]).SetConfigFilePath(((TextBox)ModelPage.Controls.Find(NewximConfigFilePathTextBoxName + ModelName, true)[0]).Text);
                ((Newxim)SimulationController.Models[ModelIndex]).SetConfigGenerationRequired(((CheckBox)ModelPage.Controls.Find(NewximConfigGenerationRequiredCheckBoxName + ModelName, true)[0]).Checked);
                ((Newxim)SimulationController.Models[ModelIndex]).SetTopology(((ComboBox)ModelPage.Controls.Find(NewximTopologyComboBoxName + ModelName, true)[0]).Text);
                ((Newxim)SimulationController.Models[ModelIndex]).SetTopologyArguments(((TextBox)ModelPage.Controls.Find(NewximTopologyArgumentsTextBoxName + ModelName, true)[0]).Text.Split());
                ((Newxim)SimulationController.Models[ModelIndex]).SetRoutingAlgorithm(((ComboBox)ModelPage.Controls.Find(NewximAlgorithmComboBoxName + ModelName, true)[0]).Text);
                ((Newxim)SimulationController.Models[ModelIndex]).SetTopologyChannels(((TextBox)ModelPage.Controls.Find(NewximTopologyChannelsTextBoxName + ModelName, true)[0]).Text);
                ((Newxim)SimulationController.Models[ModelIndex]).SetVirtualChannels(((TextBox)ModelPage.Controls.Find(NewximVirtualChannelsTextBoxName + ModelName, true)[0]).Text);
                ((Newxim)SimulationController.Models[ModelIndex]).SetBufferDepth(((TextBox)ModelPage.Controls.Find(NewximBufferDepthTextBoxName + ModelName, true)[0]).Text);
                ((Newxim)SimulationController.Models[ModelIndex]).SetMinPacketSize(((TextBox)ModelPage.Controls.Find(NewximMinPacketSizeTextBoxName + ModelName, true)[0]).Text);
                ((Newxim)SimulationController.Models[ModelIndex]).SetMaxPacketSize(((TextBox)ModelPage.Controls.Find(NewximMaxPacketSizeTextBoxName + ModelName, true)[0]).Text);
                ((Newxim)SimulationController.Models[ModelIndex]).SetPacketInjectionRate(((TextBox)ModelPage.Controls.Find(NewximPacketInjectionRateTextBoxName + ModelName, true)[0]).Text);
                ((Newxim)SimulationController.Models[ModelIndex]).SetSimulationTime(((TextBox)ModelPage.Controls.Find(NewximSimulationTimeTextBoxName + ModelName, true)[0]).Text);
                ((Newxim)SimulationController.Models[ModelIndex]).SetWarmUpTime(((TextBox)ModelPage.Controls.Find(NewximWarmUpTimeTextBoxName + ModelName, true)[0]).Text);
                ((Newxim)SimulationController.Models[ModelIndex]).SetIterationsAmount(((TextBox)ModelPage.Controls.Find(NewximIterationsAmountTextBoxName + ModelName, true)[0]).Text);
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
