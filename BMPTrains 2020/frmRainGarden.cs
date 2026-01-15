using BMPTrains_2020.DomainCode;
using System;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmRainGarden : Form
    {
        int currentCatchmentID;
        public frmRainGarden(int id)
        {
            InitializeComponent();
            currentCatchmentID = id;
            currentBMP().SetValuesFromCatchment(currentCatchment());
        }

        private void frmRainGarden_Load(object sender, EventArgs e)
        {
            cbMixes.DataSource = new BindingSource(MediaMix.MediaMixes(), null);
            cbMixes.DisplayMember = "Key";
            cbMixes.ValueMember = "Key";

            cbSystemType.DataSource = new BindingSource(RainGarden.SystemTypes, null);

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

        private RainGarden currentBMP()
        {
            // Add a custom version for each BMP edit form
            return currentCatchment().getRainGarden();
        }

        private void setOutputText()
        {
            // Add to each form
            //wbOutput.DocumentText = currentBMP().BasicReport();
            wbOutput.DocumentText = currentBMP().PrintBMPReport();

        }

        private void setValues()
        {                        
            Common.setValue(cbSystemType, currentBMP().RetentionOrDetention);
            Common.setValue(cbMixes, currentBMP().MediaMixType);
            Common.setValue(tbMediaMix, currentBMP().MediaMixType);
            Common.setValue(tbVoidFraction, currentBMP().VoidFraction);
            Common.setValue(tbMediaVolume, currentBMP().MediaVolume);
            Common.setValue(tbWaterAboveMedia, currentBMP().WaterAboveMedia);
            Common.setValue(tbMediaArea, currentBMP().CreditForCoverCrop);
            
            setMediaValues();
            setOutputText();
        }

        private void setMediaValues()
        {
            if (Common.getString(cbMixes) != MediaMix.User_Defined)
            {
                tbTN.Enabled = false;
                Common.setValue(tbTN, MediaMix.TNRemoval(currentBMP().MediaMixType));
                tbTP.Enabled = false;
                Common.setValue(tbTP, MediaMix.TPRemoval(currentBMP().MediaMixType));
            }
            else
            {
                tbTN.Enabled = true;
                Common.setValue(tbTN, currentBMP().MediaNPercentReduction);
                tbTP.Enabled = true;
                Common.setValue(tbTP, currentBMP().MediaPPercentReduction);
            }
        }

        private void getValues()
        {
            currentBMP().RetentionOrDetention = Common.getString(cbSystemType);
            currentBMP().MediaMixType = Common.getString(cbMixes);
            currentBMP().VoidFraction = Common.getDouble(tbVoidFraction);
            currentBMP().MediaVolume = Common.getDouble(tbMediaVolume);
            currentBMP().WaterAboveMedia = Common.getDouble(tbWaterAboveMedia);
            currentBMP().CreditForCoverCrop = Common.getDouble(tbMediaArea);

            if (currentBMP().MediaMixType != MediaMix.User_Defined)
            {
                currentBMP().MediaNPercentReduction = MediaMix.TNRemoval(currentBMP().MediaMixType);
                currentBMP().MediaPPercentReduction = MediaMix.TPRemoval(currentBMP().MediaMixType);
            }
            else
            {
                currentBMP().MediaNPercentReduction = Common.getDouble(tbTN); 
                currentBMP().MediaPPercentReduction = Common.getDouble(tbTP);
            }
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

        private void cbSystemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
            Common.ShowRetentionPlot(currentBMP(), "Rain Garden (retention) System Efficiency");
        }

        private void btnCost_Click(object sender, EventArgs e)
        {
            Form form = new frmCostAnalysis(currentBMP());
            form.ShowDialog();
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

        private void cbMixes_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cbMixes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbMixes_TextChanged(object sender, EventArgs e)
        {
            setMediaValues();
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            Form form = new frmMediaMix(currentBMP());
            form.ShowDialog();
            setValues();
        }
    }
}
