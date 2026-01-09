using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class VNBEfficiencyTables 
    {
        public const double minSlope = 2.0;
        public const double maxSlope = 6.0;
        public const double minBuffer = 10.0;
        public const double maxBuffer = 350.0;

        public static LookupTable NitrogenTable()
        {
            LookupTable lut = new LookupTable();
            lut.Name = "Vegetated Natural Buffer Nitrogen Efficiencies";
            lut.RowTitle = "Buffer Slope";
            lut.RowDescription = "Buffer Slope (2%-6%)";
            lut.RowData = "2\n6";

            lut.ColumnTitle = "Buffer Width (ft)";
            lut.ColumnDescription = "Percent Directly Connected Impervious Area";
            lut.ColumnData = "10\n25\n50\n100\n350";

            lut.TableData = "50\t60\t65\t75\t90\n10\t15\t25\t45\t60";

            return lut;
        }

        public static LookupTable PhosphorusTable()
        {
            LookupTable lut = new LookupTable();
            lut.Name = "Vegetated Natural Buffer Nitrogen Efficiencies";
            lut.RowTitle = "Buffer Slope";
            lut.RowDescription = "Buffer Slope (2%-6%)";
            lut.RowData = "2\n6";

            lut.ColumnTitle = "Buffer Width (ft)";
            lut.ColumnDescription = "Percent Directly Connected Impervious Area";
            lut.ColumnData = "10\n25\n50\n100\n350";

            lut.TableData = "25\t40\t55\t60\t65\n5\t10\t15\t25\t65";

            return lut;
        }

        public static bool checkBounds(double slope, double buffer)
        {
            if (slope < minSlope) return false;
            if (slope > maxSlope) return false;
            if (buffer < minBuffer) return false;
            if (buffer > maxBuffer) return false;

            return true;
        }

        public static double NitrogenRemovalEfficiency(double slope, double buffer)
        {
            if (!checkBounds(slope, buffer)) return 0.0;

            LookupTable lut = NitrogenTable();
            return lut.Calculate(slope, buffer);
        }
        public static double PhosphorusRemovalEfficiency(double slope, double buffer)
        {
            if (!checkBounds(slope, buffer)) return 0.0;

            LookupTable lut = PhosphorusTable();
            return lut.Calculate(slope, buffer);
        }
    }

    public class VegetatedNaturalBuffer : Storage
    {

        [Meta("Buffer Width", "ft", 2)]
        public double BufferW { get; set; }                 // Width ft

        [Meta("Buffer Length", "ft", 2)]
        public double BufferL { get; set; }                 // Length ft

        [Meta("Buffer Depth", "ft", 2)]
        public double BufferDepth { get; set; }             // Depth

        [Meta("Width of Area Feeding Buffer", "ft", 2)]
        public double BufferFeederWidth { get; set; }

        [Meta("Water storage capacity of soil", "in/in", 2)]
        public double SoilStorageCapacity { get; set; }     // in/in

        [Meta("Slope of Buffer under 20%", "%", 2)]
        public double BufferWidthSlope { get; set; }        // %

        [Meta("Nitrogen Removal Efficiency in Buffer", "%", 2)]
        public double BufferNRemovalEfficiency { get; set; }

        [Meta("Phosphorus Removal Efficiency in Buffer", "%", 2)]
        public double BufferPRemovalEfficiency { get; set; }
        //public double AnnualCaptureEfficiency { get; set; }

        public new static readonly string[] InputVariables = {
                "BufferW", "BufferL", "BufferDepth", "BufferFeederWidth",
                "SoilStorageCapacity", "BufferWidthSlope" };

        public override string PrintInputVariables()
        {
            return InterfaceCommon.PrintPropertyTable(this, InputVariables, "Vegetated Natural Buffer Input Variables", BMPTrainsReports.TableStyle1, "my-table");
        }

        public VegetatedNaturalBuffer(Catchment c): base(c) {
            BMPType = BMPTrainsProject.sVegetatedNaturalBuffer;
        }

        public override Dictionary<string, string> PropertyLabels()
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>
            {
                {"BufferW", "Buffer Width (ft)"},
                {"BufferL", "Buffer Length (ft)"},
                {"BufferDepth","Buffer Depth (ft)" },
                {"BufferFeederWidth","Width of Area Feeding Buffer (ft)" },
                {"SoilStorageCapacity","Water storage capacity of soil (in/in)" },
                {"BufferWidthSlope","Slope of Buffer (< 20%)" },
                {"BufferNRemovalEfficiency","Nitrogen Removal Efficiency in Buffer (%)" },
                {"BufferPRemovalEfficiency","Phosphorus Removal Efficiency in Buffer (%)" },
            };

            return Add(d1, base.PropertyLabels());
        }
        public override string BMPInputVariables()
        {
            string s = "";
            s += AsHtmlTable(
                new Dictionary<string, string>
            {
                {"BufferW", "Buffer Width (ft)"},
                {"BufferL", "Buffer Length (ft)"},
                {"BufferDepth","Storage Depth (ft)" },
                {"BufferFeederWidth","Width of Area Feeding Buffer (ft)" },
                {"SoilStorageCapacity","Water storage capacity of soil (in/in)" },
                {"BufferWidthSlope","Slope of Bufer Width (2%-6%)" },
            });
            return s;
        }

        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            var current = new Dictionary<string, int>
                {
                    {"BufferNRemovalEfficiency", 0 },
                    {"BufferPRemovalEfficiency", 0 },
                };

            return Add(current, base.PropertyDecimalPlaces());
        }
        public override Dictionary<string, string> BasicReportLabels()
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>
            {
                {"label0", "<h2>Vegetated Natural Buffer</h2>" },
                {"ContributingArea", "Contributing Catchment Area (acres)" },
                {"RequiredNTreatmentEfficiency", "Required Nitrogen Treatment Efficiency (%)" },
                {"RequiredPTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)" },
                {"BufferW", "<u>Buffer Width (ft)</u>"},
                {"BufferL", "<u>Buffer Length (ft)</u>"},
                {"BufferDepth","<u>Storage Depth (ft)</u>" },
                {"BufferFeederWidth","<u>Width of Area Feeding Buffer (ft)</u>" },
                {"SoilStorageCapacity","<u>Water storage capacity of soil (in/in)</u>" },
                {"BufferWidthSlope","<u>Slope of Bufer Width (2%-6%)</u>" },
                {"HydraulicCaptureEfficiency", "Hydraulic Capture Efficiency (%)" },
                {"BufferNRemovalEfficiency","Nitrogen Removal Efficiency in Buffer (%)" },
                {"BufferPRemovalEfficiency","Phosphorus Removal Efficiency in Buffer (%)" },
                {"CalculatedNTreatmentEfficiency", "Provided Nitrogen Removal Efficiency (%)" },
                {"CalculatedPTreatmentEfficiency", "Provided Phosphorus Removal Efficiency (%)" },
            };

            return d1;
        }
        public new bool isDefined()
        {
            if (SoilStorageCapacity > 0) return true;
            return false;
        }

        public override string BMPTypeTitle()
        {
            string s = "Vegetated Natural Buffer ";
            if (MediaMixType != MediaMix.None) s += "with media";
            return s;
        }

        public new void Calculate()
        {
            RetentionDepth = 12 * BufferW * BufferDepth * SoilStorageCapacity / (BufferW + BufferFeederWidth);

            base.CalculateTreatmentEfficiency(RetentionDepth, WatershedNDCIACurveNumber, WatershedDCIAPercent);

            // The Efficiency is based on 

            BufferNRemovalEfficiency = VNBEfficiencyTables.NitrogenRemovalEfficiency(BufferWidthSlope, BufferW);
            BufferPRemovalEfficiency = VNBEfficiencyTables.PhosphorusRemovalEfficiency(BufferWidthSlope, BufferW);

            ProvidedNTreatmentEfficiency = HydraulicCaptureEfficiency + (100 - HydraulicCaptureEfficiency) * BufferNRemovalEfficiency / 100;
            ProvidedPTreatmentEfficiency = HydraulicCaptureEfficiency + (100 - HydraulicCaptureEfficiency) * BufferPRemovalEfficiency / 100;

            CaclulateRemainingEfficiency();

            CalculateMassLoading();

            base.CalculateGroundwaterDischarge();
        }

        public override Double[] plotX()
        {
            Double[] x = new Double[15];
            for (int i = 0; i < 14; i++)
            {
                x[i] = 25 + 25 * (Double)i;
            }
            return x;
        }

        public override Double[] plotY(double ratio, string p = "Nitrogen")
        {
            Double[] x = plotX();
            Double[] y = new Double[15];
            double rd = ratio * 12 * BufferDepth * SoilStorageCapacity; // Retention Depth (in over watershed)

            for (int i = 0; i < 14; i++)
            {
                double t = RetentionEfficiencyLookupTables.CalculateEfficiency(rd,
                                                               WatershedNDCIACurveNumber,
                                                               WatershedDCIAPercent,
                                                               RainfallZone);

                double e = (p == "Nitrogen" ?
                            VNBEfficiencyTables.NitrogenRemovalEfficiency(BufferWidthSlope, x[i]) :
                            VNBEfficiencyTables.PhosphorusRemovalEfficiency(BufferWidthSlope, x[i]));

                y[i] = t + (100 - t) * e / 100;
            }
            return y;
        }

        public override double XAxisMaximum()
        {
            return 350.0;
        }

        public override string XAxisTitle()
        {
            return "Buffer Width (ft)";
        }
    }

    public class VegetatedFilterStrip : VegetatedNaturalBuffer
    {
        public VegetatedFilterStrip(Catchment c) : base(c) { }


        public override Dictionary<string, string> BasicReportLabels()
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>
            {
                {"label0", "<h2>Vegetated Natural Buffer</h2>" },
                {"ContributingArea", "Contributing Catchment Area (acres)" },
                {"RequiredNTreatmentEfficiency", "Required Nitrogen Treatment Efficiency (%)" },
                {"RequiredPTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)" },
                {"BufferW", "<u>VFS Width (ft)</u>"},
                {"BufferL", "<u>VFS Length (ft)</u>"},
                {"BufferDepth","<u>VFS Depth (ft)</u>" },
                {"BufferFeederWidth","<u>Width of Area Feeding Buffer (ft)</u>" },
                {"SoilStorageCapacity","<u>Water storage capacity of soil (in/in)</u>" },
                {"BufferWidthSlope","<u>Slope of VFS (< 20%)</u>" },
                {"HydraulicCaptureEfficiency", "Hydraulic Capture Efficiency (%)" },
                {"MediaMixType", "Type of Media" },
                {"BufferNRemovalEfficiency","Nitrogen Removal Efficiency in Buffer (%)" },
                {"BufferPRemovalEfficiency","Phosphorus Removal Efficiency in Buffer (%)" },
                {"CalculatedNTreatmentEfficiency", "Provided Nitrogen Removal Efficiency (%)" },
                {"CalculatedPTreatmentEfficiency", "Provided Phosphorus Removal Efficiency (%)" },
            };

            return d1;
        }
        public override string BMPInputVariables()
        {
            string s = "";
            s += AsHtmlTable(
                new Dictionary<string, string>
            {
                {"BufferW", "VFS Width (ft)"},
                {"BufferL", "VFS Length (ft)"},
                {"BufferDepth","VFS Depth (ft)" },
                {"BufferFeederWidth","Width of Area Feeding Buffer (ft)" },
                {"SoilStorageCapacity","Water storage capacity of soil (in/in)" },
                {"BufferWidthSlope","Slope of VFS (< 20%)" },
                {"HydraulicCaptureEfficiency", "Annual Capture Percentage" }
            });
            return s;
        }

        public override string BMPTypeTitle()
        {
            string s = "Vegetated Filter Strip ";
            if (MediaMixType != MediaMix.None) s += "with media";
            return s;
        }

        public new void Calculate()
        {
            RetentionDepth = 12 * BufferW * BufferDepth * SoilStorageCapacity / (BufferW + BufferFeederWidth);

            base.CalculateTreatmentEfficiency(RetentionDepth, WatershedNDCIACurveNumber, WatershedDCIAPercent);

            // The Efficiency is based on 

            base.CalculateMediaMixTreatmentEfficiency();

            BufferNRemovalEfficiency = VNBEfficiencyTables.NitrogenRemovalEfficiency(BufferWidthSlope, BufferW);
            BufferPRemovalEfficiency = VNBEfficiencyTables.PhosphorusRemovalEfficiency(BufferWidthSlope, BufferW);

            ProvidedNTreatmentEfficiency = HydraulicCaptureEfficiency * (MediaNPercentReduction / 100) + (100 - HydraulicCaptureEfficiency) * BufferNRemovalEfficiency / 100;
            ProvidedPTreatmentEfficiency = HydraulicCaptureEfficiency * (MediaPPercentReduction / 100) + (100 - HydraulicCaptureEfficiency) * BufferPRemovalEfficiency / 100;

            CaclulateRemainingEfficiency();

            CalculateMassLoading();
            ContributingArea = (BufferW + BufferFeederWidth) * BufferL / 43560.0; 

            base.CalculateGroundwaterDischarge();
        }
        public override double GroundwaterNLoading()
        {
            return GroundwaterNMassLoadOut;
            //          return CalculatedNTreatmentEfficiency; 
        }

        public override double GroundwaterPLoading()
        {
            return GroundwaterPMassLoadOut;
            //          return CalculatedNTreatmentEfficiency; 
        }
        public override double GroundwaterNRemovalEfficiency()
        {
            //return 100 * CalculatedNTreatmentEfficiency / MediaNPercentReduction;
            return 0; 
        }
        public override double GroundwaterPRemovalEfficiency()
        {
            //return 100 * CalculatedPTreatmentEfficiency / MediaPPercentReduction;
            return 0;
        }

        public override Double[] plotY(double ratio, string p = "Nitrogen")
        {
            Double[] x = plotX();
            Double[] y = new Double[15];

            double rd = ratio * 12 * BufferDepth * SoilStorageCapacity; // Retention Depth (in over watershed)

            base.CalculateMediaMixTreatmentEfficiency();

            for (int i = 0; i < 14; i++)
            {
                double t = RetentionEfficiencyLookupTables.CalculateEfficiency(rd,
                                                               WatershedNDCIACurveNumber,
                                                               WatershedDCIAPercent,
                                                               RainfallZone);

                double e = (p == "Nitrogen" ?
                            VNBEfficiencyTables.NitrogenRemovalEfficiency(BufferWidthSlope, x[i]) :
                            VNBEfficiencyTables.PhosphorusRemovalEfficiency(BufferWidthSlope, x[i]));

                double m = (p == "Nitrogen" ?
                            MediaNPercentReduction :
                            MediaPPercentReduction);

                y[i] = t * m / 100 + (100 - t) * e /100;
            }
            return y;
        }
    }
}
