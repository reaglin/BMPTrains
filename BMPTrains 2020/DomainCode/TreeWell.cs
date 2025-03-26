using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class TreeWell : Storage
    {
        public double WellDepth { get; set; }           // ft
        public double WellStorage { get; set; }         // ft
        public double WellLength { get; set; }          // ft
        public double WellWidth { get; set; }           // ft
        public double SoilStorageCapacity { get; set; } // ft
        public int NumWells { get; set; }

        // Used as retention or detention

        public TreeWell(Catchment c) : base(c) {
            NumWells = 1;                       // Why do we set this to 1?
            //WellDepth = 0;
            //WellStorage = 0;
            //WellLength = 0;
            //WellWidth = 0;
            //RetentionDepth = 0;
            BMPType = BMPTrainsProject.sTreeWell;
        }

        public override Dictionary<string, string> PropertyLabels()
        {
            var current = new Dictionary<string, string>
            {
                {"WellDepth", "Vegetated Area (Tree Well) depth (ft)"},
                {"WellStorage", "Tree Well Storage (above media + canopy capture)"},
                {"WellLength", "Vegetated Area (Tree Well) Length (ft)" },
                {"WellWidth", "Vegetated Area (Tree Well) Width (ft)" },
                {"SoilStorageCapacity", "Sustainable water storage capacity of the soil (ft)" },
                {"NumWells", "Number of Similar Areas in Watershed" },
            };
            return Add(current, base.PropertyLabels());
        }

        public override Dictionary<string, string> BasicReportLabels()
        {
            var current = new Dictionary<string, string>
            {
                {"label0", "<h2>Tree Well</h2>" },
                {"ContributingArea", "Contributing Catchment Area (acres)" },
                {"RequiredNTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},
                {"RequiredPTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},
                {"WellDepth", "<u>Vegetated Area (Tree Well) depth (ft)</u>"},
                {"WellStorage", "<u>Tree Well Storage (above media + canopy capture)</u>"},
                {"WellLength", "<u>Vegetated Area (Tree Well) Length (ft)</u>" },
                {"WellWidth", "<u>Vegetated Area (Tree Well) Width (ft)</u>" },
                {"SoilStorageCapacity", "<u>Sustainable water storage capacity of the soil (ft)</u>" },
                {"NumWells", "<u>Number of Similar Areas in Watershed</u>" },
                {"RetentionDepth", "Retention Depth for Provided Hydraulic Capture Efficiency (in)" },
                {"RetentionOrDetention", "<u>Retention or Detention</u>"},
                {"MediaMixType", "<u>Type of Soil Augmentation:</u>"},
                {"CalculatedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                {"CalculatedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"}
            };
            return current;
        }

        public override string BMPInputVariables()
        {
            string s = "";
            s += AsHtmlTable(
                new Dictionary<string, string>
            {
                {"WellDepth", "Vegetated Area (Tree Well) depth (ft)"},
                {"WellStorage", "Tree Well Storage (above media + canopy capture)"},
                {"WellLength", "Vegetated Area (Tree Well) Length (ft)" },
                {"WellWidth", "Vegetated Area (Tree Well) Width (ft)" },
                {"SoilStorageCapacity", "Sustainable water storage capacity of the soil (ft)" },
                {"NumWells", "Number of Similar Areas in Watershed" },
                {"RetentionDepth", "Retention Depth for Provided Hydraulic Capture Efficiency (in)" },
                {"RetentionOrDetention", "Retention or Detention"},
            });
            return s;
        }
        
        public override bool isRetention()
        {
            return true;
        }

        public override bool isDefined()
        {
            return (WellDepth != 0);
        }

        public new void SetValuesFromCatchment(Catchment c)
        {            
            this.ContributingArea = c.PostArea - c.BMPArea;

            base.SetValuesFromCatchment(c);
        }

        public override string BMPTypeTitle()
        {
            string s = "Tree Well ";
            if (RetentionOrDetention == sRetention) s += "retention "; else s += "detention ";
            if (MediaMixType != MediaMix.None) s += "with media";
            return s;
        }

        public new void Calculate()
        {
            RetentionVolume = ((WellDepth * WellLength * WellWidth * SoilStorageCapacity) + ( WellLength * WellWidth * WellStorage)) * NumWells;

            if (ContributingArea != 0.0) RetentionDepth = 12.0 * RetentionVolume / (ContributingArea * 43560.0);

            base.CalculateTreatmentEfficiency(RetentionDepth, WatershedNDCIACurveNumber, WatershedDCIAPercent);

            if (RetentionOrDetention == sDetention)
            {
                MediaNPercentReduction = MediaMix.TNRemoval(this.MediaMixType);
                MediaPPercentReduction = MediaMix.TPRemoval(this.MediaMixType);

                ProvidedNTreatmentEfficiency = ProvidedNTreatmentEfficiency * MediaNPercentReduction / 100;
                ProvidedPTreatmentEfficiency = ProvidedPTreatmentEfficiency * MediaPPercentReduction / 100;
            }

            base.CaclulateRemainingEfficiency();
        }
    }
}
