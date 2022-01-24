namespace BMPTrains_2020
{
    partial class frmStormwaterHarvesting
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
            this.tbHarvestRate = new System.Windows.Forms.TextBox();
            this.lblHarvest = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tbContributingArea = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCost = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbHarvestVolume
            // 
            this.tbHarvestVolume.Location = new System.Drawing.Point(714, 132);
            this.tbHarvestVolume.Name = "tbHarvestVolume";
            this.tbHarvestVolume.Size = new System.Drawing.Size(115, 35);
            this.tbHarvestVolume.TabIndex = 3;
            // 
            // tbIrrigationArea
            // 
            this.tbIrrigationArea.Location = new System.Drawing.Point(714, 91);
            this.tbIrrigationArea.Name = "tbIrrigationArea";
            this.tbIrrigationArea.Size = new System.Drawing.Size(115, 35);
            this.tbIrrigationArea.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(483, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 30);
            this.label2.TabIndex = 38;
            this.label2.Text = "Harvest Volume (ac-ft):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 30);
            this.label1.TabIndex = 37;
            this.label1.Text = "Area Available for Irrigation (ac):";
            // 
            // wbOutput
            // 
            this.wbOutput.Location = new System.Drawing.Point(12, 259);
            this.wbOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOutput.Name = "wbOutput";
            this.wbOutput.Size = new System.Drawing.Size(666, 271);
            this.wbOutput.TabIndex = 36;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(714, 259);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(112, 39);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Visible = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(714, 304);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(112, 39);
            this.btnCalculate.TabIndex = 8;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(714, 394);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 39);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(714, 439);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(112, 39);
            this.btnReport.TabIndex = 10;
            this.btnReport.Text = "Copy";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(714, 484);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 126);
            this.groupBox1.TabIndex = 6;
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
            this.rbHarvestRate.TabIndex = 1;
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
            this.rbHarvestEfficiency.TabIndex = 0;
            this.rbHarvestEfficiency.TabStop = true;
            this.rbHarvestEfficiency.Text = "Solve for Harvest Efficiency";
            this.rbHarvestEfficiency.UseVisualStyleBackColor = true;
            this.rbHarvestEfficiency.Click += new System.EventHandler(this.rbHarvestEfficiency_Click);
            // 
            // tbHarvestRate
            // 
            this.tbHarvestRate.Location = new System.Drawing.Point(714, 173);
            this.tbHarvestRate.Name = "tbHarvestRate";
            this.tbHarvestRate.Size = new System.Drawing.Size(115, 35);
            this.tbHarvestRate.TabIndex = 4;
            this.toolTip1.SetToolTip(this.tbHarvestRate, "0.1 - 4.0 inches/week over Irrigation Area");
            // 
            // lblHarvest
            // 
            this.lblHarvest.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHarvest.Location = new System.Drawing.Point(318, 178);
            this.lblHarvest.Name = "lblHarvest";
            this.lblHarvest.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblHarvest.Size = new System.Drawing.Size(391, 30);
            this.lblHarvest.TabIndex = 41;
            this.lblHarvest.Text = "Harvest Rate (in/week):";
            this.lblHarvest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(869, 24);
            this.menuStrip1.TabIndex = 43;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // tbContributingArea
            // 
            this.tbContributingArea.Enabled = false;
            this.tbContributingArea.Location = new System.Drawing.Point(714, 49);
            this.tbContributingArea.Name = "tbContributingArea";
            this.tbContributingArea.Size = new System.Drawing.Size(115, 35);
            this.tbContributingArea.TabIndex = 1;
            this.tbContributingArea.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(436, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 30);
            this.label4.TabIndex = 44;
            this.label4.Text = "Total Contributing Area (ac):";
            this.label4.Visible = false;
            // 
            // btnCost
            // 
            this.btnCost.Location = new System.Drawing.Point(714, 349);
            this.btnCost.Name = "btnCost";
            this.btnCost.Size = new System.Drawing.Size(112, 39);
            this.btnCost.TabIndex = 47;
            this.btnCost.Text = "Cost";
            this.btnCost.UseVisualStyleBackColor = true;
            this.btnCost.Click += new System.EventHandler(this.btnCost_Click);
            // 
            // frmStormwaterHarvesting
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(869, 548);
            this.ControlBox = false;
            this.Controls.Add(this.btnCost);
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
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStormwaterHarvesting";
            this.Text = "Stormwater Harvesting Worksheet";
            this.Load += new System.EventHandler(this.frmStormwaterHarvesting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.TextBox tbHarvestRate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblHarvest;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox tbContributingArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCost;
    }
}