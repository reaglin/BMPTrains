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
    public partial class frmCalculators : Form
    {
        public frmCalculators()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPerviousPavements_Click(object sender, EventArgs e)
        {
            DomainCode.Catchment c = new DomainCode.Catchment();
            DomainCode.PerviousPavement p = new DomainCode.PerviousPavement(c);
            Form form = new frmPervousPavementTypes(p);
            form.ShowDialog();
        }

        private void btnHarvestingEfficiency_Click(object sender, EventArgs e)
        {
            Form form = new frmTableViewer2(Globals.Project.getCatchment(1).getRainwaterHarvesting().getEfficiencyLUT());
            form.ShowDialog();
        }

        private void btnRationalC_Click(object sender, EventArgs e)
        {
            Form form = new frmRationalCoefficientTable();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new frmRetentionEfficiencyLUT();
            form.ShowDialog();
        }

        private void btnMediaFilterArea_Click(object sender, EventArgs e)
        {
            Form form = new frmMediaFilterArea();
            form.ShowDialog();
        }

        private void btnMediaServiceLife_Click(object sender, EventArgs e)
        {
            Form form = new frmMediaFilterServiceLife();
            form.ShowDialog();
        }

        private void btnHarvestingPlot_Click(object sender, EventArgs e)
        {
           // Form f = new frmPlotting();
            
            //Form form = new frmTableViewer2(Globals.Project.getCatchment(1).getRainwaterHarvesting().getEfficiencyLUT());
           // f.ShowDialog();
        }
    }
}
