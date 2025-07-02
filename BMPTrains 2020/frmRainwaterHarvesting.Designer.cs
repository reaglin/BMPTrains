namespace BMPTrains_2020
{
    partial class frmRainwaterHarvesting
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
            this.tbContributingArea = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbHarvestRate = new System.Windows.Forms.TextBox();
            this.lblHarvest = new System.Windows.Forms.Label();
            this.tbHarvestVolume = new System.Windows.Forms.TextBox();
            this.tbIrrigationArea = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.wbOutput = new System.Windows.Forms.WebBrowser();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbHarvestRate = new System.Windows.Forms.RadioButton();
            this.rbHarvestEfficiency = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label5 = new System.Windows.Forms.Label();
            this.cbRoofType = new System.Windows.Forms.ComboBox();
            this.btnEfficiencyTable = new System.Windows.Forms.Button();
            this.btnCost = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbContributingArea
            // 
            this.tbContributingArea.BackColor = System.Drawing.SystemColors.Info;
            this.tbContributingArea.Enabled = false;
            this.tbContributingArea.Location = new System.Drawing.Point(714, 45);
            this.tbContributingArea.Name = "tbContributingArea";
            this.tbContributingArea.Size = new System.Drawing.Size(115, 35);
            this.tbContributingArea.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(483, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 30);
            this.label4.TabIndex = 60;
            this.label4.Text = "Contributing Area (SF):";
            // 
            // tbHarvestRate
            // 
            this.tbHarvestRate.Location = new System.Drawing.Point(714, 170);
            this.tbHarvestRate.Name = "tbHarvestRate";
            this.tbHarvestRate.Size = new System.Drawing.Size(115, 35);
            this.tbHarvestRate.TabIndex = 4;
            // 
            // lblHarvest
            // 
            this.lblHarvest.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHarvest.Location = new System.Drawing.Point(400, 173);
            this.lblHarvest.Name = "lblHarvest";
            this.lblHarvest.Size = new System.Drawing.Size(308, 30);
            this.lblHarvest.TabIndex = 57;
            this.lblHarvest.Text = "Harvest Rate (in/week):";
            this.lblHarvest.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbHarvestVolume
            // 
            this.tbHarvestVolume.Location = new System.Drawing.Point(714, 128);
            this.tbHarvestVolume.Name = "tbHarvestVolume";
            this.tbHarvestVolume.Size = new System.Drawing.Size(115, 35);
            this.tbHarvestVolume.TabIndex = 3;
            // 
            // tbIrrigationArea
            // 
            this.tbIrrigationArea.Location = new System.Drawing.Point(714, 87);
            this.tbIrrigationArea.Name = "tbIrrigationArea";
            this.tbIrrigationArea.Size = new System.Drawing.Size(115, 35);
            this.tbIrrigationArea.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 30);
            this.label2.TabIndex = 54;
            this.label2.Text = "Available Harvest Volume (gal):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 30);
            this.label1.TabIndex = 53;
            this.label1.Text = "Area Available for Irrigation (SF):";
            // 
            // wbOutput
            // 
            this.wbOutput.Location = new System.Drawing.Point(12, 215);
            this.wbOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOutput.Name = "wbOutput";
            this.wbOutput.Size = new System.Drawing.Size(666, 329);
            this.wbOutput.TabIndex = 52;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(717, 269);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(112, 39);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Visible = false;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(717, 314);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(112, 39);
            this.btnCalculate.TabIndex = 8;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(717, 404);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 39);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(717, 449);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(112, 39);
            this.btnReport.TabIndex = 10;
            this.btnReport.Text = "Copy";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(717, 494);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 39);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Back";
            this.toolTip1.SetToolTip(this.btnClose, "Exit the Current Worksheet");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbHarvestRate);
            this.groupBox1.Controls.Add(this.rbHarvestEfficiency);
            this.groupBox1.Location = new System.Drawing.Point(22, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 126);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Calculation Option";
            this.groupBox1.Visible = false;
            // 
            // rbHarvestRate
            // 
            this.rbHarvestRate.AutoSize = true;
            this.rbHarvestRate.Location = new System.Drawing.Point(19, 78);
            this.rbHarvestRate.Name = "rbHarvestRate";
            this.rbHarvestRate.Size = new System.Drawing.Size(236, 34);
            this.rbHarvestRate.TabIndex = 7;
            this.rbHarvestRate.TabStop = true;
            this.rbHarvestRate.Text = "Solve for Harvest Rate";
            this.rbHarvestRate.UseVisualStyleBackColor = true;
            this.rbHarvestRate.Click += new System.EventHandler(this.rbHarvestRate_Click);
            // 
            // rbHarvestEfficiency
            // 
            this.rbHarvestEfficiency.AutoSize = true;
            this.rbHarvestEfficiency.Location = new System.Drawing.Point(19, 38);
            this.rbHarvestEfficiency.Name = "rbHarvestEfficiency";
            this.rbHarvestEfficiency.Size = new System.Drawing.Size(282, 34);
            this.rbHarvestEfficiency.TabIndex = 6;
            this.rbHarvestEfficiency.TabStop = true;
            this.rbHarvestEfficiency.Text = "Solve for Harvest Efficiency";
            this.rbHarvestEfficiency.UseVisualStyleBackColor = true;
            this.rbHarvestEfficiency.Click += new System.EventHandler(this.rbHarvestEfficiency_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(857, 24);
            this.menuStrip1.TabIndex = 59;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 30);
            this.label5.TabIndex = 62;
            this.label5.Text = "Roof Type:";
            // 
            // cbRoofType
            // 
            this.cbRoofType.FormattingEnabled = true;
            this.cbRoofType.Location = new System.Drawing.Point(134, 35);
            this.cbRoofType.Name = "cbRoofType";
            this.cbRoofType.Size = new System.Drawing.Size(322, 38);
            this.cbRoofType.TabIndex = 5;
            // 
            // btnEfficiencyTable
            // 
            this.btnEfficiencyTable.Location = new System.Drawing.Point(717, 224);
            this.btnEfficiencyTable.Name = "btnEfficiencyTable";
            this.btnEfficiencyTable.Size = new System.Drawing.Size(112, 39);
            this.btnEfficiencyTable.TabIndex = 6;
            this.btnEfficiencyTable.Text = "Efficiency";
            this.btnEfficiencyTable.UseVisualStyleBackColor = true;
            this.btnEfficiencyTable.Click += new System.EventHandler(this.btnEfficiencyTable_Click);
            // 
            // btnCost
            // 
            this.btnCost.Location = new System.Drawing.Point(717, 359);
            this.btnCost.Name = "btnCost";
            this.btnCost.Size = new System.Drawing.Size(112, 39);
            this.btnCost.TabIndex = 63;
            this.btnCost.Text = "Cost";
            this.btnCost.UseVisualStyleBackColor = true;
            this.btnCost.Click += new System.EventHandler(this.btnCost_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(44, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(634, 19);
            this.label3.TabIndex = 64;
            this.label3.Text = "Use this harvesting option when all harvest volume can be used, and the water can" +
    " be used every day.";
            // 
            // frmRainwaterHarvesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 556);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCost);
            this.Controls.Add(this.btnEfficiencyTable);
            this.Controls.Add(this.cbRoofType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbContributingArea);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbHarvestRate);
            this.Controls.Add(this.lblHarvest);
            this.Controls.Add(this.tbHarvestVolume);
            this.Controls.Add(this.tbIrrigationArea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wbOutput);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmRainwaterHarvesting";
            this.Text = "Rainwater Harvesting Worksheet";
            this.Load += new System.EventHandler(this.frmRainwaterHarvesting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbContributingArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbHarvestRate;
        private System.Windows.Forms.Label lblHarvest;
        private System.Windows.Forms.TextBox tbHarvestVolume;
        private System.Windows.Forms.TextBox tbIrrigationArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser wbOutput;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbHarvestRate;
        private System.Windows.Forms.RadioButton rbHarvestEfficiency;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbRoofType;
        private System.Windows.Forms.Button btnEfficiencyTable;
        private System.Windows.Forms.Button btnCost;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
    }
}