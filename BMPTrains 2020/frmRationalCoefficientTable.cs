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
    public partial class frmRationalCoefficientTable : Form
    {
        string RainfallZone;
        double NDCIACN;
        double DCIAP;
        double RationalC;
        LookupTable lut;

        public frmRationalCoefficientTable()
        {
            InitializeComponent();
        }

        private void frmRationalCoefficientTable_Load(object sender, EventArgs e)
        {
            // Bind Meteorological Zones to Combo
            cbMetZone.Items.Clear();

            BindingSource bs = new BindingSource();
            bs.DataSource = StaticLookupTables.RainfallZones();

            cbMetZone.DataSource = bs;
            Common.setValue(cbMetZone, Globals.Project.RainfallZone);

        }

        private void setValues()
        {
            Common.setValue(cbMetZone, Globals.Project.RainfallZone);
            Common.setValue(tbRow, NDCIACN, 1);
            Common.setValue(tbColumn, DCIAP, 1);
            Common.setValue(tbTable, RationalC, 3);
        }
        private void getValues()
        {
            RainfallZone = Common.getString(cbMetZone);
            NDCIACN = Common.getDouble(tbRow);
            DCIAP = Common.getDouble(tbColumn);
            RationalC = Common.getDouble(tbTable);

            lut = StaticLookupTables.RationalCoeffientLookupTable(RainfallZone);
            wbReport.DocumentText = lut.AsHtml();
        }

        private void btnRow_Click(object sender, EventArgs e)
        {
            getValues();
            NDCIACN = lut.CalculateRowValue(DCIAP,RationalC);
            setValues();
        }

        private void btnColumn_Click(object sender, EventArgs e)
        {
            getValues();
            DCIAP = lut.CalculateColumnValue(NDCIACN, RationalC);
            setValues();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            getValues();
            RationalC = lut.CalculateTableValue(NDCIACN, DCIAP);
            setValues();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.wbReport.Document.Focus();
            SendKeys.SendWait("^a");
            SendKeys.SendWait("^a^c");
        }
    }
}
