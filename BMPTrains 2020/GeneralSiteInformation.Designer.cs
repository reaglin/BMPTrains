namespace BMPTrains_2020
{
    partial class GeneralSiteInformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbProjectName = new System.Windows.Forms.TextBox();
            this.cbMetZone = new System.Windows.Forms.ComboBox();
            this.tbMeanAnnualRainfall = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAnalysisType = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCatchments = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnConfiguration = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnCostReport = new System.Windows.Forms.Button();
            this.btnCatchmentReport = new System.Windows.Forms.Button();
            this.lblN = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.tbN = new System.Windows.Forms.TextBox();
            this.tbP = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbGroundwater = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNewProject = new System.Windows.Forms.Button();
            this.btnRecentProjects = new System.Windows.Forms.Button();
            this.tbPercentLessThanPre = new System.Windows.Forms.TextBox();
            this.lblPercentLessThanPre = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnRainfallMap = new System.Windows.Forms.Button();
            this.btnZoneMaps = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Meteorological Zone for Project:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Project Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(308, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Enter the Mean Annual Rainfall:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 144);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(502, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "Performance Standard of Surface Discharge Analysis:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbProjectName
            // 
            this.tbProjectName.Location = new System.Drawing.Point(427, 14);
            this.tbProjectName.Name = "tbProjectName";
            this.tbProjectName.Size = new System.Drawing.Size(311, 35);
            this.tbProjectName.TabIndex = 4;
            // 
            // cbMetZone
            // 
            this.cbMetZone.FormattingEnabled = true;
            this.cbMetZone.Location = new System.Drawing.Point(427, 55);
            this.cbMetZone.Name = "cbMetZone";
            this.cbMetZone.Size = new System.Drawing.Size(311, 38);
            this.cbMetZone.TabIndex = 5;
            this.cbMetZone.SelectedIndexChanged += new System.EventHandler(this.cbMetZone_SelectedIndexChanged);
            // 
            // tbMeanAnnualRainfall
            // 
            this.tbMeanAnnualRainfall.Location = new System.Drawing.Point(427, 100);
            this.tbMeanAnnualRainfall.Name = "tbMeanAnnualRainfall";
            this.tbMeanAnnualRainfall.Size = new System.Drawing.Size(54, 35);
            this.tbMeanAnnualRainfall.TabIndex = 6;
            this.toolTip1.SetToolTip(this.tbMeanAnnualRainfall, "Mean Annual Rainfall can only be changed in the full version.");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(490, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 30);
            this.label5.TabIndex = 7;
            this.label5.Text = "inches";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbAnalysisType
            // 
            this.cbAnalysisType.FormattingEnabled = true;
            this.cbAnalysisType.Location = new System.Drawing.Point(507, 141);
            this.cbAnalysisType.Name = "cbAnalysisType";
            this.cbAnalysisType.Size = new System.Drawing.Size(231, 38);
            this.cbAnalysisType.TabIndex = 8;
            this.cbAnalysisType.SelectedIndexChanged += new System.EventHandler(this.cbAnalysisType_SelectedIndexChanged);
            // 
            // btnCatchments
            // 
            this.btnCatchments.Location = new System.Drawing.Point(427, 247);
            this.btnCatchments.Name = "btnCatchments";
            this.btnCatchments.Size = new System.Drawing.Size(316, 42);
            this.btnCatchments.TabIndex = 14;
            this.btnCatchments.Text = "1.                   Enter Catchment";
            this.btnCatchments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnCatchments, "Step 1 of BMPTrains, Create and Enter Watershed Information");
            this.btnCatchments.UseVisualStyleBackColor = true;
            this.btnCatchments.Click += new System.EventHandler(this.btnCatchments_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(427, 295);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(316, 39);
            this.btnOptions.TabIndex = 16;
            this.btnOptions.Text = "2.                     Enter Treatment";
            this.btnOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnOptions, "Each Watershed can have Multiple BMPs, this allows you to enter this information");
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnConfiguration
            // 
            this.btnConfiguration.Location = new System.Drawing.Point(427, 340);
            this.btnConfiguration.Name = "btnConfiguration";
            this.btnConfiguration.Size = new System.Drawing.Size(316, 40);
            this.btnConfiguration.TabIndex = 20;
            this.btnConfiguration.Text = "3.           Configure Catchments";
            this.btnConfiguration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnConfiguration, "Catchments can be routed to other Catchments thrugh this option.");
            this.btnConfiguration.UseVisualStyleBackColor = true;
            this.btnConfiguration.Click += new System.EventHandler(this.btnConfiguration_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(427, 386);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(316, 40);
            this.btnReport.TabIndex = 24;
            this.btnReport.Text = "4.   Summary Treatment Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnReport, "Summary Report of the input and output information from routing.");
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnCostReport
            // 
            this.btnCostReport.Location = new System.Drawing.Point(427, 478);
            this.btnCostReport.Name = "btnCostReport";
            this.btnCostReport.Size = new System.Drawing.Size(316, 40);
            this.btnCostReport.TabIndex = 25;
            this.btnCostReport.Text = "6.                 Cost Comparisons";
            this.btnCostReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnCostReport, "Full Cost Report, and results also copied to Clipboard to allow paste into Excel");
            this.btnCostReport.UseVisualStyleBackColor = true;
            this.btnCostReport.Click += new System.EventHandler(this.btnCostReport_Click);
            // 
            // btnCatchmentReport
            // 
            this.btnCatchmentReport.Enabled = false;
            this.btnCatchmentReport.Location = new System.Drawing.Point(427, 432);
            this.btnCatchmentReport.Name = "btnCatchmentReport";
            this.btnCatchmentReport.Size = new System.Drawing.Size(316, 40);
            this.btnCatchmentReport.TabIndex = 28;
            this.btnCatchmentReport.Text = "5.                 Complete  Report";
            this.btnCatchmentReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnCatchmentReport, "Complete Report of all information");
            this.btnCatchmentReport.UseVisualStyleBackColor = true;
            this.btnCatchmentReport.Click += new System.EventHandler(this.btnCatchmentReport_Click);
            // 
            // lblN
            // 
            this.lblN.Location = new System.Drawing.Point(11, 253);
            this.lblN.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(342, 30);
            this.lblN.TabIndex = 10;
            this.lblN.Text = "Nitrogen Removal Efficiency (%):";
            this.lblN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblP
            // 
            this.lblP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblP.Location = new System.Drawing.Point(12, 291);
            this.lblP.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(341, 30);
            this.lblP.TabIndex = 11;
            this.lblP.Text = "Phosphorus Removal Efficiency (%):";
            this.lblP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbN
            // 
            this.tbN.Location = new System.Drawing.Point(354, 247);
            this.tbN.Name = "tbN";
            this.tbN.Size = new System.Drawing.Size(62, 35);
            this.tbN.TabIndex = 12;
            this.tbN.Text = "80";
            // 
            // tbP
            // 
            this.tbP.Location = new System.Drawing.Point(354, 291);
            this.tbP.Name = "tbP";
            this.tbP.Size = new System.Drawing.Size(62, 35);
            this.tbP.TabIndex = 13;
            this.tbP.Text = "80";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(44, 470);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(165, 48);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save Project";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(234, 470);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(170, 48);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "Exit BMPTrains";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbGroundwater
            // 
            this.cbGroundwater.FormattingEnabled = true;
            this.cbGroundwater.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cbGroundwater.Location = new System.Drawing.Point(645, 185);
            this.cbGroundwater.Name = "cbGroundwater";
            this.cbGroundwater.Size = new System.Drawing.Size(93, 38);
            this.cbGroundwater.TabIndex = 22;
            this.cbGroundwater.SelectedIndexChanged += new System.EventHandler(this.cbGroundwater_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 193);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(401, 30);
            this.label6.TabIndex = 21;
            this.label6.Text = "Conduct Groundwater Discharge Analysis:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnNewProject
            // 
            this.btnNewProject.Location = new System.Drawing.Point(234, 405);
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.Size = new System.Drawing.Size(170, 47);
            this.btnNewProject.TabIndex = 23;
            this.btnNewProject.Text = "New Project";
            this.btnNewProject.UseVisualStyleBackColor = true;
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // btnRecentProjects
            // 
            this.btnRecentProjects.Location = new System.Drawing.Point(44, 405);
            this.btnRecentProjects.Name = "btnRecentProjects";
            this.btnRecentProjects.Size = new System.Drawing.Size(165, 47);
            this.btnRecentProjects.TabIndex = 30;
            this.btnRecentProjects.Text = "Open Project";
            this.btnRecentProjects.UseVisualStyleBackColor = true;
            this.btnRecentProjects.Click += new System.EventHandler(this.btnRecentProjects_Click);
            // 
            // tbPercentLessThanPre
            // 
            this.tbPercentLessThanPre.Location = new System.Drawing.Point(354, 340);
            this.tbPercentLessThanPre.Name = "tbPercentLessThanPre";
            this.tbPercentLessThanPre.Size = new System.Drawing.Size(62, 35);
            this.tbPercentLessThanPre.TabIndex = 35;
            this.tbPercentLessThanPre.Text = "80";
            // 
            // lblPercentLessThanPre
            // 
            this.lblPercentLessThanPre.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPercentLessThanPre.Location = new System.Drawing.Point(12, 340);
            this.lblPercentLessThanPre.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPercentLessThanPre.Name = "lblPercentLessThanPre";
            this.lblPercentLessThanPre.Size = new System.Drawing.Size(341, 30);
            this.lblPercentLessThanPre.TabIndex = 34;
            this.lblPercentLessThanPre.Text = "Select % less than Pre (0.1-10%):";
            this.lblPercentLessThanPre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTest
            // 
            this.btnTest.AutoEllipsis = true;
            this.btnTest.BackColor = System.Drawing.SystemColors.Info;
            this.btnTest.Location = new System.Drawing.Point(11, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(261, 43);
            this.btnTest.TabIndex = 36;
            this.btnTest.Text = "Help and Documentation";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnRainfallMap
            // 
            this.btnRainfallMap.BackColor = System.Drawing.SystemColors.Info;
            this.btnRainfallMap.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRainfallMap.Location = new System.Drawing.Point(744, 99);
            this.btnRainfallMap.Name = "btnRainfallMap";
            this.btnRainfallMap.Size = new System.Drawing.Size(34, 38);
            this.btnRainfallMap.TabIndex = 37;
            this.btnRainfallMap.Text = "?";
            this.btnRainfallMap.UseVisualStyleBackColor = false;
            this.btnRainfallMap.Click += new System.EventHandler(this.btnRainfallMap_Click_1);
            // 
            // btnZoneMaps
            // 
            this.btnZoneMaps.BackColor = System.Drawing.SystemColors.Info;
            this.btnZoneMaps.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZoneMaps.Location = new System.Drawing.Point(744, 55);
            this.btnZoneMaps.Name = "btnZoneMaps";
            this.btnZoneMaps.Size = new System.Drawing.Size(34, 38);
            this.btnZoneMaps.TabIndex = 38;
            this.btnZoneMaps.Text = "?";
            this.btnZoneMaps.UseVisualStyleBackColor = false;
            this.btnZoneMaps.Click += new System.EventHandler(this.btnZoneMaps_Click_1);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.SystemColors.Info;
            this.btnHelp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnHelp.Location = new System.Drawing.Point(744, 11);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(34, 38);
            this.btnHelp.TabIndex = 39;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click_1);
            // 
            // GeneralSiteInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 537);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnZoneMaps);
            this.Controls.Add(this.btnRainfallMap);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.tbPercentLessThanPre);
            this.Controls.Add(this.lblPercentLessThanPre);
            this.Controls.Add(this.btnRecentProjects);
            this.Controls.Add(this.btnCatchmentReport);
            this.Controls.Add(this.btnCostReport);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnNewProject);
            this.Controls.Add(this.cbGroundwater);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnConfiguration);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnCatchments);
            this.Controls.Add(this.tbP);
            this.Controls.Add(this.tbN);
            this.Controls.Add(this.lblP);
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.cbAnalysisType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbMeanAnnualRainfall);
            this.Controls.Add(this.cbMetZone);
            this.Controls.Add(this.tbProjectName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "GeneralSiteInformation";
            this.Text = "Site Information and Navigation Worksheet";
            this.Load += new System.EventHandler(this.GeneralSiteInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbProjectName;
        private System.Windows.Forms.ComboBox cbMetZone;
        private System.Windows.Forms.TextBox tbMeanAnnualRainfall;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbAnalysisType;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.TextBox tbN;
        private System.Windows.Forms.TextBox tbP;
        private System.Windows.Forms.Button btnCatchments;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConfiguration;
        private System.Windows.Forms.ComboBox cbGroundwater;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNewProject;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnCostReport;
        private System.Windows.Forms.Button btnCatchmentReport;
        private System.Windows.Forms.Button btnRecentProjects;
        private System.Windows.Forms.TextBox tbPercentLessThanPre;
        private System.Windows.Forms.Label lblPercentLessThanPre;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnRainfallMap;
        private System.Windows.Forms.Button btnZoneMaps;
        private System.Windows.Forms.Button btnHelp;
    }
}