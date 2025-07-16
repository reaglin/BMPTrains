using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class RainGarden : Storage
    {
        public static string SessionId = "RainGardenID";

        //public double ProvidedRetentionDepth { get; set; } // inches over watershed use RetentionDepth

        [Meta("Provided retention volume for efficiency", "ac-ft", "##.##")]
        public double ProvidedRetentionVolume { get; set; } // acre-feet

        public static string[] SystemTypes => new string[] { sRetention, sDetention };

        [Meta("Sustainable Void Fraction", "0-1", 2)]
        public double VoidFraction { get; set; }

        [Meta("Water Above Media", "cubic feet", 2)]
        public double WaterAboveMedia { get; set; }

        [Meta("Volume of Storage", "cubic feet", 0)]
        public double VolumeStorageCF { get; set; }

        [Meta("Volume of Storage", "inches", 2)]
        public double VolumeStorageIn { get; set; }


        //public double MediaAreaSF { get; set; }


        public double MinimumMediaArea { get; set; }

        [Meta("Credit For Cover Crop", "%", "##.##")]
        public double CreditForCoverCrop { get; set; }

        public new static readonly string[] InputVariables = {
            "RetentionOrDetention", "MediaMixType", "VoidFraction", "MediaVolume", "WaterAboveMedia",
            "ProvidedRetentionVolume", "TreatmentMediaDepth", "CreditForCoverCrop" };

        public override string PrintInputVariables()
        {
            return InterfaceCommon.PrintPropertyTable(this, InputVariables, "Rain Garden Input Variables");
        }

        public RainGarden(Catchment c) : base(c) {
            BMPType = BMPTrainsProject.sRainGarden;
        }


        public override Dictionary<string, string> PropertyLabels()
        {
            var current = new Dictionary<string, string>
                {
                    {"ContributingArea", "Contributing Catchment Area (ac)"},
                    {"RequiredNTreatmentEfficiency", "Required Nitrogen Treatment Efficiency (%)"},
                    {"RequiredPTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},                    
                    {"RetentionDepth", "Provided Retention Depth (in over Watershed)"},
                    {"ProvidedRetentionVolume", "Provided retention volume for efficiency (ac-ft)" },
                    {"RetentionOrDetention", "Type of System (Retention or Detention)" },
                    {"MediaMixSelection", "Type of Media Mix"},
                    {"CalculatedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                    {"CalculatedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"},
                    {"VoidFraction", "Sustainable Void Fraction (0-1)"},
                    {"MediaVolume", "Media Volume (Cubic Feet)"},
                    {"WaterAboveMedia", "Water Above Media (cubic feet)"},
                    {"VolumeStorageCF", "Volume of Storage (cubic feet)"},
                    {"VolumeStorageIn", "Volume of Storage (inches)"}
            };
            
            return current;
        }

        public override Dictionary<string, string> BasicReportLabels()
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>
            {
                {"label0", "<h2>Rain Garden</h2>" },
                {"ContributingArea", "Contributing Catchment Area (acres)" },
                {"RequiredNTreatmentEfficiency", "Required Nitrogen Treatment Efficiency (%)"},
                {"RequiredPTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},
                {"RainfallZone", "Rainfall Zone:"},
                {"RetentionDepth", "Provided retetention depth for hydraulic capture (in)"},
                {"ProvidedRetentionVolume", "<u>Provided retention volume for efficiency (ac-ft)</u>" },
                {"HydraulicCaptureEfficiency", "Hydraulic Capture Efficiency (%)"},
                {"RetentionOrDetention", "<u>Retention or Detention System</u>" },
                {"MediaMixType", "Type of Media Mix"},
                {"CalculatedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                {"CalculatedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"},
                {"Label1", "<b>Volume of Storage input data</b>" },
                {"VoidFraction", "<u>Sustainable Void Fraction (0-1)</u>"},
                {"MediaVolume", "<u>Media Volume (Cubic Feet)</u>"},
                {"WaterAboveMedia", "<u>Water Above Media (cubic feet)</u>"},
                {"VolumeStorageCF", "Volume of Storage (cubic feet)"},
                {"VolumeStorageIn", "Volume of Storage (inches)"}
            };
            return d1;
        }

        public override string BMPInputVariables()
        {
            string s = "";
            s += AsHtmlTable(
                new Dictionary<string, string>
            {
                {"RetentionOrDetention", "Type of System" },
                {"MediaMixType", "Type of Media Mix"},
                {"VoidFraction", "Sustainable Void Fraction (0-1)"},
                {"MediaVolume", "Media Volume (Cubic Feet)"},
                {"WaterAboveMedia", "Water Storage Above Media (cubic feet)"},
                { "ProvidedRetentionVolume", "Provided retention volume for efficiency (ac-ft)" },
                { "TreatmentMediaDepth", "Provided Media Treatment Depth (in)" },
                { "CreditForCoverCrop", "Credit For Cover Crop (%)" }
                });
            return s;
        }


        public new Dictionary<string, int> PropertyDecimalPlaces()
        {
            var current = new Dictionary<string, int>
                {
                    {"VoidFraction", 2},
                    {"VolumeStorageCF", 2},
                    {"CreditForCoverCrop", 1},

                };
            return Add(current, base.PropertyDecimalPlaces());
        }

        public override bool isDefined()
        {
            if (VolumeStorageCF > 0) return true;
            return false;
        }

        public override string BMPTypeTitle()
        {
            string s = "Rain Garden ";
            if (RetentionOrDetention == sRetention) s += "retention "; else s += "detention ";
            if ((MediaMixType != MediaMix.None) && (MediaMixType != "") ) s += "with media";
            return s;
        }

        public new void Calculate()
        {
            VolumeStorageCF = VoidFraction * MediaVolume + WaterAboveMedia;
            VolumeStorageIn = VolumeStorageCF * 12 / (43560 * ContributingArea);


            // First Calculate the efficiency of the retention
            RetentionDepth = VolumeStorageIn; // Treatment Volume is volume used in Storage Calculation
            ProvidedRetentionVolume = ContributingArea * RetentionDepth / 12;
            TreatmentMediaDepth = ProvidedRetentionVolume * 12 / ContributingArea;
            if (MediaMix.GPM_SF(MediaMixType) != 0) { 
                MinimumMediaArea = 12 * VolumeStorageCF / (2 * MediaMix.GPM_SF(MediaMixType)*96.15 * 24);
            }
            else
            {
                MinimumMediaArea = 0;
            }
            base.Calculate();
            if (RetentionOrDetention == RainGarden.sRetention)
            {
                ProvidedNTreatmentEfficiency = HydraulicCaptureEfficiency + (CreditForCoverCrop / 100.0) * (100 - HydraulicCaptureEfficiency);
                ProvidedPTreatmentEfficiency = HydraulicCaptureEfficiency + (CreditForCoverCrop / 100.0) * (100 - HydraulicCaptureEfficiency);
            }

            // The input is Retention Depth in inches over watershed
            if (RetentionOrDetention == RainGarden.sDetention)
            {
                if (MediaMixType != MediaMix.User_Defined)
                {
                    MediaNPercentReduction = MediaMix.TNRemoval(MediaMixType);
                    MediaPPercentReduction = MediaMix.TPRemoval(MediaMixType);
                }
                if (MediaNPercentReduction == 0)
                {
                    ProvidedNTreatmentEfficiency = CreditForCoverCrop;
                    ProvidedPTreatmentEfficiency = CreditForCoverCrop;
                }
                else
                {
                    ProvidedNTreatmentEfficiency = HydraulicCaptureEfficiency* MediaNPercentReduction/100 + (CreditForCoverCrop / 100.0) * (100 - HydraulicCaptureEfficiency * MediaNPercentReduction / 100);
                    ProvidedPTreatmentEfficiency = HydraulicCaptureEfficiency * MediaPPercentReduction / 100 + (CreditForCoverCrop / 100.0) * (100 - HydraulicCaptureEfficiency * MediaPPercentReduction / 100);
                }
            }
        }

        public override bool isRetention()
        {
            return (RetentionOrDetention == sRetention);
        }

        public new void SetValuesFromCatchment(Catchment c)
        {
            this.ContributingArea = c.PostArea - c.BMPArea;  // acres
            this.WatershedArea = c.PostArea - c.BMPArea;
            base.SetValuesFromCatchment(c);
        }
    }
}
