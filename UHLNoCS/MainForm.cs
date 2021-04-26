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
using UHLNoCS.Algorithms;
using UHLNoCS.Models;
using UHLNoCS.Simulation;
using UHLNoCS.Topologies;

namespace UHLNoCS
{
    public partial class MainForm : Form
    {               
        private Controller SimulationController;

        public MainForm()
        {
            InitializeComponent();

            SimulationController = new Controller();

            SimulationNameTextBox.Text = SimulationController.SimulationName;   
            
            SimulationStateTable.RowTemplate.Height = 25;
            SimulationStateTable.Rows.Add(SimulationController.SimulationState);

            ModelsStateTable.RowTemplate.Height = 25;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }
        
    }
}
