using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UHLNoCS
{
    public partial class NewximResultTable : UserControl
    {
        public NewximResultTable()
        {
            InitializeComponent();

            Chart C = (Chart)Controls[0];
            DataGridView DGV = (DataGridView)Controls[1];
            Controls.Clear();

            C.ChartAreas.Clear();
            ChartArea Area = new ChartArea();
            Area.AxisX.Minimum = 0;
            Area.AxisX.Maximum = 50;
            Area.AxisY.Minimum = 0;
            Area.AxisY.Maximum = 50;
            Area.AxisX.Interval = 2.5;
            Area.AxisY.Interval = 2.5;
            Area.AxisX.Title = "Network production, flits/sim.cycle";
            Area.AxisY.Title = "Network throughput, flits/sim.cycle";
            Area.AxisX.LineWidth = 3;
            Area.AxisY.LineWidth = 3;
            Area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            Area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            C.ChartAreas.Add(Area);

            Series Series = new Series();
            Series.MarkerStyle = MarkerStyle.Circle;
            Series.MarkerSize = 7;
            Series.ChartType = SeriesChartType.Line;
            Series.Color = Color.Red;
            Series.BorderWidth = 3;
            Series.Points.Clear();
            C.Series.Add(Series);

            Controls.Add(DGV);
            Controls.Add(C);
        }
    }
}
