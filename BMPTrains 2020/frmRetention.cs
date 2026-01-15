using BMPTrains_2020.DomainCode;
using System;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmRetention : Form
    {
        int currentCatchmentID;
        public frmRetention( int id)
        {
            currentCatchmentID = id;
            currentBMP().SetValuesFromCatchment(currentCatchment());

            InitializeComponent();            
        }

        private void frmRetention_Load(object sender, EventArgs e)
        {
            
            // Add this to each object assigned to a Catchment, Implement MenuItemClickhandler
            InterfaceCommon.BuildCatchmentMenu(menuStrip1, MenuItemClickHandler, true);
            menuStrip1.Items[currentCatchmentID - 1].BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);
            currentBMP().BMPType = BMPTrainsProject.sRetention;
            setValues();

            //if (Globals.Project.DoGroundwaterAnalysis == "No")
            //{
            //    btnMediaMix.Visible = false;
            //}

            this.Text +=currentCatchment().TitleHeader();
        }

        private Catchment currentCatchment()
        {
            // Add this to each BMP edit form
            return Globals.Project.getCatchment(currentCatchmentID);
        }

        private Retention currentBMP()
        {
            // Add a custom version for each BMP edit form
            return currentCatchment().getRetention();
        }

        private void setOutputText()
        {
            // Add to each form
            wbOutput.DocumentText = currentBMP().PrintBMPReport(); //currentBMP().getReport();
        }


        private void setValues()
        {
            // We now enter volume in Acre-feet and calculate depth
            Common.setValue(tbDepth, currentBMP().RetentionVolume);
            currentBMP().Calculate();
            setOutputText();
        }

        private void getValues()
        {
            // We now enter volume in Acre-feet and calculate depth
            currentBMP().RetentionVolume = Common.getDouble(tbDepth);
            currentBMP().RetentionDepth = currentBMP().RetentionVolume / currentBMP().ContributingArea * 12.0;
            //currentBMP().RetentionDepth = Common.getDouble(tbDepth);
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            // This must be added to handle events from every form that edits objects associated with
            // Catchments.
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            // Get current values  
            if (clickedItem.Name == "reset")
            {
                currentCatchment().Reset(currentBMP());
                setValues();
                return;
            }
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

        private void cbMixes_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tbDepth1_DoubleClick(object sender, EventArgs e)
        {
            getValues();
            setOutputText();
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
            if (Control.ModifierKeys == (Keys.Control | Keys.Shift))
            {
                // Your code here to handle the Ctrl-Shift click
                Form form1 = new frmReport(currentBMP().DebugReport());
                form1.ShowDialog();
                return;
            }
            // Same for every edit form
            Form form = new frmReport(wbOutput.DocumentText, "", this.Text);
            form.ShowDialog();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Same for every edit form - URL will change
            // This allows us to have external help by pulling up a web site in the application
            DomainCode.Common.OpenHelpUrl();
        }

        private void btnMediaMix_Click(object sender, EventArgs e)
        {
            getValues();
            Form form = new frmMediaMix(currentBMP());
            form.ShowDialog();
            currentBMP().Calculate();
            setValues();
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            Common.ShowRetentionPlot(currentBMP());
        }

        private void wbOutput_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void btnCost_Click(object sender, EventArgs e)
        {
            Form form = new frmCostAnalysis(currentBMP());
            form.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://roneaglin.online/BMPTrainsDocumentation/RetentionMethodology.pdf");
        }

        private void btnDepthFromEfficiency_Click(object sender, EventArgs e)
        {
            double value = 0.0;
            string input = "Enter Average Annual Efficiency (%) for calculating required retention depth (in)";
            if( Common.ShowInputDialog(ref input, currentBMP().ProvidedNTreatmentEfficiency.ToString("##.#")) == DialogResult.OK)
            {
                try {
                    value = Common.ToDouble(input);
                    if (value == 0) return;
                    if (value <= 0) return;
                    if (value > 98) return;

                    currentBMP().RetentionDepth = currentBMP().CaclulateRequiredTreatmentDepth(value);
                    setValues();
                }
                catch { }
            }
            
        }
    }
}
