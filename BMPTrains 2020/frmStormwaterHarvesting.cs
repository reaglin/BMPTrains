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
    public partial class frmStormwaterHarvesting : Form
    {
        public int currentCatchmentID;
        public frmStormwaterHarvesting(int id)
        {
            InitializeComponent();
            currentCatchmentID = id;
            currentBMP().SetValuesFromCatchment(currentCatchment());
        }

        private void frmStormwaterHarvesting_Load(object sender, EventArgs e)
        {
            InterfaceCommon.BuildCatchmentMenu(menuStrip1, MenuItemClickHandler, true);
            menuStrip1.Items[currentCatchmentID - 1].BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);

            setValues();
            currentBMP().BMPType = BMPTrainsProject.sStormwaterHarvesting;
            this.Text +=currentCatchment().TitleHeader();

            // Now only doing 
            currentBMP().SolveForChoice = RainwaterHarvesting.sHarvestEfficiency;

        }

        private Catchment currentCatchment()
        {
            // Add this to each BMP edit form
            return Globals.Project.getCatchment(currentCatchmentID);
        }

        private StormwaterHarvesting currentBMP()
        {
            // Add a custom version for each BMP edit form
            return currentCatchment().getStormwaterHarvesting();
        }


        private void getValues()
        {
            currentBMP().AvailableHarvestRate = Common.getDouble(tbHarvestRate);
            currentBMP().ContributingArea = Common.getDouble(tbContributingArea);
            if (currentBMP().ContributingArea > currentCatchment().PostArea) currentBMP().ContributingArea = currentCatchment().PostArea;
            currentBMP().IrrigationArea = Common.getDouble(tbIrrigationArea);            
            currentBMP().HarvestVolume = Common.getDouble(tbHarvestVolume);
        }

        private void setValues()
        {
            rbHarvestEfficiency.Checked = true;
            lblHarvest.Text = "Harvest Rate (0.1 - 4.0 in/week)";
            Common.setValue(tbHarvestRate, currentBMP().AvailableHarvestRate);


            Common.setValue(tbHarvestVolume, currentBMP().HarvestVolume);
            Common.setValue(tbIrrigationArea, currentBMP().IrrigationArea);
            Common.setValue(tbContributingArea, currentBMP().ContributingArea);

            currentBMP().Calculate();
            //wbOutput.DocumentText = currentBMP().BasicReport();
            wbOutput.DocumentText = currentBMP().PrintBMPReport();

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            getValues();
            currentBMP().Calculate();
            Globals.Project.Modified = true;
            setValues();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            getValues();
            Globals.Project.Modified = true;
            this.Close();
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
            wbOutput.Print();
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

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }

        private void rbHarvestEfficiency_Click(object sender, EventArgs e)
        {
            getValues();
            currentBMP().Calculate();
            setValues();
        }

        private void rbHarvestRate_Click(object sender, EventArgs e)
        {
            getValues();
            currentBMP().Calculate();
            setValues();
        }

        private void btnCost_Click(object sender, EventArgs e)
        {
            Form form = new frmCostAnalysis(currentBMP());
            form.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.wbOutput.Document.Focus();
            SendKeys.SendWait("^a");
            SendKeys.SendWait("^a^c");
            DialogResult dialogResult = MessageBox.Show("Report has been copied to the clipboard as HTML text", "Copy Report", MessageBoxButtons.OK);
        }

        private void btnPlotREV_Click(object sender, EventArgs e)
        {
            if (btnPlotREV.Text == "Plot REV") showREV(); else showReport();
        }

        private void pbREV_Click(object sender, EventArgs e)
        {
            showReport();
        }

        private void showREV()
        {
            Form plot = new frmPlottingREVCurves(currentBMP());
            plot.ShowDialog();
        }
        private void showReport()
        {
            btnPlotREV.Text = "Plot REV";
            pbREV.Visible = false;
            wbOutput.Visible = true;
        }
    }

}
