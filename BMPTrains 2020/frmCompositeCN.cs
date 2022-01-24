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
    public partial class frmCompositeCN : Form
    {
        const int maxRows = 20;
        double[] CCNs;
        double[] areas;
        double[] Cs;
        double[] wC;

        double averageWC;
        double CCN;
        double DCIA;

        bool preflag = true;
        Catchment c;

        public frmCompositeCN(Catchment _c, bool pre = true)
        {
            InitializeComponent();
            CCNs= new double[maxRows];
            areas = new double[maxRows];
            Cs = new double[maxRows];
            wC = new double[maxRows];

            c = _c;
            preflag = pre;
            if (pre)
            { 
                CCNs = XmlPropertyObject.AsDoubleArray(c.PreCompositeCN, maxRows);
                areas = XmlPropertyObject.AsDoubleArray(c.PreCompositeArea, maxRows);
                DCIA = c.PreDCIAPercent;
            }
            else
            {
                CCNs = XmlPropertyObject.AsDoubleArray(c.PostCompositeCN, maxRows);
                areas = XmlPropertyObject.AsDoubleArray(c.PostCompositeArea, maxRows);
                DCIA = c.PostDCIAPercent;
            }
        }

        private void frmCompositeCN_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(maxRows);
            dataGridView1.Columns[2].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.LightGray;

            Calculate();
            SetValues();
        }

        private void SetValues()
        {
            for (int i = 0; i < CCNs.Length; i++)
            {
                try
                {
                    dataGridView1[0, i].Value = XmlPropertyObject.AsString(areas[i], 3);
                    dataGridView1[1, i].Value = XmlPropertyObject.AsString(CCNs[i], 0);
                    dataGridView1[2, i].Value = XmlPropertyObject.AsString(Cs[i], 3);
                    dataGridView1[3, i].Value = XmlPropertyObject.AsString(wC[i], 3);
                }
                catch
                {

                }
            }

            lblWC.Text = XmlPropertyObject.AsString(averageWC, 3);
            lblDCIA.Text = XmlPropertyObject.AsString(DCIA, 1);
            if ((CCN > 30) && (CCN < 100))  lblCN.Text = XmlPropertyObject.AsString(CCN, 2);

        }

        private void GetValues()
        {
            for (int i = 0; i < maxRows; i++)
            {
                try
                { 
                areas[i] = Convert.ToDouble(dataGridView1[0, i].Value);
                CCNs[i] = Convert.ToDouble(dataGridView1[1, i].Value);
                }
                catch
                {
                    areas[i] = 0;
                    CCNs[i] = 0;
                }
            }

            if (preflag)
            {
                c.PreCompositeCN = XmlPropertyObject.AsString(CCNs, 2);
                c.PreCompositeArea = XmlPropertyObject.AsString(areas, 2);
            }
            else
            {
                c.PostCompositeCN = XmlPropertyObject.AsString(CCNs, 2);
                c.PostCompositeArea = XmlPropertyObject.AsString(areas, 2);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            GetValues();
            Calculate();
            SetValues();
            DialogResult d = MessageBox.Show(
              "Do you want to use this value as the Curve Number? CCN = " + XmlPropertyObject.AsString(CCN, 2)
            , "Use Composite Curve Number?"
            , MessageBoxButtons.YesNo
            , MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                if (preflag)
                {
                    c.PreNonDCIACurveNumber = CCN;
                    ((frmWatershedCharacteristics)this.Owner).setPreCN(CCN);
                }
                else
                {
                    c.PostNonDCIACurveNumber = CCN;
                    ((frmWatershedCharacteristics)this.Owner).setPostCN(CCN);

                }
            }


            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            GetValues();
            Calculate();
            SetValues();
        }

        private void Calculate()
        {
            Cs = c.CalculateWeightedC(preflag);
            wC = c.CalculateAWeightedC(areas, Cs);
            averageWC = Common.GetSumOfDouble(wC, maxRows);

            CCN = c.CalculateCCN(averageWC, DCIA);

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                DataGridViewColumn oCurrentCol = dataGridView1.Columns.GetFirstColumn(DataGridViewElementStates.Visible);

                    do
                    {
                        s = s + oCurrentCol.HeaderText + "\t";
                        oCurrentCol = dataGridView1.Columns.GetNextColumn(oCurrentCol, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                    }
                    while (oCurrentCol != null);
                    s = s.Substring(0, s.Length - 1);
                    s = s + Environment.NewLine;    //Get rows
                                  
                    for (int i = 0; i < maxRows; i++)
                    {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    oCurrentCol = dataGridView1.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
                        if (Convert.ToDouble(dataGridView1[0, i].Value) != 0)
                        {
                            do
                            {
                                if (row.Cells[oCurrentCol.Index].Value != null) s = s + row.Cells[oCurrentCol.Index].Value.ToString();
                                s = s + "\t";
                                oCurrentCol = dataGridView1.Columns.GetNextColumn(oCurrentCol, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                            }
                            while (oCurrentCol != null);
                            s = s.Substring(0, s.Length - 1);
                            s = s + Environment.NewLine;

                        }

                    }
                
                Clipboard.SetText(s);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            string s = Clipboard.GetText();
            try
            {
                string[] lines = s.Replace("\n", "").Split('\r');

                //dataGridView1.Rows.Add(lines.Length - 1);
                string[] fields;
                int row = 0;
                int col = 0;

                foreach (string item in lines)
                {
                    fields = item.Split('\t');
                    foreach (string f in fields)
                    {
                        Console.WriteLine(f);
                        dataGridView1[col, row].Value = f;
                        col++;
                    }
                    row++;
                    col = 0;
                }
            }
            catch { }
        }
    }
}
