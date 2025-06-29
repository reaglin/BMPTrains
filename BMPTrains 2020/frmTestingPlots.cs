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
    public partial class frmTestingPlots : Form
    {
        public frmTestingPlots()
        {
            InitializeComponent();
        }

        private void frmTesting_Load(object sender, EventArgs e)
        {
            CreatePlot();
        }

        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        public void CreatePlot()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreatePlot();
        }
    }
}
