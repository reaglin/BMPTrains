using System;
using System.Collections;
using System.Collections.Generic;

namespace BMPTrains_2020.DomainCode
{
    public interface ILookupTable
    {
        string Name { get; set; }
        string RowTitle { get; set; }
        string RowDescription { get; set; }
        string RowData { get; set; }                // Row data is stored as a string
        int RowDataDecimalPlaces { get; set; }

        string ColumnTitle { get; set; }
        string ColumnDescription { get; set; }
        string ColumnData { get; set; }             // Column data is stored as a string
        int ColumnDataDecimalPlaces { get; set; }

        string TableData { get; set; }              // Table data is stored as a string
        int TableDataDecimalPlaces { get; set; }

    }
    public interface ILookupArray
    {
        string Name { get; set; }
        string IndexTitle { get; set; }
        string IndexDescription { get; set; }
        string IndexData { get; set; }
        int IndexDataDecimalPlaces { get; set; }

        string LookupTitle { get; set; }
        string LookupDescription { get; set; }
        string LookupData { get; set; }
        int LookupDataDecimalPlaces { get; set; }
    }

    public class LookupArray : XmlPropertyObject, ILookupArray
    {
        /*
         *
         * Sample Lookup Array, knowing value in first column - lookup value in second column
         * using interpolation
         * 
0.000	0.00
0.250	26.20
0.500	44.30
0.750	57.30
1.000	66.80
1.250	73.70
1.500	78.90
1.750	82.80
2.000	85.80
2.250	88.10
2.500	90.00
2.750	91.60
3.000	92.90
3.250	93.90
3.500	94.80
3.750	95.50
4.000	96.20
 


         * 
         * */

        public string IndexTitle { get; set; }
        public string IndexDescription { get; set; }
        public string IndexData { get; set; }
        public int IndexDataDecimalPlaces { get; set; }

        public string LookupTitle { get; set; }
        public string LookupDescription { get; set; }
        public string LookupData { get; set; }
        public int LookupDataDecimalPlaces { get; set; }

        public override Dictionary<string, string> PropertyLabels()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            throw new NotImplementedException();
        }

        public double Calculate(double rowValue, bool extrapolate = false)
        {
            var indexValues = AsDoubleArray(IndexData);
            var lookupValues = AsDoubleArray(LookupData);

            if (!extrapolate && rowValue > indexValues[indexValues.Length - 1])
                return lookupValues[indexValues.Length - 1];

            return InterpolationValue(rowValue, indexValues, lookupValues);
        }

        public double CalculateIndex(double value, bool extrapolate = false)
        {
            var indexValues = AsDoubleArray(LookupData);
            var lookupValues = AsDoubleArray(IndexData);

            if (!extrapolate && value > indexValues[indexValues.Length - 1])
                return lookupValues[indexValues.Length - 1];

            return InterpolationValue(value, indexValues, lookupValues);

        }

        public double InterpolationValue(double value, double[] indexValues, double[] lookupValues)
        {
            // Performs and returns the actual interpolated value, index and lookupvalues must 
            // have same length
            int index = FindIndex(value, indexValues);
            double factor = InterpolationFactor(value, indexValues);

            if (factor == 0) return lookupValues[index];

            if (index == 0) return lookupValues[0];
            if (indexValues.Length == 1) return lookupValues[0];
            //if (index == indexValues.Length - 1) return lookupValues[indexValues.Length - 1];

            // Extrapolate
            if (index == indexValues.Length - 1)
                return lookupValues[index] + factor * (lookupValues[index] - lookupValues[index - 1]);

            // Interpolate
            return lookupValues[index] + factor * (lookupValues[index + 1] - lookupValues[index]);

        }

        public int FindIndex(double value, double[] values)
        {
            if (value <= values[0]) return 0;
            if (value >= values[values.Length - 1]) return values.Length - 1;
            for (int i = values.Length - 1; i >= 0; i--)
            {
                if (value >= values[i]) return i;
            }
            return 0;
        }

