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
    public partial class frmMediaFilterArea : Form
    {
        public int SelectedCatchment;
        public double DCIA;
        public double TD;
        public double Rate;
        public double PondArea;
        public double PerviousArea;
        public double CN;
        public double Filter;
        public double EIA;
        public double EIAPerv;
        public double RunoffVolPerv;
        public double SP;
        public string Mix;
        

        public frmMediaFilterArea()
        {
            InitializeComponent();
        }

        private void cbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This is selecting a new Catchment
            // Values are set from the Catchment
            SetValuesFromCatchment();
            if (SelectedCatchment == 0) return;
            lblBMP.Visible = true;
            cbBMP.Visible = true;
            SetBMPs();
        }

        private void frmMediaFilterArea_Load(object sender, EventArgs e)
        {
            SetCatchments();
            MediaMix.PopulateComboBox(cbMixes);

        }

        private void SetCatchments()
        {
            int n = Globals.Project.numCatchments;
            Dictionary<int, string> d = new Dictionary<int, string>();
            d.Add(0, "None - Enter EIA");
            for (int i = 1; i <= n; i++)
            {
                d.Add(i, "Catchment " + i.ToString());
            }
            cbTo.DataSource = new BindingSource(d, null);
            cbTo.DisplayMember = "Value";
            cbTo.ValueMember = "Key";
        }

        private Catchment GetCatchment()
        {
            SelectedCatchment = GetSelectedCatchmentNumber();
            if (SelectedCatchment != 0)
            {
                Catchment c = Globals.Project.getCatchment(SelectedCatchment);
                return c;
            }
            return new Catchment();
        }

        private void SetBMPs()
        {
            List<string> l = currentCatchment().getAvailableBMPs();

            cbBMP.Items.Clear();
            cbBMP.Items.AddRange(l.ToArray());
        }

        private Catchment currentCatchment()
        {
            SelectedCatchment = GetSelectedCatchmentNumber();
            return Globals.Project.getCatchment(SelectedCatchment);
        }


        private void SetValuesFromCatchment()
        {
            TD = Common.getDouble(tbTD);
            Rate = Common.getDouble(tbRate);
            
            SelectedCatchment = GetSelectedCatchmentNumber();
            if (SelectedCatchment != 0)
            {
                Catchment c = Globals.Project.getCatchment(SelectedCatchment);
                lblName.Text = c.CatchmentName;
                Common.setValue(cbMixes, c.getSelectedBMP().MediaMixType);
                Common.setValue(tbTD, c.getSelectedBMP().RetentionDepth, 3);
                Common.setValue(tbP, c.getSelectedBMP().HydraulicCaptureEfficiency, 0);
                if (c.getSelectedBMP().hasMediaMix()) Common.setValue(cbMixes, c.getSelectedBMP().MediaMixType.Replace('_', '&'));
            }
            else
            {
                lblName.Text = "";
                tbEIA.Enabled = true;
                EIA = Common.getDouble(tbEIA);
            }

            if (Rate == 0) return;


            if (Calculate()) PrintResults(); ;
        }


        private int GetSelectedCatchmentNumber()
        {
            try { 
                int _SelectedCatchment = Convert.ToInt32(cbTo.SelectedValue);
                if (_SelectedCatchment == 0)
                {
                    lblName.Visible = false;
                    tbEIA.Enabled = true;
                    return 0;
                }
                else
                {
                    lblName.Visible = true;
                    tbEIA.Enabled = false;
                    return _SelectedCatchment;
                }

            }
            catch
            {
                tbEIA.Enabled = false;
                return 0;
            }
        }

        private bool CalculateEIA()
        {
            if (CN == 0) return false;
            SP = 1000 / CN - 10;
            if (0.2 * SP < TD)
                RunoffVolPerv = Math.Pow((TD - 0.2 * SP), 2) / (TD + 0.8 * SP);
            else
                RunoffVolPerv = 0;

            if (TD == 0) return false;
            EIAPerv = RunoffVolPerv * PerviousArea / TD;

            EIA = EIAPerv + DCIA + PondArea;

            tbEIA.Enabled = false;
            Common.setValue(tbEIA, EIA, 2);
            return true;
        }

        private bool Calculate()
        {
            TD = Common.getDouble(tbTD);
            Rate = Common.getDouble(tbRate);

            SelectedCatchment = GetSelectedCatchmentNumber();
            if (SelectedCatchment != 0)
            {
                Catchment c = Globals.Project.getCatchment(SelectedCatchment);

                Mix = Common.getString(cbMixes);
                DCIA = c.PostDCIAPercent / 100 * (c.PostArea - c.BMPArea);
                PondArea = c.BMPArea;
                CN = c.PostNonDCIACurveNumber;
                PerviousArea = (100 - c.PostDCIAPercent) / 100 * (c.PostArea - PondArea);
                tbEIA.Enabled = false;

                CalculateEIA();
            }
            else
            {
                EIA = Common.getDouble(tbEIA);
            }

            if (Rate == 0) return false;
            //Filter = EIA * TD * 18.85 /  Rate;
            Filter = EIA * TD * 9.425 / Rate;
            //if ((Mix == MediaMix.BnG_CTS12) || (Mix == MediaMix.BnG_CTS24) || (Mix == MediaMix.SAT)) Filter = EIA * TD * 181.185 / Rate;
            //if ((Mix == MediaMix.BnG_ECT) || (Mix == MediaMix.BnG_ECT3) || (Mix == MediaMix.BnG_OTE)) Filter = EIA * TD * 9.429 / Rate;

            return true;
        }


        private void PrintResults()
        {
            string s = "<h1>Media Filter Report</h1>";
            if (SelectedCatchment != 0 ) s += "Catchment Name: " + Globals.Project.getCatchment(SelectedCatchment).CatchmentName + "<br/>";
            s += " Treatment Depth (in): " + Common.getString(TD, 2) + "<br/>";
            s += " Rate (GPM/SF): " + Common.getString(Rate, 2) + "<br/>";
            s += " Effective Impervious Area (acres): " + Common.getString(EIA, 2) + "<br/>";
            s += " Minimum Filter Area (sf): " + Common.getString(Filter, 2) + "<br/><br/>";
            s += " Treatment rate includes the safety factor<br/>";

            wbOutput.DocumentText = s;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Calculate(); PrintResults();
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

        private void cbMixes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mix = Common.getString(cbMixes);
            Common.setValue(tbRate, MediaMix.GPM_SF(cbMixes.Text), 3);
            Common.setValue(tbN, MediaMix.TNRemoval(Mix), 1);
            Common.setValue(tbP, MediaMix.TPRemoval(Mix), 1);

            Calculate();
        }

        private void cbBMP_SelectedIndexChanged(object sender, EventArgs e)
        {
            BMP bmp = currentCatchment().getBMP(Common.getString(cbBMP));
            if (bmp.hasMediaMix()) Common.setValue(cbMixes, bmp.MediaMixType.Replace('_', '&'));
        }
    }
}
