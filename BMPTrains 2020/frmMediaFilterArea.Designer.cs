namespace BMPTrains_2020
{
    partial class frmMediaFilterArea
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
            this.lblCatchments = new System.Windows.Forms.Label();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTD = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.wbOutput = new System.Windows.Forms.WebBrowser();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.cbMixes = new System.Windows.Forms.ComboBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbEIA = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbP = new System.Windows.Forms.TextBox();
            this.tbN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblBMP = new System.Windows.Forms.Label();
            this.cbBMP = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCatchments
            // 
            this.lblCatchments.AutoSize = true;
            this.lblCatchments.Location = new System.Drawing.Point(12, 35);
            this.lblCatchments.Name = "lblCatchments";
            this.lblCatchments.Size = new System.Drawing.Size(180, 30);
            this.lblCatchments.TabIndex = 26;
            this.lblCatchments.Text = "Select Catchment:";
            this.lblCatchments.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbTo
            // 
            this.cbTo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTo.FormattingEnabled = true;
            this.cbTo.Location = new System.Drawing.Point(198, 27);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(222, 38);
            this.cbTo.TabIndex = 25;
            this.toolTip1.SetToolTip(this.cbTo, "Note: This Cannot Pull Media Mix Information for Multiple BMP\'s in Series");
            this.cbTo.SelectedIndexChanged += new System.EventHandler(this.cbTo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.CausesValidation = false;
            this.label2.Location = new System.Drawing.Point(7, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 30);
            this.label2.TabIndex = 44;
            this.label2.Text = "Rate in GPM/SF (0.02-10.0):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbRate
            // 
            this.tbRate.Location = new System.Drawing.Point(331, 217);
            this.tbRate.Name = "tbRate";
            this.tbRate.Size = new System.Drawing.Size(89, 35);
            this.tbRate.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.CausesValidation = false;
            this.label8.Location = new System.Drawing.Point(7, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(318, 30);
            this.label8.TabIndex = 42;
            this.label8.Text = "Treatment Depth (0.05 in - 4 in):";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbTD
            // 
            this.tbTD.Location = new System.Drawing.Point(331, 176);
            this.tbTD.Name = "tbTD";
            this.tbTD.Size = new System.Drawing.Size(89, 35);
            this.tbTD.TabIndex = 41;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnCalculate.Location = new System.Drawing.Point(513, 344);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(112, 39);
            this.btnCalculate.TabIndex = 46;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnClose.Location = new System.Drawing.Point(513, 479);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 39);
            this.btnClose.TabIndex = 45;
            this.btnClose.Text = "Back";
            this.toolTip1.SetToolTip(this.btnClose, "Items are not saved in Calculators, make copy before returning if you wish to sav" +
        "e.");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // wbOutput
            // 
            this.wbOutput.Location = new System.Drawing.Point(12, 344);
            this.wbOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOutput.Name = "wbOutput";
            this.wbOutput.Size = new System.Drawing.Size(473, 174);
            this.wbOutput.TabIndex = 47;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnPrint.Location = new System.Drawing.Point(513, 434);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 39);
            this.btnPrint.TabIndex = 48;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnCopy.Location = new System.Drawing.Point(513, 389);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(112, 39);
            this.btnCopy.TabIndex = 49;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // cbMixes
            // 
            this.cbMixes.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMixes.FormattingEnabled = true;
            this.cbMixes.Location = new System.Drawing.Point(426, 214);
            this.cbMixes.Name = "cbMixes";
            this.cbMixes.Size = new System.Drawing.Size(218, 38);
            this.cbMixes.TabIndex = 50;
            this.toolTip1.SetToolTip(this.cbMixes, "This is the selected media of the catchment or user entered (does not work with m" +
        "ultiple BMP selections)");
            this.cbMixes.SelectedIndexChanged += new System.EventHandler(this.cbMixes_SelectedIndexChanged);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(7, 311);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(444, 30);
            this.lblMessage.TabIndex = 51;
            this.lblMessage.Text = "Half of the runoff volume is treated in day one";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.CausesValidation = false;
            this.label4.Location = new System.Drawing.Point(7, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(318, 30);
            this.label4.TabIndex = 53;
            this.label4.Text = "Effective Impervious Area (ac):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbEIA
            // 
            this.tbEIA.Location = new System.Drawing.Point(331, 131);
            this.tbEIA.Name = "tbEIA";
            this.tbEIA.Size = new System.Drawing.Size(89, 35);
            this.tbEIA.TabIndex = 52;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(426, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(176, 30);
            this.lblName.TabIndex = 54;
            this.lblName.Text = "Catchment Name";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.CausesValidation = false;
            this.label1.Location = new System.Drawing.Point(445, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 30);
            this.label1.TabIndex = 56;
            this.label1.Text = "Used for Efficiency";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Visible = false;
            // 
            // tbP
            // 
            this.tbP.Enabled = false;
            this.tbP.Location = new System.Drawing.Point(570, 173);
            this.tbP.Name = "tbP";
            this.tbP.Size = new System.Drawing.Size(74, 35);
            this.tbP.TabIndex = 55;
            this.toolTip1.SetToolTip(this.tbP, "This is the removal efficiency of the selected media");
            this.tbP.Visible = false;
            // 
            // tbN
            // 
            this.tbN.Enabled = false;
            this.tbN.Location = new System.Drawing.Point(450, 173);
            this.tbN.Name = "tbN";
            this.tbN.Size = new System.Drawing.Size(68, 35);
            this.tbN.TabIndex = 57;
            this.toolTip1.SetToolTip(this.tbN, "This is the removal efficiency of the selected media");
            this.tbN.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.CausesValidation = false;
            this.label5.Location = new System.Drawing.Point(421, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 30);
            this.label5.TabIndex = 58;
            this.label5.Text = "N";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.CausesValidation = false;
            this.label6.Location = new System.Drawing.Point(535, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 30);
            this.label6.TabIndex = 59;
            this.label6.Text = "P";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label6.Visible = false;
            // 
            // lblBMP
            // 
            this.lblBMP.AutoSize = true;
            this.lblBMP.Location = new System.Drawing.Point(70, 79);
            this.lblBMP.Name = "lblBMP";
            this.lblBMP.Size = new System.Drawing.Size(122, 30);
            this.lblBMP.TabIndex = 64;
            this.lblBMP.Text = "Select BMP:";
            this.lblBMP.Visible = false;
            // 
            // cbBMP
            // 
            this.cbBMP.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBMP.FormattingEnabled = true;
            this.cbBMP.Location = new System.Drawing.Point(198, 71);
            this.cbBMP.Name = "cbBMP";
            this.cbBMP.Size = new System.Drawing.Size(222, 38);
            this.cbBMP.TabIndex = 63;
            this.cbBMP.Visible = false;
            this.cbBMP.SelectedIndexChanged += new System.EventHandler(this.cbBMP_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 521);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(553, 30);
            this.label3.TabIndex = 65;
            this.label3.Text = "Changes made here will not be reflected in the Catchment";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(392, 30);
            this.label7.TabIndex = 66;
            this.label7.Text = "Treatment rate includes the safety factor.";
            // 
            // frmMediaFilterArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 562);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBMP);
            this.Controls.Add(this.cbBMP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbP);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbEIA);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.cbMixes);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.wbOutput);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbRate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbTD);
            this.Controls.Add(this.lblCatchments);
            this.Controls.Add(this.cbTo);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmMediaFilterArea";
            this.Text = "Calculate Media Filter Area";
            this.Load += new System.EventHandler(this.frmMediaFilterArea_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCatchments;
        private System.Windows.Forms.ComboBox cbTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbTD;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.WebBrowser wbOutput;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ComboBox cbMixes;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbEIA;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbP;
        private System.Windows.Forms.TextBox tbN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblBMP;
        private System.Windows.Forms.ComboBox cbBMP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
    }
}