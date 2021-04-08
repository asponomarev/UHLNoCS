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
            this.StartSimulationButton = new System.Windows.Forms.Button();
            this.ProgramPathTextBox = new System.Windows.Forms.TextBox();
            this.ProgramPathLabel = new System.Windows.Forms.Label();
            this.ProgramArgumentsLabel = new System.Windows.Forms.Label();
            this.ProgramArgumentsTextBox = new System.Windows.Forms.TextBox();
            this.LogsTextBox = new System.Windows.Forms.TextBox();
            this.ResultsWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // StartSimulationButton
            // 
            this.StartSimulationButton.Location = new System.Drawing.Point(154, 138);
            this.StartSimulationButton.Name = "StartSimulationButton";
            this.StartSimulationButton.Size = new System.Drawing.Size(120, 30);
            this.StartSimulationButton.TabIndex = 0;
            this.StartSimulationButton.Text = "Start simulation";
            this.StartSimulationButton.UseVisualStyleBackColor = true;
            this.StartSimulationButton.Click += new System.EventHandler(this.StartSimulationButton_Click);
            // 
            // ProgramPathTextBox
            // 
            this.ProgramPathTextBox.Location = new System.Drawing.Point(14, 33);
            this.ProgramPathTextBox.Name = "ProgramPathTextBox";
            this.ProgramPathTextBox.ReadOnly = true;
            this.ProgramPathTextBox.Size = new System.Drawing.Size(400, 20);
            this.ProgramPathTextBox.TabIndex = 1;
            this.ProgramPathTextBox.DoubleClick += new System.EventHandler(this.ProgramPathTextBox_DoubleClick);
            // 
            // ProgramPathLabel
            // 
            this.ProgramPathLabel.AutoSize = true;
            this.ProgramPathLabel.Location = new System.Drawing.Point(14, 17);
            this.ProgramPathLabel.Name = "ProgramPathLabel";
            this.ProgramPathLabel.Size = new System.Drawing.Size(143, 13);
            this.ProgramPathLabel.TabIndex = 2;
            this.ProgramPathLabel.Text = "Path to model executable file";
            // 
            // ProgramArgumentsLabel
            // 
            this.ProgramArgumentsLabel.AutoSize = true;
            this.ProgramArgumentsLabel.Location = new System.Drawing.Point(14, 73);
            this.ProgramArgumentsLabel.Name = "ProgramArgumentsLabel";
            this.ProgramArgumentsLabel.Size = new System.Drawing.Size(88, 13);
            this.ProgramArgumentsLabel.TabIndex = 3;
            this.ProgramArgumentsLabel.Text = "Model arguments";
            // 
            // ProgramArgumentsTextBox
            // 
            this.ProgramArgumentsTextBox.Location = new System.Drawing.Point(14, 89);
            this.ProgramArgumentsTextBox.Name = "ProgramArgumentsTextBox";
            this.ProgramArgumentsTextBox.Size = new System.Drawing.Size(400, 20);
            this.ProgramArgumentsTextBox.TabIndex = 4;
            this.ProgramArgumentsTextBox.DoubleClick += new System.EventHandler(this.ProgramArgumentsTextBox_DoubleClick);
            // 
            // LogsTextBox
            // 
            this.LogsTextBox.AcceptsReturn = true;
            this.LogsTextBox.Location = new System.Drawing.Point(14, 199);
            this.LogsTextBox.Multiline = true;
            this.LogsTextBox.Name = "LogsTextBox";
            this.LogsTextBox.ReadOnly = true;
            this.LogsTextBox.Size = new System.Drawing.Size(400, 250);
            this.LogsTextBox.TabIndex = 5;
            // 
            // ResultsWebBrowser
            // 
            this.ResultsWebBrowser.Location = new System.Drawing.Point(472, 33);
            this.ResultsWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.ResultsWebBrowser.Name = "ResultsWebBrowser";
            this.ResultsWebBrowser.Size = new System.Drawing.Size(500, 416);
            this.ResultsWebBrowser.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.ResultsWebBrowser);
            this.Controls.Add(this.LogsTextBox);
            this.Controls.Add(this.ProgramArgumentsTextBox);
            this.Controls.Add(this.ProgramArgumentsLabel);
            this.Controls.Add(this.ProgramPathLabel);
            this.Controls.Add(this.ProgramPathTextBox);
            this.Controls.Add(this.StartSimulationButton);
            this.Name = "MainForm";
            this.Text = "UHLNoCS";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartSimulationButton;
        private System.Windows.Forms.TextBox ProgramPathTextBox;
        private System.Windows.Forms.Label ProgramPathLabel;
        private System.Windows.Forms.Label ProgramArgumentsLabel;
        private System.Windows.Forms.TextBox ProgramArgumentsTextBox;
        private System.Windows.Forms.TextBox LogsTextBox;
        private System.Windows.Forms.WebBrowser ResultsWebBrowser;
    }
}

