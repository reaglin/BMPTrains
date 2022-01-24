using BMPTrains_2020.DomainCode;
using System;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmPerviousPavment : Form
    {
        int currentCatchmentID = 1;
        public frmPerviousPavment(int id)
        {
            currentCatchmentID = id;
            Globals.Project.Modified = true;
            currentBMP().SetValuesFromCatchment(currentCatchment());
            InitializeComponent();
        }

        private void frmRetention_Load(object sender, EventArgs e)
        {

            // Add this to each object assigned to a Catchment, Implement MenuItemClickhandler
            InterfaceCommon.BuildCatchmentMenu(menuStrip1, MenuItemClickHandler,true);
            menuStrip1.Items[currentCatchmentID - 1].BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);

            currentBMP().Calculate();
            setValues();

            this.Text +=currentCatchment().TitleHeader();
        }

        private Catchment currentCatchment()
        {
            // Add this to each BMP edit form
            return Globals.Project.getCatchment(currentCatchmentID);
        }

        private PerviousPavement currentBMP()
        {
            // Add a custom version for each BMP edit form
            return currentCatchment().getPerviousPavement();
        }

        private void setOutputText()
        {
            // Add to each form
            //wbOutput.DocumentText = currentBMP().BasicReport();
            wbOutput.DocumentText = currentBMP().BMPReport();

        }

        private void setValues()
        {
            Common.setValue(tbSurfaceArea, currentBMP().SurfaceArea,2);
            Common.setValue(tbStorage, currentBMP().TotalStorage,2);

            setOutputText();
        }

        private void getValues()
        {
            currentBMP().SurfaceArea = Common.getDouble(tbSurfaceArea);
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
            setValues();
            setOutputText();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
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

        private void btnPavements_Click(object sender, EventArgs e)
        {
            Form form = new frmPervousPavementTypes(currentBMP());
            form.ShowDialog();
            setValues();
        }

        private void tbSurfaceArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            Common.ShowRetentionPlot(currentBMP(), "Pervious Pavement (retention) System Efficiency");
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
    }
}
