using BMPTrains_2020.DomainCode;
using System;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmTreatmentOptions : Form
    {
        public int currentCatchmentID;
        public frmTreatmentOptions(int id = 1)
        {
            InitializeComponent();
            currentCatchmentID = id;
        }

        private void frmTreatmentOptions_Load(object sender, EventArgs e)
        {
            pbOptions.Image = Globals.Project.getConfigurationImage();
            pbOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;

            InterfaceCommon.BuildCatchmentMenu(menuStrip1, MenuItemClickHandler);
            menuStrip1.Items[currentCatchmentID - 1].BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);

            if (!Globals.Project.CatchmentExists(1))
            {
                DialogResult d = MessageBox.Show("You need a defined Catchment to do Analysis - would you like to create one and data for one now?",
               "Create Catchment",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);

                if (d == DialogResult.Yes)
                {
                    Form form = new frmWatershedCharacteristics(1);
                    form.ShowDialog();
                }
            }
            SetButtonColors();
            this.Text += currentCatchment().TitleHeader();
        }

        private void SetButtonColors()
        {
            Catchment c = currentCatchment();
            lblCurrent.Text = c.id.ToString() + " " + c.CatchmentName;

            Common.SetButtonColor(c, c.getRetention(), btnRetention);
            Common.SetButtonColor(c, c.getWetDetention(), bthDetention);
            Common.SetButtonColor(c, c.getExfiltration(), btExfiltration);
            Common.SetButtonColor(c, c.getPerviousPavement(), btnPeriousPavement);
            Common.SetButtonColor(c, c.getStormwaterHarvesting(), btnStormwaterHarvesting);
            Common.SetButtonColor(c, c.getFiltration(), btnBiofiltration);
            Common.SetButtonColor(c, c.getSwale(), btnSwale);
            Common.SetButtonColor(c, c.getRainwaterHarvesting(), btnRainwater);
            Common.SetButtonColor(c, c.getVegetatedNaturalBuffer(), btnNaturalBuffer);
            Common.SetButtonColor(c, c.getGreenroof(), btnGreenroof);
            Common.SetButtonColor(c, c.getVegetatedFilterStrip(), btnFilterStrip);
            Common.SetButtonColor(c, c.getRainGarden(), btnRainGarden);
            Common.SetButtonColor(c, c.getTreeWell(), btnTreeWell);
            Common.SetButtonColor(c, c.getUserDefinedBMP(), btnUserDefined);
            Common.SetButtonColor(c, c.getMultipleBMP(), btnBMPs);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Catchment currentCatchment()
        {
            return Globals.Project.getCatchment(currentCatchmentID);
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            // This must be added to handle events from every form that edits objects associated with
            // Catchments.
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            InterfaceCommon.resetMenuColors(menuStrip1);
            clickedItem.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);
            currentCatchmentID = Convert.ToInt32(clickedItem.Name);

            SetButtonColors();
        }

        private void frmTreatmentOptions_MouseHover(object sender, EventArgs e)
        {
            pbOptions.Image = Globals.Project.getConfigurationImage();
            pbOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        }

        private void btnRetention_MouseHover(object sender, EventArgs e)
        {
            pbOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbOptions.Image = BMPTrains_2020.Properties.Resources.Retention;
        }

        private void bthDetention_MouseHover(object sender, EventArgs e)
        {
            pbOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbOptions.Image = BMPTrains_2020.Properties.Resources.Detention;
        }

        private void bthSwale_MouseHover(object sender, EventArgs e)
        {
            pbOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbOptions.Image = BMPTrains_2020.Properties.Resources.Swale;
        }

        private void btExfiltration_MouseHover(object sender, EventArgs e)
        {
            pbOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbOptions.Image = BMPTrains_2020.Properties.Resources.Exfiltation;
        }

        private void btnPeriousPavement_MouseHover(object sender, EventArgs e)
        {
            pbOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbOptions.Image = BMPTrains_2020.Properties.Resources.PerviousPavement;
        }

        private void btnStormwaterHarvesting_MouseHover(object sender, EventArgs e)
        {
            pbOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbOptions.Image = BMPTrains_2020.Properties.Resources.StormwaterHarvesting;
        }

        private void btnBiofiltration_MouseHover(object sender, EventArgs e)
        {
            pbOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbOptions.Image = BMPTrains_2020.Properties.Resources.Filtration;
        }

        private void btnReusePond_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnTreeWell_MouseHover(object sender, EventArgs e)
        {
            pbOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbOptions.Image = BMPTrains_2020.Properties.Resources.Treewell;
        }

        private void btnRainGarden_MouseHover(object sender, EventArgs e)
        {
            pbOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbOptions.Image = BMPTrains_2020.Properties.Resources.RainGarden2;
        }

        private void btnFilterStrip_MouseHover(object sender, EventArgs e)
        {
            pbOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbOptions.Image = BMPTrains_2020.Properties.Resources.VegBuffer;
        }

        private void btnNaturalBuffer_MouseHover(object sender, EventArgs e)
        {
            pbOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbOptions.Image = BMPTrains_2020.Properties.Resources.VegBuffer;
        }

        private void btnAquaticPlants_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnRainwater_MouseHover(object sender, EventArgs e)
        {
            pbOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbOptions.Image = BMPTrains_2020.Properties.Resources.RainwaterHarvesting;
        }

        private void btnGreenroof_MouseHover(object sender, EventArgs e)
        {
            pbOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbOptions.Image = BMPTrains_2020.Properties.Resources.Greenroof;
        }

        private void btnRetention_Click(object sender, EventArgs e)
        {
            Form form = new frmRetention(currentCatchmentID);
            form.ShowDialog();
            SetButtonColors();
        }

        private void btExfiltration_Click(object sender, EventArgs e)
        {
            Form form = new frmExfiltration(currentCatchmentID);
            form.ShowDialog();
            SetButtonColors();
        }

        private void bthDetention_Click(object sender, EventArgs e)
        {
            Form form = new frmWetDetention(currentCatchmentID);
            form.ShowDialog();
            SetButtonColors();
        }

        private void btnStormwaterHarvesting_Click(object sender, EventArgs e)
        {         
            Form form = new frmStormwaterHarvesting(currentCatchmentID);
            form.ShowDialog();
            SetButtonColors();
        }

        private void btnGreenroof_Click(object sender, EventArgs e)
        {
            Form form = new frmGreenroof(currentCatchmentID);
            form.ShowDialog();
            SetButtonColors();
        }

        private void btnRainGarden_Click(object sender, EventArgs e)
        {
            Form form = new frmRainGarden(currentCatchmentID);
            form.ShowDialog();
            SetButtonColors();
        }

        private void btnRainwater_Click(object sender, EventArgs e)
        {
            Form form = new frmRainwaterHarvesting(currentCatchmentID);
            form.ShowDialog();
            SetButtonColors();
        }

        private void buttonCalculators_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(currentCatchment().CatchmentCostCopy());

            Form form = new frmReport(currentCatchment().CostTableReport());
            form.ShowDialog();
        }

        private void btnPeriousPavement_Click(object sender, EventArgs e)
        {
            Form form = new frmPerviousPavment(currentCatchmentID);
            form.ShowDialog();
            SetButtonColors();
        }

        private void btnBiofiltration_Click(object sender, EventArgs e)
        {
            Form form = new frmFiltration(currentCatchmentID);
            form.ShowDialog();
            SetButtonColors();
        }

        private void bthSwale_Click(object sender, EventArgs e)
        {
            Form form = new frmSwale(currentCatchmentID);
            form.ShowDialog();
            SetButtonColors();
        }

        private void btnNaturalBuffer_Click(object sender, EventArgs e)
        {
            Form form = new frmVegetatedNaturalBuffer(currentCatchmentID);
            form.ShowDialog();
            SetButtonColors();
        }

        private void btnFilterStrip_Click(object sender, EventArgs e)
        {
            Form form = new frmVegetatedFilterStrip(currentCatchmentID);
            form.ShowDialog();
            SetButtonColors();
        }

        private void btnTreeWell_Click(object sender, EventArgs e)
        {
            Form form = new frmTreeWell(currentCatchmentID);
            form.ShowDialog();
            SetButtonColors();
        }

        private void btnUserDefined_Click(object sender, EventArgs e)
        {
            Form form = new frmUserDefined(currentCatchmentID);
            form.ShowDialog();
            SetButtonColors();
        }

        private void btnBMPs_Click(object sender, EventArgs e)
        {
            Form form = new frmMultipleBMP(currentCatchmentID);
            form.ShowDialog();
            SetButtonColors();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new frmWatershedCharacteristics(currentCatchmentID);
            form.ShowDialog();
            SetButtonColors();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("This will reset all values of all BMP's for this Catchment. Continue?",
                "Reset Catchment " + currentCatchmentID.ToString(),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (d == DialogResult.No) return;

            currentCatchment().ResetAll();
            SetButtonColors();
        }

        private void btnTools_Click(object sender, EventArgs e)
        {
            Form form = new frmCalculators();
            form.ShowDialog();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmReport form = new frmReport();
            form.setURL("https://roneaglin.online/projects/bmp-trains/");
            form.ShowDialog();
        }
    }
}
