using System;
using System.Collections.Generic;
using System.Collections;


namespace BMPTrains_2020.DomainCode
{
    public class IntensityLookupTable 
    {
        private static Dictionary<string, double> intensity = new Dictionary<string, double>
        {
            {StaticLookupTables.FlZone1, 0.162580104604048 },
            {StaticLookupTables.FlZone2, 0.184777262871714 },
            {StaticLookupTables.FlZone3, 0.171405516465605 },
            {StaticLookupTables.FlZone4, 0.172857248609307 },
            {StaticLookupTables.FlZone5, 0.183762740359357 }
        };

        public static double LookupIntensity(string zone)
        {
            if ((zone == "") || (zone == null)) return 0.0;
            return intensity[zone];
        }
    }

    public class Storage : BMP
    {
        #region "Properties"
        public double RequiredWaterQualityVolume { get; set; }
        public string WetDetentionEffluent { get; set; } 

        // For Retention Systems
        public double RequiredRetentionDepth { get; set; }      // inches over watershed
        public double RequiredRetentionVolume { get; set; }     // ac-ft
        public double RemainingDepthNeeded { get; set; }
        public double TreatmentMediaVolume { get; set; }

        [Meta("Provided Media Treatment Depth", "in", "##.##")]
        public double TreatmentMediaDepth { get; set; }

        #endregion

        #region "Contructors"
        public Storage(Catchment c) : base(c)
        {
            MediaMixType = MediaMix.defaultMix;
            RetentionOrDetention = sRetention;
            BMPVolumeIn = c.PostRunoffVolume;
        }
        #endregion

        #region "Reporting"
        public override Dictionary<string, string> PropertyLabels()
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>
            {
                {"RetentionVolume", "Retention Volume (ac-ft)"},
                {"RetentionDepth", "Treatment Volume (in over watershed)"},
                {"RequiredRetentionDepth","Required Retention Depth (in of watershed)" },
                {"RequiredRetentionVolume","Required Retention Volume (ac-ft)" },
                {"RemainingDepthNeeded","Remaining Depth of Retention Needed (in)" },
                {"RetentionOrDetention","Retention or Detetention System" }
            };

            return Add(d1, base.PropertyLabels());
        }

