using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BMPTrains_2020.DomainCode;

namespace BMPTrains_2020
{
    public partial class frmMediaFilterServiceLife : Form
    {
        public int SelectedCatchment;

        public double AnnualOP;
        public double FilterVolumeProvided;
        public double SaturatedWeight;
        public double FractionOP;
        public double OPRemoved;
        public double OPCapacity;
        public double SorptionRate;
        public double ServiceLife;
        public double FilterVolume30Years;
        public double FilterVolumeForEfficiency;

        public frmMediaFilterServiceLife()
        {
            InitializeComponent();
        }

        public frmMediaFilterServiceLife(int sCatchment)
        {
            InitializeComponent();
            SelectedCatchment = sCatchment;
        }

        private void frmMediaFilterServiceLife_Load(object sender, EventArgs e)
        {
            if (SelectedCatchment == 0) SelectedCatchment = 1;
            SetCatchments();
        }

        private void SetBMPs()
        {
            List<string> l = currentCatchment().getAvailableBMPs();

            cbBMP.Items.Clear();
            cbBMP.Items.AddRange(l.ToArray());
        }

        private void SetCatchments()
        {
            int n = Globals.Project.numCatchments;
            Dictionary<string, string> d = new Dictionary<string, string>();
            for (int i = 1; i <= n; i++)
            {
                d.Add(i.ToString(), "Catchment " + i.ToString());
            }
            cbTo.DataSource = new BindingSource(d, null);
            cbTo.DisplayMember = "Value";
            cbTo.ValueMember = "Key";
            SelectedCatchment.ToString();
            SetBMPs();
        }

        private Catchment currentCatchment()
        {
            return Globals.Project.getCatchment(SelectedCatchment);
        }

        private double GetAnnualOP()
        {
            SelectedCatchment = Convert.ToInt32(cbTo.SelectedValue);
            if (SelectedCatchment == 0) return 0.0;
            Catchment c = Globals.Project.getCatchment(SelectedCatchment);

            if (Common.getString(cbBMP) == "") return 0.0;

            BMP bmp = c.getBMP(Common.getString(cbBMP));
            bmp.Calculate();

            Common.setValue(tbTD, bmp.PRetained, 3);

            if (bmp.BMPType == BMPTrainsProject.sRainGarden)
            {
                RainGarden rg = (RainGarden)bmp;
                Common.setValue(tbFilterVolume, rg.MediaVolume);
                //return bmp.BMPPMassLoadIn - bmp.BMPPMassLoadOut - bmp.GroundwaterPMassLoadOut;

                return bmp.PRetained;
            }

            if (bmp.BMPType == BMPTrainsProject.sFiltration) return bmp.BMPPMassLoadIn * bmp.ProvidedPTreatmentEfficiency / 100;
            //& (bmp.gr)) return bmp.PRetained; //
            
            return bmp.PRetained;
            return bmp.BMPPMassLoadOut * bmp.MediaPPercentReduction / 100;  
        }

        private void GetValues()
        {
            SelectedCatchment = Convert.ToInt32(cbTo.SelectedValue);
            AnnualOP = GetAnnualOP();
            FilterVolumeProvided = Common.getDouble(tbFilterVolume);
            FractionOP = Common.getDouble(tbOPFraction);
            SaturatedWeight = Common.getDouble(tbMediaWeight);
            SorptionRate = Common.getDouble(tbRate);
            
            if (Calculate()) PrintResults(); ;
        }

        private bool Calculate()
        {
            if (AnnualOP == 0) return false;
            if (FractionOP == 0) return false;

            OPRemoved = 1e6 * AnnualOP * FractionOP;
            OPCapacity = FilterVolumeProvided * SaturatedWeight * 454 * SorptionRate;

            if (OPRemoved == 0) return false;
            ServiceLife = OPCapacity / OPRemoved;

            if ((SaturatedWeight != 0)&&(SorptionRate != 0))
            {
                FilterVolume30Years = 30 * OPRemoved / (454 * SaturatedWeight * SorptionRate );
            }

            return true;
        }

        private void PrintResults()
        {
            BMP bmp = currentCatchment().getBMP(Common.getString(cbBMP));
            string s = "<h1>Media Filter Report</h1>";
            //s += "Catchment Name: Catchment " + SelectedCatchment.ToString() + "<br/>";
            if (bmp != null) { 
                s += "Treatment Depth (in): " + Common.getString(bmp.RetentionDepth, 2) + "<br/>";
            }
//            s += " Phosphorus Into Media Per Year (kg/yr): " + Common.getString(AnnualOP, 2) + "<br/>";
            s += " Phosphorus Removed per Year (kg OP/yr): " + Common.getString(OPRemoved/1e6, 2) + "<br/>";
            s += " Filter Capacity (kg OP): " + Common.getString(OPCapacity/1e6, 2) + "<br/>";
            s += " Sorption Rate (mg OP/g media): " + Common.getString(SorptionRate, 2) + "<br/>";
            s += " Filter Volume Provided (cf): " + Common.getString(FilterVolumeProvided, 2) + "<br/>";
            s += " Saturated Weight of Media (lbs/cf): " + Common.getString(SaturatedWeight, 2) + "<br/>";
            s += " Filter OP in TP (fraction): " + Common.getString(FractionOP, 2) + "<br/>";
            s += " Service Life (years): " + Common.getString(ServiceLife, 1) + "<br/>";
            //s += " Filter Volume for 30 Years Service Life (cf): " + Common.getString(FilterVolume30Years, 0) + "<br/>";

            wbOutput.DocumentText = s;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            GetValues();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            wbOutput.Print();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.wbOutput.Document.Focus();
            SendKeys.SendWait("^a");
            SendKeys.SendWait("^a^c");
        }

        private void cbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
                SelectedCatchment = Convert.ToInt32(cbTo.SelectedValue);
                Catchment c = Globals.Project.getCatchment(SelectedCatchment);
                lblName.Text = c.CatchmentName;
                SetBMPs();
            }
            catch
            {
                
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbBMP_SelectedIndexChanged(object sender, EventArgs e)
        {           
            Common.setValue(tbTD, GetAnnualOP(), 3);
            BMP bmp = currentCatchment().getBMP(Common.getString(cbBMP));
            Common.setValue(tbRate, MediaMix.SorptionRate(bmp.MediaMixType),2); //tbRate.Enabled = false;
            Common.setValue(tbMediaWeight, MediaMix.SaturatedWeight(bmp.MediaMixType)); //tbMediaWeight.Enabled = false;
            Common.setValue(tbFilterVolume, bmp.MediaVolume);
            
            GetValues();

        }
    }
}
