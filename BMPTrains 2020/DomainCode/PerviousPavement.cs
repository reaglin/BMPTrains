using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class AvailablePerviousPavements : ValueDictionary
    {
        public const string DefaultHeader = "Layer\tVoid Space(%)";
        public const string DefaultName = "Default Permeable Pavement Types";
        public const string DefaultDescription = "Concrete Permeable Pavement\t25.00\nFilterPaveTM\t20.00\nFirmaPaveTM\t20.00\n" +
            "FlexiPaveTM\t20.00\nPowerBLOCK(TM)\t5.00\n#57 rock(non-calcareous)\t21.00\n#89 pea rock\t25.00\n#4 rock\t24.00\n" +
            "Recycled (crushed) concrete\t21.00\nBold and GoldTM\t20.00\nOther Reservoir Space\t95.00\nBelgardTM\t20.00\n" +
            "User Defined(5)\t5.00\nUser Defined(20)\t20.00\nUser Defined(25)\t25.00\nUser Defined(30)\t30.00\n";

        public AvailablePerviousPavements()
        {            
            Name = DefaultName;
            Description = DefaultDescription;
            Header = DefaultHeader;
        }

        public int NumberOfRows() => Description.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).Length + 1;
    }

    public class PerviousPavement : Storage
    {
        public AvailablePerviousPavements PerviousPavements { get; set; }
        public string Thickness { get; set; }  // Thickness of any specific layer in inches
        public string Storage { get; set; }
        public double SurfaceArea { get; set; } //ac
        public double TotalStorage { get; set; }

        public PerviousPavement(Catchment c) : base(c) {
            BMPType = BMPTrainsProject.sPerviousPavement;
           PerviousPavements = new AvailablePerviousPavements();
            for (int i=0; i<PerviousPavements.NumberOfRows(); i++) { Thickness += "0.00\t"; }
        }

        public override Dictionary<string, string> PropertyLabels()
        {
            return new Dictionary<string, string>
            {
                {"WatershedArea", "Catchment Watershed Area (acres)"},
                {"ContributingArea", "Contributing Area (acres)"},
                {"SurfaceArea", "Surface Area of Pavement (acres)"},
                {"RetentionVolume", "Retention Volume (ac-ft)"},
                {"RetentionDepth", "Treatment Volume (in over watershed)"},
                {"CalculatedNTreatmentEfficiency", "Provided Treatment Capture Efficiency (%)"}
            };
        }

        public override Dictionary<string, string> BasicReportLabels()
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>
            {
                {"label0", "<h2>Permeable Pavement</h2>" },
                {"SurfaceArea", "<u>Area of the Permeable Pavement System (acres)</u>" },
                {"RetentionDepth", "<u>Provided retention depth for hydraulic capture (in)</u>"},
                {"RequiredNTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},
                {"RequiredPTreatmentEfficiency", "Required Phosphorus Treatment Efficiency (%)"},
                {"RequiredRetentionDepth", "Treatment Depth to meet Required Efficiency (in)"},
                {"RemainingDepthNeeded", "Remaining Retention Depth needed (in)" },
                {"RequiredRetentionVolume", "Required Water Quality Retention Volume (in)"},
                {"label1", "<b>Provided Values Based on Inputs</b>"  },
                {"RainfallZone", "Rainfall Zone:"},
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
                {"SurfaceArea", "Surface Area of Pavement (acres)"},
               // {"RetentionVolume", "Retention Volume (ac-ft)"},
                {"RetentionDepth", "Treatment Volume (in over watershed)"}
            });
            s += PavementsAsHtml();
            return s;
        }


        public double[] getThicknesses()
        {
            return AsDoubleArray(Thickness);
        }

        public string setThicknesses(double[] t)
        {
            Thickness = "";
            for (int i = 0; i < t.Length; i++) { Thickness +=  AsString(t[i],2) + "\t"; }
            return Thickness;
        }
        public override string BMPTypeTitle()
        {
            return "Permeable Pavement";
        }

        public new void Calculate()
        {
            string[] layerNames = PerviousPavements.Descriptions();
            double[] voidSpaces = PerviousPavements.Values();

            double[] thickness = getThicknesses();
            double[] storage = new double[layerNames.Length];

            double totalStorage = 0;
            for (int i = 0; i < layerNames.Count(); i++)
            {
                try
                {
                    storage[i] = SurfaceArea * thickness[i] * voidSpaces[i] / 100 / 12; //ac-ft 
                    totalStorage += storage[i];
                }
                catch
                {
                    storage[i] = 0;
                }
            }

            Storage = AsString(storage, 2);

            TotalStorage = totalStorage;
            RetentionVolume = TotalStorage; // ac-ft

            ContributingArea = WatershedArea - SurfaceArea;
            //RetentionDepth = RetentionVolume / ContributingArea * 12.0;  // 
            RetentionDepth = RetentionVolume / WatershedArea * 12.0;
            base.Calculate();
        }

        public string PavementsAsHtml()
        {
            string s = "<table><tr><td>Pavement Type</td><td>Thickness (in)</td><td>Storage (in)</td><td>Storage (ac-ft)</td></tr>";
            string[] layerNames = PerviousPavements.Descriptions();
            double[] voidSpaces = PerviousPavements.Values();

            double[] thickness = getThicknesses();
            double[] storageIN = new double[layerNames.Length];
            double[] storageCF = new double[layerNames.Length];

            double totalStorageIN = 0;
            double totalStorageCF = 0;
            for (int i = 0; i < layerNames.Count(); i++)
            {
                try
                {
                    storageIN[i] = thickness[i] * voidSpaces[i] / 100;
                    storageCF[i] = SurfaceArea * storageIN[i] / 12; //ac-ft 
                    if (storageCF[i] != 0)
                    {
                        s += "<tr><td>" + PerviousPavements.getDescription(i) + "</td><td>";
                        s += AsString(thickness[i], 2) + "</td><td>";
                        s += AsString(thickness[i] * voidSpaces[i] / 100, 3) + "</td><td>";
                        s += AsString(storageCF[i], 3) + "</td></tr>";
                    }
                    totalStorageIN += storageIN[i];
                    totalStorageCF += storageCF[i];
                }
                catch
                {
                    storageIN[i] = 0;
                    storageCF[i] = 0;
                }
            }
            s += "<tr><td colspan='2'><b>Total</b></td><td>" + AsString(totalStorageIN, 3) + "</td><td>" + AsString(totalStorageCF, 3) + "</td></tr></table>";
            return s;
        }

        public new string BasicReport()
        {
            string s =  base.BasicReport();
            s += "<br/>";
            s += PavementsAsHtml();
            return s;
        }

        public new string AsHtmlTable()
        {
            string s = base.AsHtmlTable();
            s += "<br/>";
            s += PavementsAsHtml();
            return s;
        }
    }
}
