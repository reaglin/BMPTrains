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
    public partial class frmNewCatchment : Form
    {
        public frmNewCatchment()
        {
            InitializeComponent();
        }

        private void frmNewCatchment_Load(object sender, EventArgs e)
        {
            DisplayToOptions(cbTo);
            DisplayToOptions(cbC1);
            DisplayToOptions(cbC2);

        }

        private void DisplayToOptions(ComboBox cb)
        {
            int n = Globals.Project.numCatchments;
            Dictionary<int, string> d = new Dictionary<int, string>();
            for (int i = 1; i <= n; i++)
            {
                    d.Add(i, "Catchment " + i.ToString());
            }
            cb.DataSource = new BindingSource(d, null);
            cb.DisplayMember = "Value";
            cb.ValueMember = "Key";
        }

        private void btnCreateNewBlank_Click(object sender, EventArgs e)
        {
            ((frmWatershedCharacteristics)this.Owner).addCatchment(Globals.Project.getNewCatchment().id);
            this.Close();
        }

        private void btnCreateCopy_Click(object sender, EventArgs e)
        {
            int copyID = Convert.ToInt32(cbTo.SelectedValue);
            if (copyID == 0) return;

            // The owner of this form has an addCatchment method that must be called. 
            // Project AddCatchment
            ((frmWatershedCharacteristics)this.Owner).addCatchment(Globals.Project.AddCatchment(copyID).id);
            this.Close();

        }

        private void btnCreateSum_Click(object sender, EventArgs e)
        {
            int copyId1 = Convert.ToInt32(cbC1.SelectedValue);
            int copyId2 = Convert.ToInt32(cbC2.SelectedValue);

            if (copyId1 == 0) return;
            if (copyId2 == 0) return;

            ((frmWatershedCharacteristics)this.Owner).addCatchment(Globals.Project.AddCatchment(copyId1, copyId2).id);
            this.Close();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
