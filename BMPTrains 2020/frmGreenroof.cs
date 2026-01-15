using BMPTrains_2020.DomainCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmGreenroof : Form
    {
        int currentCatchmentID = 1;
        public frmGreenroof(int cid)
        {
            currentCatchmentID = cid;
            currentBMP().SetValuesFromCatchment(currentCatchment());
            InitializeComponent();
        }

        private void frmGreenroof_Load(object sender, EventArgs e)
        {
            cbRainfallStation.DataSource = new BindingSource(Greenroof.RainfallStations, null);
            cbRainfallStation.DisplayMember = "Key";
            cbRainfallStation.ValueMember = "Key";

            // Add this to each object assigned to a Catchment, Implement MenuItemClickhandler
            InterfaceCommon.BuildCatchmentMenu(menuStrip1, MenuItemClickHandler,true);
            menuStrip1.Items[currentCatchmentID - 1].BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);

            // Set default value
            currentBMP().GreenroofArea = currentCatchment().PostArea * 43560;
            setValues();

            this.Text +=currentCatchment().TitleHeader();
        }

        private Catchment currentCatchment()
        {
            // Add this to each BMP edit form
            return Globals.Project.getCatchment(currentCatchmentID);
        }

        private Greenroof currentBMP()
        {
            // Add a custom version for each BMP edit form
            return currentCatchment().getGreenroof();
        }

        private void setOutputText()
        {
            // Add to each form
            //            wbOutput.DocumentText = currentBMP().BasicReport();
            wbOutput.DocumentText = currentBMP().PrintBMPReport();
        }

        private void setValues()
        {
            
            Common.setValue(cbRainfallStation, currentBMP().RainfallStation);
            Common.setValue(tbDepth, currentBMP().RetentionDepth);
            Common.setValue(tbGreenroofArea, currentBMP().GreenroofArea);
            Common.setValue(tbIrrigationDemand, currentBMP().IrrigationDemand);
            Common.setValue(tbRainfallExcess, currentBMP().RainfallExcess);
            Common.setValue(chkCistern, currentBMP().CisternIsUsed);
            
            setOutputText();
        }

        private void getValues()
        {
            // Sample
            currentBMP().RetentionDepth = Common.getDouble(tbDepth);
            currentBMP().GreenroofArea = Common.getDouble(tbGreenroofArea);
            currentBMP().IrrigationDemand = Common.getDouble(tbIrrigationDemand);
            currentBMP().RainfallExcess = Common.getDouble(tbRainfallExcess);
            currentBMP().RainfallStation = Common.getString(cbRainfallStation);
            currentBMP().CisternIsUsed = Common.getBoolean(chkCistern);
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            // This must be added to handle events from every form that edits objects associated with
            // Catchments.
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            if (clickedItem.Name == "reset")
            {
                currentCatchment().Reset(currentBMP());
                setValues();
                return;
            }

            // Get current values            
            getValues();

            InterfaceCommon.resetMenuColors(menuStrip1);
            clickedItem.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);
            currentCatchmentID = Convert.ToInt32(clickedItem.Name);

            setValues();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            getValues();
            currentBMP().Calculate();
            Globals.Project.Modified = true;
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            getValues();
            currentBMP().Calculate();
            setValues();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.wbOutput.Document.Focus();
            SendKeys.SendWait("^a");
            SendKeys.SendWait("^a^c");
            DialogResult dialogResult = MessageBox.Show("Report has been copied to the clipboard as HTML text", "Copy Report", MessageBoxButtons.OK);
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            Common.ShowRetentionPlot(currentBMP(), "Greenroof (retention) System Efficiency");
        }

        private void btnCost_Click(object sender, EventArgs e)
        {
            Form form = new frmCostAnalysis(currentBMP());
            form.ShowDialog();
        }

        private void chkCistern_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCistern.Checked)
                currentBMP().GreenroofArea = currentCatchment().PostArea * 43560;
          setValues();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == (Keys.Control | Keys.Shift))
            {
                // Your code here to handle the Ctrl-Shift click
                Form form1 = new frmReport(currentBMP().DebugReport());
                form1.ShowDialog();
                return;
            }

            Form form = new frmReport(wbOutput.DocumentText, "", this.Text);
            form.ShowDialog();
        }
    }
}
