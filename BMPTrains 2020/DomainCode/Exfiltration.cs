using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class Exfiltration :Storage
    {
        public static string SessionId = "ExfiltrationID";

        public double PipeSpan { get; set; }
        public double PipeRise { get; set; }
        public double PipeLength { get; set; }
        public double TrenchLength { get; set; }
        public double TrenchWidth { get; set; }
        public double TrenchDepth { get; set; }
        public double VoidRatio { get; set; }
        public double PipeVolumeCF { get; set; }
        public double TrenchVolumeCF { get; set; }
        public double StorageVolumeAF { get; set; }
        public double StorageVolumeIn { get; set; }
        public bool ExfiltrationOver3hours { get; set; }

        public double IncreasedEffectiveness { get; set; }


        public Exfiltration(Catchment c) : base(c) {
            BMPType = BMPTrainsProject.sExfiltration;
        }

        public new void Calculate()
        {
            // The input is Retention Depth in inches over watershed
            CalculateStorage();
            base.Calculate();
            CalculateAdjustment();
        }
        public new void SetValuesFromProject(BMPTrainsProject p, Catchment c)
        {
            this.WatershedArea = c.PostArea;
            this.ContributingArea = c.PostArea;

            base.SetValuesFromProject(p, c);
        }


        public override Dictionary<string, string> BasicReportLabels()
        {
            if (ProvidedNTreatmentEfficiency >= 100) ProvidedNTreatmentEfficiency = 99;
            if (ProvidedPTreatmentEfficiency >= 100) ProvidedPTreatmentEfficiency = 99;

            Dictionary<string, string> d1 = new Dictionary<string, string>
            {
                {"label0", "<h2>Exfiltration</h2>" },
                {"ContributingArea", "Contributing Catchment Area (acres)" },
                {"RetentionDepth", "<u>Provided retention depth for hydraulic capture (in)</u>"},
                {"RequiredNTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},
                {"RequiredPTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},
                {"RequiredRetentionDepth", "Treatment Depth to meet Required Efficiency (in)"},
                {"RemainingDepthNeeded", "Remaining Retention Depth needed (in)" },
                { "RequiredRetentionVolume", "Required Water Quality Retention Volume (in)"},
                {"label1", "<b>Provided Values Based on Inputs</b>"  },
                { "RainfallZone", "Rainfall Zone:"},
                {"ProvidedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                {"ProvidedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"},
                {"IncreasedEffectiveness", "Effectiveness Increase for > 3 hours (%)" }
            };

            Dictionary<string, string> d2 = MediaMixLabels();

            if (hasMedia()) return Add(d1, d2);

            return d1;
        }


        public Dictionary<string, string> StorageLabels()
        {
            return new Dictionary<string, string>
            {
                {"label0", "<h2>Exfiltration Input Variables</h2>" },
                {"PipeSpan", "Pipe Span (in)" },
                {"PipeRise", "Pipe Rise (in)"},
                {"PipeLength", "Pipe Length (ft)"},
                {"TrenchWidth", "Trench Width (ft)"},
                {"TrenchDepth", "Trench Depth (ft)"},
                {"TrenchLength", "Trench Length (ft)" },
                { "VoidRatio", "Void Ratio (fraction)"},
                {"label1", "<b>Exfiltration Calculated Values</b>"  },
                { "PipeVolumeCF", "Pipe Volume (cf)"},
                {"TrenchVolumeCF", "Trench Volume (cf)"},
                {"StorageVolumeAF", "Storage Volume (Ac-ft)"},
                {"StorageVolumeIn", "Storage Volume (in over CA)"}
                

            };
        }
        // This one is in the printout
        public override string BMPInputVariables()
        {
            string s = "";
            s += AsHtmlTable(
                new Dictionary<string, string>
            {
                {"PipeSpan", "Pipe Span (in)" },
                {"PipeRise", "Pipe Rise (in)"},
                {"PipeLength", "Pipe Length (ft)"},
                {"TrenchWidth", "Trench Width (ft)"},
                {"TrenchDepth", "Trench Depth (ft)"},
                {"TrenchLength", "Trench Length (ft)" },
                { "VoidRatio", "Aggregate Void (fraction) "},
                {"StorageVolumeAF", "Storage Volume (Ac-ft)"},
                {"StorageVolumeIn", "Retention Depth (in over CA)"},
                {"IncreasedEffectiveness", "Effectiveness Increase for > 3 hours (%)" }

                });
            return s;
        }

        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            return Add(new Dictionary<string, int>
            {
                {"PipeSpan", 1 },
                {"PipeRise", 1},
                {"PipeLength", 1},
                {"TrenchWidth", 1},
                {"TrenchDepth", 1},
                {"TrenchLength", 1 },
                { "VoidRatio", 2},
                { "PipeVolumeCF", 0},
                {"TrenchVolumeCF", 0},
                {"StorageVolumeAF", 2},
                {"StorageVolumeIn", 3},
                {"IncreasedEffectiveness", 3 }
            }, base.PropertyDecimalPlaces());
        }

        public new string AsHtmlTable()
        {
            string s = "<h1>Exfiltration Efficiency Report</h1>";
            s += base.AsHtmlTable();
            return s;
        }

        public override string BMPTypeTitle()
        {
            return "Exfiltration Trench";
        }

        public void CalculateStorage()
        {
            PipeVolumeCF = Math.PI * (PipeSpan / 24) * (PipeRise / 24) * PipeLength;
            TrenchVolumeCF = (TrenchWidth * TrenchDepth * TrenchLength - PipeVolumeCF) * VoidRatio;
            StorageVolumeAF = (PipeVolumeCF + TrenchVolumeCF) / 43560.0;
            if (ContributingArea != 0.0) StorageVolumeIn = StorageVolumeAF / ContributingArea * 12; else StorageVolumeIn = 0.0;
            RetentionDepth = StorageVolumeIn;
        }

        public void CalculateAdjustment()
        {
            IncreasedEffectiveness = 0.0;
            double x = RetentionDepth;
            if (ExfiltrationOver3hours) // Exfiltration over 3 hours
            {
                if (RetentionDepth > 0.01 && RetentionDepth < 2.51)
                {
                    IncreasedEffectiveness = 2.7052 * Math.Pow(x,3) - 14.728 * Math.Pow(x,2) + 19.905 * x + 0.1017;
                }
                else
                { 
                    IncreasedEffectiveness = 0.1;
                }
                ProvidedNTreatmentEfficiency = ProvidedNTreatmentEfficiency + IncreasedEffectiveness;
                ProvidedPTreatmentEfficiency = ProvidedPTreatmentEfficiency + IncreasedEffectiveness;
            }
        }


        public string StorageReport()
        {
            string s = "";
            if (TrenchWidth + 1 < PipeSpan / 12) s += "Warning: Pipe Width requires a 6 inch clearance with trench edge<br/>";
            if (TrenchWidth < 3) s += "Warning: Minimum Trench Depth is 3 ft<br/>";
            if (TrenchDepth + 1 < PipeRise / 12) s += "Warning: Trench Depth must have 6 inch clearance with trench top and bottom<br/>";

            s += base.AsHtmlTable(StorageLabels());
            return s;
        }
    }

}

