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
    
    public partial class frmWetDetention : Form
    {
        int currentCatchmentID;
        double userInputTP; 
        public frmWetDetention(int id)
        {
            currentCatchmentID = id;
            currentBMP().SetValuesFromCatchment(currentCatchment());
            
            InitializeComponent();
        }

        
        private void frmWetDetention_Load(object sender, EventArgs e)
        {            
            // Add this to each object assigned to a Catchment, Implement MenuItemClickhandler
            InterfaceCommon.BuildCatchmentMenu(menuStrip1, MenuItemClickHandler, true);
            menuStrip1.Items[currentCatchmentID - 1].BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);

            setValues();
            Common.setValue(tbUserTP, 0.0);

            currentBMP().BMPType = BMPTrainsProject.sWetDetention;
            this.Text += currentCatchment().TitleHeader();
            
        }
              
        private WetDetention currentBMP()
        {
            return Globals.Project.getCatchment(currentCatchmentID).getWetDetention();
        }

        private Catchment currentCatchment()
        {
            return Globals.Project.getCatchment(currentCatchmentID);
        }

        private void getValues()
        {
            currentBMP().HasLittoralZone = Common.getBoolean(chkLittoralZone);
            
            currentBMP().PermanentPoolVolume = Common.getDouble(tbPPVolume);
            //currentBMP().LittoralZoneEfficiencyCredit = Common.getDouble(tbLittoralCredit);
            currentBMP().WetlandEfficiencyCredit = Common.getDouble(tbWetlandCredit);
            userInputTP = Common.getDouble(tbUserTP);
        }

        private void setValues()
        {
            currentBMP().SetValuesFromCatchment(currentCatchment());
            currentBMP().Calculate();

            Common.setValue(tbPPVolume, currentBMP().PermanentPoolVolume);
            chkLittoralZone.Checked = currentBMP().HasLittoralZone;
            Common.setValue(tbWetlandCredit, currentBMP().WetlandEfficiencyCredit);

            //wbOutput.DocumentText = currentBMP().BasicReport();
            wbOutput.DocumentText = currentBMP().PrintBMPReport();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            getValues();
            currentBMP().Calculate();
            Globals.Project.Modified = true;
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            getValues();
            
            setValues();
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
            Form form = new frmHelp(currentBMP().HelpURL);
            form.ShowDialog();
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            getValues();
            currentBMP().Calculate();
            wbOutput.DocumentText = currentBMP().PrintBasicReport();
            Common.ShowDetentionPlot(currentBMP());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.wbOutput.Document.Focus();
            SendKeys.SendWait("^a");
            SendKeys.SendWait("^a^c");
            DialogResult dialogResult = MessageBox.Show("Report has been copied to the clipboard as HTML text", "Copy Report", MessageBoxButtons.OK);
        }

        private void btnCost_Click(object sender, EventArgs e)
        {
            Form form = new frmCostAnalysis(currentBMP());
            form.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == (Keys.Control | Keys.Shift))
            {
                // Your code here to handle the Ctrl-Shift click
                Form form1 = new frmReport(currentBMP().DebugReport());
                form1.ShowDialog();
                return;
            }

            Form form = new frmReport(wbOutput.DocumentText, "", this.Text);
            form.ShowDialog();
        }



        private void btnAnoxicDepth_Click(object sender, EventArgs e)
        {
            getValues();
    
            currentBMP().Calculate();

            if (userInputTP != 0.0)
                currentBMP().CalculateAnoxicDepth(0.0, userInputTP);
            else
                currentBMP().CalculateAnoxicDepth();

            wbOutput.DocumentText = currentBMP().AnoxicDepthReport();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Littoral Zone Check
            //if (chkLittoralZone.Checked) currentBMP().LittoralZoneEfficiencyCredit = -10.0; else currentBMP().LittoralZoneEfficiencyCredit = 0;

            getValues();
            setValues();

        }
    }
}
