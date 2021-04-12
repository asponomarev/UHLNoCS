using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UHLNoCS
{
    public partial class MainForm : Form
    {
        private void ToLogsTextBox(string Text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => LogsTextBox.Text += Text + "\r\n"));
            }
            else
            {
                LogsTextBox.Text += Text + "\r\n";
            }
        }

        private void LogsButton_Click(object sender, EventArgs e)
        {
            LogsTextBox.Clear();
        }

    }
}
