using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class LanduseTableRow
    {
        public string D { get; set; }
        public double N { get; set; }
        public double P { get; set; }
    }

    class LanduseTable
    {

        public static List<LanduseTableRow> Values()
        {
            List<LanduseTableRow> values = new List<LanduseTableRow>
            {
                new LanduseTableRow() {D = "Agricultural - Citrus:    TN=2.11 TP=0.18", N =2.11, P =0.18},
                new LanduseTableRow() {D = "Agricultural - General: TN=2.29 TP=0.381", N =2.29, P =0.381},
                new LanduseTableRow() {D = "Agricultural - Pasture: TN=3.03 TP=0.593", N =3.03, P =0.593},
                new LanduseTableRow() {D = "Agricultural - Row Crops: TN=2.50 TP=0.577 ", N =2.5, P =0.577},
                new LanduseTableRow() {D = "Conventional Roofs: TN=1.050 TP=0.120", N =1.05, P =0.12},
                new LanduseTableRow() {D = "High-Intensity Commercial: TN=2.40 TP=0.345", N =2.4, P =0.345},
                new LanduseTableRow() {D = "Highway: TN=1.520 TP=0.200", N =1.52, P =0.2},
                new LanduseTableRow() {D = "Light Industrial: TN=1.200 TP=0.260", N =1.2, P =0.26},
                new LanduseTableRow() {D = "Low-Density Residential: TN=1.65 TP= 0.27", N =1.65, P =0.27},
                new LanduseTableRow() {D = "Low-Intensity Commercial: TN=1.13 TP=0.188", N =1.13, P =0.188},
                new LanduseTableRow() {D = "Mining / Extractive: TN=1.180 TP=0.150", N =1.18, P =0.15},
                new LanduseTableRow() {D = "Multi-Family: TN=2.320 TP=0.520", N =2.32, P =0.52},
                new LanduseTableRow() {D = "Single-Family: TN=2.070 TP=0.327", N =2.07, P =0.327},
                new LanduseTableRow() {D = "Undeveloped - Dry Prairie: TN=2.025 TP=0.184", N =2.025, P =0.184},
                new LanduseTableRow() {D = "Undeveloped - Marl Prairie: TN=0.684 TP=0.012", N =0.684, P =0.012},
                new LanduseTableRow() {D = "Undeveloped - Mesic Flatwoods: TN=1.09 TP=0.043", N =1.09, P =0.043},
                new LanduseTableRow() {D = "Undeveloped - Ruderal/Upland Pine: TN=1.694 TP=0.162", N =1.694, P =0.162},
                new LanduseTableRow() {D = "Undeveloped - Scrubby Flatwoods: TN=1.155 TP=0.027 ", N =1.155, P =0.027},
                new LanduseTableRow() {D = "Undeveloped - Upland Hardwood: TN=1.042 TP=0.346", N =1.042, P =0.346},
                new LanduseTableRow() {D = "Undeveloped - Wet Flatwoods: TN=1.213 TP=0.021", N =1.213, P =0.021},
                new LanduseTableRow() {D = "Undeveloped - Wet Prairie: TN=1.095 TP=0.015", N =1.095, P =0.015},
                new LanduseTableRow() {D = "Undeveloped - Xeric Scrub: TN=1.596 TP=0.156", N =1.596, P =0.156},
                new LanduseTableRow() {D = "General Natural: TN=1.22 TP=0.213", N =1.22, P =0.213},
                new LanduseTableRow() {D = "SJRWMD Apopka Open Space/Recreation/Fallow Crop: TN=1.100 TP=0.050", N =1.1, P =0.05},
                new LanduseTableRow() {D = "SJRWMD Apopka Forests/Abandoned Tree Crops: TN=1.250 TP=0.080", N =1.25, P =0.08},
                new LanduseTableRow() {D = "Rangeland/Parkland: TN=1.150 TP=0.055", N =1.15, P =0.055},
                new LanduseTableRow() {D = "User Defined Values", N = 0.00, P =0.00},
            };
            return values;
        }

        public static bool isUserDefined(string lutValue)
        {
            if (lutValue == "User Defined Values") return true;
            return false;
        }

        public static double getN(string lutValue)
        {
            if (lutValue == "") return 0.0;
            try
            {
                List<LanduseTableRow> v = LanduseTable.Values();
                LanduseTableRow l = v.Find(x => x.D.Equals(lutValue));
                return l.N;
            }
            catch
            {
                return 0.0;
            }
        }

        public static double getP(string lutValue)
        {
            if (lutValue == "") return 0.0;
            try
            {
                List<LanduseTableRow> v = LanduseTable.Values();
                LanduseTableRow l = v.Find(x => x.D.Equals(lutValue));
                return l.P;
            }
            catch
            {
                return 0.0;
            }
        }

    }
}
