using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class RainwaterHarvesting : Harvesting
    {
        public const double maxHarvestTreatmentEfficiency = 90;

        public string RoofType { get; set; }

        public new static readonly string[] InputVariables = {
            "ContributingAreaSF", "IrrigationArea", "HarvestVolume", "AvailableHarvestRate", "EquivalentImperviousArea",
            "HarvestVolumeOverEIA" };

        public override string PrintInputVariables()
        {
            return InterfaceCommon.PrintPropertyTable(this, InputVariables, "Rainwater Harvesting Input Variables", BMPTrainsReports.TableStyle1, "my-table");
        }

        public static Dictionary<string, double> RoofTypes() => new Dictionary<string, double>
            {
                {"ASPHALT, 0.2% SLOPE", 0.4175},
                {"ASPHALT, 2.0% SLOPE", 0.5942},
                {"CONCRETE, 0.2% SLOPE", 0.9531},
                {"CONCRETE, 2.0% SLOPE", 0.9457},
                {"SHINGLES, 25% SLOPE", 0.9587},
                {"SHINGLES, 5% SLOPE", 0.8371},
                {"SHINGLES, 50% SLOPE", 0.9544},
                {"TILE ROOF, 25% SLOPE", 0.9678},
                {"TILE ROOF, 5% SLOPE", 0.9627},
                {"TILE ROOF, 50% SLOPE", 0.9723}
            };

        public RainwaterHarvesting(Catchment c) : base(c) {
            BMPType = BMPTrainsProject.sRainwaterHarvesting;
        }

        public double RoofFactor() { try { return RoofTypes()[RoofType]; } catch { return 0.0; } }

        public override Dictionary<string, string> BasicReportLabels()
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>
                {
                    {"RainfallZone", "Rainfall Zone"},
                    {"ContributingArea", "<u>Roof Catchment Area Contributing Area to Harvesting (SF)</u>"},
                    {"IrrigationArea", "<u>Total Area Available for Irrigation (SF)</u>"},
                    {"RationalCoefficient", "Annual C (used to calculate water supply)" },
                    {"Rainfall", "Annual Rainfall (in)" },
                    {"RoofType", "Roof Type" },
                    {"SolveForChoice", "Solve For:" },
                    {"HarvestVolume", "<u>Available Harvest Volume (gallons)</u>"},
                    { "AvailableHarvestRate", "<u>Available Harvest Rate (0.1-4.0 in/week over EIA)</u>" },
                    {"0", "<br/>" },
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
            if (SolveForChoice == sHarvestRate) d1 =  this.Add(d1, d3);

            return this.Add(d1, d4);
        }

        public override string BMPInputVariables()
        {
            string s = "";
            s += AsHtmlTable(
                new Dictionary<string, string>
            {
                    {"ContributingAreaSF", "Roof Catchment Area Contributing Area to Harvesting (SF)"},
                    {"IrrigationArea", "Total Area Available for Irrigation (SF)"},
                    {"HarvestVolume", "Available Harvest Volume (gallons)"},
                    { "AvailableHarvestRate", "Available Harvest Rate (0.1-4.0 in/week over EIA)" },
                    {"EquivalentImperviousArea", "Equivalent Impervious Area (acres)"},
                    {"HarvestVolumeOverEIA", "Harvest Volume (in over EIA)"}
            });
            return s;
        }

        public new void SetValuesFromProject(BMPTrainsProject p, Catchment c)
        {
            // Do not update Contributing Area (use temp as done in base)
            double ca = ContributingArea;
            this.HarvestEfficiency = c.RequiredNTreatmentEfficiency;
            base.SetValuesFromProject(p, c);
            ContributingArea = ca;
        }

        public override bool isDefined()
        {
            if (HarvestVolume == 0) return false;
            return true;
        }

        public override string BMPTypeTitle()
        {
            string s = "Rainwater Harvesting";
            return s;
        }

        public new void Calculate()
        {
            ContributingAreaSF = ContributingArea * 43560.0;
            // Contributing Area is input by user in SF, Roof Factor dependent upon entry of Roof Type
            if (RoofType != "" && RoofType != null) EquivalentImperviousArea = ContributingArea * RoofFactor();

            // HarvestVolume in SF,
            if (EquivalentImperviousArea != 0) HarvestVolumeOverEIA = HarvestVolume / EquivalentImperviousArea * 12 / 325851 ;

            if (SolveForChoice == sHarvestEfficiency)
            {
                HarvestRate = AvailableHarvestRate * IrrigationArea / (7 * 12);     // CF/Day 
                HarvestRateOverEIA = 12.0 * HarvestRate / (EquivalentImperviousArea * 43560.0);
                CalculatedHarvestEfficiency = getEfficiencyLUT().CalculateRowValue(HarvestVolumeOverEIA, HarvestRateOverEIA);
                if (CalculatedHarvestEfficiency > maxHarvestTreatmentEfficiency) CalculatedHarvestEfficiency = maxHarvestTreatmentEfficiency;
                HarvestWaterDemand = AvailableHarvestRate * 52 * 0.325829 * IrrigationArea / (12 * 43560);
                if (CalculatedHarvestEfficiency < 0) CalculatedHarvestEfficiency = 0;
                ProvidedNTreatmentEfficiency = CalculatedHarvestEfficiency;
                ProvidedPTreatmentEfficiency = CalculatedHarvestEfficiency;
            }

            //if (SolveForChoice == sHarvestRate)
            //{                
            //    HarvestRateOverEIA = getEfficiencyLUT().Calculate(HarvestEfficiency, HarvestVolumeOverEIA);
            //    RequiredHarvestRateCFD = HarvestRateOverEIA * EquivalentImperviousArea * 43560 / 12;
            //    RequiredHarvestRateINWEEK = RequiredHarvestRateCFD * 7 * 12 / IrrigationArea;
            //    HarvestWaterDemand = RequiredHarvestRateINWEEK * 52 * 0.325829 * IrrigationArea / (12 * 43560);
            //}

            HarvestWaterSupply = EquivalentImperviousArea * RationalCoefficient * Rainfall * 0.325829 / 12;

            if (HarvestWaterDemand > HarvestWaterSupply) SupplementalWater = HarvestWaterDemand - HarvestWaterSupply; else SupplementalWater = 0.0;

            base.Calculate();

            CalculateMassLoading();
        }
    }
}
