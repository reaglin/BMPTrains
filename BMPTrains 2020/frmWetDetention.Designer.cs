namespace BMPTrains_2020
{
    partial class frmWetDetention
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWetDetention));
            this.tbPPVolume = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.wbOutput = new System.Windows.Forms.WebBrowser();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLittoralCredit = new System.Windows.Forms.TextBox();
            this.tbWetlandCredit = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPlot = new System.Windows.Forms.Button();
            this.btnCost = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnHelp2 = new System.Windows.Forms.Button();
            this.btnAnoxicDepth = new System.Windows.Forms.Button();
            this.tbUserTP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkLittoralZone = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbPPVolume
            // 
            this.tbPPVolume.Location = new System.Drawing.Point(514, 86);
            this.tbPPVolume.Name = "tbPPVolume";
            this.tbPPVolume.Size = new System.Drawing.Size(115, 35);
            this.tbPPVolume.TabIndex = 1;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(644, 86);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(112, 39);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Visible = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(644, 132);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(112, 39);
            this.btnCalculate.TabIndex = 5;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(644, 274);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 39);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(644, 364);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(112, 39);
            this.btnReport.TabIndex = 7;
            this.btnReport.Text = "Copy";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(644, 409);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 39);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Back";
            this.toolTip1.SetToolTip(this.btnClose, "Exit the Current Worksheet");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // wbOutput
            // 
            this.wbOutput.Location = new System.Drawing.Point(12, 237);
            this.wbOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOutput.Name = "wbOutput";
            this.wbOutput.Size = new System.Drawing.Size(614, 264);
            this.wbOutput.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(478, 30);
            this.label2.TabIndex = 27;
            this.label2.Text = "Floating Wetland or Mats Improvement Credit (%):";
            // 
            // tbLittoralCredit
            // 
            this.tbLittoralCredit.Location = new System.Drawing.Point(644, 454);
            this.tbLittoralCredit.Name = "tbLittoralCredit";
            this.tbLittoralCredit.Size = new System.Drawing.Size(115, 35);
            this.tbLittoralCredit.TabIndex = 2;
            this.tbLittoralCredit.Visible = false;
            // 
            // tbWetlandCredit
            // 
            this.tbWetlandCredit.Location = new System.Drawing.Point(514, 131);
            this.tbWetlandCredit.Name = "tbWetlandCredit";
            this.tbWetlandCredit.Size = new System.Drawing.Size(115, 35);
            this.tbWetlandCredit.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(780, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(341, 30);
            this.label3.TabIndex = 31;
            this.label3.Text = "Permanent Pool Volume (acre-feet):";
            // 
            // btnPlot
            // 
            this.btnPlot.Location = new System.Drawing.Point(644, 319);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(112, 39);
            this.btnPlot.TabIndex = 32;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // btnCost
            // 
            this.btnCost.Location = new System.Drawing.Point(644, 226);
            this.btnCost.Name = "btnCost";
            this.btnCost.Size = new System.Drawing.Size(112, 39);
            this.btnCost.TabIndex = 33;
            this.btnCost.Text = "Cost";
            this.btnCost.UseVisualStyleBackColor = true;
            this.btnCost.Click += new System.EventHandler(this.btnCost_Click);
            // 
            // btnHelp2
            // 
            this.btnHelp2.BackColor = System.Drawing.Color.Yellow;
            this.btnHelp2.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp2.Image")));
            this.btnHelp2.Location = new System.Drawing.Point(710, 42);
            this.btnHelp2.Name = "btnHelp2";
            this.btnHelp2.Size = new System.Drawing.Size(46, 40);
            this.btnHelp2.TabIndex = 60;
            this.toolTip1.SetToolTip(this.btnHelp2, "Wet Detention Methodology");
            this.btnHelp2.UseVisualStyleBackColor = false;
            this.btnHelp2.Click += new System.EventHandler(this.btnHelp2_Click);
            // 
            // btnAnoxicDepth
            // 
            this.btnAnoxicDepth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnoxicDepth.Location = new System.Drawing.Point(644, 181);
            this.btnAnoxicDepth.Name = "btnAnoxicDepth";
            this.btnAnoxicDepth.Size = new System.Drawing.Size(112, 39);
            this.btnAnoxicDepth.TabIndex = 61;
            this.btnAnoxicDepth.Text = "Anoxic Depth";
            this.btnAnoxicDepth.UseVisualStyleBackColor = true;
            this.btnAnoxicDepth.Click += new System.EventHandler(this.btnAnoxicDepth_Click);
            // 
            // tbUserTP
            // 
            this.tbUserTP.Location = new System.Drawing.Point(514, 176);
            this.tbUserTP.Name = "tbUserTP";
            this.tbUserTP.Size = new System.Drawing.Size(115, 35);
            this.tbUserTP.TabIndex = 62;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(351, 30);
            this.label4.TabIndex = 63;
            this.label4.Text = "Input Pond TP (ug/l) if data available";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, -2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(744, 19);
            this.label5.TabIndex = 64;
            this.label5.Text = "Note: For credit, in some applications, annual residence times cannot exceed an u" +
    "pper limit.";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(744, 19);
            this.label6.TabIndex = 65;
            this.label6.Text = "Pond must include a littoral zone. If no littoral zone, the credit is reduced by " +
    "10%.";
            // 
            // chkLittoralZone
            // 
            this.chkLittoralZone.AutoSize = true;
            this.chkLittoralZone.Location = new System.Drawing.Point(313, 52);
            this.chkLittoralZone.Name = "chkLittoralZone";
            this.chkLittoralZone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkLittoralZone.Size = new System.Drawing.Size(313, 34);
            this.chkLittoralZone.TabIndex = 66;
            this.chkLittoralZone.Text = "Check if there is a littoral zone";
            this.chkLittoralZone.UseVisualStyleBackColor = true;
            this.chkLittoralZone.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmWetDetention
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 513);
            this.ControlBox = false;
            this.Controls.Add(this.chkLittoralZone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbUserTP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAnoxicDepth);
            this.Controls.Add(this.btnHelp2);
            this.Controls.Add(this.btnCost);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPPVolume);
            this.Controls.Add(this.tbWetlandCredit);
            this.Controls.Add(this.tbLittoralCredit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.wbOutput);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmWetDetention";
            this.Text = "Wet Detention";
            this.Load += new System.EventHandler(this.frmWetDetention_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbPPVolume;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.WebBrowser wbOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLittoralCredit;
        private System.Windows.Forms.TextBox tbWetlandCredit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Button btnCost;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnHelp2;
        private System.Windows.Forms.Button btnAnoxicDepth;
        private System.Windows.Forms.TextBox tbUserTP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkLittoralZone;
    }
}