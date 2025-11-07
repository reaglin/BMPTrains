using BMPTrains_2020.DomainCode;
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
    public partial class frmMediaMix : Form
    {
        Storage bmp;

        public frmMediaMix(Storage b)
        {
            InitializeComponent();
            bmp = b;
        }

        private void frmMediaMix_Load(object sender, EventArgs e)
        {
            MediaMix.PopulateComboBox(cbMixes);
            toolTip1.SetToolTip(cbMixes, MediaMix.ToString());
            setValues();
        }

        private void setValues()
        {

            Common.setValue(cbMixes, bmp.MediaMixType.Replace('_', '&'));
            Common.setValue(cbYesNo, bmp.WetDetentionEffluent);

            if (bmp.MediaMixType == MediaMix.User_Defined)
            {
                Common.setValue(tbTNReduction, bmp.MediaNPercentReduction);
                Common.setValue(tbTPReduction, bmp.MediaPPercentReduction);
            }
            else
            {
                SetMediaMixValues();
            }
            bmp.Calculate();
        }

        private void getValues()
        {
            bmp.MediaMixType = cbMixes.Text;
            bmp.MediaNPercentReduction = Common.getDouble(tbTNReduction);
            bmp.MediaPPercentReduction = Common.getDouble(tbTPReduction);
            bmp.WetDetentionEffluent = Common.getString(cbYesNo);
        }

        private void cbMixes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // getValues();
            if (!MediaMix.isDefined(cbMixes.Text)) return;
            bmp.MediaMixType = cbMixes.Text;

            //bmp.MediaNPercentReduction = Common.getDouble(tbTNReduction);
            //bmp.MediaPPercentReduction = Common.getDouble(tbTPReduction);
            
            SetMediaMixValues();
        }

        private void SetMediaMixValues()
        {
            bool WD = (cbYesNo.Text != "Yes"); 


            Common.setValue(tbTNReduction, MediaMix.TNRemoval(bmp.MediaMixType, bmp.MediaNPercentReduction, WD), 0);
            Common.setValue(tbTPReduction, MediaMix.TPRemoval(bmp.MediaMixType, bmp.MediaPPercentReduction, WD), 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            getValues();

            if (bmp.MediaMixType != MediaMix.None )
            {
                Globals.Project.DoGroundwaterAnalysis = "Yes";
                //DialogResult d = MessageBox.Show("The current Groundwater Analysis option is set to No, should it be set to Yes?"
                //                , "Define Catchment?"
                //                , MessageBoxButtons.YesNo
                //                , MessageBoxIcon.Information);
                //if (d == DialogResult.Yes)
                //{
                //    Globals.Project.DoGroundwaterAnalysis = "Yes";
                //    this.Close();
                //}
                //else
                //{
                //    this.Close();
                //}

            }

            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(BMPTrainsProject.URL_Documentation);

        }

        private void cbYesNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMediaMixValues();
        }
    }
}
