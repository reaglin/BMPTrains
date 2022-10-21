namespace BMPTrains_2020
{
    partial class frmRainGarden
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbMixes = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.wbOutput = new System.Windows.Forms.WebBrowser();
            this.label2 = new System.Windows.Forms.Label();
            this.tbVoidFraction = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cbSystemType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMediaVolume = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbWaterAboveMedia = new System.Windows.Forms.TextBox();
            this.btnPlot = new System.Windows.Forms.Button();
            this.btnCost = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnMedia = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTN = new System.Windows.Forms.TextBox();
            this.tbTP = new System.Windows.Forms.TextBox();
            this.tbMediaMix = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbMediaArea = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(572, 78);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(112, 39);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Visible = false;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(572, 123);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(112, 39);
            this.btnCalculate.TabIndex = 9;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 29;
            this.label1.Text = "Media Mix:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbMixes
            // 
            this.cbMixes.Enabled = false;
            this.cbMixes.FormattingEnabled = true;
            this.cbMixes.Location = new System.Drawing.Point(12, 72);
            this.cbMixes.Name = "cbMixes";
            this.cbMixes.Size = new System.Drawing.Size(171, 33);
            this.cbMixes.TabIndex = 2;
            this.cbMixes.Visible = false;
            this.cbMixes.SelectedIndexChanged += new System.EventHandler(this.cbMixes_SelectedIndexChanged);
            this.cbMixes.SelectedValueChanged += new System.EventHandler(this.cbMixes_SelectedValueChanged);
            this.cbMixes.TextChanged += new System.EventHandler(this.cbMixes_TextChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(707, 34);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 39);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(707, 123);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(112, 39);
            this.btnReport.TabIndex = 13;
            this.btnReport.Text = "Copy";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(707, 168);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 39);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Back";
            this.toolTip1.SetToolTip(this.btnClose, "Exit the Current Worksheet");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // wbOutput
            // 
            this.wbOutput.Location = new System.Drawing.Point(0, 266);
            this.wbOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOutput.Name = "wbOutput";
            this.wbOutput.Size = new System.Drawing.Size(802, 272);
            this.wbOutput.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Selection Retention or Detention:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbVoidFraction
            // 
            this.tbVoidFraction.Location = new System.Drawing.Point(452, 111);
            this.tbVoidFraction.Name = "tbVoidFraction";
            this.tbVoidFraction.Size = new System.Drawing.Size(89, 31);
            this.tbVoidFraction.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cbSystemType
            // 
            this.cbSystemType.FormattingEnabled = true;
            this.cbSystemType.Location = new System.Drawing.Point(370, 33);
            this.cbSystemType.Name = "cbSystemType";
            this.cbSystemType.Size = new System.Drawing.Size(171, 33);
            this.cbSystemType.TabIndex = 1;
            this.cbSystemType.SelectedIndexChanged += new System.EventHandler(this.cbSystemType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 25);
            this.label3.TabIndex = 38;
            this.label3.Text = "Sustainable Void Fraction:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(268, 25);
            this.label4.TabIndex = 40;
            this.label4.Text = "Media Volume (cubic feet):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbMediaVolume
            // 
            this.tbMediaVolume.Location = new System.Drawing.Point(452, 149);
            this.tbMediaVolume.Name = "tbMediaVolume";
            this.tbMediaVolume.Size = new System.Drawing.Size(89, 31);
            this.tbMediaVolume.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(399, 25);
            this.label5.TabIndex = 42;
            this.label5.Text = "Water Storage above Media (cubic feet):";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbWaterAboveMedia
            // 
            this.tbWaterAboveMedia.Location = new System.Drawing.Point(452, 187);
            this.tbWaterAboveMedia.Name = "tbWaterAboveMedia";
            this.tbWaterAboveMedia.Size = new System.Drawing.Size(89, 31);
            this.tbWaterAboveMedia.TabIndex = 5;
            // 
            // btnPlot
            // 
            this.btnPlot.Location = new System.Drawing.Point(707, 79);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(112, 39);
            this.btnPlot.TabIndex = 12;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // btnCost
            // 
            this.btnCost.Location = new System.Drawing.Point(572, 168);
            this.btnCost.Name = "btnCost";
            this.btnCost.Size = new System.Drawing.Size(112, 39);
            this.btnCost.TabIndex = 10;
            this.btnCost.Text = "Cost";
            this.btnCost.UseVisualStyleBackColor = true;
            this.btnCost.Click += new System.EventHandler(this.btnCost_Click);
            // 
            // btnMedia
            // 
            this.btnMedia.Location = new System.Drawing.Point(572, 34);
            this.btnMedia.Name = "btnMedia";
            this.btnMedia.Size = new System.Drawing.Size(112, 39);
            this.btnMedia.TabIndex = 45;
            this.btnMedia.Text = "Media";
            this.toolTip1.SetToolTip(this.btnMedia, "Select Media Mix for Groundwater Discharge");
            this.btnMedia.UseVisualStyleBackColor = true;
            this.btnMedia.Click += new System.EventHandler(this.btnMedia_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(578, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 25);
            this.label6.TabIndex = 43;
            this.label6.Text = "TN";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(694, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 25);
            this.label7.TabIndex = 44;
            this.label7.Text = "TP";
            // 
            // tbTN
            // 
            this.tbTN.Location = new System.Drawing.Point(624, 213);
            this.tbTN.Name = "tbTN";
            this.tbTN.Size = new System.Drawing.Size(52, 31);
            this.tbTN.TabIndex = 6;
            // 
            // tbTP
            // 
            this.tbTP.Location = new System.Drawing.Point(739, 213);
            this.tbTP.Name = "tbTP";
            this.tbTP.Size = new System.Drawing.Size(52, 31);
            this.tbTP.TabIndex = 7;
            // 
            // tbMediaMix
            // 
            this.tbMediaMix.Enabled = false;
            this.tbMediaMix.Location = new System.Drawing.Point(370, 72);
            this.tbMediaMix.Name = "tbMediaMix";
            this.tbMediaMix.Size = new System.Drawing.Size(171, 31);
            this.tbMediaMix.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(186, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(260, 25);
            this.label8.TabIndex = 48;
            this.label8.Text = "Credit for Cover Crop (%):";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbMediaArea
            // 
            this.tbMediaArea.Location = new System.Drawing.Point(452, 226);
            this.tbMediaArea.Name = "tbMediaArea";
            this.tbMediaArea.Size = new System.Drawing.Size(89, 31);
            this.tbMediaArea.TabIndex = 47;
            // 
            // frmRainGarden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(831, 550);
            this.ControlBox = false;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbMediaArea);
            this.Controls.Add(this.tbMediaMix);
            this.Controls.Add(this.btnMedia);
            this.Controls.Add(this.tbTP);
            this.Controls.Add(this.tbTN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCost);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbWaterAboveMedia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMediaVolume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSystemType);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMixes);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.wbOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbVoidFraction);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmRainGarden";
            this.Text = "Rain Garden Analysis Worksheet";
            this.Load += new System.EventHandler(this.frmRainGarden_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMixes;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.WebBrowser wbOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbVoidFraction;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ComboBox cbSystemType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMediaVolume;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbWaterAboveMedia;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Button btnCost;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTN;
        private System.Windows.Forms.TextBox tbTP;
        private System.Windows.Forms.Button btnMedia;
        private System.Windows.Forms.TextBox tbMediaMix;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbMediaArea;
    }
}