using System;
using System.Drawing;
using System.Windows.Forms;
using BMPTrains_2020.DomainCode;
using System.IO;

namespace BMPTrains_2020
{
    public partial class GeneralSiteInformation : Form
    {

        public GeneralSiteInformation()
        {
            InitializeComponent();
            RainfallDefault = BMPTrains_2020.Properties.Resources.RainfallMapOverall;
        }

        private System.Drawing.Bitmap rainfallDefault = BMPTrains_2020.Properties.Resources.RainfallMapOverall;

        public Bitmap RainfallDefault { get => rainfallDefault; set => rainfallDefault = value; }

        private void GeneralSiteInformation_Load(object sender, EventArgs e)
        {
            // Bind Meteorological Zones to Combo
            cbMetZone.Items.Clear();

            BindingSource bs = new BindingSource();
            bs.DataSource = StaticLookupTables.RainfallZones();
          
            cbMetZone.DataSource = bs;

            // Bind Project types to Combo
            cbAnalysisType.Items.Clear();
            BindingSource bs2 = new BindingSource();
            bs2.DataSource = BMPTrainsProject.AnalysisTypes();

            cbAnalysisType.DataSource = bs2;

            setValues();
        }

        private void btnRainfallMap_Click(object sender, EventArgs e)
        {
            // Show the Rainfall Map
            Form frmRainfall = new FormMeanAnnualRainfall();
            frmRainfall.ShowDialog(this);

        }

        private void cbAnalysisType_SelectedIndexChanged(object sender, EventArgs e)
        {

            getValues(false);
            bool showNP = false;
            bool enableNP = true;
            bool showLP = false;
            string analysisType = Common.getString(cbAnalysisType);

            Globals.Project.AnalysisType = analysisType;
            if ((BMPTrainsProject.AT_Criteria_For_Scenario(analysisType) != BMPTrainsProject.AT_Criteria_None) 
                || (analysisType == BMPTrainsProject.AT_Redevelopment)
                || (analysisType == BMPTrainsProject.AT_Redevelopment_OFW))
            {
                lblN.Text = "Nitrogen Removal Efficiency (%):";
                lblP.Text = "Phosphorus Removal Efficiency (%):";

                Common.setValue(tbN, BMPTrainsProject.AT_Removal_For_Scenario(analysisType, "N"));
                Common.setValue(tbP, BMPTrainsProject.AT_Removal_For_Scenario(analysisType, "P"));
//                enableNP = true;
                showNP = true;
            }
  
            if (analysisType == BMPTrainsProject.AT_SpecifiedRemovalEfficiency)
            {
                lblN.Text = "Nitrogen Removal Efficiency (%):";
                lblP.Text = "Phosphorus Removal Efficiency (%):";
                enableNP = true;
                showNP = true;
            }

            if ((string)cbAnalysisType.SelectedValue == BMPTrainsProject.AT_PreReductionPercent)
            {
                showLP = true;
            }

            tbN.Enabled = enableNP;
            tbP.Enabled = enableNP;
            lblN.Visible = showNP;
            lblP.Visible = showNP;
            tbN.Visible = showNP;
            tbP.Visible = showNP;
            lblPercentLessThanPre.Visible = showLP;
            tbPercentLessThanPre.Visible = showLP;
            tbPercentLessThanPre.Enabled = showLP;


            setValues();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Globals.Project.Modified)
            {
                DialogResult dialogResult = MessageBox.Show("You are exiting without saving, do you want to save your work?", "Save File", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Save();
                }
            }

            Application.Exit();
        }
      
        private void btnZoneMaps_Click(object sender, EventArgs e)
        {

            // Want to set proerty of image before loading
            this.RainfallDefault = BMPTrains_2020.Properties.Resources.RainfallZones;

            // Show the Rainfall Map
            Form frmRainfall = new FormMeanAnnualRainfall(this);
            
            frmRainfall.ShowDialog();
        }

