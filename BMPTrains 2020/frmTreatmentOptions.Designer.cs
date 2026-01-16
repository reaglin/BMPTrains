namespace BMPTrains_2020
{
    partial class frmTreatmentOptions
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
            this.btnRetention = new System.Windows.Forms.Button();
            this.bthDetention = new System.Windows.Forms.Button();
            this.btnSwale = new System.Windows.Forms.Button();
            this.pbOptions = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btExfiltration = new System.Windows.Forms.Button();
            this.btnPeriousPavement = new System.Windows.Forms.Button();
            this.btnStormwaterHarvesting = new System.Windows.Forms.Button();
            this.btnRainwater = new System.Windows.Forms.Button();
            this.btnNaturalBuffer = new System.Windows.Forms.Button();
            this.btnFilterStrip = new System.Windows.Forms.Button();
            this.btnRainGarden = new System.Windows.Forms.Button();
            this.btnTreeWell = new System.Windows.Forms.Button();
            this.btnUserDefined = new System.Windows.Forms.Button();
            this.btnWatershed = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.buttonCalculators = new System.Windows.Forms.Button();
            this.btnTools = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnBMPs = new System.Windows.Forms.Button();
            this.btnPlots = new System.Windows.Forms.Button();
            this.btnBiofiltration = new System.Windows.Forms.Button();
            this.btnGreenroof = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbOptions)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRetention
            // 
            this.btnRetention.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetention.Location = new System.Drawing.Point(6, 35);
            this.btnRetention.Name = "btnRetention";
            this.btnRetention.Size = new System.Drawing.Size(130, 51);
            this.btnRetention.TabIndex = 0;
            this.btnRetention.Text = "Retention\r\nBasin";
            this.toolTip1.SetToolTip(this.btnRetention, "Retention Basin with options for calculating effluent concentrations");
            this.btnRetention.UseVisualStyleBackColor = true;
            this.btnRetention.Click += new System.EventHandler(this.btnRetention_Click);
            this.btnRetention.MouseHover += new System.EventHandler(this.btnRetention_MouseHover);
            // 
            // bthDetention
            // 
            this.bthDetention.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bthDetention.Location = new System.Drawing.Point(6, 92);
            this.bthDetention.Name = "bthDetention";
            this.bthDetention.Size = new System.Drawing.Size(130, 51);
            this.bthDetention.TabIndex = 2;
            this.bthDetention.Text = "Wet\r\nDetention";
            this.toolTip1.SetToolTip(this.bthDetention, "Wet Detention");
            this.bthDetention.UseVisualStyleBackColor = true;
            this.bthDetention.Click += new System.EventHandler(this.bthDetention_Click);
            this.bthDetention.MouseHover += new System.EventHandler(this.bthDetention_MouseHover);
            // 
            // btnSwale
            // 
            this.btnSwale.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwale.Location = new System.Drawing.Point(6, 377);
            this.btnSwale.Name = "btnSwale";
            this.btnSwale.Size = new System.Drawing.Size(130, 51);
            this.btnSwale.TabIndex = 3;
            this.btnSwale.Text = "Swale";
            this.btnSwale.UseVisualStyleBackColor = true;
            this.btnSwale.Click += new System.EventHandler(this.bthSwale_Click);
            this.btnSwale.MouseHover += new System.EventHandler(this.bthSwale_MouseHover);
            // 
            // pbOptions
            // 
            this.pbOptions.Location = new System.Drawing.Point(319, 61);
            this.pbOptions.Name = "pbOptions";
            this.pbOptions.Size = new System.Drawing.Size(516, 348);
            this.pbOptions.TabIndex = 1;
            this.pbOptions.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(734, 470);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 46);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Back";
            this.toolTip1.SetToolTip(this.btnExit, "Exit the Current Worksheet");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btExfiltration
            // 
            this.btExfiltration.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExfiltration.Location = new System.Drawing.Point(6, 149);
            this.btExfiltration.Name = "btExfiltration";
            this.btExfiltration.Size = new System.Drawing.Size(130, 51);
            this.btExfiltration.TabIndex = 5;
            this.btExfiltration.Text = "Exfiltration\r\nTrench/Vault";
            this.toolTip1.SetToolTip(this.btExfiltration, "Exfiltration Trench");
            this.btExfiltration.UseVisualStyleBackColor = true;
            this.btExfiltration.Click += new System.EventHandler(this.btExfiltration_Click);
            this.btExfiltration.MouseHover += new System.EventHandler(this.btExfiltration_MouseHover);
            // 
            // btnPeriousPavement
            // 
            this.btnPeriousPavement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeriousPavement.Location = new System.Drawing.Point(6, 206);
            this.btnPeriousPavement.Name = "btnPeriousPavement";
            this.btnPeriousPavement.Size = new System.Drawing.Size(130, 51);
            this.btnPeriousPavement.TabIndex = 6;
            this.btnPeriousPavement.Text = "Permeable \r\nPavement";
            this.toolTip1.SetToolTip(this.btnPeriousPavement, "Permeable Pavement");
            this.btnPeriousPavement.UseVisualStyleBackColor = true;
            this.btnPeriousPavement.Click += new System.EventHandler(this.btnPeriousPavement_Click);
            this.btnPeriousPavement.MouseHover += new System.EventHandler(this.btnPeriousPavement_MouseHover);
            // 
            // btnStormwaterHarvesting
            // 
            this.btnStormwaterHarvesting.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStormwaterHarvesting.Location = new System.Drawing.Point(6, 263);
            this.btnStormwaterHarvesting.Name = "btnStormwaterHarvesting";
            this.btnStormwaterHarvesting.Size = new System.Drawing.Size(130, 51);
            this.btnStormwaterHarvesting.TabIndex = 7;
            this.btnStormwaterHarvesting.Text = "Stormwater\r\nHarvesting";
            this.toolTip1.SetToolTip(this.btnStormwaterHarvesting, "Stormwater Harvesting");
            this.btnStormwaterHarvesting.UseVisualStyleBackColor = true;
            this.btnStormwaterHarvesting.Click += new System.EventHandler(this.btnStormwaterHarvesting_Click);
            this.btnStormwaterHarvesting.MouseHover += new System.EventHandler(this.btnStormwaterHarvesting_MouseHover);
            // 
            // btnRainwater
            // 
            this.btnRainwater.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRainwater.Location = new System.Drawing.Point(149, 92);
            this.btnRainwater.Name = "btnRainwater";
            this.btnRainwater.Size = new System.Drawing.Size(130, 51);
            this.btnRainwater.TabIndex = 10;
            this.btnRainwater.Text = "Rainwater\r\nHarvesting";
            this.toolTip1.SetToolTip(this.btnRainwater, "Rainwater Harvesting");
            this.btnRainwater.UseVisualStyleBackColor = true;
            this.btnRainwater.Click += new System.EventHandler(this.btnRainwater_Click);
            this.btnRainwater.MouseHover += new System.EventHandler(this.btnRainwater_MouseHover);
            // 
            // btnNaturalBuffer
            // 
            this.btnNaturalBuffer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNaturalBuffer.Location = new System.Drawing.Point(149, 149);
            this.btnNaturalBuffer.Name = "btnNaturalBuffer";
            this.btnNaturalBuffer.Size = new System.Drawing.Size(130, 51);
            this.btnNaturalBuffer.TabIndex = 12;
            this.btnNaturalBuffer.Text = "Vegetated\r\nBuffer";
            this.toolTip1.SetToolTip(this.btnNaturalBuffer, "Vegetated Natural Buffer");
            this.btnNaturalBuffer.UseVisualStyleBackColor = true;
            this.btnNaturalBuffer.Click += new System.EventHandler(this.btnNaturalBuffer_Click);
            this.btnNaturalBuffer.MouseHover += new System.EventHandler(this.btnNaturalBuffer_MouseHover);
            // 
            // btnFilterStrip
            // 
            this.btnFilterStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterStrip.Location = new System.Drawing.Point(149, 206);
            this.btnFilterStrip.Name = "btnFilterStrip";
            this.btnFilterStrip.Size = new System.Drawing.Size(130, 51);
            this.btnFilterStrip.TabIndex = 13;
            this.btnFilterStrip.Text = "Vegetated\r\nFilter Strip";
            this.toolTip1.SetToolTip(this.btnFilterStrip, "Vegetated Filter Strip");
            this.btnFilterStrip.UseVisualStyleBackColor = true;
            this.btnFilterStrip.Click += new System.EventHandler(this.btnFilterStrip_Click);
            this.btnFilterStrip.MouseHover += new System.EventHandler(this.btnFilterStrip_MouseHover);
            // 
            // btnRainGarden
            // 
            this.btnRainGarden.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRainGarden.Location = new System.Drawing.Point(149, 263);
            this.btnRainGarden.Name = "btnRainGarden";
            this.btnRainGarden.Size = new System.Drawing.Size(130, 51);
            this.btnRainGarden.TabIndex = 14;
            this.btnRainGarden.Text = "Rain\r\nGarden";
            this.toolTip1.SetToolTip(this.btnRainGarden, "Rain Garden");
            this.btnRainGarden.UseVisualStyleBackColor = true;
            this.btnRainGarden.Click += new System.EventHandler(this.btnRainGarden_Click);
            this.btnRainGarden.MouseHover += new System.EventHandler(this.btnRainGarden_MouseHover);
            // 
            // btnTreeWell
            // 
            this.btnTreeWell.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTreeWell.Location = new System.Drawing.Point(149, 320);
            this.btnTreeWell.Name = "btnTreeWell";
            this.btnTreeWell.Size = new System.Drawing.Size(130, 51);
            this.btnTreeWell.TabIndex = 15;
            this.btnTreeWell.Text = "Tree Well";
            this.toolTip1.SetToolTip(this.btnTreeWell, "Tree Well");
            this.btnTreeWell.UseVisualStyleBackColor = true;
            this.btnTreeWell.Click += new System.EventHandler(this.btnTreeWell_Click);
            this.btnTreeWell.MouseHover += new System.EventHandler(this.btnTreeWell_MouseHover);
            // 
            // btnUserDefined
            // 
            this.btnUserDefined.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserDefined.Location = new System.Drawing.Point(149, 379);
            this.btnUserDefined.Name = "btnUserDefined";
            this.btnUserDefined.Size = new System.Drawing.Size(130, 51);
            this.btnUserDefined.TabIndex = 17;
            this.btnUserDefined.Text = "User\r\nDefined";
            this.toolTip1.SetToolTip(this.btnUserDefined, "User Defined BMP");
            this.btnUserDefined.UseVisualStyleBackColor = true;
            this.btnUserDefined.Click += new System.EventHandler(this.btnUserDefined_Click);
            // 
            // btnWatershed
            // 
            this.btnWatershed.Location = new System.Drawing.Point(479, 470);
            this.btnWatershed.Name = "btnWatershed";
            this.btnWatershed.Size = new System.Drawing.Size(122, 46);
            this.btnWatershed.TabIndex = 20;
            this.btnWatershed.Text = "Catchments";
            this.toolTip1.SetToolTip(this.btnWatershed, "Catchment Editor");
            this.btnWatershed.UseVisualStyleBackColor = true;
            this.btnWatershed.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(734, 418);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(101, 46);
            this.btnReset.TabIndex = 22;
            this.btnReset.Text = "Reset All";
            this.toolTip1.SetToolTip(this.btnReset, "Reset all BMP\'s for Catchment");
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // buttonCalculators
            // 
            this.buttonCalculators.Location = new System.Drawing.Point(617, 470);
            this.buttonCalculators.Name = "buttonCalculators";
            this.buttonCalculators.Size = new System.Drawing.Size(111, 46);
            this.buttonCalculators.TabIndex = 18;
            this.buttonCalculators.Text = "Cost Report";
            this.toolTip1.SetToolTip(this.buttonCalculators, "Will open a report with cost data and copy the data to the clipboard (for paste i" +
        "nto Excel)");
            this.buttonCalculators.UseVisualStyleBackColor = true;
            this.buttonCalculators.Click += new System.EventHandler(this.buttonCalculators_Click);
            // 
            // btnTools
            // 
            this.btnTools.Location = new System.Drawing.Point(617, 418);
            this.btnTools.Name = "btnTools";
            this.btnTools.Size = new System.Drawing.Size(111, 46);
            this.btnTools.TabIndex = 24;
            this.btnTools.Text = "Tools";
            this.toolTip1.SetToolTip(this.btnTools, "Calculating tools helpful for design");
            this.btnTools.UseVisualStyleBackColor = true;
            this.btnTools.Click += new System.EventHandler(this.btnTools_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(319, 470);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(74, 46);
            this.btnHelp.TabIndex = 25;
            this.btnHelp.Text = "Help";
            this.toolTip1.SetToolTip(this.btnHelp, "Open online help ");
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnBMPs
            // 
            this.btnBMPs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBMPs.Location = new System.Drawing.Point(6, 434);
            this.btnBMPs.Name = "btnBMPs";
            this.btnBMPs.Size = new System.Drawing.Size(130, 46);
            this.btnBMPs.TabIndex = 19;
            this.btnBMPs.Text = "BMPs in Series";
            this.toolTip1.SetToolTip(this.btnBMPs, "For more than one BMP in the same Catchment");
            this.btnBMPs.UseVisualStyleBackColor = true;
            this.btnBMPs.Click += new System.EventHandler(this.btnBMPs_Click);
            // 
            // btnPlots
            // 
            this.btnPlots.Location = new System.Drawing.Point(479, 418);
            this.btnPlots.Name = "btnPlots";
            this.btnPlots.Size = new System.Drawing.Size(122, 46);
            this.btnPlots.TabIndex = 29;
            this.btnPlots.Text = "Plots";
            this.toolTip1.SetToolTip(this.btnPlots, "Calculating tools helpful for design");
            this.btnPlots.UseVisualStyleBackColor = true;
            this.btnPlots.Visible = false;
            // 
            // btnBiofiltration
            // 
            this.btnBiofiltration.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBiofiltration.Location = new System.Drawing.Point(6, 320);
            this.btnBiofiltration.Name = "btnBiofiltration";
            this.btnBiofiltration.Size = new System.Drawing.Size(130, 51);
            this.btnBiofiltration.TabIndex = 8;
            this.btnBiofiltration.Text = "Surface Discharge Filter";
            this.btnBiofiltration.UseVisualStyleBackColor = true;
            this.btnBiofiltration.Click += new System.EventHandler(this.btnBiofiltration_Click);
            this.btnBiofiltration.MouseHover += new System.EventHandler(this.btnBiofiltration_MouseHover);
            // 
            // btnGreenroof
            // 
            this.btnGreenroof.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGreenroof.Location = new System.Drawing.Point(149, 35);
            this.btnGreenroof.Name = "btnGreenroof";
            this.btnGreenroof.Size = new System.Drawing.Size(130, 51);
            this.btnGreenroof.TabIndex = 9;
            this.btnGreenroof.Text = "Greenroof";
            this.btnGreenroof.UseVisualStyleBackColor = true;
            this.btnGreenroof.Click += new System.EventHandler(this.btnGreenroof_Click);
            this.btnGreenroof.MouseHover += new System.EventHandler(this.btnGreenroof_MouseHover);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(314, 36);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 30);
            this.lblError.TabIndex = 21;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(853, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Controls.Add(this.btnUserDefined);
            this.groupBox1.Controls.Add(this.btnRetention);
            this.groupBox1.Controls.Add(this.bthDetention);
            this.groupBox1.Controls.Add(this.btnSwale);
            this.groupBox1.Controls.Add(this.btExfiltration);
            this.groupBox1.Controls.Add(this.btnPeriousPavement);
            this.groupBox1.Controls.Add(this.btnBMPs);
            this.groupBox1.Controls.Add(this.btnStormwaterHarvesting);
            this.groupBox1.Controls.Add(this.btnBiofiltration);
            this.groupBox1.Controls.Add(this.btnGreenroof);
            this.groupBox1.Controls.Add(this.btnTreeWell);
            this.groupBox1.Controls.Add(this.btnRainwater);
            this.groupBox1.Controls.Add(this.btnRainGarden);
            this.groupBox1.Controls.Add(this.btnNaturalBuffer);
            this.groupBox1.Controls.Add(this.btnFilterStrip);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 486);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Treatment Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 30);
            this.label1.TabIndex = 27;
            this.label1.Text = "Current:";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(426, 24);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(131, 30);
            this.lblCurrent.TabIndex = 28;
            this.lblCurrent.Text = "Catchment 1";
            // 
            // frmTreatmentOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(853, 525);
            this.ControlBox = false;
            this.Controls.Add(this.btnPlots);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnTools);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnWatershed);
            this.Controls.Add(this.buttonCalculators);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pbOptions);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmTreatmentOptions";
            this.Text = "Select Treatment Options for individual performance, not in series or in multiple" +
    " catchments.";
            this.Load += new System.EventHandler(this.frmTreatmentOptions_Load);
            this.MouseHover += new System.EventHandler(this.frmTreatmentOptions_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.pbOptions)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRetention;
        private System.Windows.Forms.PictureBox pbOptions;
        private System.Windows.Forms.Button bthDetention;
        private System.Windows.Forms.Button btnSwale;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btExfiltration;
        private System.Windows.Forms.Button btnPeriousPavement;
        private System.Windows.Forms.Button btnStormwaterHarvesting;
        private System.Windows.Forms.Button btnBiofiltration;
        private System.Windows.Forms.Button btnGreenroof;
        private System.Windows.Forms.Button btnRainwater;
        private System.Windows.Forms.Button btnNaturalBuffer;
        private System.Windows.Forms.Button btnFilterStrip;
        private System.Windows.Forms.Button btnRainGarden;
        private System.Windows.Forms.Button btnTreeWell;
        private System.Windows.Forms.Button btnUserDefined;
        private System.Windows.Forms.Button buttonCalculators;
        private System.Windows.Forms.Button btnBMPs;
        private System.Windows.Forms.Button btnWatershed;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnTools;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Button btnPlots;
    }
}