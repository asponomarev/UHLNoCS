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
    public partial class CompareResultsTable : UserControl
    {
        public static string LegendName = "Legend";
        public static Color[] GraphsColors = new Color[] {Color.Red, Color.Green, Color.Blue,
                                                          Color.Yellow, Color.Magenta, Color.Cyan};
        private static Random ColorGenerator = new Random();

        public CompareResultsTable(List<Series> ModelsSeries, List<string> ModelsNames)
        {
            InitializeComponent();

            Chart Graph = (Chart)Controls[0];
            Controls.Clear();

            Graph.ChartAreas.Clear();
            ChartArea Area = new ChartArea();
            Area.AxisX.Minimum = 0;
            Area.AxisX.Maximum = 1;
            Area.AxisY.Minimum = 0;
            Area.AxisY.Maximum = 1;
            Area.AxisX.Interval = 0.1;
            Area.AxisY.Interval = 0.1;
            Area.AxisX.Title = "Flits generation rate, flits/sim.cycle";
            Area.AxisY.Title = "Network throughput, flits/sim.cycle";
            Area.AxisX.LineWidth = 3;
            Area.AxisY.LineWidth = 3;
            Area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            Area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            Graph.ChartAreas.Add(Area);

            Legend GraphLegend = new Legend(LegendName);
            GraphLegend.Title = "Compared models";
            Graph.Legends.Add(GraphLegend);

            double MaxX = 0;
            double MaxY = 0;
            for (int ModelIndex = 0; ModelIndex < ModelsSeries.Count; ModelIndex++)
            {
                Series ModelSeries = ModelsSeries[ModelIndex];
                List<DataPoint> ModelDataPoints = ModelSeries.Points.ToList();

                Series GraphSeries = new Series(ModelsNames[ModelIndex]);
                GraphSeries.MarkerStyle = MarkerStyle.Circle;
                GraphSeries.MarkerSize = 7;
                GraphSeries.ChartType = SeriesChartType.Line;
                GraphSeries.Color = GetSeriesColor(ModelIndex);
                GraphSeries.BorderWidth = 3;
                GraphSeries.Points.Clear();
                foreach (DataPoint Point in ModelDataPoints)
                {
                    GraphSeries.Points.AddXY(Point.XValue, Point.YValues[0]);
                    if (Point.XValue > MaxX)
                    {
                        MaxX = Point.XValue;
                    }
                    if (Point.YValues[0] > MaxY)
                    {
                        MaxY = Point.YValues[0];
                    }
                }
                GraphSeries.LegendText = ModelsNames[ModelIndex];
                Graph.Series.Add(GraphSeries);
                Graph.Series[ModelIndex].Legend = LegendName;
            }

            Graph.ChartAreas[0].AxisX.Maximum = Math.Round(MaxX, 3);
            Graph.ChartAreas[0].AxisX.Interval = Math.Round(Graph.ChartAreas[0].AxisX.Maximum / 19.0, 3);
            Graph.ChartAreas[0].AxisX.Maximum += Graph.ChartAreas[0].AxisX.Interval;

            Graph.ChartAreas[0].AxisY.Maximum = Math.Round(MaxY, 3);
            Graph.ChartAreas[0].AxisY.Interval = Math.Round(Graph.ChartAreas[0].AxisY.Maximum / 19.0, 3);
            Graph.ChartAreas[0].AxisY.Maximum += Graph.ChartAreas[0].AxisY.Interval;

            Controls.Add(Graph);
            Graph.Visible = false;
            Graph.Visible = true;
        }

        private Color GetSeriesColor(int ModelIndex)
        {
            Color ResultColor;

            if (ModelIndex < GraphsColors.Length)
            {
                ResultColor = GraphsColors[ModelIndex];
            }
            else
            {
                int R = ColorGenerator.Next(0, 256);
                int G = ColorGenerator.Next(0, 256);
                int B = ColorGenerator.Next(0, 256);
                ResultColor = Color.FromArgb(R, G, B);
            }

            return ResultColor;
        }

    }
}
