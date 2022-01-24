using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMPTrains_2020.DomainCode;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmPervousPavementTypes : Form
    {
        PerviousPavement p;
        public frmPervousPavementTypes(PerviousPavement _p)
        {
            InitializeComponent();
            p = _p;
        }

        private void frmPervousPavementTypes_Load(object sender, EventArgs e)
        {
            AvailablePerviousPavements app = p.PerviousPavements;
            Dictionary<string, double> d = app.AsDictionary();
            var _app = from row in d select new { Description = row.Key, VoidSpace = row.Value };
            dataGridView1.DataSource = _app.ToArray();

            DataGridViewColumn c0 = dataGridView1.Columns[0];
            c0.Width = 280;
            c0.HeaderText = "Type";

            DataGridViewColumn c1 = dataGridView1.Columns[1];
            c1.Width = 150;
            c1.HeaderText = "Sustainable Void (%)";

            DataGridViewColumn c2 = new DataGridViewColumn();
            c2.Width = 150;
            c2.HeaderText = "Thickness (in)";
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            c2.CellTemplate = cell;

            dataGridView1.Columns.Add(c2);

            SetValues();
        }

        private void SetValues()
        {
            Common.setValue(tbSurfaceArea, p.SurfaceArea);
            Common.setValue(tbStorage, p.TotalStorage,2);

            double[] t = p.getThicknesses();
            for (int i = 0; i < t.Length; i++)
            {
                try
                { 
                    dataGridView1[2, i].Value = XmlPropertyObject.AsString(t[i],2);
                }
                catch
                {

                }
            }
        }

        private void GetValues()
        {
            p.SurfaceArea = Common.getDouble(tbSurfaceArea);
            double[] t = new double[dataGridView1.Rows.Count];
            for (int i = 0; i < t.Length; i++)
            {
                try
                {
                    t[i] = Convert.ToDouble(dataGridView1[2, i].Value);
                }
                catch
                {
                    t[i] = 0.0;
                }
            }
            p.setThicknesses(t);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            GetValues();
            p.Calculate();
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            GetValues();
            p.Calculate();
            SetValues();        
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

                int maxRows = dataGridView1.Rows.Count - 1; 
                for (int i = 0; i < maxRows; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    oCurrentCol = dataGridView1.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
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


                Clipboard.SetText(s);
            }
            catch (Exception ex)
            {
                return;
            }

        }
    }
}