        private void getValues(bool readAnalysisType = true)
        {
            Globals.Project.ProjectName = tbProjectName.Text;
            Globals.Project.RainfallZone = Common.getString(cbMetZone);
            Globals.Project.MeanAnnualRainfall = Common.getDouble(tbMeanAnnualRainfall);
            if (readAnalysisType) Globals.Project.AnalysisType = Common.getString(cbAnalysisType);
            Globals.Project.DoGroundwaterAnalysis = Common.getString(cbGroundwater);

            Globals.Project.RequiredNTreatmentEfficiency = Common.getInt(tbN, 0, 99);
            Globals.Project.RequiredPTreatmentEfficiency = Common.getInt(tbP, 0 ,99);

            if (tbPercentLessThanPre.Enabled) Globals.Project.RequiredPreReductionPercent = Common.getDouble(tbPercentLessThanPre); 

            Globals.Project.Calculate();        // This also sets Catchment Values for Associated Catchments
            EnableButtons();
        }

        private void EnableButtons()
        {
            // If Routing has not been setup then the btnReport should not be enabled.
            btnReport.Enabled = true;
            btnCostReport.Enabled = true;
            btnConfiguration.Enabled = true;
            btnCatchmentReport.Enabled = true;
            btnOptions.Enabled = true;

            if (Globals.Project.Catchments.Count == 0)
            {
                btnReport.Enabled = false;
                btnCostReport.Enabled = false;
                btnConfiguration.Enabled = false;
                btnCatchmentReport.Enabled = false;
                btnOptions.Enabled = false;
                
                return;
            }
     
            if ((Globals.Project.Catchments[1].SelectedBMPType == "") || (Globals.Project.Catchments[1].SelectedBMPType == null)) {
                btnReport.Enabled = false;
                return;
            }
        }

        private void setValues()
        {
            tbProjectName.Text = Globals.Project.ProjectName;
            Common.setValue(cbMetZone, Globals.Project.RainfallZone);
            Common.setValue(tbMeanAnnualRainfall, Globals.Project.MeanAnnualRainfall);
            Common.setValue(cbAnalysisType, Globals.Project.AnalysisType);
            Common.setValue(cbGroundwater, Globals.Project.DoGroundwaterAnalysis,true);
            if (tbPercentLessThanPre.Enabled) Common.setValue(tbPercentLessThanPre, Globals.Project.RequiredPreReductionPercent);
                if ((string)cbAnalysisType.SelectedValue == BMPTrainsProject.AT_SpecifiedRemovalEfficiency)
            {
                //Common.setValue(tbN, Globals.Project.RequiredNTreatmentEfficiency);
                Common.setValue(tbN, 55);
                Common.setValue(tbP, Globals.Project.RequiredPTreatmentEfficiency);
            }

            this.Text = "General Site Information for Project File: " + Globals.Project.getFileName();
            EnableButtons();
            //btnConfiguration.Text = "Select Catchment Configuration"; // + Globals.Project.CatchmentConfiguration +;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            Globals.Project.Modified = false;
        }

        private void Save()
        {
            getValues();

            Globals.Project.Save();
        }

        public void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Common.WorkingDirectory();

            dlg.Filter = "BMPTrains files (*.bmpt)|*.bmpt";
           
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = dlg.FileName;
                OpenFile(fileName);
                
