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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            BMPTrainsProject.OpenHelp("project");
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

        private void getValues(bool readAnalysisType = true)
        {
            Globals.Project.ProjectName = tbProjectName.Text;
            Globals.Project.RainfallZone = Common.getString(cbMetZone);
            Globals.Project.MeanAnnualRainfall = Common.getDouble(tbMeanAnnualRainfall);
            if (readAnalysisType) Globals.Project.AnalysisType = Common.getString(cbAnalysisType);
            Globals.Project.DoGroundwaterAnalysis = Common.getString(cbGroundwater);

            Globals.Project.RequiredNTreatmentEfficiency = Common.getInt(tbN, 0, 99);
            Globals.Project.RequiredPTreatmentEfficiency = Common.getInt(tbP, 0, 99);

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

            if ((Globals.Project.Catchments[1].SelectedBMPType == "") || (Globals.Project.Catchments[1].SelectedBMPType == null))
            {
                btnReport.Enabled = false;
                return;
            }
        }

        private void setValues()
        {
            // This code can be added to bypass action for Non registered users
            if (!Globals.IsValidatedUser)
            {
                Globals.Project.RainfallZone = StaticLookupTables.DefaultRainfallZone;
                Globals.Project.MeanAnnualRainfall = BMPTrainsProject.DefaultMeanAnnualRainfall;
            }

            // This code can be added to bypass action for 
            // Non registered users
            tbProjectName.Text = Globals.Project.ProjectName;
            Common.setValue(cbMetZone, Globals.Project.RainfallZone);
            Common.setValue(tbMeanAnnualRainfall, Globals.Project.MeanAnnualRainfall);
            Common.setValue(cbAnalysisType, Globals.Project.AnalysisType);
            Common.setValue(cbGroundwater, Globals.Project.DoGroundwaterAnalysis, true);
            if (tbPercentLessThanPre.Enabled) Common.setValue(tbPercentLessThanPre, Globals.Project.RequiredPreReductionPercent);
            if ((string)cbAnalysisType.SelectedValue == BMPTrainsProject.AT_SpecifiedRemovalEfficiency)
            {
                //Common.setValue(tbN, Globals.Project.RequiredNTreatmentEfficiency);
                Common.setValue(tbN, 55);
                Common.setValue(tbP, Globals.Project.RequiredPTreatmentEfficiency);
            }

            this.Text = "General Site Information (Current User: " + Globals.User() + ")";
            EnableButtons();
            //btnConfiguration.Text = "Select Catchment Configuration"; // + Globals.Project.CatchmentConfiguration +;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // This code can be added to bypass action for 
            // Non registered users
            if (!Globals.IsValidatedUser)
            {
                ShowvalidationForm();
                return;
            }

            Save();
            Globals.Project.Modified = false;

        }

        private void ShowvalidationForm()
        {
            Form about = new frmAboutValidation();
            about.ShowDialog();
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

            dlg.Filter = "BMPFast files (*.bmpt)|*.bmpt";

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
            // This code can be added to bypass action for 
            // Non registered users
            if (!Globals.IsValidatedUser)
            {
                ShowvalidationForm();
                return;
            }

            getValues();
            Globals.Project.Calculate();
            Form form = new frmReport(Globals.Project.PrintSummaryReport());
            form.ShowDialog();
        }

        private void btnCostReport_Click(object sender, EventArgs e)
        {
            // This code can be added to bypass action for 
            // Non registered users
            if (!Globals.IsValidatedUser)
            {
                ShowvalidationForm();
                return;
            }

            System.Windows.Forms.Clipboard.SetText(Globals.Project.FullCostCopy());

            Form form = new frmReport(Globals.Project.FullCostReport());
            form.ShowDialog();

        }

        private void cbMetZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(StaticLookupTables.RationalCValues(cbMetZone.Text));
        }

        private void btnCatchmentReport_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == (Keys.Control | Keys.Shift))
            {
                // Your code here to handle the Ctrl-Shift click
                Form form1 = new frmReport(Globals.Project.DebugReport());
                form1.ShowDialog();
                return;
            }
            // This code can be added to bypass action for 
            // Non registered users
            if (!Globals.IsValidatedUser)
            {
                ShowvalidationForm();
                return;
            }

            getValues();
            Globals.Project.Calculate();
            Form form = new frmReport(Globals.Project.CatchmentReport());
            form.ShowDialog();
        }


        public void btnPre_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Common.WorkingDirectory();

            dlg.Filter = "BMPFast files (*.bmpt)|*.bmpt";

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
            BMPTrainsProject.OpenDocumentation();
        }

        private void btnRainfallMap_Click_1(object sender, EventArgs e)
        {
            showRainfallMap();
        }
        private void showRainfallMap()
        {
            // Show the Rainfall Map
            Form frmRainfall = new FormMeanAnnualRainfall();
            frmRainfall.ShowDialog(this);
        }

        private void showZoneMaps()
        {
            // Want to set proerty of image before loading
            this.RainfallDefault = BMPTrains_2020.Properties.Resources.RainfallZones;
            // Show the Rainfall Map
            Form frmRainfall = new FormMeanAnnualRainfall(this);
            frmRainfall.ShowDialog();
        }

        private void btnZoneMaps_Click_1(object sender, EventArgs e)
        {
            showZoneMaps();
        }

        private void btnHelp_Click_1(object sender, EventArgs e)
        {
            BMPTrainsProject.OpenHelp("project");
        }
    }
}

