
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public interface IBMP
    {
        int CatchmentId { get; set; }
        string CatchmentName { get; set; }
        string BMPType { get; set; }
        double AnnualRainfall { get; set; }
        double WatershedArea { get; set; }
        double WatershedNDCIA_CN { get; set; }
        double WatershedDCIAPercent { get; set; }
        string RainfallZone { get; set; }


        double[] plotX();
        double[] plotY();
        string LegendTitle();
        string XAxisTitle();
        string YAxisTitle();
    }

    public class BMP : XmlPropertyObject
    {
        #region "Properties"
        public const string sAllProperties = "All Properties";
        public const string sBasicReport = "Basic BMP Report";
        public const int plotN = 21;

        // Base class for all BMP Types
        public int CatchmentID { get; set; }
        public string CatchmentName { get; set; }

        [Meta("Type of Best Management Practice", "", "##.##")]
        public string BMPType { get; set; }

        [Meta("BMP Name (use to organize BMP's)", "", "##.##")]
        public string BMPName { get; set; }

        [Meta("Help URL", "", "##.##")]
        public string HelpURL { get; set; }
       
        public string ReportType { get; set; }
        public string AnalysisType { get; set; }
        public string DoGroundwaterAnalysis { get; set; }

        // Watershed Information
        [Meta("Watershed Area", "acres", "###.##")]
        public double WatershedArea { get; set; } // Area in acres

        [Meta("Watershed Non-DCIA Curve Number", "(0-100)", "##")]
        public double WatershedNDCIACurveNumber { get; set; }

        [Meta("Watershed DCIA Percent", "%", "##.##")]
        public double WatershedDCIAPercent { get; set; }

        [Meta("Calculated Annual Coefficient (0-1)", "", "##.##")]
        public double RationalCoefficient { get; set; }

        [Meta("Rainfall", "in", "##.##")] 
        public double Rainfall { get; set; } // Rainfall depth ininches
        
        [Meta("Rainfall Zone", "", "##.##")]
        public string RainfallZone { get; set; }

        [Meta("Average Annual Runoff Volume", "ac-ft/yr", "##.##")]
        public double RunoffVolume { get; set; } // Average Annual Runoff Volume

        // Always use Contributing Area as area contributing to BMP
        [Meta("Contributing Area to BMP", "ac", "##.##")]
        public double ContributingArea { get; set; }
        //public double ContributingAreaSF { get; set; }

        // Treatment Efficiency for N and P
        public double RetentionVolume { get; set; }             // Acre-feet (same as Retention Depth, different units)

        [Meta("Treatment Depth", "in", "##.##")]
        public double RetentionDepth { get; set; }             // inches over watershed (also called Treatment Volume or Treatment Depth)
        public double DelayTime { get; set; }
        public double DelayFactor { get; set; }
        public double DelayEfficiency { get; set; }

        [Meta("Hydraulic Capture Efficiency", "%", "##.##")]
        public double HydraulicCaptureEfficiency { get; set; } // Give units

        [Meta("Required Nitrogen Treatment Efficiency", "%", "##.##")]
        public double RequiredNTreatmentEfficiency { get; set; }

        [Meta("Required Phosphorus Treatment Efficiency", "%", "##.##")]
        public double RequiredPTreatmentEfficiency { get; set; }

        [Meta("Provided Nitrogen Treatment Efficiency", "%", "##.#")]
        public double ProvidedNTreatmentEfficiency { get; set; }

        [Meta("Provided Phosphorus Treatment Efficiency", "%", "##.#")]
        public double ProvidedPTreatmentEfficiency { get; set; }

        // Adjusted treatment efficiencies are the efficiencies
        // that occur when the BMP is in a routing with different
        // input conditions.
        public double AdjustedNTreatmentEfficiency { get; set; }
        public double AdjustedPTreatmentEfficiency { get; set; }

        [Meta("Remaining Nitrogen Treatment Efficiency", "%", "##.##")]
        public double RemainingNTreatmentEfficiency { get; set; }

        [Meta("Remaining Phosphorus Treatment Efficiency", "%", "##.##")]
        public double RemainingPTreatmentEfficiency { get; set; }

        public double GroundwaterNTreatmentEfficiency { get; set; }
        public double GroundwaterPTreatmentEfficiency { get; set; }

        public double GroundwaterNMassLoadIn { get; set; }
        public double GroundwaterPMassLoadIn { get; set; }

        [Meta("TN Mass Load", "kg/yr", "##.##")]
        public double GroundwaterNMassLoadOut { get; set; }

        [Meta("TP Mass Load", "kg/yr", "##.##")]
        public double GroundwaterPMassLoadOut { get; set; }

        [Meta("TN Concentration", "mg/L", "##.##")]
        public double GroundwaterTNConcentration { get; set; }

        [Meta("TP Concentration", "mg/L", "##.##")]
        public double GroundwaterTPConcentration { get; set; }

        [Meta("Treatment Rate", "MG/yr", "##.##")]
        public double RechargeRate { get; set; }

        // True of all BMP's
        // Mass loading from Catchment
        [Meta("Nitrogen Mass Loading into BMP", "kg/yr", "##.##")]
        public double BMPNMassLoadIn { get; set; }

        [Meta("Phosphorus Mass Loading into BMP", "kg/yr", "##.##")]
        public double BMPPMassLoadIn { get; set; }

        // Mass Load out to Surface Water unts
        [Meta("Nitrogen Mass Loading out of BMP", "kg/yr", "##.##")]
        public double BMPNMassLoadOut { get; set; }

        [Meta("Phosphorus Mass Loading out of BMP", "kg/yr", "##.##")]
        public double BMPPMassLoadOut { get; set; }

        [Meta("Nitrogen mass reduction", "lb/yr", "##.##")]
        public double NMassReductionLb { get; set; }

        [Meta("Phosphorus mass reduction", "lb/yr", "##.##")]
        public double PMassReductionLb { get; set; }

        // Volume into the BMP
        [Meta("Volume into BMP", "ac-ft", "##.##")]
        public double BMPVolumeIn { get; set; }

        [Meta("Volume out of BMP", "ac-ft", "##.##")]
        public double BMPVolumeOut { get; set; }

        public double GWVolumeIn { get; set; }
        public double GWVolumeOut { get; set; }

        public double NRetained { get; set; }
        public double PRetained { get; set; }

        // Cost Variables

        [Meta("Cost of Land Needed for BMP", "$", "##.##")]
        public double LandCost { get; set; }            // input: Cost of Land Needed for the BMP - $
        public double UnitCost { get; set; }

        [Meta("Fixed Cost of BMP", "$", "##.##")]
        public double FixedCost { get; set; }   // input: BMP FIxed Cost $

        [Meta("Expected Life of BMP", "years", "##.##")]
        public double ExpectedLife { get; set; }        // input: yr

        [Meta("BMP Cost Per Acre-Foot", "$", "##.##")]
        public double CostPerAcreFoot { get; set; }     // input: BMP Cost per ac-ft

        [Meta("Construction Cost of BMP", "$", "##.##")]
        public double BMPCost { get; set; }             // Calculated: TreatmentVolume * CostPerAcreFoot + Fixed Cost

        [Meta("Harvested or Supplemental Water", "1000 gal/yr", "##.##")]
        public double HarvestedWater { get; set; }      // input: Harvested or Supplemental Water 1000 gal /yr

        [Meta("Annual BMP Maintenance Cost", "$/yr", "##.##")]
        public double MaintenanceCost { get; set; }     // input: Annual BMP Maintenance Cost $/yr

        [Meta("Present Value of Maintenance Cost", "$/yr", "##.##")]
        public double PVofMaintenanceCost { get; set; }
        public double PVOfAnnualCost { get; set; }

        [Meta("Annual Cost Recovery", "$/yr", "##.##")]
        public double AnnualCostRecovery { get; set; }      // Caclulated: $/yr Harvested Water * Water Cost

        [Meta("Total Annual Cost", "$", "##.##")]
        public double TotalAnnualCost { get; set; }         // Calculated: Annual Cost recovery + Maintenance Cost

        [Meta("Future Replacement Cost", "$", "##.##")]
        public double FutureReplacementCost { get; set; }   // input: $

        [Meta("Present Value of Replacement", "$", "##.##")]
        public double PresentValueOfReplacement { get; set; }   // Calculated: Present Value of Replacement Cost

        [Meta("Present Value/Life Cycle Cost", "$", "##.##")]
        public double PresentWorth { get; set; }                // Calculated: BMP Cost + Land Cost + Present Value - PV of Total Annual Cost
        public double CostPerPoundNRemoved { get; set; }
        public double CostPerPoundPRemoved { get; set; }


        // Retention or Detention Systems
        public static string sRetention = "Retention";
        public static string sDetention = "Detention";
        public string RetentionOrDetention { get; set; }

        // Supplied Additional Media
        public double MediaVolume { get; set; }

        
        private string mediaMixType;

        [Meta("Type of Media Mix", "", "##.##")]
        public string MediaMixType
        {
            get { return mediaMixType.Replace('_', '&'); }
            set { mediaMixType = value; }
        }

        [Meta("Media N Reduction", "%", "##.##")]
        public double MediaNPercentReduction { get; set; }

        [Meta("Media P Reduction", "%", "##.##")]
        public double MediaPPercentReduction { get; set; }

        public double PostMediaNTreatmentEfficiency { get; set; }
        public double PostMediaPTreatmentEfficiency { get; set; }

        public double TNEMC { get; set; }
        public double TPEMC { get; set; }

        // Can use if meta properties are defined (Follow Meta Print for Details)
        public string Print(string property_name)
        {
            return InterfaceCommon.PrintProperty(this, property_name);
        }
        #endregion

        #region "Contructors"
        public BMP(Catchment c)
        {
            SetValuesFromCatchment(c);
            ReportType = sAllProperties;
            DoGroundwaterAnalysis = "Yes";
            MediaMixType = MediaMix.NotSpecified;
            AnalysisType = c.AnalysisType;
            CatchmentID = c.id;
            CatchmentName = c.CatchmentName;
            if ((HelpURL == "") || (HelpURL == null)) HelpURL = Globals.HelpURL;
            GroundwaterNTreatmentEfficiency = 0;
            GroundwaterPTreatmentEfficiency = 0;
            TNEMC = c.PostNConcentration;
            TPEMC = c.PostPConcentration;
        }

        public bool hasMediaMix()
        {
            if (MediaMixType == BMPTrainsProject.sNone) return false;
            if (MediaMixType == "") return false;
            if (MediaMixType == null) return false;

            return true;
        }
        #endregion

        #region "Reporting Tools"

        // Useful for a report which is simply a list of variables not divided into sections
        public string MetaReport(string[] vars, string title = "", Boolean showHeader = true)
        {
            string s = "";
            if (showHeader) {
                s += ReportHeader();
            }
                s += InterfaceCommon.PrintPropertySection(this, vars, title);
            
            return s;
        }
        
        public string ReportHeader()
        {
            string s = "";
            s += "<b>Project:</b> " + Globals.Project.ProjectName + "<br/>";
            s += "<b>Date:</b> " + DateTime.Now.ToString("d") + "<br/><br/>";
            s += "<b>" + BMPTypeTitle() + " Design</b><br/>";
            return s;
        }

        // This uses a Dictionary where the key is the section title like "Watershed Properties"
        // and the dictionary item is the list of properties that go into that section. 

        public string MetaReport(Dictionary<string, string[]> d)
        {
            string s = ReportHeader();
            foreach (KeyValuePair<string, string[]> kvp in d)
            {
                InterfaceCommon.PrintPropertySection(this, kvp.Value, kvp.Key);
            }
            return s;
        }


        public virtual string BMPReport()
        {
            string s = "<b>Project:</b> " + Globals.Project.ProjectName + "<br/>";
            s += "<b>Date:</b> " + DateTime.Now.ToString("d") + "<br/><br/>";
            s += "<b>" + BMPTypeTitle() + " Design</b><br/>";
            s += BMPInputVariables();
            s += WatershedCharacteristics();
            s += SurfaceWaterAnalysis();
            if ((DoGroundwaterAnalysis == "Yes")||(MediaMixType != MediaMix.None)) s += GroundwaterAnalysis();
            s += LoadDiagram();
            return s;
        }
        public virtual string BMPInputVariables()
        {
            string s = "";
            return s;
        }

        public string WatershedCharacteristics()
        {
            string s = "<br/><b>Watershed Characteristics</b><br/>";
            s += AsHtmlTable(
                new Dictionary<string, string>
            {
                {"WatershedArea", "Catchment Area (acres)"},
                {"ContributingArea","Contributing Area (acres)" },
                {"WatershedNDCIACurveNumber", "Non-DCIA Curve Number"},
                {"WatershedDCIAPercent", "DCIA Percent"},
                {"RainfallZone", "Rainfall Zone"},
                {"Rainfall", "Rainfall (in)" },
            });
            return s;
        }

        public string SurfaceWaterAnalysis()
        {
            if (ProvidedNTreatmentEfficiency >= 100) ProvidedNTreatmentEfficiency = 99;
            if (ProvidedPTreatmentEfficiency >= 100) ProvidedPTreatmentEfficiency = 99;

            string s = "<br/><b>Surface Water Discharge</b><br/>";
            s += AsHtmlTable(
                new Dictionary<string, string>
            {
                {"RequiredNTreatmentEfficiency", "Required TN Treatment Efficiency (%)"},
                {"ProvidedNTreatmentEfficiency", "Provided TN Treatment Efficiency (%)"},
                {"RequiredPTreatmentEfficiency", "Required TP Treatment Efficiency (%)"},
                {"ProvidedPTreatmentEfficiency", "Provided TP Treatment Efficiency (%)"},
            });
            s += "<br/>";

            return s;
        }

        public virtual string GroundwaterAnalysis()
        {
            if (BMPType == BMPTrainsProject.sMultipleBMP) return "";
            string s = "<br/>";
            if ((MediaMixType != MediaMix.None) ||((MediaMixType != MediaMix.NotSpecified))) { 
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
                {"GroundwaterNMassLoadOut", "TN Mass Load (kg/yr)"},
                {"GroundwaterTNConcentration", "TN Concentration (mg/L)"},
                {"GroundwaterPMassLoadOut", "TP Mass Load (kg/yr)"},
                {"GroundwaterTPConcentration", "TP Concentration (mg/L)"},
                });
            s += "<br/>";

            return s;
        }

        public string LoadDiagram()
        {
            string s = EfficiencyReport();
            return s;
        }


        public override Dictionary<string, string> PropertyLabels()
        {
            var current = new Dictionary<string, string>
            {
                {"BMPType", "Type of Best Management Practice"},
                {"BMPName", "BMP Name (use to organize BMP's)"},
                {"HelpURL","Help URL" },

                {"WatershedArea", "Watershed Area (acres)"},
                {"ContributingArea","Contributing Area to BMP (ac)" },
                {"WatershedNDCIACurveNumber", "Watershed Non-DCIA Curve Number"},
                {"WatershedDCIAPercent", "Watershed DCIA Percent"},
                {"RainfallZone", "Rainfall Zone"},
                {"Rainfall", "Rainfall (in)" },
                {"RationalCoefficient", "Calculated Annual Coefficient (0-1)"},

                {"HydraulicCaptureEfficiency", "Hydraulic Capture Efficiency (%)"},
                {"RequiredNTreatmentEfficiency", "Required Nitrogen Treatment Efficiency (%)"},
                {"RequiredPTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},
                {"CalculatedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                {"CalculatedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"},
                {"RemainingNTreatmentEfficiency", "Remaining Nitrogen Treatment Efficiency (%)"},
                {"RemainingPTreatmentEfficiency", "Remaining Phosphorus Treatment Efficiency (%)"},

                {"BMPNMassLoadIn","Nitrogen Mass Loading into BMP (kg/yr)" },
                {"BMPPMassLoadIn","Phosphorus Mass Loading into BMP (kg/yr)" },
                {"BMPNMassLoadOut","Nitrogen Mass Loading out of BMP (kg/yr)" },
                {"BMPPMassLoadOut","Phosphorus Mass Loading out of BMP (kg/yr)" },
                {"NMassReduction","Nitrogen mass reduction (kg/yr)" },
                {"PMassReduction","Phosphorus mass reduction (kg/yr)" },
                {"NMassReductionLb","Nitrogen mass reduction (lb/yr)" },
                {"PMassReductionLb","Phosphorus mass reduction (lb/yr)" },

                {"VolumeIn","Volume into BMP (ac-ft)" },
                {"VolumeOut","Volume out of BMP (ac-ft)" }

            };
            return current;            
        }

        public virtual Dictionary<string, string> BasicReportLabels()
        {
            return new Dictionary<string, string>
            {
                {"BMPType", "Type of Best Management Practice"},
                {"BMPName", "BMP Name (use to organize BMP's)"}
            };
        }
       
        public virtual Dictionary<string, string> MultipleBMPLabels()
        {
            return new Dictionary<string, string>
            {
                {"BMPType", "Type of BMP"},
                {"CalculatedNTreatmentEfficiency", "Provided Nitrogen Efficiency (%)"},
                {"CalculatedPTreatmentEfficiency", "Provided Phosphorus Efficiency (%)"}
            };
        }

        public Dictionary<string, string> WatershedLabels()
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>
            {
                {"WatershedLabels01", "<b>Watershed Characteristics</b>" },
                {"WatershedArea", "Catchment Area (acres)"},
                {"WatershedNDCIACurveNumber", "Watershed Non-DCIA Curve Number"},
                {"WatershedDCIAPercent", "Watershed DCIA Percent"},
                {"RainfallZone", "Rainfall Zone"}
//                {"RationalCoefficient", "Calculated Annual Coefficient (0-1)"}
            };
            return d1;
        }

        public Dictionary<string, string> EfficiencyLabels()
        {

            var current = new Dictionary<string, string>
            {
                {"EfficiencyLabels01", "<b>Efficiency Values</b>"  },
                {"RequiredNTreatmentEfficiency", "Required Nitrogen Treatment Efficiency (%)"},
                {"RequiredPTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},
                {"CalculatedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                {"CalculatedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"},
                {"RemainingNTreatmentEfficiency", "Remaining Nitrogen Treatment Efficiency (%)"},
                {"RemainingPTreatmentEfficiency", "Remaining Phosphorus Treatment Efficiency (%)"}
            };

            return current;
        }

        public Dictionary<string, string> CostLabels()
        {
            var current = new Dictionary<string, string>
            {
                {"CostLabels01", "<b>BMP Cost Information</b>"  },
                {"BMPType", "Type of BMP"},
                {"CatchmentName", "Name of Catchment"},
                {"RetentionVolume", "Treatment Volume (ac-ft)"},
                {"LandCost", "Cost of Land Needed for BMP ($)"},
                {"FixedCost", "Fixed Cost of BMP ($)"},
                {"ExpectedLife", "Expected Life of BMP (years)"},
                {"CostPerAcreFoot", "BMP Cost Per Acre-Foot ($)"},
                {"BMPCost", "Construction Cost of BMP ($)"},
                {"HarvestedWater", "Harvested or Supplemental Water (1000 gal/yr)"},
                {"MaintenanceCost", "Annual BMP Maintenance Cost ($/yr)"},
                {"PVofMaintenanceCost", "Present Value of Maintenance Cost ($/yr)"},
                {"AnnualCostRecovery", "Annual Cost Recovery ($/yr)"},
                {"TotalAnnualCost", "Total Annual Cost ($)"},
                {"FutureReplacementCost", "Future Replacement Cost ($)"},
                {"PresentValueOfReplacement", "Present Value of Replacement ($)"},
                {"PresentWorth", "Present Value/Life Cycle Cost ($)"}
                //{"CostPerPoundNRemoved", "Cost of Nitrogen Removal ($/lb-Nitrogen)"},
                //{"CostPerPoundPRemoved", "Cost of Phosphorus Removal ($/lb-Phosphorus)"}

            };
            return current;
        }

        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            var current = new Dictionary<string, int>
            {
                {"WatershedArea", 2},
                {"WatershedNDCIACurveNumber", 2},
                {"WatershedDCIAPercent", 2},
                {"Rainfall", 2},
                {"RationalCoefficient", 2},
                {"BMPNMassLoadIn", 2},
                {"BMPPMassLoadIn", 2},
                {"HydraulicCaptureEfficiency", 0 },
                {"RequiredNTreatmentEfficiency", 0},
                {"RequiredPTreatmentEfficiency", 0},
                {"CalculatedNTreatmentEfficiency", 0},
                {"CalculatedPTreatmentEfficiency", 0},
                {"ProvidedNTreatmentEfficiency", 0},
                {"ProvidedPTreatmentEfficiency", 0},
                {"RemainingNTreatmentEfficiency", 0},
                {"RemainingPTreatmentEfficiency", 0},
                {"LandCost", -2},
                {"FixedCost", -2},
                {"ExpectedLife", 0},
                {"CostPerAcreFoot", -2},
                {"BMPCost", -2},
                {"HarvestedWater", 0},
                {"MaintenanceCost", -2},
                {"PVofMaintenanceCost", -2 },
                {"AnnualCostRecovery", -2},
                {"TotalAnnualCost", -2},
                {"FutureReplacementCost", -2},
                {"PresentValueOfReplacement", -2},
                {"PresentWorth", -2}
            };
            return current;
        }

        public virtual string BasicReport()
        {
            string s = ""; // "<div style='float:right;font-size:70%;'>" + Globals.Project.Version() + "</div>";
            s += AsHtmlTable(BasicReportLabels());

            s += EfficiencyReport();
            return s;
        }

        public string CostReport()
        {
            CalculateCost();
            string s = "";
            s += Globals.Project.CostReport();
            s += "<br/>";
            s += AsHtmlTable(CostLabels());
            if (TotalAnnualCost < 0) s += "Note: Total Annual Cost is a net positive revenue stream<br/>";
            return s;
        }
        public string MultipleBMPReport()
        {
            string s = "<br/>";
            //s += AsHtmlTable(HeaderLabels());
            s += AsHtmlTable(MultipleBMPLabels());
            return s;
        }

        public  virtual Dictionary<string, string> HeaderLabels()
        {
            return new Dictionary<string, string>
            {
                {"BMPType", "Type of Best Management Practice"},
                {"BMPName", "BMP Name (use to organize BMP's)"}
            };
        }

        public virtual string getReport()
        {
            string s = "<br/>";// "<h1>" + ReportType + "</h1>";
            switch (ReportType)
            {
                case sAllProperties: return s + AsHtmlTable();
                case sBasicReport: return s + BasicReport();
                default: return s + AsHtmlTable(); 
            }
        }

        public string getNextReport()
        {
            switch (ReportType)
            {
                case sAllProperties: ReportType = sBasicReport; break;
                case sBasicReport: ReportType = sAllProperties; break;
                default: return AsHtmlTable();
            }
            return getReport();
        }

        public Dictionary<string, string> ReportHeader(string bmpType)
        {
            return new Dictionary<string, string>{
                {"ReportHeader01", "<h2>" + bmpType + " System Characteristics</h2"},
                {"Reportheader02", "Date: " + DateTime.Now.ToString("d") },
                {"AnalysisType", "Type of Analysis" }
            };
        }

        public bool TargetMet(double actual, double target, int places)
        {
            if (Math.Round(actual, places) >= Math.Round(target, places)) return true;
            return false;
        }

        #endregion

        #region "Get Values from Project and Catchment"
        public BMP setCatchmentId(int id)
        {
            this.id = id;
            return this;
        }

        public void SetValuesFromCatchment(Catchment c)
        {
            // Contribuing Area is calculated in classes that inherit from Storage
            
            this.CatchmentID = c.id;

            this.CatchmentName = c.CatchmentName;
            this.ContributingArea = c.PostArea - c.BMPArea;

            this.Rainfall = c.Rainfall;
            this.RainfallZone = c.RainfallZone;
            this.RationalCoefficient = c.PostRationalCoefficient;
            this.WatershedArea = c.PostArea;          
            this.WatershedNDCIACurveNumber = c.PostNonDCIACurveNumber;
            this.WatershedDCIAPercent = c.PostDCIAPercent;
            this.RationalCoefficient = c.PostRationalCoefficient;
            this.RequiredNTreatmentEfficiency = c.RequiredNTreatmentEfficiency;
            this.RequiredPTreatmentEfficiency = c.RequiredPTreatmentEfficiency;
            this.DoGroundwaterAnalysis = c.DoGroundwaterAnalysis;

            this.BMPNMassLoadIn = c.PostNLoading;
            this.BMPPMassLoadIn = c.PostPLoading;

            this.RunoffVolume = c.PostRunoffVolume;
            this.BMPVolumeIn = c.PostRunoffVolume;
            this.AnalysisType = c.AnalysisType;
            this.TNEMC = c.PostNConcentration;
            this.TPEMC = c.PostPConcentration;

        }

        public void SetValuesFromProject(BMPTrainsProject p, Catchment c)
        {
            // Watershed Area is calculated in classes that inherit from Storage
            SetValuesFromCatchment(c);

            this.RequiredNTreatmentEfficiency = p.RequiredNTreatmentEfficiency;
            this.RequiredPTreatmentEfficiency = p.RequiredPTreatmentEfficiency;
            this.AnalysisType = p.AnalysisType;
        }
        #endregion

        #region "Caclulation Routines - Calcs Common to all BMPs"

        public virtual bool isRetention()
        {
            return false;
        }

        public virtual bool isDefined()
        {
            return false;            
        }

        public void Calculate()
        {
            CaclulateRemainingEfficiency();

            CalculateMassLoading();
        }

        public void CalculateDelayEfficiency()
        {
            DelayEfficiency = CalculateDelayEfficiency(DelayTime);
        }

        public static double CalculateDelayEfficiency(double dt)
        {
            // Calculates Efficiency baed on Delay
            double DelayFactor = 0;
            if ((dt >= 0))
            {
                switch (Globals.Project.RainfallZone)
                {
                    case StaticLookupTables.FlZone1: DelayFactor = 0.264; break;
                    case StaticLookupTables.FlZone2: DelayFactor = 0.337; break;
                    case StaticLookupTables.FlZone3: DelayFactor = 0.350; break;
                    case StaticLookupTables.FlZone4: DelayFactor = 0.269; break;
                    case StaticLookupTables.FlZone5: DelayFactor = 0.229; break;
                    default: DelayFactor = 0; break;
                }
                return dt * DelayFactor;
            }
            return 0;
        }

        public virtual string BMPTypeTitle()
        {
            if (BMPType == BMPTrainsProject.sExfiltration) return "Surface Filter";
            return BMPType;
        }

        public void ResetCost()
        {
            // Multiple BMP is sum of BMP's
            LandCost = 0.0;
            FixedCost = 0.0;
            BMPCost = 0.0;
            AnnualCostRecovery = 0.0;
            MaintenanceCost = 0.0;
            TotalAnnualCost = 0.0;
            PresentValueOfReplacement = 0.0;
            PresentWorth = 0.0;
        }

        public virtual void CalculateCost()
        {
            CalculateCost(Globals.Project.InterestRate, Globals.Project.ProjectDuration, Globals.Project.CostOfWater);
        }

        public virtual void CalculateCost(double interestRate, double projectDuration, double costOfWater)
        {
            BMPCost = LandCost + FixedCost + RetentionVolume * CostPerAcreFoot;
            AnnualCostRecovery = HarvestedWater * costOfWater;
            TotalAnnualCost =   MaintenanceCost - AnnualCostRecovery;

            PresentValueOfReplacement = Common.PresentValueofFutureCost(FutureReplacementCost, interestRate, ExpectedLife, projectDuration);
            PVofMaintenanceCost = Common.PresentValueofAnnualCost(MaintenanceCost, interestRate, projectDuration);
            PVOfAnnualCost = Common.PresentValueofAnnualCost(TotalAnnualCost, interestRate, projectDuration);
            PresentWorth = BMPCost + PVOfAnnualCost;
            if (NMassReductionLb != 0 && Globals.Project.ProjectDuration != 0) CostPerPoundNRemoved = PresentWorth / (NMassReductionLb * Globals.Project.ProjectDuration);
            if (PMassReductionLb != 0 && Globals.Project.ProjectDuration != 0) CostPerPoundPRemoved = PresentWorth / (PMassReductionLb * Globals.Project.ProjectDuration);
        }

        public void AddCost(BMP bmp)
        {
            bmp.CalculateCost(Globals.Project.InterestRate, Globals.Project.ProjectDuration, Globals.Project.CostOfWater);

            LandCost += bmp.LandCost;
            FixedCost += bmp.FixedCost;
            BMPCost += bmp.BMPCost;
            AnnualCostRecovery += bmp.AnnualCostRecovery;
            MaintenanceCost += bmp.MaintenanceCost;
            TotalAnnualCost += bmp.TotalAnnualCost;
            PresentValueOfReplacement += bmp.PresentValueOfReplacement;
            PresentWorth += bmp.PresentWorth;
        }


        public void CaclulateRemainingEfficiency()
        {
            // Generic algorithm - based on treatment efficiency provided and required, calculates additional treatment required.

            if (ProvidedNTreatmentEfficiency < RequiredNTreatmentEfficiency)
            {
                RemainingNTreatmentEfficiency = 100 * (RequiredNTreatmentEfficiency - ProvidedNTreatmentEfficiency) / (100 - ProvidedNTreatmentEfficiency);
            }
            else
            {               
                RemainingNTreatmentEfficiency = 0;
            }

            if (ProvidedPTreatmentEfficiency < RequiredPTreatmentEfficiency)
            {
                RemainingPTreatmentEfficiency = 100 * (RequiredPTreatmentEfficiency - ProvidedPTreatmentEfficiency) / (100 - ProvidedPTreatmentEfficiency);
            }
            else
            {                
                RemainingPTreatmentEfficiency = 0;
            }

            if (RemainingNTreatmentEfficiency < 0) RemainingNTreatmentEfficiency = 0.0;
            if (RemainingPTreatmentEfficiency < 0) RemainingPTreatmentEfficiency = 0.0;
        }

        public void CalculateMassLoading(bool recalcMassLoad = false)
        {
            if (recalcMassLoad) { 
                BMPNMassLoadOut = BMPNMassLoadIn * (100 - ProvidedNTreatmentEfficiency) / 100;
                BMPPMassLoadOut = BMPPMassLoadIn * (100 - ProvidedPTreatmentEfficiency) / 100;
            }

            GroundwaterNMassLoadIn = BMPNMassLoadIn - BMPNMassLoadOut;
            GroundwaterPMassLoadIn = BMPPMassLoadIn - BMPPMassLoadOut;

            NMassReductionLb = GroundwaterNMassLoadIn * 2.205;
            PMassReductionLb = GroundwaterPMassLoadIn * 2.205;

            if (DoGroundwaterAnalysis == "Yes")
            {
                NRetained = BMPNMassLoadIn - BMPNMassLoadOut - GroundwaterNMassLoadOut;
                PRetained = BMPPMassLoadIn - BMPPMassLoadOut - GroundwaterPMassLoadOut;
            }
            else
            {
                NRetained = BMPNMassLoadIn - BMPNMassLoadOut;
                PRetained = BMPPMassLoadIn - BMPPMassLoadOut;

            }
            if (RetentionOrDetention == "Detention")
            {
                NRetained = BMPNMassLoadIn - BMPNMassLoadOut;
                PRetained = BMPPMassLoadIn - BMPPMassLoadOut;
            }
        }

        public virtual void CalculateGroundwaterDischarge()
        {
            // If No treatment - GW discharge is all of the reduction
            GroundwaterNMassLoadOut = GroundwaterNMassLoadIn;
            GroundwaterPMassLoadOut = GroundwaterPMassLoadIn;
        }

        public virtual double GroundwaterNLoading()
        {
            if (!isRetention()) return 0;
            return BMPNMassLoadIn - BMPNMassLoadOut;
        }
        public virtual double GroundwaterPLoading()
        {
            if (!isRetention()) return 0;
            return BMPPMassLoadIn - BMPPMassLoadOut;
        }

        public virtual double GroundwaterNRemovalEfficiency()
        {
            return GroundwaterNTreatmentEfficiency;
        }
        public virtual double GroundwaterPRemovalEfficiency()
        {
            return GroundwaterPTreatmentEfficiency;
        }
        public virtual double GroundwaterNRemoval()
        {
            return GroundwaterNLoading() * GroundwaterNTreatmentEfficiency / 100;
        }
        public virtual double GroundwaterPRemoval()
        {
            return GroundwaterPLoading() * GroundwaterPTreatmentEfficiency / 100;
        }


        #endregion

        #region "Load Report"
        public virtual string EfficiencyReport()
        {
            string s = "<br/><h2>Load Diagram for " + BMPTypeTitle() + " (stand-alone)</h2><br/><table>";
            s += "<tr>";         // 5 Cells per row

            double R = RunoffVolume;
            if (HydraulicCaptureEfficiency == 0) HydraulicCaptureEfficiency = ProvidedPTreatmentEfficiency;
            // Create row for load balance report, 3 columns in the row
            //if (this.RetentionOrDetention == BMP.sDetention)
            //{
            //    s += EfficiencyReportCell(BMPNMassLoadIn, BMPPMassLoadIn, 2, "kg/yr", "Load");
            //    s += EfficiencyReportCell("&rarr;");
            //    s += EfficiencyReportCell(ProvidedNTreatmentEfficiency, ProvidedPTreatmentEfficiency, 0, "%", "Treatment", 1);
            //    s += EfficiencyReportCell("&rarr;");
            //}
            //else 
            //{ 
                s += EfficiencyReportCell(BMPNMassLoadIn, BMPPMassLoadIn, R, 2, "kg/yr", "kg/yr", "ac-ft/yr", "Load");
                s += EfficiencyReportCell("&rarr;");
                s += EfficiencyReportCell(ProvidedNTreatmentEfficiency, ProvidedPTreatmentEfficiency,  0, "%", "Treatment", 1);
                s += EfficiencyReportCell("&rarr;");
            //}


            BMPNMassLoadOut = BMPNMassLoadIn * (100 - ProvidedNTreatmentEfficiency) / 100.0;
            BMPPMassLoadOut = BMPPMassLoadIn * (100 - ProvidedPTreatmentEfficiency) / 100.0;

            if (this.BMPType == BMPTrainsProject.sWetDetention)
            {
                s += EfficiencyReportCell(BMPNMassLoadOut, BMPPMassLoadOut, 2, "kg/yr", "Surface Discharge");
                s += "</tr>";
            }
            else
            {
                s += EfficiencyReportCell(BMPNMassLoadOut, BMPPMassLoadOut, ((100 - HydraulicCaptureEfficiency) / 100) * R, 2, "kg/yr", "kg/yr", "ac-ft/yr", "Surface Discharge");
                s += "</tr>";
            }


            GroundwaterNMassLoadIn = BMPNMassLoadIn * ProvidedNTreatmentEfficiency / 100.0;
            GroundwaterPMassLoadIn = BMPPMassLoadIn * ProvidedPTreatmentEfficiency / 100.0;

            NRetained = BMPNMassLoadIn - BMPNMassLoadOut - GroundwaterNMassLoadOut;
            PRetained = BMPPMassLoadIn - BMPPMassLoadOut - GroundwaterPMassLoadOut;


            // Creates second in mass balance report - only Mass reduction in this row
            s += "<tr><td></td><td></td>";
            s += EfficiencyReportCell("&darr;");
            s += "<td></td>";
            if (this.BMPType == BMPTrainsProject.sWetDetention)
            {
                s += EfficiencyReportCell(GroundwaterNMassLoadIn, GroundwaterPMassLoadIn, 2, "kg/yr", "Mass Reduction");
            }
            else
            {
                s += EfficiencyReportCell(GroundwaterNMassLoadIn, GroundwaterPMassLoadIn, HydraulicCaptureEfficiency * R / 100, 2, "kg/yr", "kg/yr", "ac-ft/yr", "Mass Reduction");
            }
            s += "</tr>";

            if (BMPType == BMPTrainsProject.sFiltration)
            {
                s += "</table>";
                return s;
            }

            if (BMPType == BMPTrainsProject.sVegetatedFilterStrip)
            {
                s += "</table>";
                return s;
            }

            if ((Globals.Project.DoGroundwaterAnalysis == "Yes") && (isRetention()))
            {
                string tTitle = (BMPType == BMPTrainsProject.sVegetatedFilterStrip ? "Media Treatment" : "GW Treatment");
                string dTitle = (BMPType == BMPTrainsProject.sVegetatedFilterStrip ? "Ditch Discharge" : "GW Discharge");

                s += "<tr>";
                s += EfficiencyReportCell(GroundwaterNMassLoadIn, GroundwaterPMassLoadIn, 3, "kg/yr", "Into Media");
                s += "<td></td>";
                s += EfficiencyReportCell(MediaNPercentReduction, MediaPPercentReduction, 0, "%", tTitle, 1);
                s += EfficiencyReportCell("&rarr;");
                s += EfficiencyReportCell(GroundwaterNMassLoadOut, GroundwaterPMassLoadOut, 3, "kg/yr", dTitle);
                s += "</tr>";

                s += "<tr><td></td><td></td>";
                s += EfficiencyReportCell("&darr;");
                s += "<td></td><td></td>";
                s += "</tr>";

                s += "<tr><td></td><td></td>";
                s += EfficiencyReportCell(NRetained, PRetained, 2, "kg/yr", "Retained");
                s += "<td></td><td></td>";
                s += "</tr>";
            }
           
            s += "</table>";
            return s;
        }
        public string EfficiencyReportCell(string s)
        {
            return "<td style='text-align:center; font-size: 150%'>" + s + "</td>";
        }

        public string EfficiencyReportCell(double val1, double val2, int places = 2, string units = "", string label = "", int border = 0)
        {
            string td = "<td style='padding: 10px'>";
            if (border != 0) td = "<td style='border: 2px solid black; padding: 10px'>";
            return td + label + "<br/> N: " + GetValue(val1, places) + " " + units + "<br/> P: " + GetValue(val2, places) + " " + units + "</td>";
        }

        public string EfficiencyReportCell(double val1, double val2, double val3, int places = 2, string units1 = "", string units2 = "", string units3 = "", string label = "", int border = 0)
        {
            string s = "";
            string td = "<td style='padding: 10px'>";
            if (border != 0) td = "<td style='border: 2px solid black; padding: 10px'>";
            s = td + label + "<br/> N: " + GetValue(val1, places) + " " + units1;
            s += "<br/> P: " + GetValue(val2, places) + " " + units2;
            s += "<br/> Q: " + GetValue(val3, places) + " " + units3 + "</td>";

            return s;
        }

        #endregion

        #region "Plotting routines"
        public virtual double[] plotX()
        {
            return new double[plotN];
        }

        public virtual double[] plotY()
        {
            return new double[plotN];
        }

        public virtual double[] plotY(double d, string s)
        {
            return new double[plotN];
        }

        public virtual double[] plotY(string s)
        {
            return new double[plotN];
        }

        public virtual string LegendTitle()
        {
            return BMPName + " " + BMPTypeTitle();
        }

        public virtual string XAxisTitle()
        {
            return "X Axis";
        }
        public virtual string YAxisTitle()
        {
            return "Y Axis";
        }

        public virtual double XAxisMinimum()
        {
            return 0.0;
        }

        public virtual double XAxisMaximum()
        {
            return 4.0;
        }
        public virtual double YAxisMinimum()
        {
            return 0.0;
        }

        public virtual double YAxisMaximum()
        {
            return 100.0;
        }

        public virtual string PlotTitle()
        {
            return "Type: " + BMPType + "\n" + "Name: " + BMPName;
        }
        #endregion
    }
}
