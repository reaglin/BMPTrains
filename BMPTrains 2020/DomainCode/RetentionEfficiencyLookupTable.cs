using System;

namespace BMPTrains_2020.DomainCode
{
    public class RetentionEfficiencyLookupTables 
    {
        public static String[] Depths = {"0.00", "0.25", "0.50", "0.75", "1.00", "1.25", "1.50", "1.75", "2.00", "2.25", "2.50", "2.75", "3.00", "3.25", "3.50", "3.75", "4.00"};

        public static double CalculateEfficiency(double depth, double NDCIACN, double DCIAPercent, string zone)
        {
            // Get the String Index of the Lower and Upper Depths to look up the table

            if (depth == 0.0) return 0.0;

            double DCIAP = DCIAPercent;
            if (DCIAP < 5) DCIAP = 5;

            int lowerDepthIndex = GetLowerDepthIndex(depth);
            int upperDepthIndex = 0;
            if (lowerDepthIndex < Depths.Length - 1)
            {
                upperDepthIndex = lowerDepthIndex + 1;
            }
            else
            {
                upperDepthIndex = Depths.Length - 1;
            }

            string lowerDepth = Depths[lowerDepthIndex];
            string upperDepth = Depths[upperDepthIndex];

            // Get the Lookup tables needed, we need 2 tables to interpolate between the tables

            var lowerLookupTable = StaticLookupTables.RetentionEfficiencyTable(lowerDepth, zone);
            var upperLookupTable = StaticLookupTables.RetentionEfficiencyTable(upperDepth, zone);

            var lowerEfficiency = lowerLookupTable.Calculate(NDCIACN, DCIAP);
            var upperEfficiency = upperLookupTable.Calculate(NDCIACN, DCIAP);

            var lowerD = Convert.ToDouble(lowerDepth);
            var upperD = Convert.ToDouble(upperDepth);

            if (Math.Abs(upperEfficiency - lowerEfficiency) < 0.00001) return lowerEfficiency;
            if (Math.Abs(upperD - lowerD) < 0.000001) return lowerEfficiency;

            // Added to fix odd efficiency problem
            if (lowerEfficiency > upperEfficiency) return upperEfficiency;

            return lowerEfficiency + ((depth - lowerD)/(upperD-lowerD))*(upperEfficiency-lowerEfficiency);
        }

        public static int GetLowerDepthIndex(double depth)
        {
            if (depth > Convert.ToDouble(Depths[Depths.Length - 1])) return Depths.Length - 1;
            for (int i = Depths.Length - 1; i >= 0; i--)
            {
                if (depth >= Convert.ToDouble(Depths[i])) return i;
            }
            return 0;
        }

        public static string getLowerDepth(double depth)
        {
            if (depth == 0.0) return "0.00";

            int lowerDepthIndex = GetLowerDepthIndex(depth);
            int upperDepthIndex = 0;
            if (lowerDepthIndex < Depths.Length - 1)
            {
                upperDepthIndex = lowerDepthIndex + 1;
            }
            else
            {
                upperDepthIndex = Depths.Length - 1;
            }

            string lowerDepth = Depths[lowerDepthIndex];
            return lowerDepth;
        }
        public static string getUpperDepth(double depth)
        {
            if (depth == 0.0) return "0.00";

            int lowerDepthIndex = GetLowerDepthIndex(depth);
            int upperDepthIndex = 0;
            if (lowerDepthIndex < Depths.Length - 1)
            {
                upperDepthIndex = lowerDepthIndex + 1;
            }
            else
            {
                upperDepthIndex = Depths.Length - 1;
            }

            string upperDepth = Depths[upperDepthIndex];
            return upperDepth;
        }

        public static LookupTable getLookupTable(double depth, string zone)
        {

            int lowerDepthIndex = GetLowerDepthIndex(depth);
            int upperDepthIndex = 0;
            if (lowerDepthIndex < Depths.Length - 1)
            {
                upperDepthIndex = lowerDepthIndex + 1;
            }
            else
            {
                upperDepthIndex = Depths.Length - 1;
            }

            string lowerDepth = Depths[lowerDepthIndex];
            string upperDepth = Depths[upperDepthIndex];

            // Get the Lookup tables needed, we need 2 tables to interpolate between the tables

            var lowerLookupTable = StaticLookupTables.RetentionEfficiencyTable(lowerDepth, zone);
            var upperLookupTable = StaticLookupTables.RetentionEfficiencyTable(upperDepth, zone);

            if (lowerDepth == upperDepth) return lowerLookupTable;

            double ratio = (depth - Convert.ToDouble(lowerDepth)) / (Convert.ToDouble(upperDepth) - Convert.ToDouble(lowerDepth));

            if (ratio == 0) return lowerLookupTable;

            // Convert To Array
            double[,] lookupValuesLower = LookupTable.AsDoubleArray2D(lowerLookupTable.TableData);
            double[,] lookupValuesUpper = LookupTable.AsDoubleArray2D(upperLookupTable.TableData);

            for (int i = 0; i < lookupValuesLower.GetLength(0); i++)
            {
                for (int j = 0; j < lookupValuesLower.GetLength(1); j++)
                {
                   
                    lookupValuesLower[i, j] = lookupValuesLower[i, j] + ratio * (lookupValuesUpper[i, j] - lookupValuesLower[i, j]);
                 }
            }

            // Convert Back to String
            lowerLookupTable.TableData = LookupTable.ImportData(lookupValuesLower, 2);
            lowerLookupTable.Name = "Efficiency at Retention Depth: " + depth.ToString() + " (in) for Rainfall " + zone;

            return lowerLookupTable;
        }
    }
}