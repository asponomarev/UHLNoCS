﻿namespace UHLNoCS
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
            this.PlsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogsTextBox
            // 
            this.LogsTextBox.AcceptsReturn = true;
            this.LogsTextBox.Location = new System.Drawing.Point(12, 12);
            this.LogsTextBox.Multiline = true;
            this.LogsTextBox.Name = "LogsTextBox";
            this.LogsTextBox.ReadOnly = true;
            this.LogsTextBox.Size = new System.Drawing.Size(400, 343);
            this.LogsTextBox.TabIndex = 5;
            // 
            // PlsButton
            // 
            this.PlsButton.Location = new System.Drawing.Point(141, 396);
            this.PlsButton.Name = "PlsButton";
            this.PlsButton.Size = new System.Drawing.Size(118, 23);
            this.PlsButton.TabIndex = 6;
            this.PlsButton.Text = "Pray";
            this.PlsButton.UseVisualStyleBackColor = true;
            this.PlsButton.Click += new System.EventHandler(this.PlsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.PlsButton);
            this.Controls.Add(this.LogsTextBox);
            this.Name = "MainForm";
            this.Text = "UHLNoCS";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox LogsTextBox;
        private System.Windows.Forms.Button PlsButton;
    }
}

