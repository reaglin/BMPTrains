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
    public partial class frmPlottingREVCurves : frmPlotting
    {
        private readonly Harvesting harvest;
        public frmPlottingREVCurves(Harvesting h)
        {
            harvest = h;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Height = base.Height;
            this.Width = base.Width;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitializeComponent();
        }

            private void fromPlottingREVCurves_Load(object sender, EventArgs e)
        {
            harvest.CreateREVScatterPlot(base.BaseChart());
        }
    }
}
