using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class Swale : Storage
    {
        #region "Input Properties"
        public double SwaleW { get; set; }                      // Width (ft)
        public double SwaleB { get; set; }                      // Bottom Width (ft)
        public double SwaleL { get; set; }                      // Length (ft)
        public double ImperviousL { get; set; }                 // Impervious Length (ft)
        public double ImperviousW { get; set; }                 // Impervious Width (ft)
        public double PerviousW { get; set; }


        public double SwaleS { get; set; }                      // Slope drop/length
        public double ManningsN { get; set; }
        public double InfiltrationRate { get; set; }            // in/hr
        public double SwaleZ { get; set; }

        public double InfiltratedStorageDepth { get; set; }
        public double SwaleH { get; set; }                      // Average height of swale blocks ft
        public double SwaleLb { get; set; }                     // Length of berm upstream of swale crest
        public double SwaleNb { get; set; }                     // Number of Swale Blocks
        #endregion

        // Caclulated Properties
        public double ContributingAreaSF { get; set; }
        public double TreatmentAreaAcres { get; set; }

        public double RainfallIntensity { get; set; }
        public double RainfallExcessArea { get; set; }
        public double RainfallExcessAreaSF { get; set; }
        public double FlowInSwale { get; set; }     // cfs
        public double CalculatedFlowInSwale { get; set; }
        public double DepthOfFlow { get; set; }
        public double WettedPerimeter {get; set;}
        public double UpstreamSwaleBlockVolume { get; set; }
        public double TotalSwaleBlockVolume { get; set; }


        public string UseConcentrationReduction { get; set; }
        public double SurfaceDischargeNReduction { get; set; }
        public double SurfaceDischargePReduction { get; set; }

        public double GroundwaterNReduction { get; set; }
        public double GroundwaterPReduction { get; set; }


        public Swale(Catchment c) : base(c) {
            BMPType = BMPTrainsProject.sSwale;
        }

        public override Dictionary<string, string> PropertyLabels()
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>
            {
                {"SwaleW", "Swale Top Width for Flood Conditions - W (ft)"},            // Width (ft)
                {"SwaleB", "Swale Bottom Width - B (ft)"},                              // Bottom Width (ft)
                {"SwaleL", "Swale Length - L (ft)"},                                    // Length (ft)
                {"ImperviousL", "Average Impervious Length (ft)"},                      // Impervious Length (ft)
                {"ImperviousW", "Average Impervious Width (ft)"},                       // Impervious Width (ft)
                {"PerviousW", "Average Pervious Width (ft)"},
                {"SwaleS", "Swale Slope (foot drop/foot length) - S"},                  // Slope drop/length
                {"ManningsN", "Mannings N"},
                {"InfiltrationRate", "Soil Infiltration Rate (in/hr)"},                 // in/hr
                {"SwaleZ", "Side Slop of Swale h/v - Z"},
                {"SwaleH", "Avg Height of Swale Block - H"},                        // Average height of swale blocks ft
                {"SwaleLb", "Length of Upstream Berm - Lb"},                   // Length of berm upstream of swale crest
                {"SwaleNb", "Number of Swale Blocks"},                                  // Number of Swale Blocks
                {"RainfallExcessArea", "Rainfall Excess Area" },
                {"FlowInSwale", "Flow in Swale (cfs)"},
                {"DepthOfFlow", "Depth of Flow in Swale (ft)"},
                {"WettedPerimeter", "Wetted Perimeter (ft)" },
                //{"InfiltratedStorageDepth", "Infiltration Storage Depth (in)"},
                {"TotalSwaleBlockVolume", "Total Swale Block Volume (in)"},
                {"SurfaceDischargeNReduction", "Surface Discharge Nitrogen Treatment Efficiency (%)"},
                {"SurfaceDischargePReduction", "Surface Discharge Phosphorus Treatment Efficiency (%)"},
                {"GroundwaterNReduction", "Groundwater Discharge Nitrogen Treatment Efficiency (%)"},
                {"GroundwaterPReduction", "Groundwater Discharge Phosphorus Treatment Efficiency (%)"}
            };
            return this.Add(d1, base.PropertyLabels());
        }

        public override Dictionary<string, string> BasicReportLabels()
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>
            {
                {"label0", "<b>Swale</b>" },
                
                {"SwaleW", "<u>Swale Top Width for Flood Conditions - <b>W</b> (ft)</u>"},  // Width (ft)
                {"SwaleB", "<u>Swale Bottom Width - <b>B</b> (ft)</u>"},                    // Bottom Width (ft)
                {"SwaleL", "<u>Swale Length - <b>L</b> (ft)</u>"},                          // Length (ft)
                {"ImperviousL", "<u>Average Impervious Length (ft)</u>"},                   // Impervious Length (ft)
                {"ImperviousW", "<u>Average Impervious Width (ft)</u>"},                    // Impervious Width (ft)
                {"PerviousW", "<u>Average Pervious Width (ft)</u>"},
                {"SwaleS", "<u>Swale Slope (foot drop/foot length) - <b>S</b></u>"},        // Slope drop/length
                {"ManningsN", "<u>Mannings N</u>"},
                {"InfiltrationRate", "<u>Soil Infiltration Rate (in/hr)</u>"},              // in/hr
                {"SwaleZ", "<u>Side Slope of Swale horizontal/vertical - <b>Z</b></u>"},
                {"SwaleH", "<u>Average Height of Swale Block - <b>H</b></u>"},              // Average height of swale blocks ft
                {"SwaleLb", "<u>Length of Berm Upstream of Crest - <b>Lb</b></u>"},         // Length of berm upstream of swale crest
                {"SwaleNb", "<u>Number of Swale Blocks</u>"},                               // Number of Swale Blocks
                //{"RainfallExcessArea", "Contributing Catchment Area (ac)" },
                {"RainfallExcessArea", "Rainfall Excess Area (ac)" },
                {"RainfallExcessAreaSF", "Rainfall Excess Area (sf)" },
                { "ContributingAreaSF", "Swale Catchment Area (sf)" },
                { "TreatmentAreaAcres", "Treatment Area (acres)" },
                //{ "RainfallExcessAreaSF", "Post Development Catchment Area (sf)" },

                //{"RainfallIntensity", "Rainfall Intensity (in/hr)" },
                //{"FlowInSwale", "Flow in Swale (cfs)"},
                //{"CalculatedFlowInSwale", "Calculated Flow in Swale (cfs)"},

                //{"DepthOfFlow", "Depth of Flow in Swale (ft)"},
                //{"WettedPerimeter", "Wetted Perimeter (ft)" },                
                //{"InfiltratedStorageDepth", "Infiltration Storage Depth (in)"},
                //{"TotalSwaleBlockVolume", "Total Swale Block Volume (in)"},
//                {"SurfaceDischargeNReduction", "Surface Discharge Nitrogen Treatment Efficiency (%)"},
//                {"SurfaceDischargePReduction", "Surface Discharge Phosphorus Treatment Efficiency (%)"},
                {"RechargeRate", "Recharge Rate (MG/yr)"},
                { "GroundwaterTNConcentration", "TN Concentration to ground (mg/l)"},
                {"GroundwaterNMassLoadOut", "TN Mass Load to ground (kg/yr)"},
                {"GroundwaterTPConcentration", "TP Concentration to ground (mg/l)"},
                {"GroundwaterPMassLoadOut", "TP Mass Load to ground (kg/yr)"}


            };
            return d1;
        }

        public override string BMPInputVariables()
        {
            string s = "";
            s += AsHtmlTable(
                new Dictionary<string, string>
            {
                {"SwaleW", "Swale Top Width for Flood Conditions - <b>W</b> (ft)"},  // Width (ft)
                {"SwaleB", "Swale Bottom Width - <b>B</b> (ft)"},                    // Bottom Width (ft)
                {"SwaleL", "Swale Length - <b>L</b> (ft)"},                          // Length (ft)
                {"ImperviousL", "Average Impervious Length (ft)"},                   // Impervious Length (ft)
                {"ImperviousW", "Average Impervious Width (ft)"},                    // Impervious Width (ft)
                {"PerviousW", "Average Pervious Width (ft)"},
                {"SwaleS", "Swale Slope (foot drop/foot length) - <b>S</b>"},        // Slope drop/length
                {"ManningsN", "Mannings N"},
                {"InfiltrationRate", "Soil Infiltration Rate (in/hr)"},              // in/hr
                {"SwaleZ", "Side Slope of Swale horizontal/vertical - <b>Z</b>"},
                {"SwaleH", "Average Height of Swale Block - <b>H</b>"},              // Average height of swale blocks ft
                {"SwaleLb", "Length of Berm Upstream of Crest - <b>L<sub>b</sub></b>"},         // Length of berm upstream of swale crest
                { "TreatmentAreaAcres", "Runoff Area (acres)" },
                {"SwaleNb", "Number of Swale Blocks"},                               // Number of Swale Blocks
                
            });
            return s;
        }

        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            var current = new Dictionary<string, int>
            {
                {"RainfallExcessAreaSF", 0 },
                {"ContributingAreaSF", 0 },
                {"SurfaceDischargeNReduction", 0},
                {"SurfaceDischargePReduction", 0},
                {"GroundwaterNReduction", 0},
                {"GroundwaterPReduction", 0},
                {"TreatmentAreaAcres", 3 },
                {"SwaleNb", 0 }
            };
            return Add(current, base.PropertyDecimalPlaces());
        }
        public new void Calculate()
        {
            if (PerviousW < SwaleW) PerviousW = SwaleW;
            ContributingAreaSF = ImperviousL * (ImperviousW + (PerviousW - SwaleW));   // Square Feet
            RainfallExcessAreaSF = (SwaleW * SwaleL) + (ImperviousL * ImperviousW);
            RainfallExcessArea = RainfallExcessAreaSF / 43560.0;  // acres

            RainfallIntensity = IntensityLookupTable.LookupIntensity(RainfallZone);
            FlowInSwale = RainfallExcessArea * RainfallIntensity;
            InfiltratedStorageDepth = RainfallIntensity;
            DepthOfFlow = CalculateDepth();
            WettedPerimeter = SwaleB + 2 * DepthOfFlow * Math.Sqrt((SwaleZ * SwaleZ + 1));
            CalculatedFlowInSwale = (1.486/ManningsN)*(SwaleB * DepthOfFlow + SwaleZ * DepthOfFlow*DepthOfFlow)* Math.Pow((SwaleB * DepthOfFlow + SwaleZ * DepthOfFlow * DepthOfFlow) / (SwaleB + 2 * DepthOfFlow * (SwaleZ * SwaleZ + 1)), 2.0/3.0) * Math.Sqrt(SwaleS);
            double fi = SwaleL * InfiltrationRate * WettedPerimeter / (12 * 3600);
            TreatmentAreaAcres = ImperviousL * (ImperviousW + PerviousW) / 43560;
            
            if (RainfallExcessArea != 0)
            {                
                InfiltratedStorageDepth = fi * 6000.0 * 12.0 /(RainfallExcessArea * 43560.0);  // 6000 is average storm duration in seconds, answer in inches
                double w = SwaleB + 2 * SwaleZ * SwaleH;   // Width of swale at crest
                double TempSwaleNb = SwaleNb;
                if (SwaleNb < 1) TempSwaleNb = 1;

                double sl = (SwaleH / SwaleS > SwaleL / TempSwaleNb) ? SwaleL / TempSwaleNb : SwaleH / SwaleS;        // Length of water at berm crest
                double swbv = ((w * SwaleH) / 6.0) * (sl - SwaleLb) * TempSwaleNb;    // Swale Block Volume (cf)
                double UpstreamSwaleBlockVolume = 12.0 * swbv / (RainfallExcessArea * 43560.0);  

                TotalSwaleBlockVolume = (UpstreamSwaleBlockVolume + InfiltratedStorageDepth) > 4 ? 4 : (UpstreamSwaleBlockVolume + InfiltratedStorageDepth); // inches
                RetentionDepth = TotalSwaleBlockVolume;

                CalculateTreatmentEfficiency(RetentionDepth, WatershedNDCIACurveNumber, WatershedDCIAPercent); // Calculates  ProvidedNTreatmentEfficiency, ProvidedPTreatmentEfficiency;
            }

            if ((SwaleS < 0.01) || (SwaleH >= 0.5)) UseConcentrationReduction = "Yes"; else UseConcentrationReduction = "No";
            if (UseConcentrationReduction == "Yes")
            {
                SurfaceDischargeNReduction = ProvidedNTreatmentEfficiency + (0.3 * (100 - ProvidedNTreatmentEfficiency));
                SurfaceDischargePReduction = ProvidedPTreatmentEfficiency + (0.3 * (100 - ProvidedPTreatmentEfficiency));
                //ProvidedNTreatmentEfficiency = SurfaceDischargeNReduction;
                //ProvidedPTreatmentEfficiency = SurfaceDischargePReduction;
            }
            else
            {
                SurfaceDischargeNReduction = ProvidedNTreatmentEfficiency;
                SurfaceDischargePReduction = ProvidedPTreatmentEfficiency;
            }

            RechargeRate = RunoffVolume * 0.3258724 * SurfaceDischargeNReduction / 100;

            base.CalculateMediaMixTreatmentEfficiency();

            base.CalculateGroundwaterDischarge();

            GroundwaterNReduction = PostMediaNTreatmentEfficiency;
            GroundwaterPReduction = PostMediaPTreatmentEfficiency;
        }

        private double CalculateDepth2()
        {
            // This routine is no longer used
            double count = 0;
            double increment = 0.1;       // Starting Increment
            double accuracy = 0.0001;

            double d1 = 0.001;              // Starting Depth
            double d2 = d1 + increment;

            bool exit = false;

            while (!exit)
            {
                double l = FlowInSwale * ManningsN / (1.486 * Math.Sqrt(SwaleS) * (SwaleB * d1 + SwaleZ * d1 * d1));
                double r = Math.Pow((SwaleB * d1 + SwaleZ * d1 * d1) / (SwaleB + 2 * d1 * (SwaleZ * SwaleZ + 1)), 0.66667);
                d2 = l - r;  // Actual calculated depth based on guess
               
                if (d1 > d2)
                {
                    d1 -= increment;
                    increment /= 10.0;
                }
                else
                {
                    d1 += increment;
                }

                if (Math.Abs(d1 - d2) < accuracy) exit = true;
                if (increment < accuracy) exit = true;
                count++;
                if (count > 10000) exit = true;   // failure to converge
            }
            return d2;
        }
        private double CalculateDepth()
        {
            double count = 0;
            double increment = 0.1;       // Starting Increment
            double accuracy = 0.00001;

            double d1 = 0.001;              // Starting Depth
            bool exit = false;

            while (!exit)
            {
                double a = (SwaleB * d1 + SwaleZ * d1 * d1);
                double wp = (SwaleB + 2 * d1 * Math.Sqrt(1 + SwaleZ * SwaleZ));
                double hr = a/wp;
                
                double q = 1.486/ ManningsN * a * Math.Pow(hr, 2.0/3.0) * Math.Sqrt(SwaleS);
                double e = FlowInSwale - q;

                if (e > 0)    // Less than flow
                {
                    d1 += increment;
                }
                else
                {
                    d1 -= increment;
                    increment /= 2;
                }

                if (Math.Abs(e) < accuracy) exit = true;
                if (increment < accuracy) exit = true;
                count++;
                if (count > 10000) exit = true;   // failure to converge
            }
            return d1;
        }
        public override string YAxisTitle()
        {
            return "Runoff Capture Efficiency (% of yearly)";
        }
    }
}
