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
    public partial class frmCostScenario : Form
    {
        public frmCostScenario()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            Common.ShowCostScenarioPlot("ConstructionCost");
        }

        private void btnPV_Click(object sender, EventArgs e)
        {
            Common.ShowCostScenarioPlot("PresentValue");
        }

        private void btnAnnualRecovery_Click(object sender, EventArgs e)
        {
            Common.ShowCostScenarioPlot("AnnualCost");
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(Globals.Project.FullCostCopy());

            Form form = new frmReport(Globals.Project.FullCostReport());
            form.ShowDialog();
        }

        private void frmCostScenario_Load(object sender, EventArgs e)
        {
            AddColumns();
            DisplayScenarios();
            this.Text += " Version: " + Application.ProductVersion;
        }

        private void AddColumns()
        {
            dataGridView1.RowTemplate.Height = 40;
            DataGridViewTextBoxColumn c0 = new DataGridViewTextBoxColumn();
            c0.Width = 60;
            c0.HeaderText = "ID";
            c0.ReadOnly = true;

            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.Width = 100;
            c1.HeaderText = "Name";
            c1.ReadOnly = true;

            DataGridViewTextBoxColumn c1b = new DataGridViewTextBoxColumn();
            c1b.Width = 150;
            c1b.HeaderText = "BMP Type";
            c1b.ReadOnly = true;


            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.Width = 210;
            c2.HeaderText = "Description";
            c2.ReadOnly = true;

            DataGridViewButtonColumn c3 = new DataGridViewButtonColumn();
            c3.Width = 100;
            c3.Name = "btnEdit";
            c3.HeaderText = "Edit";
            c3.Text = "Edit";
            c3.UseColumnTextForButtonValue = true;

            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);

            dataGridView1.Columns.Add(c0);
            dataGridView1.Columns.Add(c1);
            dataGridView1.Columns.Add(c1b);
            dataGridView1.Columns.Add(c2);
            dataGridView1.Columns.Add(c3);
        }

        private void DisplayScenarios()
        {
            dataGridView1.Rows.Clear();

            for (int i = 1; i <= Globals.Project.numCostScenarios; i++)
            {
                dataGridView1.Rows.Add(new string[] {
                    i.ToString(),
                    Globals.Project.getCostScenario(i).Name,
                    Globals.Project.getCostScenario(i).BMPType,
                    Globals.Project.getCostScenario(i).Description });
            }
        }

        private void btnScenarioReport_Click(object sender, EventArgs e)
        {
            Form form = new frmReport(Globals.Project.CostScenarioReport());
            form.ShowDialog();
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If not Edit button - ignore click
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["btnEdit"].Index) return;

            try
            {
                
                int i = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);    // Cost Scenario ID
                CostScenario cs = Globals.Project.getCostScenario(i);           // Cost Scenario
                BMP bmp = Globals.Project.getBMP(cs.CatchmentID, cs.BMPType);

                Form form = new frmCostAnalysis(bmp);
                form.ShowDialog();
            }
            catch
            {
                return;
            }

            DisplayScenarios();
        }


    }
}
