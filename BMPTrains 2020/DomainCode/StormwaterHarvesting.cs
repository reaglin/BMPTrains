using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class StormwaterHarvesting : Harvesting
    {
        #region "Properties"
        public static string SessionId = "StormwaterHarvestingId";
        public const double maxHarvestTreatmentEfficiency = 90;

        // Properties inherited from Harvesting

        public double RationalCforCAreaAt3inches { get; set; }

        #endregion

        public StormwaterHarvesting(Catchment c) : base(c) {
            BMPType = BMPTrainsProject.sStormwaterHarvesting;
        }

        public override Dictionary<string, string> BasicReportLabels()
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>
            {
                {"label0", "<b>Stormwater Harvesting</b>" },
                {"RainfallZone", "Rainfall Zone"},
                {"ContributingArea", "<u>Contributing Area to Harvesting (acres)</u>"},
                {"IrrigationArea", "<u>Total Area Available for Irrigation (acres)</u>"},
                {"SolveForChoice", "Solve For:" },
                {"HarvestVolume", "<u>Available Harvest Volume (gallons)</u>"},
                { "AvailableHarvestRate", "<u>Available Harvest Rate (0.1-4.0 in/week over EIA)</u>" },
                { "RationalCforCAreaAt3inches", "<u>Weighted Annual Coefficient</u>" },
                { "label1", "<br/>" },
                {"EquivalentImperviousArea", "Equivalent Impervious Area (acres)"},
                {"HarvestVolumeOverEIA", "Harvest Volume (in over EIA)"}
            };

            Dictionary<string, string> d2 = new Dictionary<string, string>
            {
                {"1", "<br/>Determination on Harvest Efficiency<br/>" },
                {"HarvestRate", "Harvest Rate (cf/day)"},
                {"HarvestRateOverEIA", "Harvest Rate (in/day over EIA)"},
                {"CalculatedHarvestEfficiency", "Harvest Efficiency (%)"}
            };

            Dictionary<string, string> d3 = new Dictionary<string, string>
            {
                {"2", "<br/>Determination on Harvest Rate<br/>" },
                {"HarvestEfficiency", "Harvest Efficiency (%)" },
                {"HarvestRateOverEIA", "Harvest Rate (in/day over EIA)"},
                {"RequiredHarvestRateCFD", "Required Harvest Rate (cf/day)"},
                {"RequiredHarvestRateINWEEK", "Required Harvest Rate (in/week)" }
            };

            Dictionary<string, string> d4 = new Dictionary<string, string>
            {
                {"3", "<br/>Supplemental Water<br/>" },
                {"HarvestWaterDemand", "Average yearly demand for harvested water (MGY)"},
                {"HarvestWaterSupply", "Average potential supply for harvested water (MGY)"},
                {"SupplementalWater", "Average supplemental water needed per year (MGY)" }
            };

            if (SolveForChoice == sHarvestEfficiency) d1 = this.Add(d1, d2);
            if (SolveForChoice == sHarvestRate) d1 = this.Add(d1, d3);

            return this.Add(d1, d4);
        }
        public override string BMPInputVariables()
        {
            string s = "";
            if (SolveForChoice == sHarvestEfficiency) {
                s += AsHtmlTable(new Dictionary<string, string>
                {
                    {"ContributingArea", "Total Contributing Area to Harvesting (ac)"},
                    {"IrrigationArea", "Total Area Available for Irrigation (ac)"},
                    {"HarvestVolume", "Available Harvest Volume (ac-ft)"},
                    {"AvailableHarvestRate", " Harvest Rate (0.1-4.0 in/week)" }
                });
            }
            else
            {
                s += AsHtmlTable(new Dictionary<string, string>
                {
                    {"ContributingArea", "Total Contributing Area to Harvesting (ac)"},
                    {"IrrigationArea", "Total Area Available for Irrigation (ac)"},
                    {"HarvestVolume", "Available Harvest Volume (ac-ft)"},
                    {"HarvestEfficiency", "Harvest Efficiency (%)"}
                });

            }
            return s;
        }

        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            var current = new Dictionary<string, int>
                {
                {"HarvestRate", 0},
                {"HarvestEfficiency", 0 },
                {"CalculatedHarvestEfficiency", 0 }
                };

            return Add(current, base.PropertyDecimalPlaces());
        }

        public Dictionary<string, string> InputProperties()
        {
            var current = new Dictionary<string, string>
                {
                    {"ContributingArea", "Total Contributing Area to Harvesting (ac)"},
                    {"HarvestVolume", "Harvest Volume (in over EIA)"},
                    {"HarvestEfficiency", "Harvest Efficiency (%)"},
                };
            return current;
        }

        #region "Calculation Routines"
        public override bool isDefined()
        {
            if (HarvestRate > 0) return true;
            if (HarvestVolume > 0) return true;
            return false;
        }

        public override string BMPTypeTitle()
        {
            string s = "Stormwater Harvesting";
            return s;
        }

        public new void Calculate()
        {         
            RationalCforCAreaAt3inches = StaticLookupTables.MaxRationalC(Globals.Project.RainfallZone); // Not really at 3 inches
            EquivalentImperviousArea = ContributingArea * RationalCforCAreaAt3inches; // acres
            if (EquivalentImperviousArea == 0) return;

            HarvestVolumeOverEIA = 12 * HarvestVolume / EquivalentImperviousArea;   // Harvest Volume (ac-ft) - inches over EIA
           

            //if (SolveForChoice == sHarvestEfficiency)
            //{
                HarvestRate = (AvailableHarvestRate * IrrigationArea * 43560) / (7 * 12);     // CF/Day 
                HarvestRateOverEIA = 12.0 * HarvestRate / (EquivalentImperviousArea * 43560.0);
                CalculatedHarvestEfficiency = getEfficiencyLUT().CalculateRowValue(HarvestVolumeOverEIA, HarvestRateOverEIA);
                if (CalculatedHarvestEfficiency > maxHarvestTreatmentEfficiency) CalculatedHarvestEfficiency = maxHarvestTreatmentEfficiency;
                HarvestWaterDemand = AvailableHarvestRate * 52 * 0.325829 * IrrigationArea / 12.0 ;
                HarvestWaterSupply = CalculatedHarvestEfficiency * EquivalentImperviousArea *  Rainfall * 0.325829 / 1200;
                ProvidedNTreatmentEfficiency = CalculatedHarvestEfficiency;
                ProvidedPTreatmentEfficiency = CalculatedHarvestEfficiency;
            //}

            //if (SolveForChoice == sHarvestRate)
            //{
            //    ProvidedNTreatmentEfficiency = HarvestEfficiency;
            //    ProvidedPTreatmentEfficiency = HarvestEfficiency;
            //    HarvestRateOverEIA = getEfficiencyLUT().Calculate(HarvestEfficiency, HarvestVolumeOverEIA);
            //    RequiredHarvestRateCFD = HarvestRateOverEIA * EquivalentImperviousArea * 43560 / 12;
            //    RequiredHarvestRateINWEEK = RequiredHarvestRateCFD * 7 * 12 / ( IrrigationArea * 43560);                
            //    HarvestWaterDemand = RequiredHarvestRateINWEEK * 52 * 0.325829 * IrrigationArea / 12;
            //    HarvestWaterSupply = HarvestEfficiency * EquivalentImperviousArea * Rainfall * 0.325829 / 1200;
            //}

            if (HarvestWaterDemand > HarvestWaterSupply) SupplementalWater = HarvestWaterDemand - HarvestWaterSupply; else SupplementalWater = 0.0;

            base.Calculate();

            CalculateMassLoading();
        }
        #endregion

        public new void SetValuesFromCatchment(Catchment c)
        {
            this.ContributingArea = c.PostArea; // acres
            this.WatershedArea = c.PostArea - c.BMPArea;
            base.SetValuesFromCatchment(c);
        }

        public new void SetValuesFromProject(BMPTrainsProject p, Catchment c)
        {
            this.HarvestEfficiency = c.RequiredNTreatmentEfficiency;
            this.ContributingArea = c.PostArea; // acres
            this.WatershedArea = c.PostArea - c.BMPArea;
            base.SetValuesFromProject(p, c);
        }

        public new string AsHtmlTable()
        {
            string s = "<h1>Storwater Harvesting Efficiency Report</h1>";
            s += base.AsHtmlTable();
            return s;
        }

    }
}
