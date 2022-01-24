namespace BMPTrains_2020
{
    partial class frmMediaMix
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMediaMix));
            this.labelR2 = new System.Windows.Forms.Label();
            this.labelR1 = new System.Windows.Forms.Label();
            this.tbTPReduction = new System.Windows.Forms.TextBox();
            this.tbTNReduction = new System.Windows.Forms.TextBox();
            this.labelR3 = new System.Windows.Forms.Label();
            this.labelR4 = new System.Windows.Forms.Label();
            this.labelR5 = new System.Windows.Forms.Label();
            this.cbMixes = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnHelp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbYesNo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelR2
            // 
            this.labelR2.AutoSize = true;
            this.labelR2.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR2.Location = new System.Drawing.Point(417, 107);
            this.labelR2.Name = "labelR2";
            this.labelR2.Size = new System.Drawing.Size(42, 65);
            this.labelR2.TabIndex = 29;
            this.labelR2.Text = "{";
            // 
            // labelR1
            // 
            this.labelR1.AutoSize = true;
            this.labelR1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR1.Location = new System.Drawing.Point(142, 123);
            this.labelR1.Name = "labelR1";
            this.labelR1.Size = new System.Drawing.Size(287, 37);
            this.labelR1.TabIndex = 28;
            this.labelR1.Text = "If all runoff are treated:";
            // 
            // tbTPReduction
            // 
            this.tbTPReduction.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTPReduction.Location = new System.Drawing.Point(648, 146);
            this.tbTPReduction.Name = "tbTPReduction";
            this.tbTPReduction.Size = new System.Drawing.Size(51, 35);
            this.tbTPReduction.TabIndex = 23;
            // 
            // tbTNReduction
            // 
            this.tbTNReduction.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTNReduction.Location = new System.Drawing.Point(648, 105);
            this.tbTNReduction.Name = "tbTNReduction";
            this.tbTNReduction.Size = new System.Drawing.Size(51, 35);
            this.tbTNReduction.TabIndex = 24;
            // 
            // labelR3
            // 
            this.labelR3.AutoSize = true;
            this.labelR3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR3.Location = new System.Drawing.Point(464, 151);
            this.labelR3.Name = "labelR3";
            this.labelR3.Size = new System.Drawing.Size(175, 30);
            this.labelR3.TabIndex = 27;
            this.labelR3.Text = "TP Reduction (%):";
            // 
            // labelR4
            // 
            this.labelR4.AutoSize = true;
            this.labelR4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR4.Location = new System.Drawing.Point(461, 112);
            this.labelR4.Name = "labelR4";
            this.labelR4.Size = new System.Drawing.Size(179, 30);
            this.labelR4.TabIndex = 26;
            this.labelR4.Text = "TN Reduction (%):";
            // 
            // labelR5
            // 
            this.labelR5.AutoSize = true;
            this.labelR5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR5.Location = new System.Drawing.Point(236, 66);
            this.labelR5.Name = "labelR5";
            this.labelR5.Size = new System.Drawing.Size(177, 30);
            this.labelR5.TabIndex = 25;
            this.labelR5.Text = "Select Media Mix:";
            // 
            // cbMixes
            // 
            this.cbMixes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMixes.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMixes.FormattingEnabled = true;
            this.cbMixes.Location = new System.Drawing.Point(419, 58);
            this.cbMixes.Name = "cbMixes";
            this.cbMixes.Size = new System.Drawing.Size(279, 38);
            this.cbMixes.TabIndex = 22;
            this.cbMixes.SelectedIndexChanged += new System.EventHandler(this.cbMixes_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(588, 201);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 39);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Back";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Exit the Current Worksheet";
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(184, 66);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(46, 40);
            this.btnHelp.TabIndex = 64;
            this.toolTip1.SetToolTip(this.btnHelp, "Help on Media Mix Information");
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(568, 30);
            this.label1.TabIndex = 66;
            this.label1.Text = "Is there an upstream BMP in this Catchment (ex. wet pond)?";
            // 
            // cbYesNo
            // 
            this.cbYesNo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbYesNo.FormattingEnabled = true;
            this.cbYesNo.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cbYesNo.Location = new System.Drawing.Point(609, 12);
            this.cbYesNo.Name = "cbYesNo";
            this.cbYesNo.Size = new System.Drawing.Size(89, 38);
            this.cbYesNo.TabIndex = 65;
            this.cbYesNo.SelectedIndexChanged += new System.EventHandler(this.cbYesNo_SelectedIndexChanged);
            // 
            // frmMediaMix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 250);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbYesNo);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.labelR2);
            this.Controls.Add(this.labelR1);
            this.Controls.Add(this.tbTPReduction);
            this.Controls.Add(this.tbTNReduction);
            this.Controls.Add(this.labelR3);
            this.Controls.Add(this.labelR4);
            this.Controls.Add(this.labelR5);
            this.Controls.Add(this.cbMixes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMediaMix";
            this.Text = "Enter Media Mix Information";
            this.Load += new System.EventHandler(this.frmMediaMix_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelR2;
        private System.Windows.Forms.Label labelR1;
        private System.Windows.Forms.TextBox tbTPReduction;
        private System.Windows.Forms.TextBox tbTNReduction;
        private System.Windows.Forms.Label labelR3;
        private System.Windows.Forms.Label labelR4;
        private System.Windows.Forms.Label labelR5;
        private System.Windows.Forms.ComboBox cbMixes;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbYesNo;
    }
}