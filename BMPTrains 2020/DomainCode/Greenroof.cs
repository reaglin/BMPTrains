using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class Greenroof:Reuse
    {
        public static string SessionId = "GreenroofID";

        public string RainfallStation { get; set; }
        public double GreenroofArea { get; set; } // Surface Area in square feet
        //public double RetentionProvided { get; set; } // inches over greenroof area
        public double IrrigationDemand { get; set; }  // inches/year
        public double RainfallExcess { get; set; } // filtrate under drain flow
        public double AverageYearlyDemand { get; set; }
        public double AverageSupplyHarvested { get; set; }
        public double AverageSupplementalWater { get; set; }

        public Greenroof(Catchment c) : base(c) {
            BMPType = BMPTrainsProject.sGreenroof;
        }

        public override Dictionary<string, string> PropertyLabels()
        {
            var current = new Dictionary<string, string>
                {
                    {"RainfallStation", "<u>Selected Rainfall Station</u>" },
                    {"GreenroofArea", "<u>Greenroof Area (sf)</u>"},
                    {"RetentionDepth", "<u>Retention Provided (in over greenroof area)</u>"},
                   // {"IrrigationDemand", "<u>Irrigation Demand (inches/year)"},
                   // {"RainfallExcess", "<u>Rainfall Excess - filtrate (inches/year)"},
                    {"AverageYearlyDemand", "Average Yearly Demand for Harvested Water (MGY)"},
                    {"AverageSupplyHarvested", "Average Supply of Harvested Water per year (MGY)"},
                    {"AverageSupplementalWater", "Average Supplemental Water needed per year (MGY)"}
                };

            return Add(current, base.PropertyLabels());          
        }

        public override string BMPInputVariables()
        {
            string s = "";
            s += AsHtmlTable(
                new Dictionary<string, string>
            {
                {"RainfallStation", "Selected Rainfall Station" },
                {"GreenroofArea", "Greenroof Area (sf)"},
                {"RetentionDepth", "Retention Depth (in over greenroof area)"},
                {"IrrigationDemand", "Irrigation Demand (inches/year)"},
                {"RainfallExcess", "Rainfall Excess - filtrate underdrain flow (in/yr)"},
            });
            return s;
        }

        public override Dictionary<string, string> BasicReportLabels()
        {
            // This is a second of defined report type AllProperties, Basic
            return new Dictionary<string, string>
            {
                {"label0", "<b>Greenroof</b>" },
                {"RainfallStation", "<u>Selected Rainfall Station</u>" },
                {"GreenroofArea", "<u>Greenroof Area (sf)</u>"},
                {"RetentionDepth", "<u>Retention Depth (in over greenroof area)</u>"},
                {"RequiredNTreatmentEfficiency", "Required Nitrogen Treatment Efficiency (%)"},
                {"RequiredPTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},
                {"ProvidedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                {"ProvidedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"},
                {"IrrigationDemand", "<u>Irrigation Demand (inches/year)</u>"},
                {"RainfallExcess", "<u>Rainfall Excess - filtrate underdrain flow (in/yr)</u>"},
                {"AverageYearlyDemand", "Average Yearly Demand for Harvested Water (MGY)"},
                {"AverageSupplyHarvested", "Average Supply of Harvested Water per year (MGY)"},
                {"AverageSupplementalWater", "Average Supplemental Water needed per year (MGY)"}
            };
        }


        public new Dictionary<string, int> PropertyDecimalPlaces()
        {
            var current = new Dictionary<string, int>
                {
                    {"GreenroofArea", 2},
                    {"RetentionDepth", 2},
                };

            return Add(current, base.PropertyDecimalPlaces());
        }
       
        public new void Calculate()
        {
            if (RainfallStation == "") return;

            // Allows for Calculation, vars stored
            double[] vars = Greenroof.RainfallStations[RainfallStation];

            if (RetentionDepth == 0)
            {
                ProvidedNTreatmentEfficiency = vars[2];
                ProvidedPTreatmentEfficiency = vars[2];
            }
            else
            {
                ProvidedNTreatmentEfficiency = vars[0] * Math.Log(RetentionDepth) + vars[1];
                ProvidedPTreatmentEfficiency = vars[0] * Math.Log(RetentionDepth) + vars[1];
            }

            base.CaclulateRemainingEfficiency();

            AverageYearlyDemand = IrrigationDemand * 0.325829 * GreenroofArea / 43560 / 12;
            AverageSupplyHarvested = ProvidedNTreatmentEfficiency/100 * RainfallExcess * GreenroofArea * 0.325829 / 12 / 43560;

            if (AverageYearlyDemand < AverageSupplyHarvested ) { AverageSupplementalWater = 0.0;  }
            else { AverageSupplementalWater = AverageYearlyDemand - AverageSupplyHarvested; };

            CalculateMassLoading();
        }
    }
}
