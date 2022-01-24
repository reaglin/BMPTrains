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
    public partial class frmCostAnalysis : Form
    {
        BMP bmp;
        public frmCostAnalysis(BMP _bmp)
        {
            bmp = _bmp;
            InitializeComponent();
        }

        private void frmCostAnalysis_Load(object sender, EventArgs e)
        {
            this.Text += "    Type: " + bmp.BMPTypeTitle();
            setValues();
        }

        private void setValues()
        {
            Common.setValue(tbLandCost, bmp.LandCost);
            Common.setValue(tbFixedCost, bmp.FixedCost);
            Common.setValue(tbExpectedLife, bmp.ExpectedLife);
            Common.setValue(tbCostPerAcreFoot, bmp.CostPerAcreFoot);
            Common.setValue(tbHarvestedWater, bmp.HarvestedWater);
            Common.setValue(tbMaintenanceCost, bmp.MaintenanceCost);
            Common.setValue(tbFutureReplacementCost, bmp.FutureReplacementCost);

            Common.setValue(tbInterestRate, Globals.Project.InterestRate);
            Common.setValue(tbProjectDuration, Globals.Project.ProjectDuration);
            Common.setValue(tbCostOfWater, Globals.Project.CostOfWater);

            Common.setButtonColor(Globals.Project.hasCostScenario(bmp), btnScenario);
            if (Globals.Project.hasCostScenario(bmp))
            {
                tbScenarioName.Enabled = true;
                tbScenarioDescription.Enabled = true;
                Common.setValue(tbScenarioName, getCostScenario().Name);
                Common.setValue(tbScenarioDescription, getCostScenario().Description);
            }
            else
            {
                tbScenarioName.Enabled = false;
                tbScenarioDescription.Enabled = false;
            }

            wbOutput.DocumentText = bmp.CostReport();
        }

        private void getValues()
        {
            bmp.LandCost = Common.getDouble(tbLandCost);
            bmp.FixedCost = Common.getDouble(tbFixedCost);
            bmp.ExpectedLife = Common.getDouble(tbExpectedLife);
            Common.ValidateGE(bmp.ExpectedLife, 1, "The Expected Life must be greater than 1 year", true);
            bmp.CostPerAcreFoot = Common.getDouble(tbCostPerAcreFoot);
            bmp.HarvestedWater = Common.getDouble(tbHarvestedWater);
            bmp.MaintenanceCost = Common.getDouble(tbMaintenanceCost);
            bmp.FutureReplacementCost = Common.getDouble(tbFutureReplacementCost);

            Globals.Project.InterestRate = Common.getDouble(tbInterestRate);
            Globals.Project.ProjectDuration = Common.getDouble(tbProjectDuration);
            Globals.Project.CostOfWater = Common.getDouble(tbCostOfWater);
            if (Globals.Project.hasCostScenario(bmp))
            {
                getCostScenario().Name = Common.getString(tbScenarioName);
                getCostScenario().Description = Common.getString(tbScenarioDescription);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            getValues();
            Globals.Project.Modified = true;
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            getValues();
            wbOutput.Print();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.wbOutput.Document.Focus();
            SendKeys.SendWait("^a");
            SendKeys.SendWait("^a^c");
            DialogResult dialogResult = MessageBox.Show("Report has been copied to the clipboard as HTML text", "Copy Report", MessageBoxButtons.OK);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            getValues();
            wbOutput.DocumentText = bmp.CostReport();
        }

        private CostScenario getCostScenario()
        {
            return Globals.Project.getCostScenario(bmp);
        }

        private void btnScenario_Click(object sender, EventArgs e)
        {
            getValues();
            DialogResult dialogResult = MessageBox.Show("This will create a Cost Scenario with the Current Values, Continue?", "Create Cost Scenario", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;

            CostScenario c = Globals.Project.createNewCostScenario();
            c.CreateFromBMP(bmp);
          
            MessageBox.Show("A new Cost Scenario has been created with the ID: " + c.id.ToString());
            tbScenarioName.Enabled = true;
            tbScenarioDescription.Enabled = true;
        }
    }
}
