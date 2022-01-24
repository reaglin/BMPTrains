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
    public partial class frmTableViewer : Form
    {
        LookupTable lut;
        public frmTableViewer(LookupTable l)
        {
            InitializeComponent();
            lut = l;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wbReport.Print();
        }

        private void frmTableViewer_Load(object sender, EventArgs e)
        {
            wbReport.DocumentText = lut.AsHtml();
            toolTip1.SetToolTip(tbRow, lut.RowTitle);
            toolTip1.SetToolTip(tbColumn, lut.ColumnTitle);
            toolTip1.SetToolTip(tbTable, lut.TableDescription);
        }

        private void btnRow_Click(object sender, EventArgs e)
        {
            double c = Common.getDouble(tbColumn);
            double t = Common.getDouble(tbTable);

            double r = lut.CalculateRowValue(c, t);
            Common.setValue(tbRow, r);
        }

        private void btnColumn_Click(object sender, EventArgs e)
        {
            double r = Common.getDouble(tbRow);
            double t = Common.getDouble(tbTable);

            double c = lut.CalculateColumnValue(r, t);
            Common.setValue(tbColumn, c);
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            double r = Common.getDouble(tbRow);
            double c = Common.getDouble(tbColumn);

            double t = lut.Calculate(r, c);
            Common.setValue(tbTable, t);
        }
    }
}
