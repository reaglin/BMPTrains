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
    public partial class FormMeanAnnualRainfall : Form
    {
        public FormMeanAnnualRainfall()
        {
            InitializeComponent();
        }
        public FormMeanAnnualRainfall(GeneralSiteInformation f)
        {
            InitializeComponent();
            setImage(f.RainfallDefault);
        }

        public void setImage(Bitmap bm)
        {
            pbState.Image = bm;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            
            pbState.Image = BMPTrains_2020.Properties.Resources.RainfallMapOverall;
        }

        private void btnNW_Click(object sender, EventArgs e)
        {
            pbState.Image = BMPTrains_2020.Properties.Resources.RainfallMap_NW;
        }

       

        private void btnCentral_Click(object sender, EventArgs e)
        {
            pbState.Image = BMPTrains_2020.Properties.Resources.RainfallMap_Central;
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            pbState.Image = BMPTrains_2020.Properties.Resources.RainfallMap_South;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNE_Click(object sender, EventArgs e)
        {
            //rename remnant - leave
        }

        private void btnNE_Click_1(object sender, EventArgs e)
        {
            pbState.Image = BMPTrains_2020.Properties.Resources.RainfallMap_NE;
        }

        public void btnZones_Click(object sender, EventArgs e)
        {
            pbState.Image = BMPTrains_2020.Properties.Resources.RainfallZones;
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            pbState.Image = BMPTrains_2020.Properties.Resources.NOAA_2023;
            // DomainCode.Common.OpenURL(Globals.HelpURL);
            // Same for every edit form - URL will change
            // This allows us to have external help by pulling up a web site in the application
            //Form form = new frmHelp("https://stormwater.ucf.edu/research-publications/");
            //form.ShowDialog();
        }
    }
}
