using BMPTrains_2020.DomainCode;
using System;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmRainwaterHarvesting : Form
    {
        int currentCatchmentID;
        public frmRainwaterHarvesting(int id)
        {
            InitializeComponent();
            currentCatchmentID = id;
            currentBMP().SetValuesFromCatchment(currentCatchment());
        }

        private void frmRainwaterHarvesting_Load(object sender, EventArgs e)
        {
            cbRoofType.DataSource = new BindingSource(RainwaterHarvesting.RoofTypes(), null);
            cbRoofType.DisplayMember = "Key";
            cbRoofType.ValueMember = "Key";

            InterfaceCommon.BuildCatchmentMenu(menuStrip1, MenuItemClickHandler, true);
            menuStrip1.Items[currentCatchmentID - 1].BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);

            setValues();

            this.Text +=currentCatchment().TitleHeader();

            // We are only doing Harvest Efficiency
            currentBMP().SolveForChoice = RainwaterHarvesting.sHarvestEfficiency;
            currentBMP().ContributingAreaSF = 43560 * currentCatchment().PostArea;
        }

        private Catchment currentCatchment()
        {
            // Add this to each BMP edit form
            return Globals.Project.getCatchment(currentCatchmentID);
        }

        private RainwaterHarvesting currentBMP()
        {
            // Add a custom version for each BMP edit form
            return currentCatchment().getRainwaterHarvesting();
        }

        private void getValues()
        {
            currentBMP().AvailableHarvestRate = Common.getDouble(tbHarvestRate);
            currentBMP().HarvestVolume = Common.getDouble(tbHarvestVolume);
            currentBMP().RoofType = Common.getString(cbRoofType);
            currentBMP().ContributingAreaSF = Common.getDouble(tbContributingArea);
            currentBMP().IrrigationArea = Common.getDouble(tbIrrigationArea);
        }

        private void setValues()
        {


            rbHarvestEfficiency.Checked = true;
            lblHarvest.Text = "Harvest Rate (0.1 - 4.0 in/week)";
            Common.setValue(tbHarvestRate, currentBMP().AvailableHarvestRate);


            Common.setValue(cbRoofType, currentBMP().RoofType);
            Common.setValue(tbHarvestVolume, currentBMP().HarvestVolume);
            Common.setValue(tbIrrigationArea, currentBMP().IrrigationArea);
            Common.setValue(tbContributingArea, currentBMP().ContributingAreaSF);

            ///wbOutput.DocumentText = currentBMP().BasicReport();
            wbOutput.DocumentText = currentBMP().PrintBMPReport();

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            getValues();
            currentBMP().Calculate();
            setValues();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            getValues();
            currentBMP().Calculate();
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
            Form form = new frmReport(wbOutput.DocumentText, "", this.Text);
            form.ShowDialog();
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

        private void btnEfficiencyTable_Click(object sender, EventArgs e)
        {
            Form form = new frmTableViewer2(currentBMP().getEfficiencyLUT());
            form.ShowDialog();
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
    }
}
