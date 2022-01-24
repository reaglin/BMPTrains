namespace BMPTrains_2020
{
    partial class frmSwale
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
            this.tbW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.wbOutput = new System.Windows.Forms.WebBrowser();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbB = new System.Windows.Forms.TextBox();
            this.tbL = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.tbImpW = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbImpL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPervW = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbInfRate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbZ = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbH = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbLb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbNb = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pbSwale = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbCReduction = new System.Windows.Forms.ComboBox();
            this.btnPlot = new System.Windows.Forms.Button();
            this.btnCost = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnMedia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbSwale)).BeginInit();
            this.SuspendLayout();
            // 
            // tbW
            // 
            this.tbW.Location = new System.Drawing.Point(423, 27);
            this.tbW.Name = "tbW";
            this.tbW.Size = new System.Drawing.Size(54, 29);
            this.tbW.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(390, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Swale top width calculated for flood conditions (ft) [W]:";
            // 
            // wbOutput
            // 
            this.wbOutput.Location = new System.Drawing.Point(12, 280);
            this.wbOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOutput.Name = "wbOutput";
            this.wbOutput.Size = new System.Drawing.Size(465, 260);
            this.wbOutput.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(496, 512);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 28);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Back";
            this.toolTip1.SetToolTip(this.btnClose, "Exit the Current Worksheet");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(496, 478);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(112, 28);
            this.btnReport.TabIndex = 19;
            this.btnReport.Text = "Copy";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(496, 411);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 28);
            this.btnPrint.TabIndex = 18;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(925, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(371, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Swale bottom width (0 for triangular section) (ft) [B]:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "Swale length (ft) [L]:";
            // 
            // tbB
            // 
            this.tbB.Location = new System.Drawing.Point(423, 62);
            this.tbB.Name = "tbB";
            this.tbB.Size = new System.Drawing.Size(54, 29);
            this.tbB.TabIndex = 2;
            // 
            // tbL
            // 
            this.tbL.Location = new System.Drawing.Point(423, 97);
            this.tbL.Name = "tbL";
            this.tbL.Size = new System.Drawing.Size(54, 29);
            this.tbL.TabIndex = 3;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(496, 342);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(112, 28);
            this.btnCalculate.TabIndex = 17;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(496, 307);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(112, 29);
            this.btnHelp.TabIndex = 16;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Visible = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // tbImpW
            // 
            this.tbImpW.Location = new System.Drawing.Point(423, 167);
            this.tbImpW.Name = "tbImpW";
            this.tbImpW.Size = new System.Drawing.Size(54, 29);
            this.tbImpW.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Average impervious width (including shoulder) (ft):";
            // 
            // tbImpL
            // 
            this.tbImpL.Location = new System.Drawing.Point(423, 132);
            this.tbImpL.Name = "tbImpL";
            this.tbImpL.Size = new System.Drawing.Size(54, 29);
            this.tbImpL.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 21);
            this.label5.TabIndex = 22;
            this.label5.Text = "Average impervious length (ft):";
            // 
            // tbPervW
            // 
            this.tbPervW.Location = new System.Drawing.Point(423, 202);
            this.tbPervW.Name = "tbPervW";
            this.tbPervW.Size = new System.Drawing.Size(54, 29);
            this.tbPervW.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(407, 21);
            this.label6.TabIndex = 24;
            this.label6.Text = "Average width of pervious area including swale width (ft):";
            // 
            // tbS
            // 
            this.tbS.Location = new System.Drawing.Point(423, 237);
            this.tbS.Name = "tbS";
            this.tbS.Size = new System.Drawing.Size(54, 29);
            this.tbS.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(174, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(243, 21);
            this.label7.TabIndex = 26;
            this.label7.Text = "Swale slope (ft drop/ft length) [S]:";
            // 
            // tbN
            // 
            this.tbN.Location = new System.Drawing.Point(843, 29);
            this.tbN.Name = "tbN";
            this.tbN.Size = new System.Drawing.Size(54, 29);
            this.tbN.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(735, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 21);
            this.label8.TabIndex = 28;
            this.label8.Text = "Manning\'s N:";
            // 
            // tbInfRate
            // 
            this.tbInfRate.Location = new System.Drawing.Point(843, 64);
            this.tbInfRate.Name = "tbInfRate";
            this.tbInfRate.Size = new System.Drawing.Size(54, 29);
            this.tbInfRate.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(643, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(194, 21);
            this.label9.TabIndex = 30;
            this.label9.Text = "Soil infiltration rate (in/hr):";
            // 
            // tbZ
            // 
            this.tbZ.Location = new System.Drawing.Point(843, 97);
            this.tbZ.Name = "tbZ";
            this.tbZ.Size = new System.Drawing.Size(54, 29);
            this.tbZ.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(501, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(336, 21);
            this.label10.TabIndex = 32;
            this.label10.Text = "Side slope of swale (horizontal ft/vertical ft) [Z]:";
            // 
            // tbH
            // 
            this.tbH.Location = new System.Drawing.Point(843, 132);
            this.tbH.Name = "tbH";
            this.tbH.Size = new System.Drawing.Size(54, 29);
            this.tbH.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(535, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(302, 21);
            this.label11.TabIndex = 34;
            this.label11.Text = "Average height of the swale blocks (ft) [H]:";
            // 
            // tbLb
            // 
            this.tbLb.Location = new System.Drawing.Point(843, 167);
            this.tbLb.Name = "tbLb";
            this.tbLb.Size = new System.Drawing.Size(54, 29);
            this.tbLb.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(516, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(321, 21);
            this.label12.TabIndex = 36;
            this.label12.Text = "Length of the berm upstream of the crest (ft):";
            // 
            // tbNb
            // 
            this.tbNb.Location = new System.Drawing.Point(843, 202);
            this.tbNb.Name = "tbNb";
            this.tbNb.Size = new System.Drawing.Size(54, 29);
            this.tbNb.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(655, 210);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(182, 21);
            this.label13.TabIndex = 38;
            this.label13.Text = "Number of Swale blocks:";
            // 
            // pbSwale
            // 
            this.pbSwale.BackgroundImage = global::BMPTrains_2020.Properties.Resources.Swale;
            this.pbSwale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSwale.Location = new System.Drawing.Point(631, 280);
            this.pbSwale.Name = "pbSwale";
            this.pbSwale.Size = new System.Drawing.Size(282, 260);
            this.pbSwale.TabIndex = 40;
            this.pbSwale.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(482, 240);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(355, 21);
            this.label14.TabIndex = 42;
            this.label14.Text = "Concentration reduction? (If S<= 1% or H>= 6 in)";
            this.label14.Visible = false;
            // 
            // cbCReduction
            // 
            this.cbCReduction.FormattingEnabled = true;
            this.cbCReduction.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cbCReduction.Location = new System.Drawing.Point(845, 237);
            this.cbCReduction.Name = "cbCReduction";
            this.cbCReduction.Size = new System.Drawing.Size(52, 29);
            this.cbCReduction.TabIndex = 45;
            this.cbCReduction.Visible = false;
            this.cbCReduction.SelectedIndexChanged += new System.EventHandler(this.cbCReduction_SelectedIndexChanged);
            // 
            // btnPlot
            // 
            this.btnPlot.Location = new System.Drawing.Point(496, 444);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(112, 28);
            this.btnPlot.TabIndex = 46;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // btnCost
            // 
            this.btnCost.Location = new System.Drawing.Point(496, 376);
            this.btnCost.Name = "btnCost";
            this.btnCost.Size = new System.Drawing.Size(112, 28);
            this.btnCost.TabIndex = 47;
            this.btnCost.Text = "Cost";
            this.btnCost.UseVisualStyleBackColor = true;
            this.btnCost.Click += new System.EventHandler(this.btnCost_Click);
            // 
            // btnMedia
            // 
            this.btnMedia.Location = new System.Drawing.Point(496, 272);
            this.btnMedia.Name = "btnMedia";
            this.btnMedia.Size = new System.Drawing.Size(112, 29);
            this.btnMedia.TabIndex = 48;
            this.btnMedia.Text = "Media";
            this.toolTip1.SetToolTip(this.btnMedia, "Select Media Mix for Groundwater Discharge");
            this.btnMedia.UseVisualStyleBackColor = true;
            this.btnMedia.Click += new System.EventHandler(this.btnMedia_Click);
            // 
            // frmSwale
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(925, 552);
            this.ControlBox = false;
            this.Controls.Add(this.btnMedia);
            this.Controls.Add(this.btnCost);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.cbCReduction);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pbSwale);
            this.Controls.Add(this.tbNb);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbLb);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbH);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbZ);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbInfRate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbN);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbS);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPervW);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbImpL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbImpW);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.tbL);
            this.Controls.Add(this.tbB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.wbOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbW);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSwale";
            this.Text = "Swale Worksheet";
            this.Load += new System.EventHandler(this.frmRetention_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSwale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser wbOutput;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbB;
        private System.Windows.Forms.TextBox tbL;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TextBox tbImpW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbImpL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPervW;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbInfRate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbZ;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbH;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbLb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbNb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pbSwale;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbCReduction;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Button btnCost;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnMedia;
    }
}