                Globals.Project.Calculate();
            }
            
        }

        public void OpenFile(string filename)
        {
            
            string res = Globals.Project.openFromFile(filename);
            Common.setValue(cbGroundwater, Globals.Project.DoGroundwaterAnalysis, true);
            if (res == "")
            {
                Globals.Project.FileName = filename;
                Common.setValue(cbGroundwater, Globals.Project.DoGroundwaterAnalysis, true);
                setValues();
            }
            else
            { 
                MessageBox.Show(res);
            }
        }

        private void btnCatchments_Click(object sender, EventArgs e)
        {
            getValues();
            Globals.Project.Calculate();

            Form form = new frmWatershedCharacteristics(1); 
            form.ShowDialog();

            EnableButtons();
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            getValues();
            Form form = new frmSelectCatchmentConfiguration();
            form.ShowDialog();
            EnableButtons();
//            btnConfiguration.Text = "Catchment Configuration " + Globals.Project.CatchmentConfiguration;
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            if (!Globals.Project.Catchments.ContainsKey(1))
            { 
                DialogResult dialogResult = MessageBox.Show("You must create a Catchment before defining treatment options, would you like to do that now?", "Define Catchment", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    btnCatchments_Click(sender, e);
                    return;
                }
            }

            getValues();
            Form form = new frmTreatmentOptions();
            form.ShowDialog();
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will create a new project, all current project data that is not saved will be lost, continue?", "New Project", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Globals.Project = new BMPTrainsProject();
                    setValues();
                }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            getValues();
            Globals.Project.Calculate();
            Form form = new frmReport(Globals.Project.summaryReport(),false);
            form.ShowDialog();
        }

        private void btnCostReport_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Clipboard.SetText(Globals.Project.FullCostCopy());

            Form form = new frmReport(Globals.Project.FullCostReport());
            form.ShowDialog();

            //Form form = new frmCostScenario();
            //form.ShowDialog();
        }

        private void cbMetZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(StaticLookupTables.RationalCValues(cbMetZone.Text));
        }
        #region "User Documentation Links"
        private void btnHarper_Click(object sender, EventArgs e)
        {
            BMPTrainsProject.openURL(BMPTrainsProject.URL_Harper_Report);
        }

        private void btnFDEP_Click(object sender, EventArgs e)
        {
            // Link to FDEP Rules
            BMPTrainsProject.openURL(BMPTrainsProject.URL_FDEP_Rules);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Should be link to Applicants Handbook
            BMPTrainsProject.openURL(BMPTrainsProject.URL_Applicants_Handbook);
        }

        private void btnPerformanceSummary_Click(object sender, EventArgs e)
        {
            BMPTrainsProject.openURL(BMPTrainsProject.URL_Performance_Summary);
        }

        #endregion
        private void btnCatchmentReport_Click(object sender, EventArgs e)
        {
            getValues();
            Globals.Project.Calculate();
            Form form = new frmReport(Globals.Project.CatchmentReport(), false);
            form.ShowDialog();
        }
        private void btnUserManual_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://roneaglin.online/bmptrains");
        }

        public void btnPre_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Common.WorkingDirectory();

            dlg.Filter = "BMPTrains files (*.bmpt)|*.bmpt";

            BMPTrainsProject pre = new BMPTrainsProject();
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                DialogResult dialogResult = MessageBox.Show("This will set all pre-condition catchment values equal to the pre-condition values from the selected file. It will replace all existing pre-condition data, continue?", "Use Existing Pre-Condition Values", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }

                string fileName = dlg.FileName;
                string res = pre.openFromFile(fileName);
                if (res == "")
                {
                    pre.FileName = fileName;
                    pre.Calculate();
                    Globals.Project.getValuesFromPreDevelopment(pre);
                    lblN.Text = "Existing N Discharge (kg/yr)";
                    lblP.Text = "Existing P Discharge (kg/yr)";
                    tbN.Text = Globals.Project.TargetNMassLoad.ToString("##.##");
                    tbP.Text = Globals.Project.TargetPMassLoad.ToString("##.###");
                    //showNP = true;
                    //enableNP = false;
                }
                else
                {
                    MessageBox.Show(res);
                    return;
                }
            }
            tbN.Enabled = false;
            tbP.Enabled = false;
            lblN.Visible = true;
            lblP.Visible = true;
            tbN.Visible = true;
            tbP.Visible = true;

            setValues();
        }

        private void btnRecentProjects_Click(object sender, EventArgs e)
        {
            getValues();
            Globals.Project.Calculate();

            Form form = new frmOpenFile(this);
            form.ShowDialog();

            Globals.Project.Calculate();
            EnableButtons();
            setValues();
        }

        private void cbGroundwater_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No action
           
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Form frmTestingPlots = new frmTestingPlots();
            frmTestingPlots.ShowDialog();
        }
    }
}
