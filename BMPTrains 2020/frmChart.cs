using BMPTrains_2020.DomainCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BMPTrains_2020
{
    public partial class frmChart : Form
    {
        public string ChartType;
        public BMP bmp;
        public frmChart(DomainCode.BMP _bmp, string BMPType)
        {
            InitializeComponent();
            ChartType = BMPType;
            bmp = _bmp;
            if (BMPType == "Storage") PlotStorage(bmp);
            if (BMPType == "VNB") PlotVNB((VegetatedNaturalBuffer)bmp, "Nitrogen");
            if (BMPType == "VFS") PlotVFS((VegetatedFilterStrip)bmp, "Nitrogen");
            if (BMPType == "WetDetention") PlotWetDetention((WetDetention)bmp, "Nitrogen");
        }

        public frmChart(string costType)
        {
            InitializeComponent();
            ChartType = costType;
            PlotCost(costType);
        }

        public void addXY(int n, Series s, Double[] x, Double[] y)
        {
            for (int i = 0; i < n; i++)
            {
                s.Points.AddXY(x[i], y[i]);
            }
        }


        private void frmChart_Load(object sender, EventArgs e)
        {

        }

        private void PlotStorage(BMP bmp)
        {
            chart1.Series.Clear();
            Series series1 = new Series
            {
                Name = "default",
                Color = System.Drawing.Color.Blue,
                ChartType = SeriesChartType.Line
            };

            chart1.Titles.Add("Title");
            chart1.Titles[0].Text = "Plot of Retention Storage Curve";

            chart1.Series.Add(series1);
            addXY(21, chart1.Series["default"], bmp.plotX(), bmp.plotY());

            chart1.Series[0].LegendText = bmp.LegendTitle();

            SetChartArea(chart1.ChartAreas[0], bmp);
        }

        private void PlotVNB(VegetatedNaturalBuffer bmp, string p = "Nitrogen")
        {
            SetupVNBChart(p);
            addXY(14, chart1.Series["1"], bmp.plotX(), bmp.plotY(0.2, p));

            addXY(14, chart1.Series["2"], bmp.plotX(), bmp.plotY(0.4, p));

            addXY(14, chart1.Series["3"], bmp.plotX(), bmp.plotY(0.6, p));

            addXY(14, chart1.Series["4"], bmp.plotX(), bmp.plotY(0.8, p));

            addXY(14, chart1.Series["5"], bmp.plotX(), bmp.plotY(1.0, p));

            SetChartArea(chart1.ChartAreas[0], bmp);

            if (p == "Nitrogen")
            {
                AddMarker(bmp.BufferW, bmp.ProvidedNTreatmentEfficiency,
                    "Nitrogen Removal Efficiency at Buffer Width: " + XmlPropertyObject.AsString(bmp.BufferW, 2));
            }
            else
            {
                AddMarker(bmp.BufferW, bmp.ProvidedPTreatmentEfficiency,
                    "Phosphorus Removal Efficiency at Buffer Width: " + XmlPropertyObject.AsString(bmp.BufferW, 2));
            }
        }

        private void PlotVFS(VegetatedFilterStrip bmp, string p = "Nitrogen")
        {
            SetupVNBChart(p);
            addXY(14, chart1.Series["1"], bmp.plotX(), bmp.plotY(0.2, p));

            addXY(14, chart1.Series["2"], bmp.plotX(), bmp.plotY(0.4, p));

            addXY(14, chart1.Series["3"], bmp.plotX(), bmp.plotY(0.6, p));

            addXY(14, chart1.Series["4"], bmp.plotX(), bmp.plotY(0.8, p));

            addXY(14, chart1.Series["5"], bmp.plotX(), bmp.plotY(1.0, p));

            SetChartArea(chart1.ChartAreas[0], bmp);

            if (p == "Nitrogen")
            {
                AddMarker(bmp.BufferW, bmp.ProvidedNTreatmentEfficiency,
                    "Nitrogen Removal Efficiency at Buffer Width: " + XmlPropertyObject.AsString(bmp.BufferW, 2));
            }
            else
            {
                AddMarker(bmp.BufferW, bmp.ProvidedPTreatmentEfficiency,
                    "Phosphorus Removal Efficiency at Buffer Width: " + XmlPropertyObject.AsString(bmp.BufferW, 2));
            }
        }

        private void PlotWetDetention(WetDetention bmp, string p = "Nitrogen")
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();

            chart1.Titles.Add("Title");
            chart1.Titles[0].Text = "Plot of " + p + " for Wet Detention";

            Series series1 = new Series
            {
                Name = "1",
                Color = System.Drawing.Color.Blue,
                ChartType = SeriesChartType.Line
            };

            chart1.Series.Add(series1);
            chart1.Series["1"].LegendText = "Wet Detention Efficiency for " + p;

            addXY(14, chart1.Series["1"], bmp.plotX(), bmp.plotY(p));

            SetChartArea(chart1.ChartAreas[0], bmp); 

            if (p == "Nitrogen")
            {
                AddMarker(bmp.ResidenceTime, bmp.ProvidedNTreatmentEfficiency,
                    "Nitrogen Removal Efficiency for Residence Time (days): " + XmlPropertyObject.AsString(bmp.ResidenceTime, 1));
            }
            else
            {
                AddMarker(bmp.ResidenceTime, bmp.ProvidedPTreatmentEfficiency,
                    "Phosphorus Removal Efficiency for Residence Time (days): " + XmlPropertyObject.AsString(bmp.ResidenceTime, 1));
            }
        }

        private void PlotCost(string CostType)
        {
            CostScenario c = new CostScenario();
            chart1.Series.Clear();
            chart1.Titles.Clear();

            chart1.Titles.Add("Cost Scenario");
            chart1.Titles[0].Text = "Plot of " + c.PropertyLabels()[CostType];

            // Data arrays
            string[] seriesArray = Globals.Project.CostScenarioNames();
            double[] pointsArray = Globals.Project.CostScenarioValues(CostType);

            // Set palette
            this.chart1.Palette = ChartColorPalette.EarthTones;

            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = this.chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }
        }

        private void SetupVNBChart(string p = "Nitrogen")
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();

            chart1.Titles.Add("Title");
            chart1.Titles[0].Text = "Plot of " + p + " for Buffer Width / Contributing Area ratio";

            Series series1 = new Series
            {
                Name = "1",
                Color = System.Drawing.Color.Blue,
                ChartType = SeriesChartType.Line
            };

            Series series2 = new Series
            {
                Name = "2",
                Color = System.Drawing.Color.Red,
                ChartType = SeriesChartType.Line
            };
            Series series3 = new Series
            {
                Name = "3",
                Color = System.Drawing.Color.Green,
                ChartType = SeriesChartType.Line
            };
            Series series4 = new Series
            {
                Name = "4",
                Color = System.Drawing.Color.Purple,
                ChartType = SeriesChartType.Line
            };

            Series series5 = new Series
            {
                Name = "5",
                Color = System.Drawing.Color.Black,
                ChartType = SeriesChartType.Line
            };

            chart1.Series.Add(series1);
            chart1.Series["1"].LegendText = "Buffer W / C Area = 0.2";

            chart1.Series.Add(series2);
            chart1.Series["2"].LegendText = "Buffer W / C Area = 0.4";

            chart1.Series.Add(series3);
            chart1.Series["3"].LegendText = "Buffer W / C Area = 0.6";

            chart1.Series.Add(series4);
            chart1.Series["4"].LegendText = "Buffer W / C Area = 0.8";

            chart1.Series.Add(series5);
            chart1.Series["5"].LegendText = "Buffer W / C Area = 1.0";
        }

        private void SetChartArea(ChartArea ca, BMP bmp)
        {
            ca.AxisX.LabelStyle.Angle = -90;
            ca.AxisX.Title = bmp.XAxisTitle();
            ca.AxisY.Title = bmp.YAxisTitle();

            ca.AxisX.Minimum = bmp.XAxisMinimum();
            ca.AxisX.Maximum = bmp.XAxisMaximum();
            ca.AxisY.Minimum = bmp.YAxisMinimum();
            ca.AxisY.Maximum = bmp.YAxisMaximum();
        }

        public Series DefaultSeries()
        {
            return chart1.Series["default"];
        }

        public void AddMarker(double x, double y, string label)
        {
            chart1.Series.Add((chart1.Series.Count + 1).ToString());
            int i = chart1.Series.Count;

            chart1.Series[i - 1].ChartType = SeriesChartType.Line;
            chart1.Series[i - 1].IsValueShownAsLabel = false;
            chart1.Series[i - 1].Label = String.Format("{0:N0}", y);
            chart1.Series[i - 1].Color = System.Drawing.Color.Red;
            chart1.Series[i - 1].MarkerStyle = MarkerStyle.Diamond;
            chart1.Series[i - 1].Points.AddXY(x, y);
            chart1.Series[i - 1].LegendText = label;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Printing.PrintPreview();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void phosphorusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChartType == "VNB") PlotVNB((VegetatedNaturalBuffer)bmp, "Phosphorus");
            if (ChartType == "VFS") PlotVFS((VegetatedFilterStrip)bmp, "Phosphorus");
            if (ChartType == "WetDetention") PlotWetDetention((WetDetention)bmp, "Phosphorus");
        }

        private void nitrogenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChartType == "VNB") PlotVNB((VegetatedNaturalBuffer)bmp, "Nitrogen");
            if (ChartType == "VFS") PlotVFS((VegetatedFilterStrip)bmp, "Nitrogen");
            if (ChartType == "WetDetention") PlotWetDetention((WetDetention)bmp, "Nitrogen");
        }

        private void frmChart_Resize(object sender, EventArgs e)
        {
            chart1.Width = this.Width - 20;
            chart1.Height = this.Height - 60;
        }
    }
}
