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
    public partial class frmRetentionEfficiencyLUT : Form
    {
        string RainfallZone;
        double NDCIACN;
        double DCIAP;
        double Efficiency;
        double RetentionDepth;

        LookupTable lutLower;
        LookupTable lutUpper;
        LookupTable lut;

        public frmRetentionEfficiencyLUT()
        {
            InitializeComponent();
        }

        private void frmRetentionEfficiencyLUT_Load(object sender, EventArgs e)
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
            Common.setValue(tbTable, Efficiency, 1);
            Common.setValue(tbDepth, RetentionDepth, 2);
            wbReport.DocumentText = lut.AsHtml();
        }
        private void getValues()
        {
            RainfallZone = Common.getString(cbMetZone);
            NDCIACN = Common.getDouble(tbRow);
            DCIAP = Common.getDouble(tbColumn);
            Efficiency = Common.getDouble(tbTable);
            RetentionDepth = Common.getDouble(tbDepth);
            CalculateLUT();
        }

        private void CalculateLUT()
        {
            string LowerDepth = RetentionEfficiencyLookupTables.getLowerDepth(RetentionDepth);
            string UpperDepth = RetentionEfficiencyLookupTables.getUpperDepth(RetentionDepth);

            lutLower = StaticLookupTables.RetentionEfficiencyTable(LowerDepth, RainfallZone);
            lutUpper = StaticLookupTables.RetentionEfficiencyTable(UpperDepth, RainfallZone);

            if (LowerDepth == UpperDepth)
            {
                lut = lutLower;
            }
            else
            {
                lut = RetentionEfficiencyLookupTables.getLookupTable(RetentionDepth, RainfallZone);
            }
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            getValues();
            Efficiency = RetentionEfficiencyLookupTables.CalculateEfficiency(RetentionDepth, NDCIACN, DCIAP, RainfallZone);
            setValues();
        }

        private void btnRow_Click(object sender, EventArgs e)
        {
            getValues();
            NDCIACN = lut.CalculateRowValue(DCIAP, Efficiency);
            if (NDCIACN < 30) NDCIACN = 30;
            if (NDCIACN > 98) NDCIACN = 98;
            setValues();
        }

        private void btnColumn_Click(object sender, EventArgs e)
        {
            getValues();
            DCIAP = lut.CalculateColumnValue(NDCIACN, Efficiency);
            if (DCIAP > 100) DCIAP = 100;
            if (DCIAP < 0) DCIAP = 0;
            setValues();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.wbReport.Document.Focus();
            SendKeys.SendWait("^a");
            SendKeys.SendWait("^a^c");
        }
    }
}
