namespace BMPTrains_2020
{
    partial class frmGreenroof
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
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.wbOutput = new System.Windows.Forms.WebBrowser();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDepth = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRainfallStation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbGreenroofArea = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbIrrigationDemand = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRainfallExcess = new System.Windows.Forms.TextBox();
            this.btnPlot = new System.Windows.Forms.Button();
            this.btnCost = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkCistern = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(28, 196);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(112, 39);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Visible = false;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(570, 262);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(112, 39);
            this.btnCalculate.TabIndex = 7;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(570, 352);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 39);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(570, 397);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(112, 39);
            this.btnReport.TabIndex = 9;
            this.btnReport.Text = "Copy";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(570, 442);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 39);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Back";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // wbOutput
            // 
            this.wbOutput.Location = new System.Drawing.Point(28, 262);
            this.wbOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOutput.Name = "wbOutput";
            this.wbOutput.Size = new System.Drawing.Size(523, 294);
            this.wbOutput.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(579, 25);
            this.label2.TabIndex = 36;
            this.label2.Text = "Cistern Storage provided over Greenroof Area (0.00-5.0 in):";
            // 
            // tbDepth
            // 
            this.tbDepth.Location = new System.Drawing.Point(593, 115);
            this.tbDepth.Name = "tbDepth";
            this.tbDepth.Size = new System.Drawing.Size(89, 31);
            this.tbDepth.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(692, 24);
            this.menuStrip1.TabIndex = 42;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 25);
            this.label1.TabIndex = 44;
            this.label1.Text = "Select Rainfall Station";
            // 
            // cbRainfallStation
            // 
            this.cbRainfallStation.FormattingEnabled = true;
            this.cbRainfallStation.Location = new System.Drawing.Point(312, 39);
            this.cbRainfallStation.Name = "cbRainfallStation";
            this.cbRainfallStation.Size = new System.Drawing.Size(370, 33);
            this.cbRainfallStation.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(303, 25);
            this.label3.TabIndex = 47;
            this.label3.Text = "Greenroof Area (Square Feet):";
            // 
            // tbGreenroofArea
            // 
            this.tbGreenroofArea.Enabled = false;
            this.tbGreenroofArea.Location = new System.Drawing.Point(593, 78);
            this.tbGreenroofArea.Name = "tbGreenroofArea";
            this.tbGreenroofArea.Size = new System.Drawing.Size(89, 31);
            this.tbGreenroofArea.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(318, 25);
            this.label4.TabIndex = 49;
            this.label4.Text = "Irrigation Demand (inches/year):";
            this.label4.Visible = false;
            // 
            // tbIrrigationDemand
            // 
            this.tbIrrigationDemand.Location = new System.Drawing.Point(593, 152);
            this.tbIrrigationDemand.Name = "tbIrrigationDemand";
            this.tbIrrigationDemand.Size = new System.Drawing.Size(89, 31);
            this.tbIrrigationDemand.TabIndex = 4;
            this.tbIrrigationDemand.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(427, 25);
            this.label5.TabIndex = 51;
            this.label5.Text = "Rainfall Excess (filtrate underdrain flow, in):";
            this.label5.Visible = false;
            // 
            // tbRainfallExcess
            // 
            this.tbRainfallExcess.Location = new System.Drawing.Point(593, 190);
            this.tbRainfallExcess.Name = "tbRainfallExcess";
            this.tbRainfallExcess.Size = new System.Drawing.Size(89, 31);
            this.tbRainfallExcess.TabIndex = 5;
            this.tbRainfallExcess.Visible = false;
            // 
            // btnPlot
            // 
            this.btnPlot.Location = new System.Drawing.Point(570, 517);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(112, 39);
            this.btnPlot.TabIndex = 52;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Visible = false;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // btnCost
            // 
            this.btnCost.Location = new System.Drawing.Point(570, 307);
            this.btnCost.Name = "btnCost";
            this.btnCost.Size = new System.Drawing.Size(112, 39);
            this.btnCost.TabIndex = 53;
            this.btnCost.Text = "Cost";
            this.btnCost.UseVisualStyleBackColor = true;
            this.btnCost.Click += new System.EventHandler(this.btnCost_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Exit the Current Worksheet";
            // 
            // chkCistern
            // 
            this.chkCistern.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCistern.Location = new System.Drawing.Point(340, 227);
            this.chkCistern.Name = "chkCistern";
            this.chkCistern.Size = new System.Drawing.Size(300, 29);
            this.chkCistern.TabIndex = 55;
            this.chkCistern.Text = "Check if Cistern is used:";
            this.chkCistern.UseVisualStyleBackColor = true;
            this.chkCistern.Visible = false;
            this.chkCistern.CheckedChanged += new System.EventHandler(this.chkCistern_CheckedChanged);
            // 
            // frmGreenroof
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(710, 571);
            this.ControlBox = false;
            this.Controls.Add(this.chkCistern);
            this.Controls.Add(this.btnCost);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbRainfallExcess);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbIrrigationDemand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbGreenroofArea);
            this.Controls.Add(this.cbRainfallStation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.wbOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDepth);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGreenroof";
            this.Text = "Greenroof";
            this.Load += new System.EventHandler(this.frmGreenroof_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.WebBrowser wbOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDepth;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRainfallStation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbGreenroofArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbIrrigationDemand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRainfallExcess;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Button btnCost;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkCistern;
    }
}