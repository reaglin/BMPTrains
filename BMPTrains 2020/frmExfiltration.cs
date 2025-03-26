using BMPTrains_2020.DomainCode;
using System;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmExfiltration : Form
    {
        public int currentCatchmentID = 1;
        public frmExfiltration(int id)
        {
            InitializeComponent();
            currentCatchmentID = id;
            currentBMP().SetValuesFromCatchment(currentCatchment());
        }

        private void frmExfiltration_Load(object sender, EventArgs e)
        {
            // Add this to each object assigned to a Catchment, Implement MenuItemClickhandler
            InterfaceCommon.BuildCatchmentMenu(menuStrip1, MenuItemClickHandler,true);
            menuStrip1.Items[currentCatchmentID - 1].BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);

            setValues();

            this.Text +=currentCatchment().TitleHeader();
            if (Globals.Project.DoGroundwaterAnalysis != "Yes")
            {
                btnMediaMix.Visible = false;
            }

        }

        private Catchment currentCatchment()
        {
            return Globals.Project.getCatchment(currentCatchmentID);
        }

        private Exfiltration currentBMP()
        {
            return currentCatchment().getExfiltration();
        }

        private void setValues()
        {
            Common.setValue(tbPipeSpan, currentBMP().PipeSpan);
            Common.setValue(tbPipeRise, currentBMP().PipeRise);
            Common.setValue(tbPipeLength, currentBMP().PipeLength);
            Common.setValue(tbTrenchWidth, currentBMP().TrenchWidth);
            Common.setValue(tbTrenchDepth, currentBMP().TrenchDepth);
            Common.setValue(tbTrenchLength, currentBMP().TrenchLength);
            Common.setValue(tbVoidRatio, currentBMP().VoidRatio);
            Common.setValue(chkThreeHours, !currentBMP().ExfiltrationUnder3hours);

            currentBMP().Calculate();
            setOutputText();
        }

        private void getValues()
        {
            currentBMP().PipeSpan = Common.getDouble(tbPipeSpan);
            currentBMP().PipeRise = Common.getDouble(tbPipeRise);
            currentBMP().PipeLength = Common.getDouble(tbPipeLength);
            currentBMP().TrenchWidth = Common.getDouble(tbTrenchWidth);
            currentBMP().TrenchDepth = Common.getDouble(tbTrenchDepth);
            currentBMP().TrenchLength = Common.getDouble(tbTrenchLength);
            currentBMP().VoidRatio = Common.getDouble(tbVoidRatio,0.0,1.0);
            currentBMP().ExfiltrationUnder3hours = !Common.getBoolean(chkThreeHours);
        }

        private void setOutputText()
        {
            wbOutput.DocumentText = currentBMP().BMPReport(); 
//            wbOutput.DocumentText = currentBMP().BasicReport();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            getValues();
            currentBMP().Calculate();
            setOutputText();
        }

        private void btnPrint_Click(object sender, EventArgs e) => wbOutput.Print();

        private void btnClose_Click(object sender, EventArgs e)
        {
            getValues();
            currentBMP().Calculate();
            Globals.Project.Modified = true;
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.wbOutput.Document.Focus();
            SendKeys.SendWait("^a");
            SendKeys.SendWait("^a^c");
            DialogResult dialogResult = MessageBox.Show("Report has been copied to the clipboard as HTML text", "Copy Report", MessageBoxButtons.OK);
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            if (clickedItem.Name == "reset")
            {
                currentCatchment().Reset(currentBMP());
                setValues();
                return;
            }

            // Get current values            
            getValues();

            InterfaceCommon.resetMenuColors(menuStrip1);
            clickedItem.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);
            currentCatchmentID = Convert.ToInt32(clickedItem.Name);

            setValues();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            // This allows us to have external help by pulling up a web site in the application
            Form form = new frmHelp("https://stormwater.ucf.edu/research-publications/");
            form.ShowDialog();
        }

        private void btnExfiltrationCalculator_Click(object sender, EventArgs e)
        {
            Form form = new frmExfiltrationCalculator(currentCatchmentID);
            form.ShowDialog();
            currentBMP().Calculate();
            setOutputText();
            setValues();
        }

        private void btnMediaMix_Click(object sender, EventArgs e)
        {
            getValues();
            Form form = new frmMediaMix(currentBMP());
            form.ShowDialog();
            setValues();
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            Common.ShowRetentionPlot(currentBMP(), "Exfiltration (retention) System Efficiency");
        }

        private void bnCost_Click(object sender, EventArgs e)
        {
            Form form = new frmCostAnalysis(currentBMP());
            form.ShowDialog();
        }

        private void chkThreeHours_CheckedChanged(object sender, EventArgs e)
        {
            getValues();
            currentBMP().Calculate();
            setOutputText();
        }
    }
}
