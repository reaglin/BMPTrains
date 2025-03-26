using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class Filtration : Storage
    {               
        
        public Filtration(Catchment c) : base(c) {
            BMPType = BMPTrainsProject.sFiltration;           
        }

        public override Dictionary<string, string> PropertyLabels()
        {           
            return base.PropertyLabels();
        }

        public override Dictionary<string, string> BasicReportLabels()
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>
            {
                {"label0", "<b>Filtration</b>" },
                {"ContributingArea", "Contributing Catchment Area (ac)" },
                {"RetentionDepth", "Treatment Depth (1-4 in over watershed)"},
                {"RetentionVolume", "Treatment Volume provided for Treatment Depth (ac-ft)" },
                {"RequiredNTreatmentEfficiency", "Required Nitrogen Treatment Efficiency (%)"  },
                {"RequiredPTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"  },
                {"HydraulicCaptureEfficiency", "Hydraulic Capture Efficiency (%)"},
                {"MediaMixType", "Type of Down Flow Media"},
                {"CalculatedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                {"CalculatedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"}
            };
            return d1;
            }

        public override string BMPInputVariables()
        {
            string s = "";
            s += AsHtmlTable(
                new Dictionary<string, string>
            {
                {"RetentionDepth", "Treatment Depth (in)"},
                {"HydraulicCaptureEfficiency", "Hydraulic Capture Efficiency (%)"},
                {"MediaMixType", "Media Type" },
                {"MediaNPercentReduction", "Media N Reduction (%)"}, //Eaglin Added 4/26/21
                {"MediaPPercentReduction", "Media P Reduction (%)"}
            });
            return s;
        }

        public override string GroundwaterAnalysis()
        {
            string s = "<br/>";
            if (MediaMixType != MediaMix.None)
            {
                s += "<b>Media Mix Information</b><br/>";
                s += AsHtmlTable(
                    new Dictionary<string, string>
                    {
                        {"MediaMixType", "Type of Media Mix"},
                        {"MediaNPercentReduction", "Media N Reduction (%)"},
                        {"MediaPPercentReduction", "Media P Reduction (%)"}
                    });
            }

            s += "<br/>";
            s += "<br/><b>Groundwater Discharge (Stand-Alone)</b><br/>";
            s += AsHtmlTable(
                new Dictionary<string, string>
            {
                {"RechargeRate", "Treatment Rate (MG/yr)"},
                {"BMPNMassLoadOut", "TN Mass Load (kg/yr)"},
                {"GroundwaterTNConcentration", "TN Concentration (mg/L)"},
                {"BMPPMassLoadOut", "TP Mass Load (kg/yr)"},
                {"GroundwaterTPConcentration", "TP Concentration (mg/L)"},
                });
            s += "<br/>";

            return s;
        }


        public new void SetValuesFromCatchment(Catchment c)
        {
            this.WatershedArea = c.PostArea;
            this.ContributingArea = c.PostArea;
            
            base.SetValuesFromCatchment(c);
        }

        public override string BMPTypeTitle()
        {
            string s = "Surface Discharge Filtration";
            return s;
        }

        public override bool isRetention()
        {
            return false;
        }
        public override bool isDefined()
        {
            return ((MediaMixType != MediaMix.None) && (MediaMixType != MediaMix.NotSpecified));
        }
 
        public new void Calculate()
        {            

            base.CalculateTreatmentEfficiency(RetentionDepth, WatershedNDCIACurveNumber, WatershedDCIAPercent);
            HydraulicCaptureEfficiency = ProvidedNTreatmentEfficiency; // in over watershed
            bool WetD = (WetDetentionEffluent == "Yes" ? true : false);
            if ((MediaMixType == MediaMix.None)||(MediaMixType == MediaMix.NotSpecified))
            {
                ProvidedNTreatmentEfficiency = 0;
                ProvidedPTreatmentEfficiency = 0;
            }
            else
            {
                MediaNPercentReduction = MediaMix.TNRemoval(MediaMixType, MediaNPercentReduction, WetD);
                ProvidedNTreatmentEfficiency = HydraulicCaptureEfficiency * MediaNPercentReduction / 100;
                MediaPPercentReduction = MediaMix.TPRemoval(MediaMixType, MediaPPercentReduction, WetD);
                ProvidedPTreatmentEfficiency = HydraulicCaptureEfficiency * MediaPPercentReduction / 100;
                if (WatershedArea != 0 ) TreatmentMediaVolume = RetentionDepth / WatershedArea / 12;
            }

            RechargeRate = RunoffVolume * 0.3258724 * HydraulicCaptureEfficiency / 100;
            if (RechargeRate != 0) GroundwaterTNConcentration = BMPNMassLoadOut / (RechargeRate * 3.785);
            if (RechargeRate != 0) GroundwaterTPConcentration = BMPPMassLoadOut / (RechargeRate * 3.785);

            base.CaclulateRemainingEfficiency();

            base.CalculateMassLoading();
        }
    }
}
