using BMPTrains_2020.DomainCode;
using System;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmFiltration : Form
    {
        int currentCatchmentID = 1;
        public frmFiltration(int id)
        {
            currentCatchmentID = id;
            currentBMP().SetValuesFromCatchment(currentCatchment());

            InitializeComponent();
        }

        private void frmRetention_Load(object sender, EventArgs e)
        {

            // Add this to each object assigned to a Catchment, Implement MenuItemClickhandler
            InterfaceCommon.BuildCatchmentMenu(menuStrip1, MenuItemClickHandler,true);
            menuStrip1.Items[currentCatchmentID - 1].BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);

            setValues();

            this.Text +=currentCatchment().TitleHeader();
       
        }

        private Catchment currentCatchment()
        {
            // Add this to each BMP edit form
            return Globals.Project.getCatchment(currentCatchmentID);
        }

        private Filtration currentBMP()
        {
            // Add a custom version for each BMP edit form
            return currentCatchment().getFiltration();
        }

        private void setOutputText()
        {
            // Add to each form
            //            wbOutput.DocumentText = currentBMP().BasicReport();
            wbOutput.DocumentText = currentBMP().PrintBMPReport();
        }

        private void setValues()
        {
            if (currentBMP().MediaMixType == BMPTrainsProject.sNone)
            {
                tbTreatmentDepth.Enabled = false;
            }
            else
            {
                tbTreatmentDepth.Enabled = true;
            }

            Common.setValue(tbMedia, currentBMP().MediaMixType.Replace('_', '&'));
            Common.setValue(tbTreatmentDepth, currentBMP().RetentionDepth);

            setOutputText();
        }

        private void getValues()
        {
            currentBMP().RetentionDepth = Common.getDouble(tbTreatmentDepth);
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

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.wbOutput.Document.Focus();
            SendKeys.SendWait("^a");
            SendKeys.SendWait("^a^c");
            DialogResult dialogResult = MessageBox.Show("Report has been copied to the clipboard as HTML text", "Copy Report", MessageBoxButtons.OK);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // If using naming convention, this should always be the same
            getValues();
            currentBMP().Calculate();
            setOutputText();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Same for every edit form
            wbOutput.Print();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Now used as Cost
            Form form = new frmCostAnalysis(currentBMP());
            form.ShowDialog();

            currentBMP().Calculate();
            setOutputText();
        }

        private void btnMediaMix_Click(object sender, EventArgs e)
        {
            getValues();
            Form form = new frmMediaMix(currentBMP());
            form.ShowDialog();
            setValues();
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            Common.ShowRetentionPlot(currentBMP(), "Filtration (retention) System Efficiency");
        }
    }
}