        public double InterpolationFactor(double value, double[] values)
        {
            // this finds the fraction difference a value lies between 2 points
            int baseIndex = FindIndex(value, values);

            if (values.Length == 1) return values[0];
            if (baseIndex == 0) return values[0];

            // First make sure not over limit on size, if so extrapolate
            if (baseIndex == values.Length - 1)
            {
                if (values[baseIndex] == values[baseIndex - 1]) return 0;
                return (value - values[baseIndex - 1]) / (values[baseIndex] - values[baseIndex - 1]);
            }

            if (values[baseIndex + 1] == values[baseIndex]) return 0;
            return (value - values[baseIndex]) / (values[baseIndex + 1] - values[baseIndex]);
        }
    }

    public class LookupTable : XmlPropertyObject, ILookupTable
    {
        /* This class is a base for a lookup table in 2 dimensions
         The table allows values to be looked up in the table and 
         interpolated values obtained. Example would be
         * 
                                    Curve Number
         *             10     20     30     40    50
         *       10    0.2   0.3    0.4    0.5   0.6    
         * DCIA  20    0.4   0.5    0.6    0.7   0.8
         *  %    30    0.5   0.6    0.7    0.8   0.9
         *  
         * For Curve Number = 30
         * DCIA = 20
         * 
         * Lookup Value = 0.6
         * 
         * RowData is new line delimited
         * ColumnData is new line delimited
         * TableData is tab (columns) and new line (rows) delimited
         * 
         */
        public const string SessionId = "LookupTableID";

        public string TableTitle { get; set; }
        public string TableDescription { get; set; }

        public string RowTitle { get; set; }
        public string RowDescription { get; set; }
        public string RowData { get; set; }
        public int RowDataDecimalPlaces { get; set; }

        public string ColumnTitle { get; set; }
        public string ColumnDescription { get; set; }
        public string ColumnData { get; set; }
        public int ColumnDataDecimalPlaces { get; set; }

        public string TableData { get; set; }
        public int TableDataDecimalPlaces { get; set; }

        public override Dictionary<string, string> PropertyLabels()
        {
            return new Dictionary<string, string>
                {
                    {"Name", "Title"},
                    {"RowTitle", "Row Title"},
                    {"RowDescription", "Row Description"},
                    {"ColumnTitle", "Column Title"},
                    {"ColumnDescription", "Column Description"},
                };
        }

        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            return new Dictionary<string, int>
                {
                    {"RowData", RowDataDecimalPlaces},
                    {"ColumnData", ColumnDataDecimalPlaces},
                    {"TableData", ColumnDataDecimalPlaces}
                };
        }

        public double CalculateTableValue(double rowValue, double columnValue)
        {
            return Calculate(rowValue, columnValue);
        }

        public double Calculate(double rowValue, double columnValue)
        {           
            // We first find a row that is a slice at the given row value
            double[] rowInterpolated = CreateInterpolationRow(rowValue);

            // We now have a single row with associated column values
            double[] colValues = AsDoubleArray(ColumnData);

            // We simply interpolate based on the 2 parallel arrays; colValues and rowInterpolated
            return InterpolationValue(columnValue, colValues, rowInterpolated);
        }

        public double CalculateRowValue(double columnValue, double tableValue)
        {
            // Given Column Value and Value from Table - Calculates Corresponding Row Value
            double[] colInterpolated = CreateInterpolationColumn(columnValue);

            double[] rowValues = AsDoubleArray(RowData);

            return InterpolationValue(tableValue, colInterpolated, rowValues); 
        }

        public double CalculateColumnValue(double rowValue, double tableValue)
        {           
            // We first find a row that is a slice at the given row value
            double[] rowInterpolated = CreateInterpolationRow(rowValue);

            // We now have a single row with associated column values
            var colValues = AsDoubleArray(ColumnData);

            // We simply interpolate based on the 2 parallel arrays; colValues and rowInterpolated
            return InterpolationValue(tableValue, rowInterpolated, colValues);
        }

        public string ImportData(string data, int decimalPlaces = 2)
        {

            data = data.TrimEnd();
            data = data.TrimStart();
            while (data.Contains("  "))
            {
                data = data.Replace("  ", " ");
            }

            string finalData = String.Empty;
            string formatString = "{0:N" + decimalPlaces.ToString().Trim() + "}";

            // makes a string array of all values
            string[] rowVals = data.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string row in rowVals)
            {
                var r = new ArrayList();
                string[] colVals = row.Split(new String[] { " ", ";", ",", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                string rowString = String.Empty;
                foreach (string colVal in colVals)
                {
                    r.Add(colVal);
                }
                foreach (string colVal in r)
                {
                    double tempVal = Convert.ToDouble(colVal);
                    string formattedVal = String.Format(formatString, (double)tempVal);
                    rowString += formattedVal + "\t";
                }
                finalData += rowString.Trim();
                finalData += "\n";
            }
            finalData += finalData.Trim();
            return finalData;
        }

        private int FindIndex(double value, double[] values)
        {
            // Must handle ascending and descending values
            // Regardless answers the first index in the sequence before 
            // the location of value in values

            if (values[0] < values[values.Length - 1]) // ascending
            { 
                if (value <= values[0]) return 0;
                if (value >= values[values.Length - 1]) return values.Length - 1;
                for (int i = values.Length - 1; i >= 0; i--)
                {
                    if (value >= values[i]) return i;
                }
                return 0;
            }
            else  // descending
            {
                if (value >= values[0]) return 0;
                if (value <= values[values.Length - 1]) return values.Length - 1;
                for (int i = 0; i <= values.Length - 1; i++)
                {
                    if (value >= values[i]) return i;
                }
                return values.Length - 1;
            }
        }

        private double InterpolationFactor(int index, double value, double[] values)
        {
            // Answers a number between 0 and 1
            // this finds the fraction difference a value lies between 2 points  
            // example: 0, 2  the value 1.5 would have factor of 0.75

            // index is always the index of the array value prior to the lookup value

            int max = values.Length - 1;
            // Trivial Case 0 or 1 value in array
            if (values.Length <= 1) return 0.0;

            // First make sure not over limit on size, if so extrapolate
            if (index == max)
            {
                return (value - values[index - 1]) / (values[index] - values[index - 1]);
            }

            // If values are equal at indexes - return 0
            if (values[index + 1] == values[index]) return 0;

            // If value is equal to vlaue at index - return 0
            if (value == values[index]) return 0.0;

            return (value - values[index]) / (values[index + 1] - values[index]);            
        }

        private double InterpolationValue(double value, double[] indexValues, double[] lookupValues)
        {
            // If equal to max, set to Max
            if (value == indexValues[indexValues.Length - 1]) return lookupValues[indexValues.Length - 1];
            // Performs and returns the actual interpolated value, index and lookupvalues must 
            // have same length
            int index = FindIndex(value, indexValues);
            double factor = InterpolationFactor(index, value, indexValues);


            if (factor == 0)
            {
                if (index < lookupValues.Length - 1)
                    return lookupValues[index];
                else
                    return lookupValues[lookupValues.Length - 1];
            }

            //if (index == 0) return lookupValues[0];
            if (indexValues.Length == 1) return lookupValues[0];
            //if (index == indexValues.Length - 1) return lookupValues[indexValues.Length - 1];

            // Extrapolate
            if (index == indexValues.Length - 1)
                return lookupValues[index] + factor * (lookupValues[index] - lookupValues[index - 1]);
            try
            {
                return lookupValues[index] + factor * (lookupValues[index + 1] - lookupValues[index]);
            }
            catch
            {
                return 0;
            }
            
        }

        private double[] CreateInterpolationRow(double rowValue)
        {
            // This creates a new row - by interpolating the row Value against the 
            // the row values - it creates an interpolation factor and a base index.
            // It then must apply this for every column to create a row value

            // result is a row that has the same # of columns as every row

            double[] rowValues = AsDoubleArray(RowData);                            // Converts string to double[]

            if (rowValue == rowValues[0]) return GetRowData(0, AsDoubleArray2D(TableData));
            if (rowValue == rowValues[rowValues.Length - 1]) return GetRowData(rowValues.Length - 1, AsDoubleArray2D(TableData));

            int rowIndex = FindIndex(rowValue, rowValues);                            // This finds the index of the row below the value
            double rowFactor = InterpolationFactor(rowIndex, rowValue, rowValues);    // The factor 0-1 above rowIndex, below next rowIndex

            double[,] data = AsDoubleArray2D(TableData);                    // Data is data[row, col]
            int nRows = data.GetLength(0);
            int nCols = data.GetLength(1);

            double[] row = new double[nCols];
            double[] lookupValues = new double[nCols];

            for (int i = 0; i <= nCols - 1; i++)
            {
                // lookupValues is the column as double[]
                lookupValues = GetColumnData(i, data);           // This gets the column at row i
                row[i] = InterpolationValue(rowValue, rowValues, lookupValues);
            }
            return row;
        }

        private double[] CreateInterpolationColumn(double colValue)
        {
            // This creates a new row - by interpolating the row Value against the 
            // the row values - it creates an interpolation factor and a base index.
            // It then must apply this for every column to create a row value

            // result is a row that has the same # of columns as every row

            double[] colValues = AsDoubleArray(ColumnData);                              // Converts string to double[]

            int colIndex = FindIndex(colValue, colValues);                            // This finds the index of the row below the value
            double factor = InterpolationFactor(colIndex, colValue, colValues);    // The factor 0-1 above rowIndex, below next rowIndex

            double[,] data = AsDoubleArray2D(TableData);
            int nRows = data.GetLength(0);
            int nCols = data.GetLength(1);

            double[] col = new double[nRows];
            double[] lookupValues = new double[nRows];

            for (int i = 0; i <= nRows - 1; i++)
            {
                // lookupValues is the column as double[]
                lookupValues = GetRowData(i, data);              // This gets the row at Column i
                col[i] = InterpolationValue(colValue, colValues, lookupValues);
            }
            return col;
        }

        private string CalculatedRowValues(double rv)
        {
            return AsString(CreateInterpolationRow(rv), TableDataDecimalPlaces);
        }

        private double[] GetColumnData(int index,  double[,] values)
        {
            // This Answers the Column at index
            double[] ret = new double[values.GetLength(0)];

            for (int i = 0; i < values.GetLength(0); i++)
            {
                ret[i] = values[i, index];
            }
            return ret;
        }

        private double[] GetRowData(int index, double[,] values)
        {
            double[] ret = new double[values.GetLength(1)];

            for (int i = 0; i < values.GetLength(1); i++)
            {
                ret[i] = values[index, i];
            }
            return ret;
        }

        public static double[,] AsDoubleArray2D(string values)
        {
            string s = values;
            s = s.TrimEnd();
            s = s.TrimStart();
            while (s.Contains("  "))
            {
                s = s.Replace("  ", " ");
            }

            // makes a string array of all values
            string[] rowVals = s.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] temp = rowVals[0].Split(new String[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);

            // dimensioned retVals[rowIndex, columnIndex]
            double[,] returnValues = new double[rowVals.Length, temp.Length];

            // Reinitialize the ArrayList
            var arraylist = new ArrayList();
            int rowIndex = 0;
            foreach (string rowVal in rowVals)
            {
                int colIndex = 0;
                string[] colVals = rowVal.Split(new String[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string colVal in colVals)
                {
                    returnValues[rowIndex, colIndex] = Convert.ToDouble(colVal);
                    colIndex++;
                }
                rowIndex++;
            }
            return returnValues;
        }

        public static string ImportData(double[,] data, int places = 2)
        {
            string s = "";
            string formatString = "{0:N" + places.ToString().Trim() + "}";
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    s += String.Format(formatString, (double)data[i, j]) + "\t";
                }
                s = s.Substring(0, s.Length - 2);
                s += "\n";
            }
            s = s.Substring(0, s.Length - 2);

            return s;
        }

        public new string AsHtmlTable()
        {
            string s = "<table>";
            foreach (KeyValuePair<string, string> pair in PropertyLabels())
            {
                s += "<tr>";
                s += "<td>" + pair.Value + "</td>";
                string v = GetValue(pair.Key);
                s += "<td>" + v + "</td>";
                s += "</tr>";
            }

            s += "<tr>";
            s += "<td colspan='2'>";
            s += AsHtml();
            s += "</td>";
            s += "</tr>";

            s += "</table>";

            return s;
        }

        public string AsHtml()
        {
            ArrayList rows = AsArrayList(RowData, "String");
            ArrayList cols = AsArrayList(ColumnData, "String");
            ArrayList rowValues = AsArrayList(TableData, "String", new string[] { "\n" });

            string s = "<h1>" + Name +"</h1>";
            s += TableDescription + "<br/>";
            s += "<table>";
            s += "<tr>";
            s += "<td rowspan='" + (rows.Count + 2).ToString() + "'><h2>" + RowTitle + "</h2></td>";
            s += "<td colspan='" + cols.Count.ToString() + "'><h2>" + ColumnTitle + "</h2></td>";
            s += "</tr>";

            s += "<tr>";
            s += "<td></td>";
            foreach (string col in cols)
            {
                s += "<td><b>" + col + "</b></td>";

            }
            s += "</tr>";


            int i = 0;
            foreach (string row in rows)
            {
                s += "<tr>";                
                s += "<td><b>" + row + "</b></td>";
                ArrayList cellValues = AsArrayList(Convert.ToString(rowValues[i]), "String");
                foreach (string cell in cellValues)
                {
                    s += "<td>" + cell + "</td>";
                }
                s += "</tr>";
                i++;
            }
            s += "</table>";
            return s;
        }

        public void ImportFromExcel(string data)
        {
            /* Sample Import
             * 
             * First Row is Name
             * Second Row is Tab - then Row Title, Column Titles
             * Third Row is Tab - then Column Values
             * Remaining Rows are Row Values [tab] Table Values (tab delimited)
             * Example
             * 
             [Title] Mean Annual Mass Removal Efficiencies for 0.25-inches of Retention for Zone 1														
             [Row Title ] NDCIA CN	[Column Title] Percent DCIA																			
	    5.0	    10.0	15.0	20.0	25.0	30.0	35.0	40.0	45.0	50.0	55.0	60.0	65.0	70.0	75.0	80.0	85.0	90.0	95.0	100.0
30.0	86.20	81.30	73.30	65.50	58.70	53.00	48.30	44.20	40.80	37.90	35.30	33.10	31.10	29.40	27.80	26.40	25.10	24.00	22.90	21.90
35.0	81.60	78.70	71.70	64.50	58.00	52.50	47.90	44.00	40.60	37.70	35.20	33.00	31.00	29.30	27.80	26.40	25.10	23.90	22.90	21.90
40.0	76.40	75.50	69.60	63.10	57.10	51.90	47.40	43.60	40.30	37.50	35.00	32.90	30.90	29.20	27.70	26.30	25.10	23.90	22.90	21.90
45.0	70.70	71.70	67.20	61.40	55.90	51.00	46.80	43.10	40.00	37.20	34.80	32.70	30.80	29.10	27.60	26.30	25.00	23.90	22.90	21.90
50.0	64.70	67.50	64.20	59.40	54.50	50.00	46.00	42.60	39.50	36.90	34.60	32.50	30.70	29.00	27.50	26.20	25.00	23.90	22.90	21.90
55.0	58.60	62.80	60.90	57.00	52.70	48.70	45.10	41.80	39.00	36.50	34.20	32.30	30.50	28.90	27.40	26.10	24.90	23.90	22.90	21.90
60.0	52.80	57.80	57.10	54.20	50.70	47.10	43.90	40.90	38.30	35.90	33.80	31.90	30.20	28.70	27.30	26.00	24.90	23.80	22.80	21.90
65.0	47.30	52.60	53.00	51.10	48.30	45.30	42.50	39.80	37.40	35.30	33.30	31.50	29.90	28.40	27.10	25.90	24.80	23.80	22.80	21.90
70.0	42.20	47.30	48.60	47.60	45.60	43.20	40.80	38.50	36.40	34.40	32.60	31.00	29.50	28.10	26.90	25.70	24.70	23.70	22.80	21.90
75.0	37.80	42.20	43.90	43.70	42.40	40.70	38.80	36.90	35.10	33.40	31.80	30.40	29.00	27.80	26.60	25.50	24.50	23.60	22.70	21.90
80.0	34.00	37.50	39.10	39.40	38.80	37.70	36.40	34.90	33.50	32.10	30.80	29.50	28.30	27.20	26.20	25.20	24.30	23.50	22.70	21.90
85.0	30.80	33.10	34.30	34.80	34.70	34.20	33.40	32.50	31.40	30.40	29.40	28.40	27.40	26.50	25.70	24.80	24.10	23.30	22.60	21.90
90.0	27.90	29.20	29.90	30.30	30.30	30.20	29.80	29.30	28.80	28.20	27.50	26.80	26.20	25.50	24.90	24.20	23.60	23.00	22.50	21.90
95.0	25.30	25.60	25.80	25.90	26.00	25.90	25.80	25.60	25.40	25.20	24.90	24.60	24.30	24.00	23.60	23.30	23.00	22.60	22.30	21.90
98.0	23.80	23.80	23.80	23.70	23.70	23.60	23.50	23.40	23.30	23.20	23.10	23.00	22.90	22.80	22.60	22.50	22.40	22.20	22.10	21.90

             * * 
             */

            string[] raw = data.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            // Row 1
            Name = raw[0].Trim();
            Description = Name;
            // Row 2
            string[] temp = raw[3].Trim().Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
            RowTitle = temp[0];
            ColumnTitle = temp[1];
            //Row 3
            ColumnData = raw[4].Replace('\t', '\n').Trim();

            // Get decimal places
            temp = ColumnData.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < temp.Length; i++)
            {
                ColumnDataDecimalPlaces = Math.Max(RowDataDecimalPlaces, temp[0].Length - temp[0].IndexOf(".") - 1);
            }

            RowData = String.Empty;
            TableData = String.Empty;
            for (int i = 5; i < raw.Length; i++)
            {
                string[] colData = raw[i].Trim().Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                // First Value is Row data

                RowData += colData[0] + "\n";
                RowDataDecimalPlaces = Math.Max(RowDataDecimalPlaces, colData[0].Length - colData[0].IndexOf(".") - 1);

                for (int j = 1; j < colData.Length; j++)
                {
                    TableDataDecimalPlaces = Math.Max(TableDataDecimalPlaces, colData[j].Length - colData[j].IndexOf(".") - 1);
                    TableData += colData[j] + "\t";
                }
                TableData = TableData.Trim();
                TableData += "\n";
            }

            TableData = TableData.Trim();
            RowData = RowData.Trim();
        }
    }
}
