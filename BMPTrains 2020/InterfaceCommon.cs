using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public class InterfaceCommon
    {
        public static Boolean IsNotInArray(string value, string[] array)
        {
            foreach (string s in array)
            {
                if (s == value)
                {
                    return false;
                }
            }
            return true;
        }
        public static void BuildCatchmentMenu(MenuStrip m, EventHandler e, bool IsBMP = false)
        {
            m.CanOverflow = true;
            int n = Globals.Project.numCatchments;
            if (n == 0)
            {

                BuildMenuItem(m, e, Globals.Project.getCatchment().id);
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    BuildMenuItem(m, e, i, Globals.Project.getCatchment(i).CatchmentName);
                }
            }

            if (IsBMP)
            { 
                ToolStripMenuItem item = new ToolStripMenuItem();
                item = new ToolStripMenuItem();
                item.Name = "reset";
                item.Text = "Reset All Values";
                item.Font = m.Font;
                item.Click += new EventHandler(e);
                item.Overflow = ToolStripItemOverflow.AsNeeded;
                
                m.Items.Add(item);
            }
        }

        private static void BuildMenuItem(MenuStrip m, EventHandler e, int id, string name = "")
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item = new ToolStripMenuItem();
            item.Name = Convert.ToString(id);
            item.Text = "Catchment " + id.ToString() + " " + name;
            
            item.AutoToolTip = true;
            item.ToolTipText = name;

            item.Font = m.Font;
            item.Click += new EventHandler(e);
            item.Overflow = ToolStripItemOverflow.AsNeeded;
            m.Items.Add(item);
        }

        public static void resetMenuColors(MenuStrip m)
        {

            foreach (ToolStripMenuItem t in m.Items)
            {
                t.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control);
            }
        }

        public static void setBrowserStyles(WebBrowser w)
        {
           // This is reserved to set custom styles for the WB control

        }

        public static string Yes()
        {
            return "<span style='color:green; font-weight:bold'> Yes</span>";
        }
        public static string No()
        {
            return "<span style='color:red; font-weight:bold'> No</span>";
        }

        public static string GreenText(String s)
        {
            return "<span style='color:green; font-weight:bold'> " + s + "</span>";
        }
        public static string RedText(String s)
        {
            return "<span style='color:red; font-weight:bold'> " + s + "</span>";
        }
        public static string YesNo(string s)
        {
            if (s.Trim().ToUpper() == "YES") return GreenText(s);
            return RedText(s);
        }
        public static string YesNo(Boolean val)
        {
            if (val)
                return Yes();
            else
                return No();
        }
        private static DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Name";

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }
        public static string PrintPropertySection(object o, string[] properties, string Label)
        {
            string s = "<h2>" + Label + "</h2>";
            foreach (var property in properties)
            {
                s += PrintProperty(o, property);
            }
            return s;
        }
        public static string PrintPropertyTable(object o, string[] properties, string Label)
        {
            string s = "<h2>" + Label + "</h2>";
            s += "<table>";
            foreach (var property in properties)
            {
                s += PrintPropertyRow(o, property);
            }
            s += "</table><br/>";
            return s;
        }
        public static string PrintPropertyRow(object o, string property)
        {
            return PrintProperty(o, property, true);
        }

        // Does both rows and tables
        public static string PrintProperty(object o, string propertyName, bool AsTableRow = false)
        {
            // v is the object that has the property, propertyName is the name of the property
            string s = "";
            var object_type = o.GetType();                          // The type of the object passed, in this case a domain object
            var property = object_type.GetProperty(propertyName);   // The specific property (by name) of the variable to print in object o
            var property_type = property.PropertyType;

            if (property_type != null)
            {
                var metaInfo = (Meta)Attribute.GetCustomAttribute(property, typeof(Meta));
                try
                {
                    if (AsTableRow) s += "<tr><td>";
                    s += metaInfo.Description;
                    if (metaInfo.Units != "") s += " (" + metaInfo.Units + ")";
                    if (AsTableRow) s += "</td><td>"; else s += ": ";

                    if (property_type == typeof(string)) s += ((string)property.GetValue(o));
                    if (property_type == typeof(Double)) s += AsString((Double)property.GetValue(o), (int)metaInfo.Places);
                    if (property_type == typeof(int)) s += ((int)property.GetValue(o)).ToString(metaInfo.Format);
                    if (property_type == typeof(bool)) s += ((bool)property.GetValue(o)).ToString();
                    if (AsTableRow) s += "</td></tr>";
                    return s;
                }
                catch
                {
                    return $"Print Information not found for Property {propertyName}.";
                }
            }
            return s;
        }

        public static string AsString(double value, int decimalPlaces)
        {
            string formatString = "{0:N" + decimalPlaces.ToString().Trim() + "}";
            return String.Format(formatString, value);
        }
    }   
}
