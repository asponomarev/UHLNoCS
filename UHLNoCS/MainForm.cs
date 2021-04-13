using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHLNoCS.Models;
using UHLNoCS.Topologies;

namespace UHLNoCS
{
    public partial class MainForm : Form
    {
        public static string SimulationFolderName = "simulations";

        private Controller SimulationController;

        public MainForm()
        {
            InitializeComponent();

            SimulationController = new Controller();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

    }
}
