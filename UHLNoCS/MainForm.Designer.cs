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
            this.LogsTextBox = new System.Windows.Forms.TextBox();
            this.Pages = new System.Windows.Forms.TabControl();
            this.SettingsPage = new System.Windows.Forms.TabPage();
            this.ModelAddButton = new System.Windows.Forms.Button();
            this.LogsPage = new System.Windows.Forms.TabPage();
            this.LogsButton = new System.Windows.Forms.Button();
            this.ResultsPage = new System.Windows.Forms.TabPage();
            this.Pages.SuspendLayout();
            this.SettingsPage.SuspendLayout();
            this.LogsPage.SuspendLayout();
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
            this.LogsTextBox.Size = new System.Drawing.Size(990, 495);
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
            this.Pages.Size = new System.Drawing.Size(1010, 562);
            this.Pages.TabIndex = 6;
            // 
            // SettingsPage
            // 
            this.SettingsPage.Controls.Add(this.ModelAddButton);
            this.SettingsPage.Location = new System.Drawing.Point(4, 22);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsPage.Size = new System.Drawing.Size(1002, 536);
            this.SettingsPage.TabIndex = 0;
            this.SettingsPage.Text = "Settings";
            this.SettingsPage.UseVisualStyleBackColor = true;
            // 
            // ModelAddButton
            // 
            this.ModelAddButton.Location = new System.Drawing.Point(429, 213);
            this.ModelAddButton.Name = "ModelAddButton";
            this.ModelAddButton.Size = new System.Drawing.Size(88, 23);
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
            this.LogsPage.Size = new System.Drawing.Size(1002, 536);
            this.LogsPage.TabIndex = 1;
            this.LogsPage.Text = "Logs";
            this.LogsPage.UseVisualStyleBackColor = true;
            // 
            // LogsButton
            // 
            this.LogsButton.Location = new System.Drawing.Point(448, 507);
            this.LogsButton.Name = "LogsButton";
            this.LogsButton.Size = new System.Drawing.Size(106, 23);
            this.LogsButton.TabIndex = 6;
            this.LogsButton.Text = "Clear";
            this.LogsButton.UseVisualStyleBackColor = true;
            this.LogsButton.Click += new System.EventHandler(this.LogsButton_Click);
            // 
            // ResultsPage
            // 
            this.ResultsPage.Location = new System.Drawing.Point(4, 22);
            this.ResultsPage.Name = "ResultsPage";
            this.ResultsPage.Size = new System.Drawing.Size(1002, 536);
            this.ResultsPage.TabIndex = 2;
            this.ResultsPage.Text = "Results";
            this.ResultsPage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 586);
            this.Controls.Add(this.Pages);
            this.Name = "MainForm";
            this.Text = "UHLNoCS";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Pages.ResumeLayout(false);
            this.SettingsPage.ResumeLayout(false);
            this.LogsPage.ResumeLayout(false);
            this.LogsPage.PerformLayout();
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
    }
}

