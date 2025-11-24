using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPTrains_2020.DomainCode
{
    // THis class is used in reporting. It holds a metric name, value and unit.
    // It is used to pass metrics to reporting routines.
    public class ReportMetric
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; }

        public int Places { get; set; } = 2;           // Default to 2 decimal places
        public string FormatString { get; set; } = ""; // Default to empty

        // Logic: Use FormatString if present, otherwise generate standard Number format from Places
        public string EffectiveFormat
        {
            get
            {
                if (!string.IsNullOrEmpty(FormatString))
                {
                    return FormatString;
                }
                return "N" + Places;
            }
        }

        // Constructor 1: Simple (Defaults to Places=2, Format="")
        public ReportMetric(string name, double value, string unit = "")
        {
            Name = name;
            Value = value;
            Unit = unit;
        }

        // Constructor 2: Specify Places (Format remains "")
        public ReportMetric(string name, double value, string unit, int places)
        {
            Name = name;
            Value = value;
            Unit = unit;
            Places = places;
        }

        // Constructor 3: Specify FormatString (Places defaults to 2, but FormatString takes precedence)
        public ReportMetric(string name, double value, string unit, string formatString)
        {
            Name = name;
            Value = value;
            Unit = unit;
            FormatString = formatString;
        }

        // Constructor 4: Full Control (Sets both)
        public ReportMetric(string name, double value, string unit, int places, string formatString)
        {
            Name = name;
            Value = value;
            Unit = unit;
            Places = places;
            FormatString = formatString;
        }
    }

    public class Common
    {
        // Common is routines used by different classes that are able to be
        // reused
        public static string HomePage = "~/DefaultLoggedIn.aspx";

        public static string ManagePage(string className)
        {
            return "~/Pages/ManageXMLPropertyObject.aspx?Class=" + className;
        }
        public static string getDateString(bool toRight = false)
        {
            string s = "";
            if (toRight) s += "<div style = 'text-align: right;' >" + DateTime.Now.ToString("d") + "</div>";
            else s +=  DateTime.Now.ToString("d");
            return s;
        }

        public static string Spaces(int n)
        {
            string s = "";
            for (int i = 1; i < n; i++)
            {
                s += "&nbsp;";
            }
            return s;
        }
        public static int getInt(TextBox tb)
        {
            try
            {
                return Convert.ToInt32(tb.Text);
            }
            catch
            {
                return 0;
            }
        }
        public static int getInt(TextBox tb, int min, int max)
        {
            try
            {
                int a = Convert.ToInt32(tb.Text);
                if (a < min) return min;
                if (a > max) return max;
                return a;
            }
            catch
            {
                return 0;
            }
        }

        public static int getInt(ComboBox cb)
        {
            try
            {
                return Convert.ToInt32(getString(cb));
            }
            catch
            {
                return 0;
            }
        }
        public static string getString(ComboBox cb)
        {
            // keyOnly returns the key, not the text in the combobox.
            try
            {
                return cb.Text;
            }
            catch
            {
                return "";
            }
        }
        public static double getDouble(ComboBox cb)
        {
            try
            {
                return Convert.ToDouble(getString(cb));
            }
            catch
            {
                return 0.0;
            }
        }

        public static string getString(double value, int decimalPlaces)
        {
            string formatString = "{0:N" + decimalPlaces.ToString().Trim() + "}";
            return String.Format(formatString, value);
        }

        public static string getString(TextBox tb)
        {
            try
            {
                return tb.Text;
            }
            catch
            {
                return "";
            }
        }

        public static double getDouble(TextBox tb)
        {
            try
            {
                return Convert.ToDouble(tb.Text);
            }
            catch
            {
                return 0.0;
            }
        }
        public static double getDouble(TextBox tb, double min, double max)
        {
            try
            {
                double a =  Convert.ToDouble(tb.Text);
                if (a < min) return min;
                if (a > max) return max;
                return a;
            }
            catch
            {
                return 0.0;
            }
        }



        public static double getDouble(MaskedTextBox tb)
        {
            try
            {
                return Convert.ToDouble(tb.Text);
            }
            catch
            {
                return 0.0;
            }
        }

        public static void setValue(ComboBox cb, string s, bool addString = false)
        {
             
            try
            {
                cb.SelectedIndex = cb.FindStringExact(s);
            }
            catch
            {
                // will add items
                if (addString) cb.Items.Add(s);
            }
        }

        public static void setValue(ComboBox cb, double d, string format = "#.##" )
        {
            try
            {
                cb.SelectedIndex = cb.FindStringExact(d.ToString(format));
                // if not found we will look for closest match
                if (cb.SelectedIndex == -1)
                {
                    foreach (Object c in cb.Items)
                    {
                        double diff = Math.Abs(Convert.ToDouble(c) - d);
                        if (diff == 0) cb.SelectedIndex = cb.FindStringExact(c.ToString());
                    }
                }
            }
            catch
            {
                // do nothing
            }
        }
        public static void setValue(TextBox tb, string s)
        {
            try
            {
                tb.Text = s;
            }
            catch
            {
                tb.Text = "";
            }
        }
        public static void setValue(TextBox tb, int i)
        {
            try
            {
                tb.Text = Convert.ToString(i);
            }
            catch
            {
                tb.Text = "";
            }
        }

        public static void setValue(TextBox tb, double d)
        {
            try
            {
                tb.Text = Convert.ToString(d);
            }
            catch
            {
                tb.Text = "";
            }
        }

        public static void setValue(MaskedTextBox tb, double d)
        {
            try
            {
                tb.Text = Convert.ToString(d);
            }
            catch
            {
                tb.Text = "";
            }
        }

        public static void setValue(TextBox tb, double d, int p)
        {
            try
            {
                tb.Text = d.ToString("N"+p.ToString());
            }
            catch
            {
                tb.Text = "";
            }

        }

        public static void setValue(CheckBox cb, bool isChecked)
        {
            try {
                cb.Checked = isChecked;
            }
            catch { }
            
        }

        public static bool getBoolean(CheckBox cb)
        {
            bool result = false;
            try
            {
                result = cb.Checked;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }


        public static double ToDouble(string v)
        {
            try { return Convert.ToDouble(v); }
            catch { return 0; }
        }

        public static string ShortClassName(string name)
        {
            string fc = name;
            while (fc.Contains("."))
            {
                fc = fc.Substring(fc.IndexOf(".") + 1);
            }
            return fc;
        }

        //public static Dictionary<string, string> ClassLabels()
        //{
        //    // This routine returns a label for the interface for classes that use
        //    // the class name for identification of interface properties.

        //    var d = new Dictionary<string, string>();
        //    d.Add("Watershed", "Watershed");
        //    d.Add("Rainfall", "Rainfall");
        //    d.Add("CircularChannel", "Circular Channel");
        //    d.Add("TrapezoidalChannel", "Trapezoidal Channel");
        //    d.Add("DimensionlessRainfall", "Dimensionless Rainfall");
        //    return d;
        //}

        public static string ParameterString(string value, string label)
        {
            return label + ": " + value + "<br/>";
        }

        public static string ParameterString(double value, string label, int places)
        {
            return label + ": " + FormattedString(value, places) + "<br/>"; 
        }

        public static string ParameterString(int value, string label)
        {
            return label + ": " + value.ToString() + "<br/>";
        }
        //public static KeyValuePair<string, string> GetRandomClass()
        //{
        //    Dictionary<string, string> d = ClassLabels();
        //    Random r = new Random();
        //    int i = 0;
        //    int randIndex = r.Next(0, d.Values.Count);
        //    foreach (KeyValuePair<string, string> value in d)
        //    {
        //        if (i++ == randIndex)
        //            return value;
        //    }
        //    return new KeyValuePair<string, string>();
        //}
        #region "Tables"
        public static string TableCell(string s, string styles = "", bool border = false)
        {
            if (border) styles += "border: 2px solid black; padding: 10px;";
            return "<td style='text-align:center; "+ styles +"'>" + s + "</td>";
        }

        public static string BlankTableRows(int n = 1)
        {
            string s = "<tr>";
            for (int i = 0; i <= n; i++)
                s += "<td></td>";
            s+= "</tr>";
            return s;
        }

        public static string FilledTableRows(params string[] cells)
        {
            string s = "<tr>";
            foreach (string cell in cells)
            {
                s += "<td style='text-align:center; font-size: 150%'>" + cell + "</td>";
            }
            s += "</tr>";
            return s;
        }
        public static string TableCellReport(string label, bool showBorder, string customStyle, params ReportMetric[] metrics)
        {
            var styleBuilder = new System.Text.StringBuilder();
            styleBuilder.Append(showBorder ? "border: 2px solid black; " : "");
            styleBuilder.Append(string.IsNullOrEmpty(customStyle) ? "padding: 10px;" : customStyle);

            var html = new System.Text.StringBuilder();
            html.Append($"<td style='{styleBuilder}'>");

            if (!string.IsNullOrEmpty(label))
            {
                html.Append(label);
            }

            foreach (var metric in metrics)
            {
                if (html.Length > 4) html.Append("<br/>");

                // USE metric.EffectiveFormat HERE
                html.Append($"{metric.Name}: {GetFormattedValue(metric.Value, metric.EffectiveFormat)} {metric.Unit}");
            }

            html.Append("</td>");
            return html.ToString();
        }

        /// <summary>
        /// Generates a table cell report by reading [Meta] attributes from the provided properties.
        /// </summary>
        /// <param name="label">The header label for the cell.</param>
        /// <param name="showBorder">Whether to show the border.</param>
        /// <param name="customStyle">Custom CSS style.</param>
        /// <param name="propertyExpressions">Lambda expressions pointing to the properties (e.g., () => MyProp)  
        /// example call: Common.TableCellReport("Summary", true, "", () => TotalCost, () => Ratio);</param>
        public static string TableCellReport(string label, bool showBorder, string customStyle, params Expression<Func<double>>[] propertyExpressions)
        {
            var metricsList = new List<ReportMetric>();

            foreach (var expr in propertyExpressions)
            {
                double value = expr.Compile().Invoke();

                var memberExpr = expr.Body as MemberExpression;
                if (memberExpr == null)
                {
                    metricsList.Add(new ReportMetric("Unknown", value));
                    continue;
                }

                var propInfo = memberExpr.Member as PropertyInfo;
                var meta = propInfo.GetCustomAttribute<Meta>();

                if (meta != null)
                {
                    string metricName = !string.IsNullOrEmpty(meta.ReportLabel) ? meta.ReportLabel :
                                        (!string.IsNullOrEmpty(meta.Description) ? meta.Description : propInfo.Name);

                    // We pass BOTH Places and Format from the attribute to the Metric
                    metricsList.Add(new ReportMetric(metricName, value, meta.Units, meta.Places, meta.Format));
                }
                else
                {
                    metricsList.Add(new ReportMetric(propInfo.Name, value));
                }
            }

            return TableCellReport(label, showBorder, customStyle, metricsList.ToArray());
        }

        public static string TableCellRightArrow( string styles = "", bool border = false)
        {
            // if right is true, right arrow, else down arrow
            if (border) styles += "border: 2px solid black; padding: 10px;";
            string arrow = "&#8594;"; 
            return "<td style='text-align:center; font-size: 150%" + styles + "'>" + arrow + "</td>";
        }

        public static string TableCellDownArrow(string styles = "", bool border = false)
        {
            if (border) styles += "border: 2px solid black; padding: 10px;";
            string arrow = "&#8595;";
            return "<td style='text-align:center; font-size: 150% " + styles + "'>" + arrow + "</td>";
        }

        public static string TableCellBlank(int n = 1)
        {
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append("<td></td>");
            }
            return sb.ToString();
        }

        public static string GetFormattedValue(double d, int places)
        {
            string formatString = "{0:N" + places.ToString().Trim() + "}";
            if (places == 0) return d.ToString("#");

            return String.Format(formatString, d);
        }

        public static string GetFormattedValue(double value, string format)
        {
            // Safety check: if format is null or empty, return default string representation
            if (string.IsNullOrEmpty(format))
            {
                return value.ToString();
            }

            try
            {
                return value.ToString(format);
            }
            catch (FormatException)
            {
                // Fallback if the format string is invalid
                return value.ToString();
            }
        }

        /// <summary>
        /// Generates an HTML table for a list of objects, with rows defined by the passed property expressions.
        /// </summary>
        /// <typeparam name="T">The type of object (e.g., Catchment)</typeparam>
        /// <param name="items">The list of objects (columns).</param>
        /// <param name="tableTitle">The header title for the table.</param>
        /// <param name="properties">A comma-separated list of properties to include as rows.</param>
        /// <summary>
        /// Generates a 2-column HTML table (Label | Value) for a single object instance.
        /// </summary>
        /// <typeparam name="T">The type of the object (e.g., Catchment)</typeparam>
        /// <param name="item">The specific instance to report on.</param>
        /// <param name="tableTitle">Optional header for the table.</param>
        /// <param name="properties">Comma-separated list of properties to include.</param>
        public static string GeneratePropertyTable<T>(T item, string tableTitle, params Expression<Func<T, object>>[] properties)
        {
            var sb = new StringBuilder();

            // Optional: Wrap in a stylized div or just the table
            sb.Append("<table border='1' cellpadding='5' style='border-collapse:collapse; width:100%; margin-bottom:15px;'>");

            // 1. Table Header (Optional)
            if (!string.IsNullOrEmpty(tableTitle))
            {
                // Spans 2 columns (Label + Value)
                sb.Append($"<tr><th colspan='2' style='background-color:#EEE; text-align:left;'>{tableTitle}</th></tr>");
            }

            // 2. Loop through requested properties
            foreach (var selector in properties)
            {
                // Extract Property Info
                var propInfo = GetPropertyInfo(selector);
                if (propInfo == null) continue;

                // Get Meta Attributes
                var meta = propInfo.GetCustomAttribute<Meta>();

                // Determine Label, Format, Unit
                string rowLabel = propInfo.Name;
                string format = "";
                string unit = "";

                if (meta != null)
                {
                    rowLabel = !string.IsNullOrEmpty(meta.ReportLabel) ? meta.ReportLabel :
                               (!string.IsNullOrEmpty(meta.Description) ? meta.Description : propInfo.Name);

                    // Logic: Format String > Places > Default
                    format = !string.IsNullOrEmpty(meta.Format) ? meta.Format : "N" + meta.Places;
                    unit = meta.Units;
                }

                // Append Unit to Label
                if (!string.IsNullOrEmpty(unit)) rowLabel += $" ({unit})";

                // 3. Get the Value
                var func = selector.Compile();
                object rawValue = func(item);

                string displayValue;
                if (rawValue is double dVal)
                {
                    // Use your existing Common.GetValue logic
                    displayValue = Common.GetFormattedValue(dVal, format);
                }
                else
                {
                    displayValue = rawValue?.ToString() ?? "";
                }

                // 4. Render Row
                sb.Append("<tr>");
                sb.Append($"<td style='width:60%;'>{rowLabel}</td>"); // Label Column
                sb.Append($"<td style='width:40%; text-align:center;'>{displayValue}</td>"); // Value Column
                sb.Append("</tr>");
            }

            sb.Append("</table>");
            return sb.ToString();
        }

        // Helper to unwrap Expression<Func<T, object>> (handles boxing of value types)
        private static PropertyInfo GetPropertyInfo<T>(Expression<Func<T, object>> propertyLambda)
        {
            MemberExpression member = propertyLambda.Body as MemberExpression;
            if (member == null)
            {
                // If the property is a value type (double/int), it gets wrapped in a Convert() operation.
                var unary = propertyLambda.Body as UnaryExpression;
                if (unary != null) member = unary.Operand as MemberExpression;
            }
            return member?.Member as PropertyInfo;
        }

        private static bool IsSimpleType(Type type)
        {
            if (type.IsPrimitive || type.IsEnum) return true;
            if (type == typeof(string)) return true;
            if (type == typeof(decimal)) return true;
            if (type == typeof(DateTime)) return true;

            // Handle Nullable types (e.g., double?)
            if (Nullable.GetUnderlyingType(type) != null)
            {
                return IsSimpleType(Nullable.GetUnderlyingType(type));
            }

            return false;
        }

        /// <summary>
        /// Reflects over an object to print all Primitive properties in a table.
        /// Recursively calls itself for non-primitive properties.
        /// </summary>
        public static string AllProperties(object item, string titleOverride = "")
        {
            if (item == null) return "";

            var type = item.GetType();
            var sb = new StringBuilder();

            // Determine Header Title (Override -> Meta Description -> Class Name)
            string headerText = titleOverride;
            if (string.IsNullOrEmpty(headerText))
            {
                // Try to find a [Meta] tag on the Class itself (if you use them there) 
                // or just use the Class Name.
                headerText = type.Name;
            }

            // --- PASS 1: Generate Table for Primitive Types ---
            sb.Append("<table border='1' cellpadding='5' style='border-collapse:collapse; width:100%; margin-bottom:20px;'>");

            // Header Row
            sb.Append($"<tr><th colspan='2' style='background-color:#CCC; text-align:left;'>{headerText}</th></tr>");

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // We will store complex objects here to process AFTER we close this table
            var complexProperties = new List<(PropertyInfo prop, object val)>();

            foreach (var prop in properties)
            {
                // Skip indexers (properties that require arguments)
                if (prop.GetIndexParameters().Length > 0) continue;

                var val = prop.GetValue(item);

                // Check if Primitive/Simple
                if (IsSimpleType(prop.PropertyType))
                {
                    // --- Extract Meta Data ---
                    var meta = prop.GetCustomAttribute<Meta>();

                    string rowLabel = prop.Name;
                    string format = "";
                    string unit = "";

                    if (meta != null)
                    {
                        // Priority: ReportLabel > Description > Name
                        rowLabel = !string.IsNullOrEmpty(meta.ReportLabel) ? meta.ReportLabel :
                                   (!string.IsNullOrEmpty(meta.Description) ? meta.Description : prop.Name);

                        format = !string.IsNullOrEmpty(meta.Format) ? meta.Format : "N" + meta.Places;
                        unit = meta.Units;
                    }

                    if (!string.IsNullOrEmpty(unit)) rowLabel += $" ({unit})";

                    // --- Format Value ---
                    string displayValue;
                    if (val is double dVal) displayValue = Common.GetFormattedValue(dVal, format);
                    else if (val is DateTime dtVal) displayValue = dtVal.ToShortDateString();
                    else displayValue = val?.ToString() ?? "";

                    // --- Render Row ---
                    sb.Append("<tr>");
                    sb.Append($"<td style='width:60%; font-weight:bold; background-color:#f9f9f9;'>{rowLabel}</td>");
                    sb.Append($"<td style='width:40%; text-align:center;'>{displayValue}</td>");
                    sb.Append("</tr>");
                }
                else
                {
                    // Valid Non-Primitive? (Ignore Lists/Collections for now to prevent huge dumps, unless desired)
                    if (val != null && !typeof(System.Collections.IEnumerable).IsAssignableFrom(prop.PropertyType))
                    {
                        complexProperties.Add((prop, val));
                    }
                }
            }
            sb.Append("</table>");

            // --- PASS 2: Recursion for Complex Types ---
            foreach (var complex in complexProperties)
            {
                // Use the Property Name as the title for the sub-table
                string subTitle = complex.prop.Name;

                // Check for Meta label on the complex property itself
                var meta = complex.prop.GetCustomAttribute<Meta>();
                if (meta != null && !string.IsNullOrEmpty(meta.ReportLabel)) subTitle = meta.ReportLabel;

                // RECURSIVE CALL
                sb.Append(AllProperties(complex.val, subTitle));
            }

            return sb.ToString();
        }

        #endregion
        #region "Validation Routines"
        public static bool ValidateGE(double v, double lower, string message, bool allowZero = true)
        {
            if (allowZero && v == 0) return true;
            if (lower >= v)
            {
                MessageBox.Show(message, "Error");
                return false;
            }
            return true;
        }

        public static bool ValidateRange(double v, double lower, double upper, string message, bool allowZero = true)
        {
            if (allowZero && v == 0) return true;
            if ((v <= lower ) || (v >= upper))
            {
                MessageBox.Show(message, "Error");
                return false;
            }
            return true;
        }

        public static double GetAverageOfDouble(double[] x, int maxRows)
        {
            double j = 0;
            double sum = 0.0;
            for (int i = 0; i < maxRows; i++)
            {
                if (x[i] != 0)
                {
                    sum += x[i];
                    j++;
                }
            }
            if (j > 0) return sum / j;
            return 0.0;
        }

        public static double GetSumOfDouble(double[] x, int maxRows)
        {
            double sum = 0.0;
            for (int i = 0; i < maxRows; i++)
            {
                if (x[i] != 0)
                {
                    sum += x[i];
                }
            }
            return sum;
        }


        #endregion

        #region "String Routines"
        //public static string GetClassLabel(string name)
        //{
        //    try
        //    {
        //        return ClassLabels()[ShortClassName(name)];
        //    }
        //    catch
        //    {
        //        return name;
        //    }

        //}

        public static string getUniqueFileName(string header, string extension)
        {
            int i = 1;

            string filename = header + i.ToString() + "." + extension;
            while (File.Exists(WorkingDirectory() + "\\" + filename))
            {
                i++;
                filename = header + i.ToString() + "." + extension;
            }
            return filename;
        }

        public static string WorkingDirectory()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BMPTrains";
            Directory.CreateDirectory(path);
            return path;
        }

        public static void SetButtonColor(Catchment catchment, BMP bmp, System.Windows.Forms.Button btn)
        {
            System.Drawing.Color dColor = System.Drawing.Color.LightGreen;
            System.Drawing.Color bColor = System.Drawing.Color.LightGray;
            System.Drawing.Color sColor = System.Drawing.Color.LightCyan;

            setButtonColor(bmp.isDefined(), btn);
            if ((catchment.getSelectedBMP() == bmp)&&bmp.isDefined()) btn.BackColor = sColor;
        }

        public static void setButtonColor(bool defined, System.Windows.Forms.Button btn)
        {
            System.Drawing.Color dColor = System.Drawing.Color.LightGreen;
            System.Drawing.Color bColor = System.Drawing.Color.LightGray;

            if (defined) btn.BackColor = dColor; else btn.BackColor = bColor;
        }

        public static string FormattedString(double value, int places)
        {
            return String.Format("{0:N" + places.ToString().Trim() + "}", value);
        }

        public static string ConvertTabDelimitedToHtml(string input)
        {
            // Converts tab delimited \t for columns and new line \n for rows
            // to html but without header information
            string s = "<tr><td>" + input;
            s = s.Replace("\n", "</tr><tr><td>");
            s = s.Replace("\t", "</td><td>");
            s = s.Replace("<td><tr>", "<tr>");
            s += "</td></tr>";
            return s;
        }

        #endregion
        public static void ShowRetentionPlot(BMP bmp, string plotTitle = "Retention Treatment Efficiency")
        {
            frmChart formC = new frmChart(bmp, "Storage");
            formC.Text = plotTitle;
            formC.AddMarker(bmp.RetentionDepth, bmp.HydraulicCaptureEfficiency,
                "System Efficiency at Treatment Depth (in over watershed): " + XmlPropertyObject.AsString(bmp.RetentionDepth, 2));
            formC.ShowDialog();
        }

        public static void ShowVNBPlot(BMP bmp, string plotTitle = "Vegetated Natural Buffer Plot")
        {
            VegetatedNaturalBuffer vnb = (VegetatedNaturalBuffer)bmp;
            frmChart formC = new frmChart(bmp, "VNB");
            formC.Text = plotTitle;
            formC.ShowDialog();
        }

        public static void ShowVFSPlot(BMP bmp, string plotTitle = "Vegetated Filter Strip Plot")
        {
            VegetatedFilterStrip vnb = (VegetatedFilterStrip)bmp;
            frmChart formC = new frmChart(bmp, "VFS");
            formC.Text = plotTitle;
            formC.ShowDialog();
        }

        public static void ShowDetentionPlot(BMP bmp, string plotTitle = "Wet Detention System Plot")
        {            
            frmChart formC = new frmChart(bmp, "WetDetention");
            formC.Text = plotTitle;
            formC.ShowDialog();
        }

        public static void ShowCostScenarioPlot(string plotType)
        {
            frmChart formC = new frmChart(plotType);
            formC.Text = plotType;
            formC.ShowDialog();
        }


        public static double PresentValueofFutureCost(double value, double interestRate, double years, double duration = 0)
        {
            // years = expected life in years
            // duration = duration of project
            double d = years;
            int n = 1;              // Number of times to calculate value

            if (years <= 0) return value;
            if (duration < years) d = years;
            if (duration > years) n = Convert.ToInt32(Math.Floor(duration / years));

            
            if (interestRate <= 0) return value / years;

            double retval = 0.0;
            for (int i=1; i <= n; i++)
            {
                retval += value / Math.Pow(1 + interestRate / 100, (i *years));
            }

            return retval;
        }

        public static double PresentValueofAnnualCost(double value, double interestRate, double years)
        {
            if (years <= 0) return value;
            if (interestRate <= 0) return value / years;
            return value * (Math.Pow((1 + interestRate / 100), years) - 1) / (interestRate / 100 * Math.Pow((1 + interestRate / 100), years));
        }



        public static void OpenHelpUrl()
        {
            DomainCode.Common.OpenURL("http://roneaglin.online/bmptrains/help/");
        }

        public static void OpenURL(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception)
            {
                return;
            }
        }

        public static void OpenURL(int code)
        {
            try
            {
                string url = "http://storrmwater.ucf.edu/BMPVideo/?id=" + code.ToString();
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception)
            {
                return;
            }
        }
        public static DialogResult ShowInputDialog(ref string prompt, string def = "00")
        {
            System.Drawing.Size size = new System.Drawing.Size(400, 140);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Name";

            System.Windows.Forms.Label label = new Label();
            label.Size = new System.Drawing.Size(size.Width - 10, 23);
            label.Location = new System.Drawing.Point(5, 5);
            label.Text = prompt;
            inputBox.Controls.Add(label);


            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 46);
            textBox.Text = def;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 79);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 79);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            prompt = textBox.Text;
            return result;
        }
    }
}
