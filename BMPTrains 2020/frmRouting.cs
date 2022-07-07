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
    public partial class frmRouting : Form
    {
        public int routingID;
        public const string outlet = "Outlet";
        public frmRouting(int id)
        {
            InitializeComponent();
            routingID = id;
        }

        private void frmRouting_Load(object sender, EventArgs e)
        {
            btnEdit.Text = "Edit Catchment " + routingID.ToString();
            this.Text = "Routing Catchment From: " + routingID.ToString();
            lblFrom.Text = "Routing Catchment From: " + routingID.ToString();

            DisplayToOptions();
            DisplayDefinedBMPs();
            SetValues();
        }

        private void DisplayToOptions()
        {
            int n = Globals.Project.numCatchments;
            Dictionary<int, string> d = new Dictionary<int, string>();
            d.Add(0, outlet);            
            for (int i = 1; i <= n; i++)
            {
                if (i != routingID)
                {
                    d.Add(i, "Catchment " + i.ToString());
                }
            }
            cbTo.DataSource = new BindingSource(d, null);
            cbTo.DisplayMember = "Value";
            cbTo.ValueMember = "Key";

            int t = getCatchment().routing.ToID;
            if ( t > 0)
                cbTo.SelectedText = "Catchment " + t.ToString();
            else
                Common.setValue(cbTo, "Outlet");
        }

        private void DisplayDefinedBMPs()
        {
            //Catchment c = getCatchment();

            //if (getCatchment().PostArea == 0)
            //{
            //    DialogResult d = MessageBox.Show("This Catchment is Not Defined. Would you like to enter catchment characteristics?"
            //                                    , "Define Catchment?"
            //                                    , MessageBoxButtons.YesNo
            //                                    , MessageBoxIcon.Information);
            //    if (d == DialogResult.Yes)
            //    {
            //        Form form = new frmWatershedCharacteristics(routingID);
            //        form.ShowDialog();
            //        this.Close();
            //    }
            //    else
            //    {
            //        this.Close();
            //    }
            //}

            Dictionary<string, BMP> dbmp = getCatchment().DefinedBMPs();
            if (dbmp.Count == 0)
            {
                DialogResult d = MessageBox.Show("You have no BMPs defined for this Catchment, would you like to define a BMP?"
                                                , "Define BMP?"
                                                , MessageBoxButtons.YesNo
                                                , MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    Form form = new frmTreatmentOptions(routingID);
                    form.ShowDialog();
                    //this.Close();
                }
                else
                {
                    //this.Close();
                }
            }
            else
            {
                cbBMP.DataSource = new BindingSource(dbmp, null);
                cbBMP.DisplayMember = "Key";
                cbBMP.ValueMember = "Key";
            }

        }

        private Catchment getCatchment()
        {
            return Globals.Project.getCatchment(routingID);
        }

        private CatchmentRouting getRouting()
        {
            return Globals.Project.getRouting(routingID);
        }
        private void SetDelayTime()
        {
            Common.setValue(cbBMP, getCatchment().SelectedBMPType);
            //if (getCatchment().SelectedBMPType == BMPTrainsProject.sRetention)
            //{
                lblDelay.Visible = true;
                tbDelayTime.Visible = true;
                Common.setValue(tbDelayTime, getCatchment().getSelectedBMP().DelayTime);
            //}
            //else
            //{
            //    lblDelay.Visible = false;
            //    tbDelayTime.Visible = false;
            //}
        }

        private void SetValues()
        {
            // Setting Selected BMP
            SetDelayTime();
            
            //
            if (getRouting().ToID == 0)
            {
                Common.setValue(cbTo, outlet);
            }
            else
            {
                Common.setValue(cbTo, "Catchment " + getRouting().ToID.ToString());
            }

            if (getCatchment().Disabled)
            {
                lblActive.Text = "Catchment Disabled";
                btnDisable.Text = "Enable Catchment";
            }
            else
            {
                lblActive.Text = "Catchment Active";
                btnDisable.Text = "Disable Catchment";
            }

        }

        private void GetValues()
        {            
            getCatchment().SelectedBMPType = Common.getString(cbBMP);
            getCatchment().getSelectedBMP().DelayTime = Common.getDouble(tbDelayTime);

            try { getCatchment().setToRouting(Convert.ToInt32(cbTo.SelectedValue)); } catch { getRouting().ToID = 0; getCatchment().ToID = 0;  }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GetValues();
            this.Close();
        }

        private void lblFrom_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form form = new frmWatershedCharacteristics(routingID);
            form.ShowDialog();
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            if (getCatchment().Disabled) getCatchment().Disabled = false; else getCatchment().Disabled = true;
            SetValues();
        }

        private void btnEditBMP_Click(object sender, EventArgs e)
        {
            // Tricky - but need to bring up edit screen for the selected BMP
            GetValues();
            getCatchment().OpenSelectedBMPForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.Project.Calculate();
            Form form = new frmReport(Globals.Project.FlowBalanceReport(), false);
            form.ShowDialog();
        }
    }
}
