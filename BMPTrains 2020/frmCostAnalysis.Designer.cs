namespace BMPTrains_2020
{
    partial class frmCostAnalysis
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.wbOutput = new System.Windows.Forms.WebBrowser();
            this.tbLandCost = new System.Windows.Forms.TextBox();
            this.tbFixedCost = new System.Windows.Forms.TextBox();
            this.tbExpectedLife = new System.Windows.Forms.TextBox();
            this.tbCostPerAcreFoot = new System.Windows.Forms.TextBox();
            this.tbHarvestedWater = new System.Windows.Forms.TextBox();
            this.tbMaintenanceCost = new System.Windows.Forms.TextBox();
            this.tbFutureReplacementCost = new System.Windows.Forms.TextBox();
            this.tbInterestRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbProjectDuration = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCostOfWater = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnScenario = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.tbScenarioName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbScenarioDescription = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(355, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cost of Land Needed for the BMP ($)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fixed Cost ($)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(276, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "Expected Life of BMP (years)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(313, 30);
            this.label4.TabIndex = 8;
            this.label4.Text = "BMP Cost Per Acre Foot ($/ac-ft)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(294, 30);
            this.label5.TabIndex = 10;
            this.label5.Text = "Harvested Water (1000 gal /yr)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(356, 30);
            this.label6.TabIndex = 12;
            this.label6.Text = "Annual BMP Maintenance Cost ($/yr)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(362, 30);
            this.label7.TabIndex = 14;
            this.label7.Text = "Replacement Cost at Expected Life ($)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(633, 257);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(112, 39);
            this.btnHelp.TabIndex = 29;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(751, 212);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 39);
            this.btnPrint.TabIndex = 27;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(633, 212);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(112, 39);
            this.btnReport.TabIndex = 26;
            this.btnReport.Text = "Copy";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(751, 257);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 39);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Back";
            this.toolTip1.SetToolTip(this.btnClose, "Items are not saved in Calculators, make copy before returning if you wish to sav" +
        "e.");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // wbOutput
            // 
            this.wbOutput.Location = new System.Drawing.Point(5, 353);
            this.wbOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOutput.Name = "wbOutput";
            this.wbOutput.Size = new System.Drawing.Size(858, 243);
            this.wbOutput.TabIndex = 31;
            // 
            // tbLandCost
            // 
            this.tbLandCost.Location = new System.Drawing.Point(383, 12);
            this.tbLandCost.Name = "tbLandCost";
            this.tbLandCost.Size = new System.Drawing.Size(105, 35);
            this.tbLandCost.TabIndex = 1;
            // 
            // tbFixedCost
            // 
            this.tbFixedCost.Location = new System.Drawing.Point(383, 56);
            this.tbFixedCost.Name = "tbFixedCost";
            this.tbFixedCost.Size = new System.Drawing.Size(105, 35);
            this.tbFixedCost.TabIndex = 2;
            // 
            // tbExpectedLife
            // 
            this.tbExpectedLife.Location = new System.Drawing.Point(383, 100);
            this.tbExpectedLife.Name = "tbExpectedLife";
            this.tbExpectedLife.Size = new System.Drawing.Size(105, 35);
            this.tbExpectedLife.TabIndex = 3;
            // 
            // tbCostPerAcreFoot
            // 
            this.tbCostPerAcreFoot.Location = new System.Drawing.Point(383, 140);
            this.tbCostPerAcreFoot.Name = "tbCostPerAcreFoot";
            this.tbCostPerAcreFoot.Size = new System.Drawing.Size(105, 35);
            this.tbCostPerAcreFoot.TabIndex = 4;
            // 
            // tbHarvestedWater
            // 
            this.tbHarvestedWater.Location = new System.Drawing.Point(383, 181);
            this.tbHarvestedWater.Name = "tbHarvestedWater";
            this.tbHarvestedWater.Size = new System.Drawing.Size(105, 35);
            this.tbHarvestedWater.TabIndex = 5;
            // 
            // tbMaintenanceCost
            // 
            this.tbMaintenanceCost.Location = new System.Drawing.Point(383, 222);
            this.tbMaintenanceCost.Name = "tbMaintenanceCost";
            this.tbMaintenanceCost.Size = new System.Drawing.Size(105, 35);
            this.tbMaintenanceCost.TabIndex = 6;
            // 
            // tbFutureReplacementCost
            // 
            this.tbFutureReplacementCost.Location = new System.Drawing.Point(383, 266);
            this.tbFutureReplacementCost.Name = "tbFutureReplacementCost";
            this.tbFutureReplacementCost.Size = new System.Drawing.Size(105, 35);
            this.tbFutureReplacementCost.TabIndex = 7;
            // 
            // tbInterestRate
            // 
            this.tbInterestRate.Location = new System.Drawing.Point(751, 63);
            this.tbInterestRate.Name = "tbInterestRate";
            this.tbInterestRate.Size = new System.Drawing.Size(105, 35);
            this.tbInterestRate.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(507, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(238, 30);
            this.label8.TabIndex = 33;
            this.label8.Text = "Interest Rate (Annual %)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbProjectDuration
            // 
            this.tbProjectDuration.Location = new System.Drawing.Point(751, 104);
            this.tbProjectDuration.Name = "tbProjectDuration";
            this.tbProjectDuration.Size = new System.Drawing.Size(105, 35);
            this.tbProjectDuration.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(537, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(208, 30);
            this.label9.TabIndex = 35;
            this.label9.Text = "Project Duration (yrs)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbCostOfWater
            // 
            this.tbCostOfWater.Location = new System.Drawing.Point(751, 145);
            this.tbCostOfWater.Name = "tbCostOfWater";
            this.tbCostOfWater.Size = new System.Drawing.Size(105, 35);
            this.tbCostOfWater.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(494, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(255, 30);
            this.label10.TabIndex = 37;
            this.label10.Text = "Cost of Water ($/1000 gal)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(554, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(278, 30);
            this.label11.TabIndex = 38;
            this.label11.Text = "Global Values for Calculation";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Exit the Current Worksheet";
            // 
            // btnScenario
            // 
            this.btnScenario.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScenario.Location = new System.Drawing.Point(515, 257);
            this.btnScenario.Name = "btnScenario";
            this.btnScenario.Size = new System.Drawing.Size(112, 39);
            this.btnScenario.TabIndex = 40;
            this.btnScenario.Text = "Scenario";
            this.toolTip1.SetToolTip(this.btnScenario, "Saves the Current Cost Analysis as a Scenario");
            this.btnScenario.UseVisualStyleBackColor = true;
            this.btnScenario.Click += new System.EventHandler(this.btnScenario_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(515, 212);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(112, 39);
            this.btnCalculate.TabIndex = 39;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // tbScenarioName
            // 
            this.tbScenarioName.Location = new System.Drawing.Point(177, 310);
            this.tbScenarioName.Name = "tbScenarioName";
            this.tbScenarioName.Size = new System.Drawing.Size(105, 35);
            this.tbScenarioName.TabIndex = 41;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 315);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 30);
            this.label12.TabIndex = 42;
            this.label12.Text = "Scenario Name:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbScenarioDescription
            // 
            this.tbScenarioDescription.Location = new System.Drawing.Point(511, 310);
            this.tbScenarioDescription.Name = "tbScenarioDescription";
            this.tbScenarioDescription.Size = new System.Drawing.Size(352, 35);
            this.tbScenarioDescription.TabIndex = 43;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(297, 313);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(208, 30);
            this.label13.TabIndex = 44;
            this.label13.Text = "Scenario Description:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmCostAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(885, 608);
            this.ControlBox = false;
            this.Controls.Add(this.tbScenarioDescription);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbScenarioName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnScenario);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbCostOfWater);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbProjectDuration);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbInterestRate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbFutureReplacementCost);
            this.Controls.Add(this.tbMaintenanceCost);
            this.Controls.Add(this.tbHarvestedWater);
            this.Controls.Add(this.tbCostPerAcreFoot);
            this.Controls.Add(this.tbExpectedLife);
            this.Controls.Add(this.tbFixedCost);
            this.Controls.Add(this.tbLandCost);
            this.Controls.Add(this.wbOutput);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmCostAnalysis";
            this.Text = "Cost Analysis Entry";
            this.Load += new System.EventHandler(this.frmCostAnalysis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.WebBrowser wbOutput;
        private System.Windows.Forms.TextBox tbLandCost;
        private System.Windows.Forms.TextBox tbFixedCost;
        private System.Windows.Forms.TextBox tbExpectedLife;
        private System.Windows.Forms.TextBox tbCostPerAcreFoot;
        private System.Windows.Forms.TextBox tbHarvestedWater;
        private System.Windows.Forms.TextBox tbMaintenanceCost;
        private System.Windows.Forms.TextBox tbFutureReplacementCost;
        private System.Windows.Forms.TextBox tbInterestRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbProjectDuration;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbCostOfWater;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnScenario;
        private System.Windows.Forms.TextBox tbScenarioName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbScenarioDescription;
        private System.Windows.Forms.Label label13;
    }
}