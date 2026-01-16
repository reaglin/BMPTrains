namespace BMPTrains_2020
{
    partial class frmExfiltration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExfiltration));
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.wbOutput = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnExfiltrationCalculator = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMediaMix = new System.Windows.Forms.Button();
            this.btnPlot = new System.Windows.Forms.Button();
            this.bnCost = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbVoidRatio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTrenchLength = new System.Windows.Forms.TextBox();
            this.tbTrenchDepth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTrenchWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPipeLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPipeRise = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPipeSpan = new System.Windows.Forms.TextBox();
            this.chkThreeHours = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(698, 333);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(112, 39);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(698, 424);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 39);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(698, 559);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 39);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Back";
            this.toolTip1.SetToolTip(this.btnClose, "Exit the Current Worksheet");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // wbOutput
            // 
            this.wbOutput.Location = new System.Drawing.Point(23, 246);
            this.wbOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOutput.Name = "wbOutput";
            this.wbOutput.Size = new System.Drawing.Size(650, 352);
            this.wbOutput.TabIndex = 21;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(830, 24);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(69, 147);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(112, 39);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Visible = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnExfiltrationCalculator
            // 
            this.btnExfiltrationCalculator.Image = ((System.Drawing.Image)(resources.GetObject("btnExfiltrationCalculator.Image")));
            this.btnExfiltrationCalculator.Location = new System.Drawing.Point(758, 163);
            this.btnExfiltrationCalculator.Name = "btnExfiltrationCalculator";
            this.btnExfiltrationCalculator.Size = new System.Drawing.Size(46, 40);
            this.btnExfiltrationCalculator.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnExfiltrationCalculator, "Exfiltration Calculator");
            this.btnExfiltrationCalculator.UseVisualStyleBackColor = true;
            this.btnExfiltrationCalculator.Visible = false;
            this.btnExfiltrationCalculator.Click += new System.EventHandler(this.btnExfiltrationCalculator_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.CausesValidation = false;
            this.label5.Location = new System.Drawing.Point(410, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(246, 30);
            this.label5.TabIndex = 46;
            this.label5.Text = "Trench/Vault Depth (ft):";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.label5, "To water table or the bottom of the pipe, whichever is less");
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.CausesValidation = false;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(354, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(475, 33);
            this.label2.TabIndex = 51;
            this.label2.Text = "To water table or the bottom of the trench/vault, whichever is less";
            this.toolTip1.SetToolTip(this.label2, "o water table or the bottom of the pipe, whichever is less");
            // 
            // btnMediaMix
            // 
            this.btnMediaMix.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMediaMix.Location = new System.Drawing.Point(698, 288);
            this.btnMediaMix.Name = "btnMediaMix";
            this.btnMediaMix.Size = new System.Drawing.Size(112, 39);
            this.btnMediaMix.TabIndex = 34;
            this.btnMediaMix.Text = "Media";
            this.btnMediaMix.UseVisualStyleBackColor = true;
            this.btnMediaMix.Click += new System.EventHandler(this.btnMediaMix_Click);
            // 
            // btnPlot
            // 
            this.btnPlot.Location = new System.Drawing.Point(698, 469);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(112, 39);
            this.btnPlot.TabIndex = 35;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // bnCost
            // 
            this.bnCost.Location = new System.Drawing.Point(698, 378);
            this.bnCost.Name = "bnCost";
            this.bnCost.Size = new System.Drawing.Size(112, 39);
            this.bnCost.TabIndex = 36;
            this.bnCost.Text = "Cost";
            this.bnCost.UseVisualStyleBackColor = true;
            this.bnCost.Click += new System.EventHandler(this.bnCost_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.CausesValidation = false;
            this.label7.Location = new System.Drawing.Point(254, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(402, 30);
            this.label7.TabIndex = 50;
            this.label7.Text = "Void space fraction not in pipe (0-1.0) :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbVoidRatio
            // 
            this.tbVoidRatio.Location = new System.Drawing.Point(663, 165);
            this.tbVoidRatio.Name = "tbVoidRatio";
            this.tbVoidRatio.Size = new System.Drawing.Size(89, 35);
            this.tbVoidRatio.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.CausesValidation = false;
            this.label4.Location = new System.Drawing.Point(415, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 30);
            this.label4.TabIndex = 48;
            this.label4.Text = "Trench/Vault Length (ft):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbTrenchLength
            // 
            this.tbTrenchLength.Location = new System.Drawing.Point(663, 124);
            this.tbTrenchLength.Name = "tbTrenchLength";
            this.tbTrenchLength.Size = new System.Drawing.Size(89, 35);
            this.tbTrenchLength.TabIndex = 47;
            // 
            // tbTrenchDepth
            // 
            this.tbTrenchDepth.Location = new System.Drawing.Point(663, 53);
            this.tbTrenchDepth.Name = "tbTrenchDepth";
            this.tbTrenchDepth.Size = new System.Drawing.Size(89, 35);
            this.tbTrenchDepth.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.CausesValidation = false;
            this.label6.Location = new System.Drawing.Point(415, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(241, 30);
            this.label6.TabIndex = 44;
            this.label6.Text = "Trench/Vault Width (ft):";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbTrenchWidth
            // 
            this.tbTrenchWidth.Location = new System.Drawing.Point(663, 12);
            this.tbTrenchWidth.Name = "tbTrenchWidth";
            this.tbTrenchWidth.Size = new System.Drawing.Size(89, 35);
            this.tbTrenchWidth.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.CausesValidation = false;
            this.label3.Location = new System.Drawing.Point(64, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 30);
            this.label3.TabIndex = 42;
            this.label3.Text = "Pipe Length (ft):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbPipeLength
            // 
            this.tbPipeLength.Location = new System.Drawing.Point(259, 94);
            this.tbPipeLength.Name = "tbPipeLength";
            this.tbPipeLength.Size = new System.Drawing.Size(89, 35);
            this.tbPipeLength.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.CausesValidation = false;
            this.label1.Location = new System.Drawing.Point(64, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 30);
            this.label1.TabIndex = 40;
            this.label1.Text = "Pipe Rise (in):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbPipeRise
            // 
            this.tbPipeRise.Location = new System.Drawing.Point(259, 53);
            this.tbPipeRise.Name = "tbPipeRise";
            this.tbPipeRise.Size = new System.Drawing.Size(89, 35);
            this.tbPipeRise.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.CausesValidation = false;
            this.label8.Location = new System.Drawing.Point(64, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 30);
            this.label8.TabIndex = 38;
            this.label8.Text = "Pipe Span (in):";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbPipeSpan
            // 
            this.tbPipeSpan.Location = new System.Drawing.Point(259, 12);
            this.tbPipeSpan.Name = "tbPipeSpan";
            this.tbPipeSpan.Size = new System.Drawing.Size(89, 35);
            this.tbPipeSpan.TabIndex = 37;
            // 
            // chkThreeHours
            // 
            this.chkThreeHours.AutoSize = true;
            this.chkThreeHours.Location = new System.Drawing.Point(112, 201);
            this.chkThreeHours.Name = "chkThreeHours";
            this.chkThreeHours.Size = new System.Drawing.Size(558, 34);
            this.chkThreeHours.TabIndex = 52;
            this.chkThreeHours.Text = "Check if design volume removal takes more than 3 hours";
            this.chkThreeHours.UseVisualStyleBackColor = true;
            this.chkThreeHours.CheckedChanged += new System.EventHandler(this.chkThreeHours_CheckedChanged);
            // 
            // frmExfiltration
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(830, 610);
            this.ControlBox = false;
            this.Controls.Add(this.chkThreeHours);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbVoidRatio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTrenchLength);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbTrenchDepth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbTrenchWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPipeLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPipeRise);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbPipeSpan);
            this.Controls.Add(this.bnCost);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.btnMediaMix);
            this.Controls.Add(this.btnExfiltrationCalculator);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.wbOutput);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExfiltration";
            this.Text = "Exfiltration Systems Worksheet";
            this.Load += new System.EventHandler(this.frmExfiltration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.WebBrowser wbOutput;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnExfiltrationCalculator;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnMediaMix;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Button bnCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbVoidRatio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTrenchLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTrenchDepth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTrenchWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPipeLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPipeRise;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbPipeSpan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkThreeHours;
    }
}