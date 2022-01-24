﻿namespace BMPTrains_2020
{
    partial class frmMediaFilterServiceLife
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
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.wbOutput = new System.Windows.Forms.WebBrowser();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBMP = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMediaWeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFilterVolume = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbOPFraction = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnCopy.Location = new System.Drawing.Point(520, 399);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(112, 39);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnPrint.Location = new System.Drawing.Point(520, 444);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 39);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // wbOutput
            // 
            this.wbOutput.Location = new System.Drawing.Point(16, 346);
            this.wbOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOutput.Name = "wbOutput";
            this.wbOutput.Size = new System.Drawing.Size(473, 187);
            this.wbOutput.TabIndex = 58;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnCalculate.Location = new System.Drawing.Point(520, 354);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(112, 39);
            this.btnCalculate.TabIndex = 7;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnClose.Location = new System.Drawing.Point(520, 489);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 38);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Back";
            this.toolTip1.SetToolTip(this.btnClose, "Items are not saved in Calculators, make copy before returning if you wish to sav" +
        "e.");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.CausesValidation = false;
            this.label2.Location = new System.Drawing.Point(97, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(431, 43);
            this.label2.TabIndex = 55;
            this.label2.Text = "Removal Rate in mg OP/g media (0.01-10.0):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbRate
            // 
            this.tbRate.Location = new System.Drawing.Point(543, 174);
            this.tbRate.Name = "tbRate";
            this.tbRate.Size = new System.Drawing.Size(89, 35);
            this.tbRate.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.CausesValidation = false;
            this.label8.Location = new System.Drawing.Point(209, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(318, 43);
            this.label8.TabIndex = 53;
            this.label8.Text = "Amount Removed (kg TP/yr):";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label8.Visible = false;
            // 
            // tbTD
            // 
            this.tbTD.Enabled = false;
            this.tbTD.Location = new System.Drawing.Point(543, 133);
            this.tbTD.Name = "tbTD";
            this.tbTD.Size = new System.Drawing.Size(89, 35);
            this.tbTD.TabIndex = 3;
            this.tbTD.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 30);
            this.label1.TabIndex = 51;
            this.label1.Text = "Select Catchment:";
            // 
            // cbTo
            // 
            this.cbTo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTo.FormattingEnabled = true;
            this.cbTo.Location = new System.Drawing.Point(198, 16);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(245, 38);
            this.cbTo.TabIndex = 1;
            this.cbTo.SelectedIndexChanged += new System.EventHandler(this.cbTo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 30);
            this.label3.TabIndex = 62;
            this.label3.Text = "Select BMP:";
            // 
            // cbBMP
            // 
            this.cbBMP.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBMP.FormattingEnabled = true;
            this.cbBMP.Location = new System.Drawing.Point(198, 60);
            this.cbBMP.Name = "cbBMP";
            this.cbBMP.Size = new System.Drawing.Size(245, 38);
            this.cbBMP.TabIndex = 2;
            this.cbBMP.SelectedIndexChanged += new System.EventHandler(this.cbBMP_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.CausesValidation = false;
            this.label4.Location = new System.Drawing.Point(98, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(431, 43);
            this.label4.TabIndex = 66;
            this.label4.Text = "Saturated Weight of Media (lbs/cf):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbMediaWeight
            // 
            this.tbMediaWeight.Location = new System.Drawing.Point(543, 256);
            this.tbMediaWeight.Name = "tbMediaWeight";
            this.tbMediaWeight.Size = new System.Drawing.Size(89, 35);
            this.tbMediaWeight.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.CausesValidation = false;
            this.label5.Location = new System.Drawing.Point(210, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(318, 43);
            this.label5.TabIndex = 64;
            this.label5.Text = "Filter Volume Provide (cf):";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbFilterVolume
            // 
            this.tbFilterVolume.Location = new System.Drawing.Point(543, 215);
            this.tbFilterVolume.Name = "tbFilterVolume";
            this.tbFilterVolume.Size = new System.Drawing.Size(89, 35);
            this.tbFilterVolume.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.CausesValidation = false;
            this.label6.Location = new System.Drawing.Point(98, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(431, 43);
            this.label6.TabIndex = 68;
            this.label6.Text = "Fraction OP in TP (<= 1.0):";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbOPFraction
            // 
            this.tbOPFraction.Location = new System.Drawing.Point(543, 297);
            this.tbOPFraction.Name = "tbOPFraction";
            this.tbOPFraction.Size = new System.Drawing.Size(89, 35);
            this.tbOPFraction.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(469, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(176, 30);
            this.lblName.TabIndex = 69;
            this.lblName.Text = "Catchment Name";
            this.lblName.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.CausesValidation = false;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(578, 22);
            this.label7.TabIndex = 70;
            this.label7.Text = "The service life calculation is only for stand alone catchment and not for catchm" +
    "ents in series";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmMediaFilterServiceLife
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 541);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbOPFraction);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMediaWeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbFilterVolume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbBMP);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.wbOutput);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbRate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbTD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTo);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmMediaFilterServiceLife";
            this.Text = "Calculate Media Filter Service Life";
            this.Load += new System.EventHandler(this.frmMediaFilterServiceLife_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.WebBrowser wbOutput;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbTD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBMP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMediaWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFilterVolume;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbOPFraction;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label7;
    }
}