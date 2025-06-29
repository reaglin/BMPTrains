using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace BMPTrains_2020.DomainCode
{
    public class Harvesting : Storage
    {
        public string SolveForChoice { get; set; }
        public static string sHarvestEfficiency = "Harvest Efficiency";
        public static string sHarvestRate = "Harvest Rate";
        public static string[] SolveForChoices => new string[] { sHarvestEfficiency , sHarvestRate };

        public double HarvestVolume { get; set; }
        public double HarvestEfficiency { get; set; }
        public double CalculatedHarvestEfficiency { get; set; }
        public double IrrigationArea { get; set; }

        public double ContributingAreaSF { get; set; }
        public double EquivalentImperviousArea { get; set; } //acres
        public double HarvestVolumeOverEIA { get; set; }

        public double AvailableHarvestRate { get; set; }    // INPUT (0.1 - 4 in/week over EIA)
        public double HarvestRate { get; set; }             // CALCULATED  cf/day
        public double HarvestRateOverEIA { get; set; }      // CALCULATED in day over EIA

        public double RequiredHarvestRateCFD { get; set; }
        public double RequiredHarvestRateINWEEK { get; set; }

        public double HarvestWaterDemand { get; set; }  // MGY
        public double HarvestWaterSupply { get; set; }  //MGY
        public double SupplementalWater { get; set; }   //MGY

        public double[,] REVXValues = new double[8,116];
        public double[,] REVYValues = new double[8,116];

        public double[,] FlZone1R = new double[,]
    {
                {0.00, 0.0090000, 0.0568000, 0.1275000, 0.1220000, 0.0860000},
                {0.00, 0.0050000, 0.0389000, 0.1089000, 0.1311000, 0.1153000},
                {0.00, 0.0034700, 0.0316500, 0.1044400, 0.1495900, 0.1511500},
                {-0.000240, 0.0043670, 0.0301240, 0.0984680, 0.1551950, 0.1912920},
                {-0.000400, 0.0065200, 0.0444000, 0.1456000, 0.2399000, 0.2887000},
                {0.00, 0.0003850, 0.0076000, 0.0552000, 0.1781000, 0.3551000},
                {0.00, 0.0004200, 0.0086000, 0.0659000, 0.2327000, 0.4952000},
                {0.00, 0.0002000, 0.0048350, 0.0478000, 0.2322000, 0.6710000}
    };

        public double[,] FlZone2R = new double[,]
            {
                {0.00, 0.00, 0.0031000, 0.0182000, 0.0358000, 0.0436000},
                {0.00, 0.0013000, 0.0111000, 0.0341000, 0.0454000, 0.0638000},
                {0.00, 0.0007600, 0.0084000, 0.0346400, 0.0650600, 0.0987200},
                {-0.000200, 0.0035000, 0.0241000, 0.0785000, 0.1239000, 0.1468000},
                {-0.000347, 0.0063000, 0.0435000, 0.1428000, 0.2280000, 0.2359000},
                {-0.000380, 0.0071600, 0.0520300, 0.1831700, 0.3234100, 0.3515000},
                {0.00, 0.0007900, 0.0136400, 0.0885000, 0.2638000, 0.4458000},
                {0.00, 0.0004600, 0.0099600, 0.0810000, 0.3060000, 0.6366000}
            };

        public double[,] FlZone3R = new double[,]
            {
                {0.00, 0.0018000, 0.0106400, 0.0239000, 0.0284000, 0.0416000},
                {0.00, 0.0012000, 0.0102000, 0.0306000, 0.0408000, 0.0623000},
                {0.00, 0.0008300, 0.0088000, 0.0340000, 0.0595000, 0.0922000},
                {0.00, 0.0004082, 0.0061000, 0.0319800, 0.0706000, 0.1138000},
                {-0.000421, 0.0074480, 0.0496900, 0.1552300, 0.2304300, 0.2096100},
                {-0.000710, 0.0131000, 0.0909000, 0.2974000, 0.4695000, 0.3920000},
                {0.00, 0.0018500, 0.0302000, 0.1806000, 0.4795000, 0.6063000},
                {0.00, 0.00, 0.0026000, 0.0576000, 0.4091000, 1.0840000}
            };

        public double[,] FlZone4R = new double[,]
            {
                {0.00, 0.00, 0.0025000, 0.0157000, 0.0314000, 0.0391000},
                {0.00, 0.00, 0.0017000, 0.0128000, 0.0306000, 0.0600000},
                {0.00, 0.00, 0.0018000, 0.0153000, 0.0431000, 0.0896000},
                {0.00, 0.0004000, 0.0067000, 0.0361000, 0.0823000, 0.1457000},
                {-0.000170, 0.0035000, 0.0272500, 0.0998000, 0.1787000, 0.2341000},
                {0.00, 0.0011350, 0.0172000, 0.0935000, 0.2238000, 0.3380000},
                {0.00, 0.0013500, 0.0219000, 0.1283000, 0.3337000, 0.5114000},
                {0.00, 0.0008100, 0.0159000, 0.1166000, 0.3912000, 0.7470000}
            };

        //public double[,] FlZone5R = new double[,]
        //    {
        //        {0.00, 0.0031400, 0.0212000, 0.0528000, 0.0592000, 0.0516000},
        //        {0.00, 0.0020000, 0.0172000, 0.0544000, 0.0737000, 0.0791000},
        //        {-0.000890, 0.0111000, 0.0526000, 0.1181000, 0.1290000, 0.1229000},
        //        {-0.000300,0.0052710,-0.0355000,0.1136000,-0.1745000,0.1944000 },
        //        {-0.000500, 0.0090000, 0.0622700, 0.2048300, 0.3246000, 0.3194000},
        //        {0.00, 0.0011000, 0.0173800, 0.1008000, 0.2614000, 0.3983000},
        //        {0.00, 0.0005250, 0.0098000, 0.0703000, 0.2407000, 0.5054000},
        //        {0.00, 0.00, 0.0020000, 0.0354000, 0.2239000, 0.7061000}
        //    };

        public double[,] FlZone5R = new double[,]
            {
                {0.00, 0.0031400, 0.0212000, 0.0528000, 0.0592000, 0.0516000},
                {0.00, 0.0020000, 0.0172000, 0.0544000, 0.0737000, 0.0791000},
                {-0.000890, 0.0111000, 0.0526000, 0.1181000, 0.1290000, 0.1229000},
                {-0.0001542405,0.0032245262,-0.254227472,0.093820545,-0.1638103135,0.2016530820},
                {-0.000500, 0.0090000, 0.0622700, 0.2048300, 0.3246000, 0.3194000},
                {0.00, 0.0011000, 0.0173800, 0.1008000, 0.2614000, 0.3983000},
                {0.00, 0.0005250, 0.0098000, 0.0703000, 0.2407000, 0.5054000},
                {0.00, 0.00, 0.0020000, 0.0354000, 0.2239000, 0.7061000}
            };
        public double[,] FlZone1CurveFitLimit = new double[,]
            {{1.85, 0.043},
            {2.45, 0.056},
            {3.05, 0.068},
            {4.05, 0.09},
            {3.00, 0.111},
            {6.10, 0.131},
            {6.10, 0.158},
            {6.10, 0.213}};

        public double[,] FlZone2CurveFitLimit = new double[,]
            {{2.45, 0.019},
            {3.05, 0.04},
            {3.05, 0.068},
            {3.55, 0.049},
            {2.55, 0.068},
            {5.00, 0.081},
            {5.80, 0.125},
            {6.10, 0.161}};

        public double[,] FlZone3CurveFitLimit = new double[,]
            {{2.55, 0.024},
            {3.55, 0.037},
            {4.05, 0.047},
            {5.05, 0.053},
            {5.05, 0.066},
            {4.55, 0.080},
            {5.05, 0.104},
            {6.10, 0.141}};

        public double[,] FlZone4CurveFitLimit = new double[,] // not correct
            {{1.55, 0.018},
            {2.05, 0.036},
            {2.55, 0.049},
            {3.55, 0.072},
            {4.55, 0.089},
            {5.55, 0.112},
            {6.10, 0.417},
            {6.10, 0.213}};

        public double[,] FlZone5CurveFitLimit = new double[,] // not correct
            {{2.55, 0.025},
            {1.90, 0.043},
            {4.05, 0.060},
            {5.05, 0.08},
            {5.05, 0.08},
            {4.55, 0.10},
            {6.10, 0.156},
            {6.10, 0.205}};

        public Harvesting(Catchment c) : base(c) { }

        public override Dictionary<string, string> PropertyLabels()
        {
            var current = new Dictionary<string, string>
                {
                    {"RainfallZone", "Rainfall Zone"},
                    {"ContributingArea", "Total Contributing Area to Harvesting (SF)"},
                    {"EquivalentImperviousArea", "Equivalent Impervious Area (acres)"},
                    {"IrrigationArea", "Area Available for Irrigattion (ac)"},
                    {"HarvestVolume", "Harvest Volume (ac-ft)"},
                    {"HarvestVolumeOverEIA", "Harvest Volume (in over EIA)"},
                    {"HarvestEfficiency", "Harvest Efficiency (%)"},
                    {"HarvestRateOverEIA", "Harvest Rate (in/day over EIA)"},
                    {"HarvestRate", "Harvest Rate (cf/day)"},
                    {"RationalCoefficient","Rational Coefficient"},
                };
            return current;
        }

        public override string BMPInputVariables()
        {
            string s = "";
            s += AsHtmlTable(
                new Dictionary<string, string>
            {
                {"RetentionDepth", "Retention Depth (in)"},
                {"RetentionVolume", "Retention Volume (ac-ft)"}
            });
            return s;
        }

        public new void SetValuesFromCatchment(Catchment c)
        {
            // Watershed Area is calculated in classes that inherit from Storage

            this.WatershedArea = c.PostArea;            
        }

        public double[,] RValues(string zone)
        {
            switch (zone)
            {
                case StaticLookupTables.FlZone1:
                    return FlZone1R;
                case StaticLookupTables.FlZone2:
                    return FlZone2R;
                case StaticLookupTables.FlZone3:
                    return FlZone3R;
                case StaticLookupTables.FlZone4:
                    return FlZone4R;
                case StaticLookupTables.FlZone5:
                    return FlZone5R;
                default:
                    return FlZone1R;
            }
        }

        public double[,] CurveFitLimits(string zone)
        {
            switch (zone)
            {
                case StaticLookupTables.FlZone1:
                    return FlZone1CurveFitLimit;
                case StaticLookupTables.FlZone2:
                    return FlZone2CurveFitLimit;
                case StaticLookupTables.FlZone3:
                    return FlZone3CurveFitLimit;
                case StaticLookupTables.FlZone4:
                    return FlZone4CurveFitLimit;
                case StaticLookupTables.FlZone5:
                    return FlZone5CurveFitLimit;
                default:
                    return FlZone1CurveFitLimit;
            }
        }
        public LookupTable getEfficiencyLUT()
        {
            LookupTable lut = new LookupTable();

            lut.Name = "Harvesting Efficiency Curves: " + RainfallZone;
            lut.TableDescription = "Values - Harvest Rate (in/day over EIA)";
            lut.RowTitle = "Harvest Efficiency (%)";
            lut.ColumnTitle = "Harvest Volume (in over EIA)";

            // Columns Go Incrementally from 0.000 by 0.005 to 6
            // Column corresponds to Harvest Volume inches over EIA
            lut.ColumnData = "";
            for (double i = 0.25; i <= 6.0; i += 0.05)
            {
                lut.ColumnData += String.Format("\t{0:N4}", i);
            }
            lut.ColumnData = lut.ColumnData.Trim();

            // Rows go incrementally from 20 to 90
            lut.RowData = "";
            for (int i = 20; i <= 90; i += 10)
            {
                lut.RowData += String.Format("\t{0:N0}", i);
            }
            lut.RowData = lut.RowData.Trim();

            int col = 0;
            int row = 0;
            double[,] v = RValues(RainfallZone);
            double[,] limits = CurveFitLimits(RainfallZone);

            lut.TableData = String.Empty;
            for (int r = 20; r <= 90; r += 10)
            {
                col = 0;
                string l = String.Empty;
                for (double c = 0.25; c <= 6.0; c += 0.05)
                {
                    double x;
                    if (c < limits[row, 0])
                    {
                        x = v[row, 0] * Math.Pow(c, 5) + v[row, 1] * Math.Pow(c, 4) - v[row, 2] * Math.Pow(c, 3) +
                                   v[row, 3] * Math.Pow(c, 2) - v[row, 4] * c + v[row, 5];
                    }
                    else
                    {
                        x = limits[row, 1];
                    }

                    l += String.Format("\t{0:N4}", x);
                    col++;
                }

                l = l.Trim();

                lut.TableData += l + "\n";
                row++;
            }
            lut.TableData = lut.TableData.Trim();

            return lut;
        }



        public void SetREVPlottingValues()
        {
            int row = 0;
            int col = 0;
            double[,] v = RValues(RainfallZone);
            double[,] limits = CurveFitLimits(RainfallZone);

            for (int r = 20; r <= 90; r += 10)
            {
                col = 0;
                string l = String.Empty;
                for (double c = 0.25; c <= 6.0; c += 0.05)
                {
                    double y;
                    if (c < limits[row, 0])
                    {
                        y = v[row, 0] * Math.Pow(c, 5) + v[row, 1] * Math.Pow(c, 4) - v[row, 2] * Math.Pow(c, 3) +
                                   v[row, 3] * Math.Pow(c, 2) - v[row, 4] * c + v[row, 5];
                    }
                    else
                    {
                        y = limits[row, 1];
                    }
                    REVXValues[row, col] = c;
                    REVYValues[row, col] = y;
                    col++;
                }
                row++;
            }
        }

        public string[] plotLegend()
        {
            string[] legend = { "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%" };
            return legend;
        }


        public new void Calculate()
        {
            
        }

        public void CreateREVScatterPlot(Chart chart)
        {

            SetREVPlottingValues();
            
            double[,] xvalues = REVXValues;
            double[,] yvalues = REVYValues;

            if (xvalues == null || yvalues == null)
                throw new ArgumentException("X and Y value arrays cannot be null");

            if (xvalues.GetLength(0) != 8 || yvalues.GetLength(0) != 8)
                throw new ArgumentException("Arrays must have 8 lines (20% through 90%)");

            // Clear any existing series and chart areas
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Legends.Clear();

            // Create chart area
            ChartArea chartArea = new ChartArea("MainArea");
            chart.ChartAreas.Add(chartArea);

            // Configure X-axis
            chartArea.AxisX.Title = "Runoff Volume of Water (inches over EIA)";
            chartArea.AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 6;
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.MajorGrid.Enabled = true;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            // Configure Y-axis
            chartArea.AxisY.Title = "Use Rate (inches/day over EIA)";
            chartArea.AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 0.5;
            chartArea.AxisY.Interval = 0.1;
            chartArea.AxisY.MajorGrid.Enabled = true;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            // Create and configure legend
            Legend legend = new Legend("MainLegend");
            legend.Docking = Docking.Right;
            legend.Alignment = StringAlignment.Center;
            legend.Font = new Font("Arial", 10);
            legend.Title = "Percentages";
            legend.TitleFont = new Font("Arial", 11, FontStyle.Bold);
            chart.Legends.Add(legend);

            // Define colors for each line
            Color[] lineColors = {
        Color.Red,           // 20%
        Color.Blue,          // 30%
        Color.Green,         // 40%
        Color.Orange,        // 50%
        Color.Purple,        // 60%
        Color.Brown,         // 70%
        Color.Pink,          // 80%
        Color.DarkBlue       // 90%
    };

            // Define legend labels
            string[] percentages = { "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%" };

            // Create series for each line
            for (int lineIndex = 0; lineIndex < 8; lineIndex++)
            {
                // Create new series
                Series series = new Series(percentages[lineIndex]);
                series.ChartType = SeriesChartType.Line;
                series.Color = lineColors[lineIndex];
                series.BorderWidth = 2;
                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerSize = 6;
                series.MarkerColor = lineColors[lineIndex];
                series.MarkerBorderColor = Color.Black;
                series.MarkerBorderWidth = 1;

                // Get the number of points for this line
                int pointCount = yvalues.GetLength(1);

                // Add data points to the series
                for (int pointIndex = 0; pointIndex < pointCount; pointIndex++)
                {
                    double xValue = xvalues[lineIndex, pointIndex];
                    double yValue = yvalues[lineIndex, pointIndex];

                    // Add point to series
                    series.Points.AddXY(xValue, yValue);
                }

                // Add series to chart
                chart.Series.Add(series);
            }

            // Additional chart formatting
            chart.BackColor = Color.White;
            chartArea.BackColor = Color.White;

            // Set chart title (optional)
            Title title = new Title("Use Rate vs Runoff Volume");
            title.Font = new Font("Arial", 14, FontStyle.Bold);
            chart.Titles.Add(title);

            // Enable anti-aliasing for smoother lines
            chart.AntiAliasing = AntiAliasingStyles.All;
            
        }


    }
}

