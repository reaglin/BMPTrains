using BMPTrains_2020.DomainCode;
using System;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmSwale : Form
    {
        int currentCatchmentID = 1;
        public frmSwale(int id)
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

            setValues();

            currentBMP().BMPType = BMPTrainsProject.sSwale;
            this.Text +=currentCatchment().TitleHeader();
        }

        private Catchment currentCatchment()
        {
            // Add this to each BMP edit form
            return Globals.Project.getCatchment(currentCatchmentID);
        }

        private Swale currentBMP()
        {
            // Add a custom version for each BMP edit form
            return currentCatchment().getSwale();
        }

        private void setOutputText()
        {
            // Add to each form
            //wbOutput.DocumentText = currentBMP().BasicReport(); // + currentBMP().EfficiencyReport();
            currentBMP().Calculate();
            wbOutput.DocumentText = currentBMP().PrintBMPReport();
        }

        private void setValues()
        {
            currentBMP().SetValuesFromCatchment(currentCatchment());

            Common.setValue(tbW, currentBMP().SwaleW);
            Common.setValue(tbB, currentBMP().SwaleB);
            Common.setValue(tbL, currentBMP().SwaleL);
            Common.setValue(tbImpL, currentBMP().ImperviousL);
            Common.setValue(tbImpW, currentBMP().ImperviousW);
            Common.setValue(tbPervW, currentBMP().PerviousW);
            Common.setValue(tbS, currentBMP().SwaleS);
            Common.setValue(tbN, currentBMP().ManningsN);
            Common.setValue(tbInfRate, currentBMP().InfiltrationRate);
            Common.setValue(tbZ, currentBMP().SwaleZ);
            Common.setValue(tbH, currentBMP().SwaleH);
            Common.setValue(tbLb, currentBMP().SwaleLb);
            Common.setValue(tbNb, currentBMP().SwaleNb);
            Common.setValue(cbCReduction, currentBMP().UseConcentrationReduction);
            currentBMP().Calculate();
            setOutputText();
        }

        private void getValues()
        {
            currentBMP().SwaleW = Common.getDouble(tbW);
            currentBMP().SwaleB = Common.getDouble(tbB);
            currentBMP().SwaleL = Common.getDouble(tbL);
            currentBMP().ImperviousL = Common.getDouble(tbImpL);
            currentBMP().ImperviousW = Common.getDouble(tbImpW);
            currentBMP().PerviousW = Common.getDouble(tbPervW);
            currentBMP().SwaleS = Common.getDouble(tbS);
            currentBMP().ManningsN = Common.getDouble(tbN);
            currentBMP().InfiltrationRate = Common.getDouble(tbInfRate);
            currentBMP().SwaleZ = Common.getDouble(tbZ);
            currentBMP().SwaleH = Common.getDouble(tbH);
            currentBMP().SwaleLb = Common.getDouble(tbLb);
            currentBMP().SwaleNb = Common.getDouble(tbNb);
            currentBMP().UseConcentrationReduction = cbCReduction.Text;
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
            wbOutput.Print();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Same for every edit form - URL will change
            // This allows us to have external help by pulling up a web site in the application
            Form form = new frmHelp(currentBMP().HelpURL);
            form.ShowDialog();
        }

        private void cbMixes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            Common.ShowRetentionPlot(currentBMP(), "Swale (retention) System Efficiency");
        }

        private void btnCost_Click(object sender, EventArgs e)
        {
            Form form = new frmCostAnalysis(currentBMP());
            form.ShowDialog();
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            getValues();
            Form form = new frmMediaMix(currentBMP());
            form.ShowDialog();
            setValues();
        }

        private void cbCReduction_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