        public Dictionary<string, string> RequiredRetentionLabels()
        {
            return new Dictionary<string, string>
            {
                {"RequiredRetentionLabels01", "<b>Required Retention Values</b>" },
                {"RequiredNTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},
                {"RequiredPTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},
                {"RequiredRetentionDepth","Required Retention Depth for Removal (in of watershed)" },
                {"RetentionDepth", "Provided Treatment Depth (in over watershed)"},
                { "RequiredRetentionVolume","Required Retention Volume (ac-ft)" },
                {"RetentionVolume", "Provided Retention Volume (ac-ft)"},
                { "RemainingDepthNeeded","Remaining Depth of Retention Needed (in)" }
            };
        }

        public Dictionary<string, string> ProvidedRetentionLabels()
        {
            return new Dictionary<string, string>
            {
                {"ProvidedRetentionLabels01", "<b>Retention System Information</b>" },
                {"RetentionDepth", "Provided Treatment Depth (in over watershed)"},
                {"RetentionVolume", "Provided Retention Volume (ac-ft)"},
                {"CalculatedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                {"CalculatedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"}
            };
        }

        public Dictionary<string, string> GroundwaterDischargeLabels() {
            return new Dictionary<string, string>
            {
                {"GWLabel01", "<b>Groundwater Analysis</b>" },
                {"RechargeRate", "Recharge (MG/yr) "},
                {"GroundwaterTNConcentration", "TN Concentration to ground (mg/l)"},
                {"GroundwaterNMassLoadOut", "TN Mass Load to ground (kg/yr)"},
                {"GroundwaterTPConcentration", "TP Concentration to ground (mg/l)"},
                {"GroundwaterPMassLoadOut", "TP Mass Load to ground (kg/yr)"}
            };
        }

        public Dictionary<string, string> MediaMixLabels() {  
            return new Dictionary<string, string>
            {
                {"label2", "<b>Groundwater Media</b>"  },
                {"MediaMixType", "Type of Media Mix"},
                {"MediaNPercentReduction", "Nitrogen Reduction in Media (%)"},
                {"MediaPPercentReduction", "Phosphorus Reduction in Media (%)"},
                {"PostMediaNTreatmentEfficiency", "Nitrogen Mass Reduction in Groundwater Discharge (%)"},
                {"PostMediaPTreatmentEfficiency", "Phosphorus Mass Reduction in Groundwater Discharge (%)"}
            };
        }

        public Dictionary<string, string> SpecificLabels()
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>
                {
                    {"WatershedArea", "Catchment Area (acres)"},
                    {"WatershedNDCIACurveNumber", "Watershed Non-DCIA Curve Number"},
                    {"WatershedDCIAPercent", "Watershed DCIA Percent"},
                    {"RainfallZone", "Rainfall Zone"},
                    {"RationalCoefficient", "Calculated Annual Coefficient (0-1)"},
                    {"RetentionVolume", "Retention Volume (ac-ft)"},
                    {"RetentionDepth", "Treatment Volume (in over watershed)"},
                    {"RequiredNTreatmentEfficiency", "Required Nitrogen Treatment Efficiency (%)"},
                    {"RequiredPTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},
                    {"CalculatedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                    {"CalculatedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"},
                    {"RemainingNTreatmentEfficiency", "Remaining Nitrogen Treatment Efficiency (%)"},
                    {"RemainingPTreatmentEfficiency", "Remaining Phosphorus Treatment Efficiency (%)"}
            };


            Dictionary<string, string> d2 = MediaMixLabels();

            if (hasMedia()) return Add(d1, d2);

            return d1;
        }

        public bool hasMedia()
        {
            return (MediaMixType != MediaMix.defaultMix);
        }

        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            return Add(new Dictionary<string, int>
            {
                {"TreatmentEfficiencyCalculated", 2},
                {"RetentionDepth", 3},
                {"RetentionVolume", 3},
                {"MediaNPercentReduction", 0},
                {"MediaPPercentReduction", 0},
                {"PostMediaNTreatmentEfficiency", 0},
                {"PostMediaPTreatmentEfficiency",0}
            }, base.PropertyDecimalPlaces());
        }

        public List<string> RainfallZones()
        {
            return StaticLookupTables.RainfallZones();
        }

        #endregion

        #region "Calculation Routines"
        public override bool isRetention()
        {
            return true;
        }

        public override bool isDefined()
        {
            if (RetentionDepth > 0) return true;
            return false;
        }

        public new void Calculate()
        {
            CalculateDelayEfficiency();

            CalculateTreatmentEfficiency(RetentionDepth, WatershedNDCIACurveNumber, WatershedDCIAPercent);

            CalculateRequiredDepth();

            CalculateMediaMixTreatmentEfficiency();

            CaclulateRemainingEfficiency();

            base.Calculate();

            CalculateGroundwaterDischarge();
        }

        public void CalculateTreatmentEfficiency(double RD, double NDCIACN, double DCIAP)
        {
            // RD - Retention Depth
            // NDCIACN Non Directly connected CN
            // DCIAP - Directly Connected Impervious Area Perccent
            RetentionVolume = RD * ContributingArea / 12;       // Acre-feet
            if ((RainfallZone == "") || (RainfallZone == null)) return;

            // These are all in %
            double t = RetentionEfficiencyLookupTables.CalculateEfficiency(RD,
                                                                           NDCIACN,
                                                                           DCIAP,
                                                                           RainfallZone);

            HydraulicCaptureEfficiency = t;
            ProvidedNTreatmentEfficiency = t + DelayEfficiency;
            ProvidedPTreatmentEfficiency = t + DelayEfficiency;

            if (ProvidedNTreatmentEfficiency > 100) ProvidedNTreatmentEfficiency = 100;
            if (ProvidedPTreatmentEfficiency > 100) ProvidedPTreatmentEfficiency = 100;
        }


        public void CalculateRequiredDepth()
        {
            RequiredRetentionDepth = CaclulateRequiredTreatmentDepth(RequiredNTreatmentEfficiency > RequiredPTreatmentEfficiency ? RequiredNTreatmentEfficiency : RequiredPTreatmentEfficiency);
            RequiredRetentionVolume = RequiredRetentionDepth * ContributingArea / 12;

            if (RequiredRetentionDepth > RetentionDepth)
            {
                RemainingDepthNeeded = RequiredRetentionDepth - RetentionDepth;
            }
            else
            {
                RemainingDepthNeeded = 0.0;
            }
        }

        public double CaclulateRequiredTreatmentDepth(double targetEfficiency)
        {
            double count = 0;
            double increment = 0.1;       // Starting Increment
            double accuracy = 0.001;

            double d1 = 0.25;              // Starting Depth

            if (targetEfficiency <= 0) return 0.0;
            bool exit = false;

            while (!exit)
            {
                double e = RetentionEfficiencyLookupTables.CalculateEfficiency(d1,
                                                                           WatershedNDCIACurveNumber,
                                                                           WatershedDCIAPercent,
                                                                           RainfallZone);

                if (e > targetEfficiency)
                {
                    d1 -= increment;
                    increment /= 10.0;
                }
                else
                {
                    d1 += increment;
                }

                if (Math.Abs(e - targetEfficiency) < accuracy) exit = true;

                count++;
                if (count > 10000) exit = true;   // failure to converge
                if (d1 >= 4) { d1 = 4; exit = true; }
            }
            return d1;
        }


        public void CalculateMediaMixTreatmentEfficiency()
        {
            // If Groundwater Calculations are required then calculates the efficiency 
            // and reductions of groundwater discharge.

            MediaNPercentReduction = MediaMix.TNRemoval(this.MediaMixType, MediaNPercentReduction);
            MediaPPercentReduction = MediaMix.TPRemoval(this.MediaMixType, MediaPPercentReduction);
            PostMediaNTreatmentEfficiency = 0;
            PostMediaPTreatmentEfficiency = 0;

            //if (BMPType == BMPTrainsProject.sVegetatedFilterStrip)
            //{
            //    PostMediaNTreatmentEfficiency = 0; MediaNPercentReduction = 0;
            //    PostMediaPTreatmentEfficiency = 0; MediaPPercentReduction = 0;
            //    return;
            //}

            if (MediaNPercentReduction != 0)
            {
                PostMediaNTreatmentEfficiency = 100 * (0.3 * ProvidedNTreatmentEfficiency / 100 + 0.7 * ProvidedNTreatmentEfficiency / 100 * MediaNPercentReduction / 100);
                //GroundwaterNMassDischarge = 
            }
            else
            {
                PostMediaNTreatmentEfficiency = 0;// CalculatedNTreatmentEfficiency;
            }

            if (MediaPPercentReduction != 0)
            {
                PostMediaPTreatmentEfficiency = 100 * (0.3 * ProvidedPTreatmentEfficiency / 100 + 0.7 * ProvidedPTreatmentEfficiency / 100 * MediaPPercentReduction / 100);
                //GroundwaterPMassDischarge = 
            }
            else
            {
                PostMediaPTreatmentEfficiency = 0;// CalculatedPTreatmentEfficiency;
            }
        }

        public override void CalculateGroundwaterDischarge()
        {
            if (MediaNPercentReduction != 0) DoGroundwaterAnalysis = "Yes";

            if (DoGroundwaterAnalysis != "Yes")
            {
                base.CalculateGroundwaterDischarge();
                return;
            }

            RechargeRate = RunoffVolume * 0.3258724 * HydraulicCaptureEfficiency / 100;

            GroundwaterNTreatmentEfficiency = MediaNPercentReduction;
            GroundwaterPTreatmentEfficiency = MediaPPercentReduction;

            GroundwaterNMassLoadIn = BMPNMassLoadIn * HydraulicCaptureEfficiency / 100; // - BMPNMassLoadOut;  
            GroundwaterPMassLoadIn = BMPPMassLoadIn * HydraulicCaptureEfficiency / 100; // - BMPPMassLoadOut;

            //if (BMPType == BMPTrainsProject.sVegetatedFilterStrip)
            //{
            //    GroundwaterNMassLoadOut = MediaNPercentReduction/100 *(100 - MediaNPercentReduction) / 100 * GroundwaterNMassLoadIn;
            //    GroundwaterPMassLoadOut = MediaPPercentReduction/100*(100 - MediaPPercentReduction) / 100 * GroundwaterPMassLoadIn;

            //    GroundwaterTNConcentration = MediaNPercentReduction/100 * TNEMC * (100 - MediaNPercentReduction) / 100;
            //    GroundwaterTPConcentration = MediaPPercentReduction/100 * TPEMC * (100 - MediaPPercentReduction) / 100;

            //}
            //else
            //{
                GroundwaterNMassLoadOut = (100 - MediaNPercentReduction) / 100 * GroundwaterNMassLoadIn;
                GroundwaterPMassLoadOut = (100 - MediaPPercentReduction) / 100 * GroundwaterPMassLoadIn;

                GroundwaterTNConcentration = TNEMC * (100 - MediaNPercentReduction) / 100;
                GroundwaterTPConcentration = TPEMC * (100 - MediaPPercentReduction) / 100;
            //}
    }
        #endregion


        #region "Plot Routines"
        public override Double[] plotX()
        {
            Double[] x = new Double[21];
            for (int i = 0; i <= 20; i ++)
            {
                x[i] = 0.2 * (Double)i;
            }
            return x;
        }

        public override Double[] plotY()
        {
            Double[] x = plotX();
            Double[] y = new Double[21];
            for (int i = 0; i <= 20; i++)
            {
                y[i] = RetentionEfficiencyLookupTables.CalculateEfficiency(x[i],
                                                                           WatershedNDCIACurveNumber,
                                                                           WatershedDCIAPercent,
                                                                           RainfallZone);
            }
            return y;
        }

        public override string LegendTitle()
        {
            return "Retention System - NDCIA CN: " + AsString(WatershedNDCIACurveNumber, 0) +  " DCIA %: " + AsString(WatershedDCIAPercent, 2) + " Rainfall Zone: " + RainfallZone;
        }

        public override string XAxisTitle()
        {
            return "Retention Depth (in)";
        }

        public override string YAxisTitle()
        {
            return "Treatment Efficiency (%)";
        }
        
        public override string PlotTitle()
        {
            return "Type: " + BMPTypeTitle() + "\n" + "Name: " + BMPName;
        }
        #endregion
    }
}