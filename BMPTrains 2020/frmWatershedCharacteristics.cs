using BMPTrains_2020.DomainCode;
using System;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmWatershedCharacteristics : Form
    {
        public int currentCatchmentNum { get; set; }
        

        public frmWatershedCharacteristics(int c)
        {            
            InitializeComponent();
            currentCatchmentNum = c;
        }

        public Catchment c()
        {
            return Globals.Project.getCatchment(currentCatchmentNum);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmWatershedCharacteristics_Load(object sender, EventArgs e)
        {
            if (currentCatchmentNum == 0) currentCatchmentNum = 1;
                        
            cbPostLanduse.Items.Clear();
           
            cbPostLanduse.DataSource = LanduseTable.Values();
            cbPostLanduse.DisplayMember = "D";
            cbPostLanduse.ValueMember = "D";

            cbPreLanduse.DataSource = LanduseTable.Values();
            cbPreLanduse.DisplayMember = "D";
            cbPostLanduse.ValueMember = "D";

            this.Text += " Version: " + Application.ProductVersion;

            InterfaceCommon.BuildCatchmentMenu(menuStrip1, MenuItemClickHandler);

            menuStrip1.Items[1].BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);
            menuStrip1.CanOverflow = true;
            setValues();
        }

        public void setPreCN(double v)
        {
            Common.setValue(tbPreNonDCIACurveNumber, v);
        }
        public void setPostCN(double v)
        {
            Common.setValue(tbPostNonDICACurveNumber, v);
        }

        public void setPreNEMC(double v)
        {
            Common.setValue(tbPreNConcentration, v);
        }

        public void setPrePEMC(double v)
        {
            Common.setValue(tbPrePConcentration, v);
        }

        public void setPostNEMC(double v)
        {
            Common.setValue(tbPostNConcentration, v);
        }

        public void setPostPEMC(double v)
        {
            Common.setValue(tbPostPConcentration, v);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Actually Cancel            
            this.Close();
        }

        private Catchment getCatchment(int id)
        {
            return Globals.Project.getCatchment(id);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            getValues();
            c().Calculate();

            // Read values here and then close
            this.Close();
        }

        private void cbPreLanduse_SelectedIndexChanged(object sender, EventArgs e)
        {
            getPandNValues();
        }

        private void cbPostLanduse_SelectedIndexChanged(object sender, EventArgs e)
        {
            getPandNValues();
        }

        private void getPandNValues()
        {
            string preLanduse = Common.getString(cbPreLanduse);
            double tPreN = LanduseTable.getN(preLanduse);
            double tPreP = LanduseTable.getP(preLanduse);

            string postLanduse = Common.getString(cbPostLanduse);
            double tPostN = LanduseTable.getN(postLanduse);
            double tPostP = LanduseTable.getP(postLanduse);

            if (!LanduseTable.isUserDefined(preLanduse)) Common.setValue(tbPreNConcentration, tPreN, 3);
            if (!LanduseTable.isUserDefined(preLanduse)) Common.setValue(tbPrePConcentration, tPreP, 3);

            if (!LanduseTable.isUserDefined(postLanduse)) Common.setValue(tbPostNConcentration, tPostN, 3);
            if (!LanduseTable.isUserDefined(postLanduse)) Common.setValue(tbPostPConcentration, tPostP, 3);

            if (LanduseTable.isUserDefined(preLanduse))
            {
                tbPreNConcentration.Enabled = true;
                tbPrePConcentration.Enabled = true;
                btnEMCPreN.Visible = true;
                btnEMCPreP.Visible = true;
            }
            else
            {
                tbPreNConcentration.Enabled = false;
                tbPrePConcentration.Enabled = false;
                btnEMCPreN.Visible = false;
                btnEMCPreP.Visible = false;

            }

            if (LanduseTable.isUserDefined(postLanduse))
            {
                tbPostNConcentration.Enabled = true;
                tbPostPConcentration.Enabled = true;
                btnEMCPostN.Visible = true;
                btnEMCPostP.Visible = true;

            }
            else
            {
                tbPostNConcentration.Enabled = false;
                tbPostPConcentration.Enabled = false;
                btnEMCPostN.Visible = false;
                btnEMCPostP.Visible = false;

            }
        }

        private void getValues()
        {
            // Gets all the Catchment Values from the Form

            c().CatchmentName = Common.getString(tbCatchmentName);
            c().PreLandUseName = Common.getString(cbPreLanduse);
            c().PostLandUseName = Common.getString(cbPostLanduse);
            c().PreArea = Common.getDouble(tbPreArea);
            c().PostArea = Common.getDouble(tbPostArea);
            c().PreNonDCIACurveNumber = Common.getDouble(tbPreNonDCIACurveNumber, 29.9, 100);
            c().PostNonDCIACurveNumber = Common.getDouble(tbPostNonDICACurveNumber, 29.9, 100);
            c().PreDCIAPercent = Common.getDouble(tbPreDCIAPercentage, 0, 100);
            c().PostDCIAPercent = Common.getDouble(tbPostDCIAPercent, 0, 100);
            c().BMPArea = Common.getDouble(tbBMPArea);
            c().PreNConcentration = Common.getDouble(tbPreNConcentration);
            c().PrePConcentration = Common.getDouble(tbPrePConcentration);
            c().PostNConcentration = Common.getDouble(tbPostNConcentration);
            c().PostPConcentration = Common.getDouble(tbPostPConcentration);
            c().PreGWN = Common.getDouble(tbPreGWN);
            c().PreGWP = Common.getDouble(tbPreGWP);
            c().PostGWN = Common.getDouble(tbPostGWN);
            c().PostGWP = Common.getDouble(tbPostGWP);

            c().SetValuesFromProject(Globals.Project);
            labelError.Text = "";
        }

        private void setValues()
        {
            // Set N, P Concentrations after settign Combo (in case user over-rode them)
            // sett
            
            lblCatchmentNum.Text = c().id.ToString() + " " + c().CatchmentName;
            Common.setValue(tbCatchmentName, c().CatchmentName);
            Common.setValue(cbPreLanduse, c().PreLandUseName);
            Common.setValue(cbPostLanduse, c().PostLandUseName);
            Common.setValue(tbPreArea, c().PreArea,2);
            Common.setValue(tbPostArea, c().PostArea, 2);
            Common.setValue(tbPreNonDCIACurveNumber, c().PreNonDCIACurveNumber,2);
            Common.setValue(tbPostNonDICACurveNumber , c().PostNonDCIACurveNumber, 2);
            Common.setValue(tbPreDCIAPercentage, c().PreDCIAPercent, 2);
            Common.setValue(tbPostDCIAPercent, c().PostDCIAPercent, 2);
            Common.setValue(tbBMPArea, c().BMPArea, 2);
            Common.setValue(tbPostNConcentration, c().PostNConcentration, 3);
            Common.setValue(tbPostPConcentration, c().PostPConcentration, 3);

            Common.setValue(tbPreGWN, c().PreGWN, 3);
            Common.setValue(tbPreGWP, c().PreGWP, 3);
            Common.setValue(tbPostGWN, c().PostGWN, 3);
            Common.setValue(tbPostGWP, c().PostGWP, 3);

            c().SetValuesFromProject(Globals.Project);
            c().Calculate();
            Globals.Project.Calculate();

            Common.setValue(tbPostC, c().PostRationalCoefficient,3);
            Common.setValue(tbPostRunoffVolume, c().PostRunoffVolume, 3);
            Common.setValue(tbPostNLoading, c().PostNLoading, 3);
            Common.setValue(tbPostPLoading, c().PostPLoading, 3);

            Common.setValue(tbPreRunoffVolume, c().PreRunoffVolume, 3);
            Common.setValue(tbPreC, c().PreRationalCoefficient,3);
            Common.setValue(tbPreNConcentration, c().PreNConcentration, 3);
            Common.setValue(tbPrePConcentration, c().PrePConcentration, 3);
            Common.setValue(tbPreNLoading, c().PreNLoading, 3);
            Common.setValue(tbPrePLoading, c().PrePLoading, 3);

            cbPreLanduse.Enabled = !Globals.Project.LockedPreCondition;
            tbPreArea.Enabled = !Globals.Project.LockedPreCondition;
            tbPreDCIAPercentage.Enabled = !Globals.Project.LockedPreCondition;
            tbPreNonDCIACurveNumber.Enabled = !Globals.Project.LockedPreCondition; 
            tbPreDCIAPercentage.Enabled = !Globals.Project.LockedPreCondition; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // This is the Caclulate Button (not Save)
            getValues();

            checkErrors();

            setValues();            
        }

        private void checkErrors()
        {
            labelError.Text = c().ErrorMessage(Globals.Project.AnalysisType);
        }

        
        private void btnReport_Click(object sender, EventArgs e)
        {
            Form form = new frmReport(Globals.Project.CatchmentReport(currentCatchmentNum));
            form.ShowDialog();
        }


        private void BuildMenuItems()
        {
            int n = Globals.Project.numCatchments;
            if (n == 0)
            {
              
                BuildMenuItem(Globals.Project.getCatchment().id);
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    BuildMenuItem(i);
                }
            }
            
        }

        public void BuildMenuItem(int id)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(); 
            item = new ToolStripMenuItem();
            item.Name = Convert.ToString(id);
            item.Text = "Catchment " + id.ToString();
            item.Font = addCatchmentToolStripMenuItem.Font;
            item.Click += new EventHandler(MenuItemClickHandler);
            item.Overflow = ToolStripItemOverflow.AsNeeded;
            menuStrip1.Items.Add(item);
            
