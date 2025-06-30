using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class WetDetention : Storage
    {
        public static string SessionId = "WetDetentionID";

        [Meta("Average Residence Time", "days", "##.##")]
        public double ResidenceTime { get; set; }
        public double PermanentPoolPondDepth { get; set; } // feet

        [Meta("Permanent Pool Area", "acres", "##.##")]
        public double PermanentPoolArea { get; set; } // acres

        [Meta("Permanent Pool Volume", "ac-ft", "##.##")]
        public double PermanentPoolVolume { get; set; } // ac-ft

        [Meta("Permanent Pool Volume for 31 days residence", "ac-ft", "##.##")]
        public double PermanentPoolVolume31 { get; set; } // ac-ft

        public double PermanentPoolVolumeOverWatershed { get; set; }
        public double MinimumPermanentPoolVolume { get; set; }


        //public double LittoralZoneEfficiencyCredit { get; set; }

        [Meta("Additional N Littoral Removal", "%", "##.##")]
        public double AdditionalPercentNLittoralRemoval { get; set; }

        [Meta("Additional P Littoral Removal", "%", "##.##")]
        public double AdditionalPercentPLittoralRemoval { get; set; }

        [Meta("Has Littoral Zone", "", "##.##")]
        public bool HasLittoralZone { get; set; }

        [Meta("Wetland Efficiency Credit", "", "##.##")]
        public double WetlandEfficiencyCredit { get; set; }

        [Meta("Additional N Wetland Removal", "%", "##.##")]
        public double AdditionalPercentNWetlandRemoval { get; set; }

        [Meta("Additional P Wetland Removal", "%", "##.##")]
        public double AdditionalPercentPWetlandRemoval { get; set; }

        [Meta("Overall Provided Phosphorus Treatment Efficiency", "%", "##.##")]
        public double DetentionPercentPhosphorusRemoval { get; set; }

        [Meta("Overall Provided Nitrogen Treatment Efficiency", "%", "##.##")]
        public double DetentionPercentNitrogenRemoval { get; set; }


        [Meta("Mean Annual Pond TP Concentration", "ug/l", "##.##")]
        public double MeanAnnualPondTPConcentration { get; set;}    // ug/l

        [Meta("Mean chlorophyll-a concentration", "mg/m^3", "##.##")]
        public double MeanChlorophyllA { get; set;}                 // mg/m^3

        [Meta("Mean Secchi Disk Depth", "m", "##.##")]
        public double MeanSecchiDisk { get; set; }                  // m

        [Meta("Anoxic Pool Depth", "ft", "##.##")]
        public double AnoxicPoolDepth { get; set; }                 // ft

        public WetDetention(Catchment c) : base(c)
        {
            BMPType = BMPTrainsProject.sWetDetention;
        }

        public override Dictionary<string, string> PropertyLabels()
        {
            var current = new Dictionary<string, string>
            {
                {"ResidenceTime", "Average Residence Time (days)"},
                {"PermanentPoolPondDepth", "Average Permanent Pool Pond Depth (in)"},
                {"PermanentPoolArea", "Permanent Pool Area (acres)"},
                {"PermanentPoolVolume", "Permanent Pool Volume (ac-ft)" },
                {"PermanentPoolVolumeOverWatershed", "Permanent Pool Volume (in over watershed)" },
                {"MinimumPermanentPoolVolume", "Minimum Permanent Pool Volume (ac-ft)" },
                {"LittoralZoneEfficiencyCredit","Littoral Zone Efficiency Credit" },
                {"AdditionalPercentNLittoralRemoval","Additional Percent N Littoral Removal" },
                {"AdditionalPercentPLittoralRemoval","Additional Percent P Littoral Removal" },
                {"HasLittoralZone", "Has Littoral Zone" },
                {"WetlandEfficiencyCredit","Wetland Efficiency Credit" },
                {"AdditionalPercentNWetlandRemoval","Additional Percent  NWetland Removal" },
                {"AdditionalPercentPWetlandRemoval","Additional Percent P Wetland Removal" },
                {"AnnualVolume", "Average Annual Runoff Volume (ac-ft/yr)"}
            };

            return Add(current, base.PropertyLabels());
        }

        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            var current = new Dictionary<string, int>
            {
                {"AnnualRainfall", 2},
                {"PermanentPoolPondDepth", 2},
                {"PermanentPoolArea", 2},
                {"CalculatedResidenceTime", 1},
                {"DetentionPercentPhosphorusRemoval",2},
                {"DetentionPercentNitrogenRemoval", 2},
                {"ResidenceTime", 0},
                {"LittoralZoneEfficiencyCredit",0},
                { "WetlandEfficiencyCredit", 0 },
                {"RunoffVolume", 2 },
                {"MinimumPermanentPoolVolume", 2},
                {"AdditionalPercentNLittoralRemoval", 0},
                {"AdditionalPercentPLittoralRemoval", 0},
                {"AdditionalPercentNWetlandRemoval", 0 },
                {"AdditionalPercentPWetlandRemoval", 0 },
                {"MeanAnnualPondTPConcentration", 2 },
                {"MeanChlorophyllA", 2 },
                {"MeanSecchiDisk", 2 },
                {"AnoxicPoolDepth", 2 }
            };

            return Add(current, base.PropertyDecimalPlaces());
        }

        public override Dictionary<string, string> BasicReportLabels()
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>
            {
                {"label0", "<h2>Wet Detention</h2>" },
                {"ContributingArea", "Contributing Catchment Area (acres)" },
                {"PermanentPoolArea", "Permanent Pool Area (acres)" },
                {"RequiredNTreatmentEfficiency", "Required Nitrogen Treatment Efficiency (%)"},
                {"RequiredPTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},
                {"ResidenceTime", "Average Residence Time (days)"},
                {"RunoffVolume", "Average Annual Runoff Volume (ac-ft/yr)" },
                {"PermanentPoolVolume", "<u>Permanent Pool Volume (ac-ft)</u>"},

                {"label1", "<b>Removal Efficiencies </b>" },
                { "LittoralZoneEfficiencyCredit","<u>Littoral Zone Efficiency Credit</u>" },
                {"AdditionalPercentNLittoralRemoval","Additional N Littoral Removal (%)" },
                {"AdditionalPercentPLittoralRemoval","Additional P Littoral Removal (%)" },

                {"WetlandEfficiencyCredit","<u>Wetland Efficiency Credit</u>" },
                {"AdditionalPercentNWetlandRemoval","Additional N Wetland Removal (%)" },
                {"AdditionalPercentPWetlandRemoval","Additional P Wetland Removal (%)" },

                {"CalculatedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                {"CalculatedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"},
            };
            return d1;
        }
        public override string BMPInputVariables()
        {
            string s = "";
            s += AsHtmlTable(
                new Dictionary<string, string>
            {
                {"PermanentPoolVolume", "Permanent Pool Volume (ac-ft)"},
                {"PermanentPoolVolume31", "Permanent Pool Volume (ac-ft) for 31 days residence"},

                {"ResidenceTime", "Annual Residence Time (days)"},
                { "HasLittoralZone","Has Littoral Zone" },
                { "WetlandEfficiencyCredit","Wetland Efficiency Credit" }

            });
            return s;
        }

        public string AnoxicDepthReport()
        {
            string s = "<b>The following calculations are based on the mean annual stormwater mass <br/>";
            s += "remaining in the wet detention pond. The equation used are those used by Harper (2007, Chapter 7)<br/>";
            s += " and valid for anoxic depths from 0.8 to 29.5 feet.<br/>";
            s += "WET DETENTION AS A FIRST BMP: " + CatchmentName + "<br/><br/>" ;

            s += AsHtmlTable(
                new Dictionary<string, string>
            {
                {"DetentionPercentPhosphorusRemoval", "Overall Provided Phosphorus Treatment Efficiency (%)"},
                {"MeanAnnualPondTPConcentration", "Mean Annual Pond TP Concentration (ug/l)"},
                {"MeanChlorophyllA", "Mean chlorophyll-a concentration (mg/m^3)"},      
                {"MeanSecchiDisk", "Mean Secchi Disk Depth (m)"},
                {"AnoxicPoolDepth","Anoxic Pool Depth (ft)" }
              
            });
            s += "<br/>Note: If anoxic depth < pond depth, recalculate permanent pool volume using the anoxic<br/>";
            s += "depth and re-enter the permanent pool volume.";
            return s;
        }

        public new void SetValuesFromCatchment(Catchment c)
        {
            PermanentPoolArea = c.BMPArea;
            WatershedArea = c.PostArea - c.BMPArea;
            ContributingArea = WatershedArea;
            base.SetValuesFromCatchment(c);
        }

        public override bool isDefined()
        {
            if (BMPType == "WetDetention") BMPType = BMPTrainsProject.sWetDetention;
            if (PermanentPoolVolume == 0) return false;
            return true;
        }
        public override bool isRetention()
        {
            return false;
        }

        public override string BMPTypeTitle()
        {
            string s = "Wet Detention";
            //if (LittoralZoneEfficiencyCredit >= 0) s += " with Littoral Shelf";
            if (WetlandEfficiencyCredit > 0) s += " with Floating Wetland Mats";
            return s;
        }

        public new void Calculate()
        {
  
            ResidenceTime = PermanentPoolVolume / RunoffVolume * 365;      // Permanent Pool Volume in Acre-feet
            PermanentPoolVolume31 = 31 * RunoffVolume / 365;

            BMPVolumeOut = BMPVolumeIn;

            Calculate(ResidenceTime);

            //CalculateAnoxicDepth();

        }

        public void CalculateAnoxicDepth(double PRemoval = 0.0, double PondTPConcentration = 0.0)
        {
            if (TPEMC <= 0.0) return;
            if (PRemoval == 0)
                PRemoval = DetentionPercentPhosphorusRemoval;
            else
                DetentionPercentPhosphorusRemoval = PRemoval;

            if ((PRemoval <= 0.0) || (PRemoval >= 100)) return;

            if (PondTPConcentration == 0.0)
                MeanAnnualPondTPConcentration = 1000 * TPEMC * (1.0 - PRemoval / 100.0);
            else
                MeanAnnualPondTPConcentration = PondTPConcentration;

            MeanChlorophyllA = Math.Pow(Math.E, 1.058 * Math.Log(MeanAnnualPondTPConcentration) - 0.934);

            MeanSecchiDisk = (24.2386 + ((0.3041) * MeanChlorophyllA)) / (6.0632 + MeanChlorophyllA);

            AnoxicPoolDepth = ((3.035 * MeanSecchiDisk) + (0.02164 * MeanChlorophyllA) - 0.004979 * MeanAnnualPondTPConcentration) * 3.281;
        }

        public void Calculate(double ResTime)
        {
            DetentionPercentNitrogenRemoval = CalculateNitrogenRemoval(ResTime);
            DetentionPercentPhosphorusRemoval = CalculatePhosphorusRemoval(ResTime);

            MinimumPermanentPoolVolume = ResTime * RunoffVolume / 365;

            CalculateWetlandCredits(DetentionPercentNitrogenRemoval, DetentionPercentPhosphorusRemoval);

            base.CaclulateRemainingEfficiency();

            base.CalculateMassLoading();

        }

        public void CalculateWetlandCredits(double Neff, double Peff)
        {
            ProvidedNTreatmentEfficiency = Neff;
            ProvidedPTreatmentEfficiency = Peff;

            double NRemaining = 100 - Neff;
            double PRemaining = 100 - Peff;

            //if (LittoralZoneEfficiencyCredit != 0)
            //{
            //    AdditionalPercentNLittoralRemoval = LittoralZoneEfficiencyCredit * NRemaining / 100;
            //    AdditionalPercentPLittoralRemoval = LittoralZoneEfficiencyCredit * PRemaining / 100;
            //    CalculatedNTreatmentEfficiency = CalculatedNTreatmentEfficiency + AdditionalPercentNLittoralRemoval;
            //    CalculatedPTreatmentEfficiency = CalculatedPTreatmentEfficiency + AdditionalPercentPLittoralRemoval;
            //}

            if (!HasLittoralZone)
            {
                ProvidedNTreatmentEfficiency = Math.Max(ProvidedNTreatmentEfficiency - 10, 0.0);
                ProvidedPTreatmentEfficiency = Math.Max(ProvidedPTreatmentEfficiency - 10, 0.0);
            }

            NRemaining = 100 - ProvidedNTreatmentEfficiency;
            PRemaining = 100 - ProvidedPTreatmentEfficiency;

            if (WetlandEfficiencyCredit != 0)
            {
                AdditionalPercentNWetlandRemoval = WetlandEfficiencyCredit * NRemaining / 100;
                AdditionalPercentPWetlandRemoval = WetlandEfficiencyCredit * PRemaining / 100;
                ProvidedNTreatmentEfficiency = ProvidedNTreatmentEfficiency + AdditionalPercentNWetlandRemoval;
                ProvidedPTreatmentEfficiency = ProvidedPTreatmentEfficiency + AdditionalPercentPWetlandRemoval;
            }
                if (!HasLittoralZone)


            if (ProvidedNTreatmentEfficiency > 100.0) ProvidedNTreatmentEfficiency = 100.0;
            if (ProvidedPTreatmentEfficiency > 100.0) ProvidedPTreatmentEfficiency = 100.0;
        }

        public static double CalculateNitrogenRemoval(double rt)
        {
            return (43.75 * rt) / (4.38 + rt);
        }

        public static double CalculatePhosphorusRemoval(double rt)
        {
            return 40.13 + 6.372 * Math.Log(rt) + 0.213 * Math.Pow(Math.Log(rt), 2);
        }

        public override Double[] plotX()
        {
            double[] x = new double[] { 0.0, 2.0, 4.0, 8.0, 16.0, 32.0, 64.0, 100.0, 128.0, 150.0, 200.0, 250.0, 400.0, 500.0 };

            return x;
        }

        public override Double[] plotY(string p = "Nitrogen")
        {
            Double[] x = plotX();
            Double[] y = new Double[x.Length];

            for (int i = 0; i < x.Length; i++)
            {
                if (p == "Nitrogen")
                {
                    y[i] = (43.75 * x[i]) / (4.38 + x[i]);
                }
                else
                {
                    y[i] = 40.13 + 6.372 * Math.Log(x[i]) + 0.213 * Math.Pow(Math.Log(x[i]), 2);
                }
                double nr = 100 - y[i];

                if (!HasLittoralZone)
                {
                    // No Littoral Zone reduce by 10%
//                    double apr = LittoralZoneEfficiencyCredit * nr / 100;
                    y[i] = y[i] - 0.1*nr;

                }

                //if (LittoralZoneEfficiencyCredit != 0)
                //{
                //    double apr = LittoralZoneEfficiencyCredit * nr / 100;
                //    y[i] = y[i] + apr;
                //}

                if (WetlandEfficiencyCredit != 0)
                {
                    double apr = WetlandEfficiencyCredit * nr / 100;
                    y[i] = y[i] + apr;
                }

                if (y[i] > 100) y[i] = 100;
            }
            return y;
        }

        public override double XAxisMaximum()
        {
            return 500.0;
        }
        public override string XAxisTitle()
        {
            return "Average Residence Time (days)";
        }
    }
}