using System.Collections.Generic;

namespace BMPTrains_2020.DomainCode
{
    public class Retention : Storage
    {
        #region "Properties"
        public static string SessionId = "RetentionID"; 

        public double RetentionArea { get; set; } // Surface Area in acres        
        #endregion

        #region "Contructors"
        public Retention(Catchment c) : base(c) {
            BMPType = BMPTrainsProject.sRetention;
        }

        public new void SetValuesFromCatchment(Catchment c)
        {
            this.RetentionArea = c.BMPArea; // acres
            this.ContributingArea = c.PostArea - c.BMPArea;

            base.SetValuesFromCatchment(c);
        }

        #endregion

        #region "Reporting"
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

        public override Dictionary<string, string> PropertyLabels()
        {
            var current = new Dictionary<string, string>
                {
                    {"RetentionArea", "Retention Area (acres)"}
                };
            return Add(current, base.PropertyLabels());            
        }

        public new Dictionary<string, int> PropertyDecimalPlaces()
        {
            var current = new Dictionary<string, int>
                {
                    {"RetentionArea", 3},
                };
            return Add(current, base.PropertyDecimalPlaces());
        }

        public override Dictionary<string, string> BasicReportLabels()
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>
            {
                {"BasicReportlabels01", "<h2>Retention System</h2>" },
                {"AnalysisType", "Type of Analysis Performed" },
                {"ContributingArea", "Contributing Catchment Area (acres)" },
                {"RetentionDepth", "<u>Provided retetention depth for hydraulic capture (in)</u>"},                
                {"label1", "<b>Provided Values Based on Inputs</b>"  },
                {"RainfallZone", "Rainfall Zone:"},
                {"ProvidedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                {"ProvidedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"}
            };

            Dictionary<string, string> d2 = new Dictionary<string, string>
            {
                {"label2", "<b>Groundwater Reductions</b>"  },
                {"MediaMixType", "Type of Media Mix"},
                {"MediaNPercentReduction", "Nitrogen Reduction in Media (%)"},
                {"MediaPPercentReduction", "Phosphorus Reduction in Media (%)"},
                {"PostMediaNTreatmentEfficiency", "Nitrogen Mass Reduction in Groundwater Discharge (%)"},
                {"PostMediaPTreatmentEfficiency", "Phosphorus Mass Reduction in Groundwater Discharge (%)"}
            };

            Dictionary<string, string> d3 = new Dictionary<string, string>
            {
                {"RequiredNTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},
                {"RequiredPTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},
                {"RequiredRetentionDepth", "Treatment Depth to meet Required Efficiency (in)"},
                {"RemainingDepthNeeded", "Remaining Retention Depth needed (in)" },
                {"RequiredRetentionVolume", "Required Water Quality Retention Volume (in)"},
            };

            if (MediaMixType == MediaMix.None) return d1;

            return Add(d1, d2);
        }

        public Dictionary<string, string> ReportHeader()
        {
            return ReportHeader("Retention");         
        }

        public new string getReport()
        {
            Dictionary<string, string> retVal = ReportHeader();

            // Retention Values
            switch (AnalysisType)
            {
                case BMPTrainsProject.sSpecifiedRemovalEfficiency:
                    retVal = Add(retVal, RequiredRetentionLabels());
                    break;
                default:
                    retVal = Add(retVal, ProvidedRetentionLabels());
                    break;
            }
            // Watershed values
            retVal = Add(retVal, WatershedLabels());

            // Groundwater values
            if (DoGroundwaterAnalysis == "Yes")
                retVal = Add(retVal, GroundwaterDischargeLabels());

            string s =  AsHtmlTable(retVal);

            return s + EfficiencyReport();
        }

        public new string AsHtmlTable()
        {
            string s = "<h1>Retention Efficiency Report</h1>";
            s += base.AsHtmlTable();
            return s;
        }

        #endregion

        #region "Calculations"
        public new void Calculate()
        {            
            // The input is Retention Depth in inches over watershed
            base.Calculate();
        }
        #endregion       
    }
}