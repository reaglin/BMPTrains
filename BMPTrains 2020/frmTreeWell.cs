using BMPTrains_2020.DomainCode;
using System;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmTreeWell : Form
    {
        int currentCatchmentID = 1;
        public frmTreeWell(int id)
        {
            currentCatchmentID = id;
            currentBMP().SetValuesFromCatchment(currentCatchment());

            InitializeComponent();
        }

        private void frmRetention_Load(object sender, EventArgs e)
        {
            cbRetentionOrDetention.Items.Add(Storage.sRetention);
            cbRetentionOrDetention.Items.Add(Storage.sDetention);
        
            // Add this to each object assigned to a Catchment, Implement MenuItemClickhandler
            InterfaceCommon.BuildCatchmentMenu(menuStrip1, MenuItemClickHandler, true);
            menuStrip1.Items[currentCatchmentID - 1].BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);

            setValues();
            currentBMP().BMPType = BMPTrainsProject.sTreeWell;
            this.Text +=currentCatchment().TitleHeader();
        }

        private Catchment currentCatchment()
        {
            // Add this to each BMP edit form
            return Globals.Project.getCatchment(currentCatchmentID);
        }

        private TreeWell currentBMP()
        {
            // Add a custom version for each BMP edit form
            return currentCatchment().getTreeWell();
        }

        private void setOutputText()
        {
            // Add to each form 
            //wbOutput.DocumentText = currentBMP().BasicReport();
            wbOutput.DocumentText = currentBMP().PrintBMPReport();
        }


        private void setValues()
        {          
            Common.setValue(tbTreeWellDepth, currentBMP().WellDepth);
            Common.setValue(tbTreeWellStorage, currentBMP().WellStorage);
            Common.setValue(tbWidth, currentBMP().WellWidth);
            Common.setValue(tbLength, currentBMP().WellLength);
            Common.setValue(tbNumWells, currentBMP().NumWells);
            Common.setValue(cbSoilStorage, currentBMP().SoilStorageCapacity, "#.##");
            Common.setValue(cbRetentionOrDetention, currentBMP().RetentionOrDetention);

            setOutputText();
        }

        private void getValues()
        {
            currentBMP().WellDepth = Common.getDouble(tbTreeWellDepth);
            currentBMP().WellStorage = Common.getDouble(tbTreeWellStorage);
            currentBMP().WellWidth = Common.getDouble(tbWidth);
            currentBMP().WellLength = Common.getDouble(tbLength);
            currentBMP().NumWells = Common.getInt(tbNumWells);
            currentBMP().SoilStorageCapacity = Common.getDouble(cbSoilStorage);
            currentBMP().RetentionOrDetention = cbRetentionOrDetention.Text;
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

        private void btnPlot_Click(object sender, EventArgs e)
        {
            Common.ShowRetentionPlot(currentBMP(), "Tree Well (retention) System Efficiency");
        }

        private void btnCost_Click(object sender, EventArgs e)
        {
            Form form = new frmCostAnalysis(currentBMP());
            form.ShowDialog();
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            Form form = new frmMediaMix(currentBMP());
            form.ShowDialog();
            setValues();
        }
    }
}
