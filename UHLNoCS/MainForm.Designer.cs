namespace UHLNoCS
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LogsTextBox = new System.Windows.Forms.TextBox();
            this.Pages = new System.Windows.Forms.TabControl();
            this.SettingsPage = new System.Windows.Forms.TabPage();
            this.ModelsStateTable = new System.Windows.Forms.DataGridView();
            this.ModelNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelPreparationProcessColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelSimulationProcessColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelCollectingResultsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SimulationStateTable = new System.Windows.Forms.DataGridView();
            this.AddingModelsProcessColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreparationProcessColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SimulationProcessColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollectingResultsProcessColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SimulationNameTextBox = new System.Windows.Forms.TextBox();
            this.DeleteModelButton = new System.Windows.Forms.Button();
            this.StopModelButton = new System.Windows.Forms.Button();
            this.StopSimulationButton = new System.Windows.Forms.Button();
            this.StartSimulationButton = new System.Windows.Forms.Button();
            this.NewSimulationButton = new System.Windows.Forms.Button();
            this.SimulationNameButton = new System.Windows.Forms.Button();
            this.ModelsStateLabel = new System.Windows.Forms.Label();
            this.SimulationStateLabel = new System.Windows.Forms.Label();
            this.SimulationNameLabel = new System.Windows.Forms.Label();
            this.ModelAddButton = new System.Windows.Forms.Button();
            this.LogsPage = new System.Windows.Forms.TabPage();
            this.LogsButton = new System.Windows.Forms.Button();
            this.ResultsPage = new System.Windows.Forms.TabPage();
            this.CompareButton = new System.Windows.Forms.Button();
            this.TablesGraphsButton = new System.Windows.Forms.Button();
            this.ExportResultsButton = new System.Windows.Forms.Button();
            this.ModelsResultsPages = new System.Windows.Forms.TabControl();
            this.Pages.SuspendLayout();
            this.SettingsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModelsStateTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SimulationStateTable)).BeginInit();
            this.LogsPage.SuspendLayout();
            this.ResultsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogsTextBox
            // 
            this.LogsTextBox.AcceptsReturn = true;
            this.LogsTextBox.Location = new System.Drawing.Point(6, 6);
            this.LogsTextBox.Multiline = true;
            this.LogsTextBox.Name = "LogsTextBox";
            this.LogsTextBox.ReadOnly = true;
            this.LogsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogsTextBox.Size = new System.Drawing.Size(1140, 495);
            this.LogsTextBox.TabIndex = 5;
            // 
            // Pages
            // 
            this.Pages.Controls.Add(this.SettingsPage);
            this.Pages.Controls.Add(this.LogsPage);
            this.Pages.Controls.Add(this.ResultsPage);
            this.Pages.Location = new System.Drawing.Point(12, 12);
            this.Pages.Name = "Pages";
            this.Pages.SelectedIndex = 0;
            this.Pages.Size = new System.Drawing.Size(1160, 562);
            this.Pages.TabIndex = 6;
            // 
            // SettingsPage
            // 
            this.SettingsPage.Controls.Add(this.ModelsStateTable);
            this.SettingsPage.Controls.Add(this.SimulationStateTable);
            this.SettingsPage.Controls.Add(this.SimulationNameTextBox);
            this.SettingsPage.Controls.Add(this.DeleteModelButton);
            this.SettingsPage.Controls.Add(this.StopModelButton);
            this.SettingsPage.Controls.Add(this.StopSimulationButton);
            this.SettingsPage.Controls.Add(this.StartSimulationButton);
            this.SettingsPage.Controls.Add(this.NewSimulationButton);
            this.SettingsPage.Controls.Add(this.SimulationNameButton);
            this.SettingsPage.Controls.Add(this.ModelsStateLabel);
            this.SettingsPage.Controls.Add(this.SimulationStateLabel);
            this.SettingsPage.Controls.Add(this.SimulationNameLabel);
            this.SettingsPage.Controls.Add(this.ModelAddButton);
            this.SettingsPage.Location = new System.Drawing.Point(4, 22);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsPage.Size = new System.Drawing.Size(1152, 536);
            this.SettingsPage.TabIndex = 0;
            this.SettingsPage.Text = "Simulation settings";
            this.SettingsPage.UseVisualStyleBackColor = true;
            // 
            // ModelsStateTable
            // 
            this.ModelsStateTable.AllowUserToAddRows = false;
            this.ModelsStateTable.AllowUserToDeleteRows = false;
            this.ModelsStateTable.AllowUserToResizeColumns = false;
            this.ModelsStateTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ModelsStateTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ModelsStateTable.ColumnHeadersHeight = 25;
            this.ModelsStateTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ModelsStateTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModelNameColumn,
            this.ModelPreparationProcessColumn,
            this.ModelSimulationProcessColumn,
            this.ModelCollectingResultsColumn});
            this.ModelsStateTable.Location = new System.Drawing.Point(270, 226);
            this.ModelsStateTable.Name = "ModelsStateTable";
            this.ModelsStateTable.ReadOnly = true;
            this.ModelsStateTable.RowHeadersVisible = false;
            this.ModelsStateTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ModelsStateTable.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.ModelsStateTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ModelsStateTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ModelsStateTable.Size = new System.Drawing.Size(603, 273);
            this.ModelsStateTable.TabIndex = 14;
            // 
            // ModelNameColumn
            // 
            this.ModelNameColumn.Frozen = true;
            this.ModelNameColumn.HeaderText = "Model name";
            this.ModelNameColumn.Name = "ModelNameColumn";
            this.ModelNameColumn.ReadOnly = true;
            this.ModelNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ModelNameColumn.Width = 150;
            // 
            // ModelPreparationProcessColumn
            // 
            this.ModelPreparationProcessColumn.Frozen = true;
            this.ModelPreparationProcessColumn.HeaderText = "Preparation for simulation";
            this.ModelPreparationProcessColumn.Name = "ModelPreparationProcessColumn";
            this.ModelPreparationProcessColumn.ReadOnly = true;
            this.ModelPreparationProcessColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ModelPreparationProcessColumn.Width = 150;
            // 
            // ModelSimulationProcessColumn
            // 
            this.ModelSimulationProcessColumn.Frozen = true;
            this.ModelSimulationProcessColumn.HeaderText = "Simulation process";
            this.ModelSimulationProcessColumn.Name = "ModelSimulationProcessColumn";
            this.ModelSimulationProcessColumn.ReadOnly = true;
            this.ModelSimulationProcessColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ModelSimulationProcessColumn.Width = 150;
            // 
            // ModelCollectingResultsColumn
            // 
            this.ModelCollectingResultsColumn.Frozen = true;
            this.ModelCollectingResultsColumn.HeaderText = "Collecting results";
            this.ModelCollectingResultsColumn.Name = "ModelCollectingResultsColumn";
            this.ModelCollectingResultsColumn.ReadOnly = true;
            this.ModelCollectingResultsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ModelCollectingResultsColumn.Width = 150;
            // 
            // SimulationStateTable
            // 
            this.SimulationStateTable.AllowUserToAddRows = false;
            this.SimulationStateTable.AllowUserToDeleteRows = false;
            this.SimulationStateTable.AllowUserToResizeColumns = false;
            this.SimulationStateTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SimulationStateTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.SimulationStateTable.ColumnHeadersHeight = 25;
            this.SimulationStateTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.SimulationStateTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AddingModelsProcessColumn,
            this.PreparationProcessColumn,
            this.SimulationProcessColumn,
            this.CollectingResultsProcessColumn});
            this.SimulationStateTable.Location = new System.Drawing.Point(270, 83);
            this.SimulationStateTable.Name = "SimulationStateTable";
            this.SimulationStateTable.ReadOnly = true;
            this.SimulationStateTable.RowHeadersVisible = false;
            this.SimulationStateTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SimulationStateTable.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.SimulationStateTable.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SimulationStateTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SimulationStateTable.Size = new System.Drawing.Size(603, 50);
            this.SimulationStateTable.TabIndex = 13;
            this.SimulationStateTable.SelectionChanged += new System.EventHandler(this.SimulationStateTable_SelectionChanged);
            // 
            // AddingModelsProcessColumn
            // 
            this.AddingModelsProcessColumn.Frozen = true;
            this.AddingModelsProcessColumn.HeaderText = "Adding models";
            this.AddingModelsProcessColumn.Name = "AddingModelsProcessColumn";
            this.AddingModelsProcessColumn.ReadOnly = true;
            this.AddingModelsProcessColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AddingModelsProcessColumn.Width = 150;
            // 
            // PreparationProcessColumn
            // 
            this.PreparationProcessColumn.Frozen = true;
            this.PreparationProcessColumn.HeaderText = "Preparation for simulation";
            this.PreparationProcessColumn.Name = "PreparationProcessColumn";
            this.PreparationProcessColumn.ReadOnly = true;
            this.PreparationProcessColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PreparationProcessColumn.Width = 150;
            // 
            // SimulationProcessColumn
            // 
            this.SimulationProcessColumn.Frozen = true;
            this.SimulationProcessColumn.HeaderText = "Simulation process";
            this.SimulationProcessColumn.Name = "SimulationProcessColumn";
            this.SimulationProcessColumn.ReadOnly = true;
            this.SimulationProcessColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SimulationProcessColumn.Width = 150;
            // 
            // CollectingResultsProcessColumn
            // 
            this.CollectingResultsProcessColumn.Frozen = true;
            this.CollectingResultsProcessColumn.HeaderText = "Collecting results";
            this.CollectingResultsProcessColumn.Name = "CollectingResultsProcessColumn";
            this.CollectingResultsProcessColumn.ReadOnly = true;
            this.CollectingResultsProcessColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CollectingResultsProcessColumn.Width = 150;
            // 
            // SimulationNameTextBox
            // 
            this.SimulationNameTextBox.Location = new System.Drawing.Point(468, 8);
            this.SimulationNameTextBox.Name = "SimulationNameTextBox";
            this.SimulationNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.SimulationNameTextBox.TabIndex = 12;
            // 
            // DeleteModelButton
            // 
            this.DeleteModelButton.Enabled = false;
            this.DeleteModelButton.Location = new System.Drawing.Point(723, 505);
            this.DeleteModelButton.Name = "DeleteModelButton";
            this.DeleteModelButton.Size = new System.Drawing.Size(150, 25);
            this.DeleteModelButton.TabIndex = 11;
            this.DeleteModelButton.Text = "Delete model(s)";
            this.DeleteModelButton.UseVisualStyleBackColor = true;
            this.DeleteModelButton.Click += new System.EventHandler(this.DeleteModelButton_Click);
            // 
            // StopModelButton
            // 
            this.StopModelButton.Enabled = false;
            this.StopModelButton.Location = new System.Drawing.Point(494, 505);
            this.StopModelButton.Name = "StopModelButton";
            this.StopModelButton.Size = new System.Drawing.Size(150, 25);
            this.StopModelButton.TabIndex = 10;
            this.StopModelButton.Text = "Stop model(s) simulation";
            this.StopModelButton.UseVisualStyleBackColor = true;
            this.StopModelButton.Click += new System.EventHandler(this.StopModelButton_Click);
            // 
            // StopSimulationButton
            // 
            this.StopSimulationButton.Enabled = false;
            this.StopSimulationButton.Location = new System.Drawing.Point(494, 139);
            this.StopSimulationButton.Name = "StopSimulationButton";
            this.StopSimulationButton.Size = new System.Drawing.Size(150, 25);
            this.StopSimulationButton.TabIndex = 8;
            this.StopSimulationButton.Text = "Stop simulation process";
            this.StopSimulationButton.UseVisualStyleBackColor = true;
            this.StopSimulationButton.Click += new System.EventHandler(this.StopSimulationButton_Click);
            // 
            // StartSimulationButton
            // 
            this.StartSimulationButton.Enabled = false;
            this.StartSimulationButton.Location = new System.Drawing.Point(270, 139);
            this.StartSimulationButton.Name = "StartSimulationButton";
            this.StartSimulationButton.Size = new System.Drawing.Size(150, 25);
            this.StartSimulationButton.TabIndex = 6;
            this.StartSimulationButton.Text = "Start simulation";
            this.StartSimulationButton.UseVisualStyleBackColor = true;
            this.StartSimulationButton.Click += new System.EventHandler(this.StartSimulationButton_Click);
            // 
            // NewSimulationButton
            // 
            this.NewSimulationButton.Enabled = false;
            this.NewSimulationButton.Location = new System.Drawing.Point(723, 139);
            this.NewSimulationButton.Name = "NewSimulationButton";
            this.NewSimulationButton.Size = new System.Drawing.Size(150, 25);
            this.NewSimulationButton.TabIndex = 5;
            this.NewSimulationButton.Text = "New simulation";
            this.NewSimulationButton.UseVisualStyleBackColor = true;
            this.NewSimulationButton.Click += new System.EventHandler(this.NewSimulationButton_Click);
            // 
            // SimulationNameButton
            // 
            this.SimulationNameButton.Location = new System.Drawing.Point(674, 6);
            this.SimulationNameButton.Name = "SimulationNameButton";
            this.SimulationNameButton.Size = new System.Drawing.Size(150, 25);
            this.SimulationNameButton.TabIndex = 4;
            this.SimulationNameButton.Text = "Save name";
            this.SimulationNameButton.UseVisualStyleBackColor = true;
            this.SimulationNameButton.Click += new System.EventHandler(this.SimulationNameButton_Click);
            // 
            // ModelsStateLabel
            // 
            this.ModelsStateLabel.Location = new System.Drawing.Point(494, 198);
            this.ModelsStateLabel.Name = "ModelsStateLabel";
            this.ModelsStateLabel.Size = new System.Drawing.Size(150, 25);
            this.ModelsStateLabel.TabIndex = 3;
            this.ModelsStateLabel.Text = "Models state information";
            this.ModelsStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SimulationStateLabel
            // 
            this.SimulationStateLabel.Location = new System.Drawing.Point(494, 55);
            this.SimulationStateLabel.Name = "SimulationStateLabel";
            this.SimulationStateLabel.Size = new System.Drawing.Size(150, 25);
            this.SimulationStateLabel.TabIndex = 2;
            this.SimulationStateLabel.Text = "Simulation state information";
            this.SimulationStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SimulationNameLabel
            // 
            this.SimulationNameLabel.Location = new System.Drawing.Point(312, 6);
            this.SimulationNameLabel.Name = "SimulationNameLabel";
            this.SimulationNameLabel.Size = new System.Drawing.Size(150, 25);
            this.SimulationNameLabel.TabIndex = 1;
            this.SimulationNameLabel.Text = "Simulation name";
            this.SimulationNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ModelAddButton
            // 
            this.ModelAddButton.Location = new System.Drawing.Point(270, 505);
            this.ModelAddButton.Name = "ModelAddButton";
            this.ModelAddButton.Size = new System.Drawing.Size(150, 25);
            this.ModelAddButton.TabIndex = 0;
            this.ModelAddButton.Text = "Add model";
            this.ModelAddButton.UseVisualStyleBackColor = true;
            this.ModelAddButton.Click += new System.EventHandler(this.ModelAddButton_Click);
            // 
            // LogsPage
            // 
            this.LogsPage.Controls.Add(this.LogsButton);
            this.LogsPage.Controls.Add(this.LogsTextBox);
            this.LogsPage.Location = new System.Drawing.Point(4, 22);
            this.LogsPage.Name = "LogsPage";
            this.LogsPage.Padding = new System.Windows.Forms.Padding(3);
            this.LogsPage.Size = new System.Drawing.Size(1152, 536);
            this.LogsPage.TabIndex = 1;
            this.LogsPage.Text = "Simulation logs";
            this.LogsPage.UseVisualStyleBackColor = true;
            // 
            // LogsButton
            // 
            this.LogsButton.Location = new System.Drawing.Point(523, 507);
            this.LogsButton.Name = "LogsButton";
            this.LogsButton.Size = new System.Drawing.Size(106, 23);
            this.LogsButton.TabIndex = 6;
            this.LogsButton.Text = "Clear";
            this.LogsButton.UseVisualStyleBackColor = true;
            this.LogsButton.Click += new System.EventHandler(this.LogsButton_Click);
            // 
            // ResultsPage
            // 
            this.ResultsPage.Controls.Add(this.CompareButton);
            this.ResultsPage.Controls.Add(this.TablesGraphsButton);
            this.ResultsPage.Controls.Add(this.ExportResultsButton);
            this.ResultsPage.Controls.Add(this.ModelsResultsPages);
            this.ResultsPage.Location = new System.Drawing.Point(4, 22);
            this.ResultsPage.Name = "ResultsPage";
            this.ResultsPage.Size = new System.Drawing.Size(1152, 536);
            this.ResultsPage.TabIndex = 2;
            this.ResultsPage.Text = "Simulation results";
            this.ResultsPage.UseVisualStyleBackColor = true;
            // 
            // CompareButton
            // 
            this.CompareButton.Location = new System.Drawing.Point(749, 502);
            this.CompareButton.Name = "CompareButton";
            this.CompareButton.Size = new System.Drawing.Size(150, 25);
            this.CompareButton.TabIndex = 3;
            this.CompareButton.Text = "Compare results";
            this.CompareButton.UseVisualStyleBackColor = true;
            this.CompareButton.Click += new System.EventHandler(this.CompareButton_Click);
            // 
            // TablesGraphsButton
            // 
            this.TablesGraphsButton.Location = new System.Drawing.Point(518, 502);
            this.TablesGraphsButton.Name = "TablesGraphsButton";
            this.TablesGraphsButton.Size = new System.Drawing.Size(150, 25);
            this.TablesGraphsButton.TabIndex = 2;
            this.TablesGraphsButton.Text = "Show graphs";
            this.TablesGraphsButton.UseVisualStyleBackColor = true;
            this.TablesGraphsButton.Click += new System.EventHandler(this.TablesGraphsButton_Click);
            // 
            // ExportResultsButton
            // 
            this.ExportResultsButton.Location = new System.Drawing.Point(278, 501);
            this.ExportResultsButton.Name = "ExportResultsButton";
            this.ExportResultsButton.Size = new System.Drawing.Size(150, 25);
            this.ExportResultsButton.TabIndex = 1;
            this.ExportResultsButton.Text = "Export results";
            this.ExportResultsButton.UseVisualStyleBackColor = true;
            this.ExportResultsButton.Click += new System.EventHandler(this.ExportResultsButton_Click);
            // 
            // ModelsResultsPages
            // 
            this.ModelsResultsPages.Location = new System.Drawing.Point(3, 3);
            this.ModelsResultsPages.Name = "ModelsResultsPages";
            this.ModelsResultsPages.SelectedIndex = 0;
            this.ModelsResultsPages.Size = new System.Drawing.Size(1146, 493);
            this.ModelsResultsPages.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 586);
            this.Controls.Add(this.Pages);
            this.Name = "MainForm";
            this.Text = "UHLNoCS";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Pages.ResumeLayout(false);
            this.SettingsPage.ResumeLayout(false);
            this.SettingsPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModelsStateTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SimulationStateTable)).EndInit();
            this.LogsPage.ResumeLayout(false);
            this.LogsPage.PerformLayout();
            this.ResultsPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox LogsTextBox;
        private System.Windows.Forms.TabControl Pages;
        private System.Windows.Forms.TabPage SettingsPage;
        private System.Windows.Forms.TabPage LogsPage;
        private System.Windows.Forms.TabPage ResultsPage;
        private System.Windows.Forms.Button LogsButton;
        private System.Windows.Forms.Button ModelAddButton;
        private System.Windows.Forms.TextBox SimulationNameTextBox;
        private System.Windows.Forms.Button DeleteModelButton;
        private System.Windows.Forms.Button StopModelButton;
        private System.Windows.Forms.Button StopSimulationButton;
        private System.Windows.Forms.Button StartSimulationButton;
        private System.Windows.Forms.Button NewSimulationButton;
        private System.Windows.Forms.Button SimulationNameButton;
        private System.Windows.Forms.Label ModelsStateLabel;
        private System.Windows.Forms.Label SimulationStateLabel;
        private System.Windows.Forms.Label SimulationNameLabel;
        private System.Windows.Forms.DataGridView ModelsStateTable;
        private System.Windows.Forms.DataGridView SimulationStateTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelPreparationProcessColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelSimulationProcessColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelCollectingResultsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddingModelsProcessColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreparationProcessColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SimulationProcessColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollectingResultsProcessColumn;
        private System.Windows.Forms.Button ExportResultsButton;
        private System.Windows.Forms.TabControl ModelsResultsPages;
        private System.Windows.Forms.Button TablesGraphsButton;
        private System.Windows.Forms.Button CompareButton;
    }
}