//            item.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            // Get current values            
            getValues();

            InterfaceCommon.resetMenuColors(menuStrip1);
            clickedItem.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);
            currentCatchmentNum = Convert.ToInt32(clickedItem.Name);

            setValues();
        }

       
        private void addCatchmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getValues();
            Form form = new frmNewCatchment();
            form.ShowDialog(this);
            //Globals.Project.getNewCatchment();
            setValues();
        }

        private int addCatchment()
        {
            getValues();            // Save the current information

            currentCatchmentNum = Globals.Project.getNewCatchment().id;      // Get a new Catchment
            
            setValues();               // Set those values
            return currentCatchmentNum;
        }

        public void addCatchment(int c)
        {
            currentCatchmentNum = c;
            BuildMenuItem(c);
            setValues();
        }

        private void btnZoneMaps_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://roneaglin.online/BMPTrainsDocumentation/GeneralLandUseCategories.pdf"); ;
        }

        private void btnNaturalCommunity_Click(object sender, EventArgs e)
        {
            Form form = new frmReport(StaticReports.NaturalCommunitySummary());
            form.Text = "Natural Community Summary";
            form.ShowDialog();
        }

        private void btnFLUCCS_Click(object sender, EventArgs e)
        {
            Form form = new frmReport(StaticReports.FLUCCSCodeSummary());
            form.Text = "FLUCCS Code Summary";
            form.ShowDialog();
        }

        private void btnPreCCN_Click(object sender, EventArgs e)
        {
            Form form = new frmCompositeCN(c(), true);
            form.ShowDialog(this);
        }

        private void btnPostCCN_Click(object sender, EventArgs e)
        {
            Form form = new frmCompositeCN(c(), false);
            form.ShowDialog(this);
        }

        private void btnViewAnnualC_Click(object sender, EventArgs e)
        {
            // #eaglin - make clean output

            Form form = new frmReport(StaticLookupTables.RationalCTableAsHtml(Globals.Project.RainfallZone));
            form.ShowDialog();
        }

        private void btnMassLoadingDoc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://roneaglin.online/BMPTrainsDocumentation/MassLoadingMethodology.pdf");
        }

        private void btnEMCPreN_Click(object sender, EventArgs e)
        {
            Form form = new frmCompositeEMC(c(), true, true);
            form.ShowDialog(this);
        }

        private void btnEMCPostN_Click(object sender, EventArgs e)
        {
            Form form = new frmCompositeEMC(c(), false, true);
            form.ShowDialog(this);
        }

        private void btnEMCPreP_Click(object sender, EventArgs e)
        {
            Form form = new frmCompositeEMC(c(), true, false);
            form.ShowDialog(this);
        }

        private void btnEMCPostP_Click(object sender, EventArgs e)
        {
            Form form = new frmCompositeEMC(c(), false, false);
            form.ShowDialog(this);
        }
    }
}
