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
    }
}
