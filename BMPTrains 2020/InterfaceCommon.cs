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

    }
}
