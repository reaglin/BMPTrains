using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class LanduseTableRow
    {
        // Key is the unique identifier (e.g., "Agricultural - Citrus")
        public string Key { get; set; }
        public double N { get; set; }
        public double P { get; set; }

        // The Display property is now a calculated getter. 
        // It always reflects the current N and P values.
        public string Display
        {
            get
            {
                // Check if it's the special "User Defined Values" row
                if (LanduseTable.isUserDefined(this.Key))
                {
                    return this.Key;
                }

                // Format the display string using the current N and P values
                return $"{this.Key}: (TN={this.N:F3} TP={this.P:F3})";
            }
        }
    }

    // This class remains the same and is used for the ComboBox DataSource
    public class LanduseDisplayRow
    {
        public string Key { get; set; }
        public string Display { get; set; }
    }

    class LanduseTable
    {
        // Private static field to store the core Landuse data
        private static List<LanduseTableRow> _values;

        // Static method to initialize and return the core Landuse data (Key, N, P)
        public static List<LanduseTableRow> Values()
        {
            if (_values == null)
            {
                // Define data using only the Key, N, and P. 
                // The Display property is calculated dynamically by LanduseTableRow.
                _values = new List<LanduseTableRow>
                {
                    new LanduseTableRow() {Key = "Agricultural - Citrus", N = 2.11, P = 0.18},
                    new LanduseTableRow() {Key = "Agricultural - General", N = 2.29, P = 0.381},
                    new LanduseTableRow() {Key = "Agricultural - Pasture", N = 3.03, P = 0.593},
                    new LanduseTableRow() {Key = "Agricultural - Row Crops", N = 2.50, P = 0.577},
                    new LanduseTableRow() {Key = "Conventional Roofs", N = 1.050, P = 0.120},
                    new LanduseTableRow() {Key = "High-Intensity Commercial", N = 2.40, P = 0.345},
                    new LanduseTableRow() {Key = "Highway", N = 1.250, P = 0.173},
                    new LanduseTableRow() {Key = "Light Industrial", N = 1.200, P = 0.260},
                    new LanduseTableRow() {Key = "Low-Density Residential", N = 1.65, P = 0.27},
                    new LanduseTableRow() {Key = "Low-Intensity Commercial", N = 0.93, P = 0.188},
                    new LanduseTableRow() {Key = "Mining / Extractive", N = 1.180, P = 0.150},
                    new LanduseTableRow() {Key = "Multi-Family", N = 1.84, P = 0.520},
                    new LanduseTableRow() {Key = "Single-Family", N = 1.77, P = 0.327},
                    new LanduseTableRow() {Key = "Undeveloped - Dry Prairie", N = 2.025, P = 0.184},
                    new LanduseTableRow() {Key = "Undeveloped - Marl Prairie", N = 0.684, P = 0.012},
                    new LanduseTableRow() {Key = "Undeveloped - Mesic Flatwoods", N = 1.087, P = 0.043},
                    new LanduseTableRow() {Key = "Undeveloped - Ruderal/Upland Pine", N = 1.694, P = 0.162},
                    new LanduseTableRow() {Key = "Undeveloped - Scrubby Flatwoods", N = 1.155, P = 0.027},
                    new LanduseTableRow() {Key = "Undeveloped - Upland Hardwood", N = 1.042, P = 0.346},
                    new LanduseTableRow() {Key = "Undeveloped - Wet Flatwoods", N = 1.213, P = 0.021},
                    new LanduseTableRow() {Key = "Undeveloped - Wet Prairie", N = 1.095, P = 0.015},
                    new LanduseTableRow() {Key = "Undeveloped - Xeric Scrub", N = 1.596, P = 0.156},
                    new LanduseTableRow() {Key = "General Natural", N = 1.22, P = 0.213},
                    new LanduseTableRow() {Key = "SJRWMD Apopka Open Space/Recreation/Fallow Crop", N = 1.1, P = 0.05},
                    new LanduseTableRow() {Key = "SJRWMD Apopka Forests/Abandoned Tree Crops", N = 1.25, P = 0.08},
                    new LanduseTableRow() {Key = "Rangeland/Parkland", N = 1.15, P = 0.055},
                    new LanduseTableRow() {Key = "User Defined Values", N = 0.00, P = 0.00},
                };
            }
            return _values;
        }

        // Returns a list suitable for the ComboBox DataSource. 
        // It uses the dynamic LanduseTableRow.Display property.
        public static List<LanduseDisplayRow> DisplayValues()
        {
            return Values()
                .Select(v => new LanduseDisplayRow { Key = v.Key, Display = v.Display })
                .ToList();
        }

        // Checks for the special User Defined Key
        public static bool isUserDefined(string lutValue)
        {
            return lutValue == "User Defined Values";
        }

        // Get N value by Key
        public static double getN(string lutValue)
        {
            if (string.IsNullOrEmpty(lutValue)) return 0.0;
            try
            {
                LanduseTableRow l = LanduseTable.Values().Find(x => x.Key.Equals(lutValue));
                return l?.N ?? 0.0;
            }
            catch
            {
                return 0.0;
            }
        }

        // Get P value by Key
        public static double getP(string lutValue)
        {
            if (string.IsNullOrEmpty(lutValue)) return 0.0;
            try
            {
                LanduseTableRow l = LanduseTable.Values().Find(x => x.Key.Equals(lutValue));
                return l?.P ?? 0.0;
            }
            catch
            {
                return 0.0;
            }
        }
    }
}