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

        [Meta("Pipe Span", "in",  2)]
        public double PipeSpan { get; set; }

        [Meta("Pipe Rise", "in",  2)]
        public double PipeRise { get; set; }

        [Meta("Pipe Length", "ft",  2)]
        public double PipeLength { get; set; }

        [Meta("Trench Length", "ft",  2)]
        public double TrenchLength { get; set; }

        [Meta("Trench/Vault Width", "ft",  2)]
        public double TrenchWidth { get; set; }

        [Meta("Trench Depth", "ft",  2)]
        public double TrenchDepth { get; set; }

        [Meta("Void Ratio", "fraction",  2)]
        public double VoidRatio { get; set; }

        [Meta("Pipe Volume", "cf",  2)]
        public double PipeVolumeCF { get; set; }

        [Meta("Trench/Vault Volume", "cf",  2)]
        public double TrenchVolumeCF { get; set; }

        [Meta("Storage Volume", "Ac-ft",  2)]
        public double StorageVolumeAF { get; set; }

        [Meta("Storage Volume", "in over CA",  2)]
        public double StorageVolumeIn { get; set; }
        public bool ExfiltrationUnder3hours { get; set; }

        [Meta("Effectiveness Increase for > 3 hours", "%",  2)]
        public double IncreasedEffectiveness { get; set; }

        public new static readonly string[] InputVariables = {"PipeSpan", "PipeRise", "PipeLength", "TrenchWidth", "TrenchDepth", "TrenchLength",
                "VoidRatio", "PipeVolumeCF", "TrenchVolumeCF", "StorageVolumeAF", "StorageVolumeIn"};

        public override string PrintInputVariables()
        {
            return InterfaceCommon.PrintPropertyTable(this, InputVariables, "Exfiltration System Input Variables", BMPTrainsReports.TableStyle1, "my-table");
        }

        public string PrintStorageVariables()
        {
            string[] values = { "PipeVolumeCF", "TrenchVolumeCF", "StorageVolumeAF", "StorageVolumeIn" };
            return InterfaceCommon.PrintPropertyTable(this, values, "Exfiltration Storage Variables", BMPTrainsReports.TableStyle1, "my-table");
        }

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
                {"CalculatedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                {"CalculatedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"},
                {"IncreasedEffectiveness", "Effectiveness Increase for > 3 hours (%)" }
            };

            Dictionary<string, string> d2 = MediaMixLabels();

            if (hasMedia()) return Add(d1, d2);

            return d1;
        }


        //public Dictionary<string, string> StorageLabels()
        //{
        //    return new Dictionary<string, string>
        //    {
        //        {"label0", "<h2>Exfiltration Input Variables</h2>" },
        //        {"PipeSpan", "Pipe Span (in)" },
        //        {"PipeRise", "Pipe Rise (in)"},
        //        {"PipeLength", "Pipe Length (ft)"},
        //        {"TrenchWidth", "Trench/Vault Width (ft)"},
        //        {"TrenchDepth", "Trench Depth (ft)"},
        //        {"TrenchLength", "Trench Length (ft)" },
        //        { "VoidRatio", "Void Ratio (fraction)"},
        //        {"label1", "<b>Exfiltration Calculated Values</b>"  },
        //        { "PipeVolumeCF", "Pipe Volume (cf)"},
        //        {"TrenchVolumeCF", "Trench/Vault Volume (cf)"},
        //        {"StorageVolumeAF", "Storage Volume (Ac-ft)"},
        //        {"StorageVolumeIn", "Storage Volume (in over CA)"}
        //    };
        //}
        //// This one is in the printout
        //public override string BMPInputVariables()
        //{
        //    string s = "";
        //    s += AsHtmlTable(
        //        new Dictionary<string, string>
        //    {
        //        {"PipeSpan", "Pipe Span (in)" },
        //        {"PipeRise", "Pipe Rise (in)"},
        //        {"PipeLength", "Pipe Length (ft)"},
        //        {"TrenchWidth", "Trench/Vault Width (ft)"},
        //        {"TrenchDepth", "Trench/Vault Depth (ft)"},
        //        {"TrenchLength", "Trench Length (ft)" },
        //        { "VoidRatio", "Void not in pipe (fraction) "},
        //        {"StorageVolumeAF", "Storage Volume (Ac-ft)"},
        //        {"StorageVolumeIn", "Retention Depth (in over CA)"},
        //        {"IncreasedEffectiveness", "Effectiveness Increase for < 3 hours (%)" }

        //        });
        //    return s;
        //}


        //public override Dictionary<string, int> PropertyDecimalPlaces()
        //{
        //    return Add(new Dictionary<string, int>
        //    {
        //        {"PipeSpan", 1 },
        //        {"PipeRise", 1},
        //        {"PipeLength", 1},
        //        {"TrenchWidth", 1},
        //        {"TrenchDepth", 1},
        //        {"TrenchLength", 1 },
        //        { "VoidRatio", 2},
        //        { "PipeVolumeCF", 0},
        //        {"TrenchVolumeCF", 0},
        //        {"StorageVolumeAF", 2},
        //        {"StorageVolumeIn", 3},
        //        {"IncreasedEffectiveness", 3 }
        //    }, base.PropertyDecimalPlaces());
        //}

        //public new string AsHtmlTable()
        //{
        //    string s = "<h1>Exfiltration Efficiency Report</h1>";
        //    s += base.AsHtmlTable();
        //    return s;
        //}

        public override string BMPTypeTitle()
        {
            return "Exfiltration";
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
            if (ExfiltrationUnder3hours) // Exfiltration under 3 hours
            {
                if (RetentionDepth > 0.01 && RetentionDepth < 2.51)
                {
                    IncreasedEffectiveness = 2.7052 * Math.Pow(x, 3) - 14.728 * Math.Pow(x, 2) + 19.905 * x + 0.1017;
                }
                else
                {
                    IncreasedEffectiveness = 0.1;
                }
                ProvidedNTreatmentEfficiency = ProvidedNTreatmentEfficiency + IncreasedEffectiveness;
                ProvidedPTreatmentEfficiency = ProvidedPTreatmentEfficiency + IncreasedEffectiveness;
            }
        }


        public string PrintStorageReport()
        {
            string s = "";

            s += PrintInputVariables();

            s += PrintStorageVariables();

            if (TrenchWidth + 1 < PipeSpan / 12) s += "Warning: Pipe Width requires a 6 inch clearance with trench edge<br/>";
            if (TrenchWidth < 3) s += "Warning: Minimum Trench/Vault Depth is 3 ft<br/>";
            if (TrenchDepth + 1 < PipeRise / 12) s += "Warning: Trench/Vault Depth must have 6 inch clearance with trench top and bottom<br/>";
            return s;
        }
    }

}

