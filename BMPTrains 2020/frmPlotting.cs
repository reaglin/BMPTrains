using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BMPTrains_2020.DomainCode;

namespace BMPTrains_2020
{
    public partial class frmPlotting : Form
    {

        private readonly Harvesting harvest;
        
        public frmPlotting(Harvesting h)
        {
            harvest = h;
            InitializeComponent();
        }


        private void Plotting_Load(object sender, EventArgs e)
        {
            harvest.CreateREVScatterPlot(chart1); 

        }




    }
}
