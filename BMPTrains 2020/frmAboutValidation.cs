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
    public partial class frmAboutValidation : Form
    {
        public frmAboutValidation()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnWebsite_Click(object sender, EventArgs e)
        {
            BMPTrainsProject.openRawURL(BMPTrainsProject.URL_Website);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
