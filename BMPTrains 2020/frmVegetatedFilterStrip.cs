using BMPTrains_2020.DomainCode;
using System;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmVegetatedFilterStrip : Form
    {
        int currentCatchmentID = 1;
        public frmVegetatedFilterStrip(int id)
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

            pictureBox1.Image = BMPTrains_2020.Properties.Resources.VegBuffer;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            setValues();
            currentBMP().BMPType = BMPTrainsProject.sVegetatedFilterStrip;
            this.Text +=currentCatchment().TitleHeader();
        }

        private Catchment currentCatchment()
        {
            // Add this to each BMP edit form
            return Globals.Project.getCatchment(currentCatchmentID);
        }

        private VegetatedFilterStrip currentBMP()
        {
            // Add a custom version for each BMP edit form
            return currentCatchment().getVegetatedFilterStrip();
        }

        private void setOutputText()
        {
            // Add to each form
            //wbOutput.DocumentText = currentBMP().BasicReport();
            wbOutput.DocumentText = currentBMP().PrintBMPReport();
        }

        private void setValues()
        {
            Common.setValue(tbW, currentBMP().BufferW);
            Common.setValue(tbL, currentBMP().BufferL);
            Common.setValue(tbD, currentBMP().BufferDepth);
            Common.setValue(tbFeederW, currentBMP().BufferFeederWidth);
            Common.setValue(tbStorage, currentBMP().SoilStorageCapacity);
            Common.setValue(tbSlope, currentBMP().BufferWidthSlope);

            setOutputText();
        }

        private void getValues()
        {
            currentBMP().BufferW = Common.getDouble(tbW,10.0,30.0);
            currentBMP().BufferL = Common.getDouble(tbL);
            currentBMP().BufferDepth = Common.getDouble(tbD, 1.0, 2.0);
            currentBMP().BufferFeederWidth = Common.getDouble(tbFeederW);
            currentBMP().SoilStorageCapacity = Common.getDouble(tbStorage);
            currentBMP().BufferWidthSlope = Common.getDouble(tbSlope, 2.0, 20.0);

            setValues();
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
            getValues();
            currentBMP().Calculate();
            setOutputText();
            Common.ShowVFSPlot(currentBMP());
        }

        private void btnCost_Click(object sender, EventArgs e)
        {
            getValues();
            Form form = new frmCostAnalysis(currentBMP());
            form.ShowDialog();
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            // Also have to cache status of Do Ground Water Analysis
            String dGWA = Globals.Project.DoGroundwaterAnalysis;
            getValues();
            Form form = new frmMediaMix(currentBMP());
            form.ShowDialog();
            Globals.Project.DoGroundwaterAnalysis = dGWA;
            currentBMP().Calculate();
            setValues();
        }
    }
}
