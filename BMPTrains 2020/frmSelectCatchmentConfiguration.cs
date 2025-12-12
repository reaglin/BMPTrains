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
    public partial class frmSelectCatchmentConfiguration : Form
    {
        public frmSelectCatchmentConfiguration()
        {
            InitializeComponent();
            Globals.Project.CatchmentConfiguration = "U";
        }

        private void frmSelectCatchmentConfiguration_Load(object sender, EventArgs e)
        {
            AddColumns();
            DisplayCatchmentConfigurationsCombo();
            DisplayCurrentRouting();
        }

        private void DisplayCatchmentConfigurationsCombo()
        {
            cbOptions.DataSource = new BindingSource(BMPTrainsProject.CatchmentConfigurations(), null);
            cbOptions.DisplayMember = "Value";
            cbOptions.ValueMember = "Key";

            if ((Globals.Project.CatchmentConfiguration != "") || (Globals.Project.CatchmentConfiguration != null))
            {
                cbOptions.SelectedValue = Globals.Project.CatchmentConfiguration;
            }
        }

        private void AddColumns()
        {
            dataGridView1.RowTemplate.Height = 40;
            DataGridViewTextBoxColumn c0 = new DataGridViewTextBoxColumn();
            c0.Width = 60;
            c0.HeaderText = "From";
            c0.ReadOnly = true;

            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.Width = 60;
            c1.HeaderText = "To";
            c1.ReadOnly = true;

            DataGridViewTextBoxColumn c1b = new DataGridViewTextBoxColumn();
            c1b.Width = 100;
            c1b.HeaderText = "Area";
            c1b.ReadOnly = true;


            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.Width = 210;
            c2.HeaderText = "BMP Used";
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

        private void DisplayCurrentRouting()
        {
            dataGridView1.Rows.Clear();

            for (int i = 1; i <= Globals.Project.numCatchments; i++)
            {
                Catchment c = Globals.Project.getCatchment(i);
                dataGridView1.Rows.Add(new string[] { i.ToString(),
                    c.routing.ToID.ToString(),
                    Common.getString(c.PostArea, 2),
                    c.getSelectedBMP().BMPType });

                //dataGridView1.Rows.Add(new string[] { i.ToString(),                   
                //    Globals.Project.getCatchment(i).routing.ToID.ToString(),
                //    Common.getString(Globals.Project.Catchments[i].PostArea, 2),
                //    Globals.Project.Catchments[i].SelectedBMPType });
            }

            DataGridViewCellStyle sDisabled = new DataGridViewCellStyle(dataGridView1.DefaultCellStyle);
            sDisabled.BackColor = Color.Gray;

            DataGridViewCellStyle sEnabled = new DataGridViewCellStyle(dataGridView1.DefaultCellStyle);

            for (int i = 1; i <= Globals.Project.numCatchments; i++)
            {

                if (Globals.Project.getCatchment(i).Disabled)
                {
                    dataGridView1.Rows[i - 1].Cells[0].Style = sDisabled;
                    dataGridView1.Rows[i - 1].Cells[1].Style = sDisabled;
                    dataGridView1.Rows[i - 1].Cells[2].Style = sDisabled;
                    dataGridView1.Rows[i - 1].Cells[3].Style = sDisabled;
                }
                else
                {
                    dataGridView1.Rows[i - 1].Cells[0].Style = sEnabled;
                    dataGridView1.Rows[i - 1].Cells[1].Style = sEnabled;
                    dataGridView1.Rows[i - 1].Cells[2].Style = sEnabled;
                    dataGridView1.Rows[i - 1].Cells[3].Style = sEnabled;
                }
            }
        }

        private void cbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayImage();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Globals.Project.CatchmentConfiguration = "U"; // cbOptions.SelectedValue.ToString();
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will overwrite the existing routing, Continue?", "Overwrite Existing Routing", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;

            if (cbOptions.SelectedValue.ToString() != "" && cbOptions.SelectedValue != null)
            {
                try
                {
                    int[] cc = CatchmentConfigurations.Routings[cbOptions.SelectedValue.ToString()];
                    dataGridView1.Rows.Clear();
                    Globals.Project.numCatchments = cc.Length - 1;
                    for (int i = 1; i < cc.Length; i++)
                    {
                        // We are also going to set to values
                        int from = i;
                        Globals.Project.getCatchment(i).setToRouting(cc[i]);
                    }
                }
                catch { return; }
                DisplayCurrentRouting();
                DisplayImage();

            }
        }
        public void DisplayImage()
        {
            pbOptions.Image = Globals.Project.getConfigurationImage(cbOptions.SelectedValue.ToString());
            pbOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }
        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If not Edit button - ignore click
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["btnEdit"].Index) return;

            try
            { 
                // Get FROM Catchment ID
                int catchmentID = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);

                Form form = new frmRouting(catchmentID);
                form.ShowDialog();
            }
            catch
            {
                return;
            }

            DisplayCurrentRouting();
        }

        private void btnAddCatchment_Click(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Adding a New Catchment cannot be deleted (they can be disabled), Continue to add new catchment to the routing?", 
            //    "Add New Catchment?", MessageBoxButtons.YesNo);

            //if (dialogResult == DialogResult.No) return;

            //Globals.Project.getNewCatchment();
            //DisplayCurrentRouting();

            Form form = new frmWatershedCharacteristics(1);
            form.ShowDialog();

            DisplayCurrentRouting();

        }

        private void btnReport_Click(object sender, EventArgs e)
        {

            Globals.Project.Calculate();
            Form form = new frmReport(Globals.Project.getRoutingReport());
            form.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnFlowBalance_Click(object sender, EventArgs e)
        {
            DisplayCurrentRouting();
            Globals.Project.Calculate();
            Form form = new frmReport(Globals.Project.FlowBalanceReport(), false);
            form.ShowDialog();
        }

        private void btn_Retention_Click(object sender, EventArgs e)
        {
            Form form = new frmRetentionInSeries();
            form.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new frmRetentionInSeries("Detention");
            form.ShowDialog();
        }
    }
}
