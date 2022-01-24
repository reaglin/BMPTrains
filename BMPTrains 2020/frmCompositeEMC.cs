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
    public partial class frmCompositeEMC : Form
    {
        const int maxRows = 20;
        double[] EMCs;
        double[] CCNs;
        double[] areas;
        double[] Cs;
        double[] wC;

        double averageWC;
        double EMC;
        double dCCN;
        double DCIA;
        bool NitrogenFlag = true;
        bool preflag = true;

        string preString;
        string NString;
        Catchment c;

        public frmCompositeEMC(Catchment _c, bool pre = true, bool Nitrogen = true)
        {
            InitializeComponent();
            EMCs= new double[maxRows];
            CCNs = new double[maxRows];
            areas = new double[maxRows];
            Cs = new double[maxRows];
            wC = new double[maxRows];

            c = _c;
            preflag = pre;
            NitrogenFlag = Nitrogen;

            if (pre)
            {
                preString = "Pre-Development";
                CCNs = XmlPropertyObject.AsDoubleArray(c.PreCompositeCN, maxRows);
                if (Nitrogen) {
                    EMCs = XmlPropertyObject.AsDoubleArray(c.PreNCompositeEMC, maxRows);
                    NString = "Total Nitrogen";
                } else
                {
                    EMCs = XmlPropertyObject.AsDoubleArray(c.PrePCompositeEMC, maxRows);
                    NString = "Total Phosphorus";
                }
                areas = XmlPropertyObject.AsDoubleArray(c.PreCompositeArea, maxRows);
                DCIA = c.PreDCIAPercent;
            }
            else
            {
                preString = "Post-Development";
                CCNs = XmlPropertyObject.AsDoubleArray(c.PostCompositeCN, maxRows);
                if (Nitrogen) {
                    EMCs = XmlPropertyObject.AsDoubleArray(c.PostNCompositeEMC, maxRows);
                    NString = "Total Nitrogen";
                } else {
                    EMCs = XmlPropertyObject.AsDoubleArray(c.PostPCompositeEMC, maxRows);
                    NString = "Total Phosphorus";
                }
                areas = XmlPropertyObject.AsDoubleArray(c.PostCompositeArea, maxRows);
                DCIA = c.PostDCIAPercent;
            }
        }

        private void frmCompositeEMC_Load(object sender, EventArgs e)
        {
            this.Text += "  " + preString + " " + NString;
            dataGridView1.Rows.Add(maxRows);
            dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.Columns[4].DefaultCellStyle.BackColor = Color.LightGray;

            Calculate();
            SetValues();
        }

        private void SetValues()
        {
            for (int i = 0; i < EMCs.Length; i++)
            {
                try
                {
                    dataGridView1[0, i].Value = XmlPropertyObject.AsString(areas[i], 3);                    
                    dataGridView1[1, i].Value = XmlPropertyObject.AsString(EMCs[i], 3);
                    dataGridView1[2, i].Value = XmlPropertyObject.AsString(CCNs[i], 0);
                    dataGridView1[3, i].Value = XmlPropertyObject.AsString(Cs[i], 3);                  
                    dataGridView1[4, i].Value = XmlPropertyObject.AsString(wC[i], 3);
                }
                catch
                {

                }
            }

            lblWC.Text = XmlPropertyObject.AsString(averageWC, 3);
            lblDCIA.Text = XmlPropertyObject.AsString(DCIA, 1);
            lblCN.Text = XmlPropertyObject.AsString(EMC, 3);

        }

        private void GetValues()
        {
            for (int i = 0; i < maxRows; i++)
            {
                areas[i] = Convert.ToDouble(dataGridView1[0, i].Value);
                EMCs[i] = Convert.ToDouble(dataGridView1[1, i].Value);
                CCNs[i] = Convert.ToDouble(dataGridView1[2, i].Value);
            }

            if (preflag)
            {
                c.PreCompositeCN = XmlPropertyObject.AsString(CCNs, 0);
                if (NitrogenFlag) c.PreNCompositeEMC = XmlPropertyObject.AsString(EMCs, 3); else c.PrePCompositeEMC = XmlPropertyObject.AsString(EMCs, 3);
                c.PreCompositeArea = XmlPropertyObject.AsString(areas, 2);
            }
            else
            {
                c.PostCompositeCN = XmlPropertyObject.AsString(CCNs, 0);
                if (NitrogenFlag) c.PostNCompositeEMC = XmlPropertyObject.AsString(EMCs, 3); else c.PostPCompositeEMC = XmlPropertyObject.AsString(EMCs, 3);
                c.PostCompositeArea = XmlPropertyObject.AsString(areas, 2);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            GetValues();
            Calculate();
            SetValues();
            DialogResult d = MessageBox.Show(
              "Do you want to use this value as the Event Mean Concentration? EMC = " + XmlPropertyObject.AsString(EMC, 3)
            , "Use Event Mean Concentration?"
            , MessageBoxButtons.YesNo
            , MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                if (preflag)
                {
                    if (NitrogenFlag) { 
                    c.PreNConcentration = Math.Round(EMC,3);
                    ((frmWatershedCharacteristics)this.Owner).setPreNEMC(Math.Round(EMC,3));
                    }
                    else
                    {
                        c.PrePConcentration = Math.Round(EMC);
                        ((frmWatershedCharacteristics)this.Owner).setPrePEMC(Math.Round(EMC,3));
                    }
                }
                else
                {
                    if (NitrogenFlag)
                    {
                        c.PostNConcentration = Math.Round(EMC,3);
                        ((frmWatershedCharacteristics)this.Owner).setPostNEMC(Math.Round(EMC,3));
                    }
                    else
                    {
                        c.PostPConcentration = Math.Round(EMC,3);
                        ((frmWatershedCharacteristics)this.Owner).setPostPEMC(Math.Round(EMC,3));
                    }

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

            dCCN = c.CalculateCCN(averageWC, DCIA);
            EMC = c.CalculateWeightedEMC(preflag, NitrogenFlag);

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
