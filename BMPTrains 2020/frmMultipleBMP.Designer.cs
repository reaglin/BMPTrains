namespace BMPTrains_2020
{
    partial class frmMultipleBMP 
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBMP1 = new System.Windows.Forms.ComboBox();
            this.cbBMP2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBMP3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbBMP4 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnOpen1 = new System.Windows.Forms.Button();
            this.btnOpen2 = new System.Windows.Forms.Button();
            this.btnOpen3 = new System.Windows.Forms.Button();
            this.btnOpen4 = new System.Windows.Forms.Button();
            this.btnAnoxicDepth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(515, 269);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 39);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Back";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(515, 201);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(112, 39);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "Copy";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(515, 147);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 39);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Full Report";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(652, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(515, 57);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(112, 39);
            this.btnCalculate.TabIndex = 18;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(515, 12);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(112, 39);
            this.btnHelp.TabIndex = 19;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Visible = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Add up to 4 BMP\'s to each catchment in order of routing";
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Location = new System.Drawing.Point(27, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 23);
            this.label2.TabIndex = 21;
            this.label2.Text = "BMP 1:";
            // 
            // cbBMP1
            // 
            this.cbBMP1.DropDownWidth = 220;
            this.cbBMP1.FormattingEnabled = true;
            this.cbBMP1.Location = new System.Drawing.Point(91, 71);
            this.cbBMP1.Name = "cbBMP1";
            this.cbBMP1.Size = new System.Drawing.Size(220, 29);
            this.cbBMP1.TabIndex = 22;
            this.cbBMP1.SelectedIndexChanged += new System.EventHandler(this.cbBMP1_SelectedIndexChanged);
            // 
            // cbBMP2
            // 
            this.cbBMP2.DropDownWidth = 220;
            this.cbBMP2.FormattingEnabled = true;
            this.cbBMP2.Location = new System.Drawing.Point(91, 135);
            this.cbBMP2.Name = "cbBMP2";
            this.cbBMP2.Size = new System.Drawing.Size(220, 29);
            this.cbBMP2.TabIndex = 24;
            this.cbBMP2.SelectedIndexChanged += new System.EventHandler(this.cbBMP2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(25, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 23);
            this.label3.TabIndex = 23;
            this.label3.Text = "BMP 2:";
            // 
            // cbBMP3
            // 
            this.cbBMP3.FormattingEnabled = true;
            this.cbBMP3.Location = new System.Drawing.Point(91, 206);
            this.cbBMP3.Name = "cbBMP3";
            this.cbBMP3.Size = new System.Drawing.Size(220, 29);
            this.cbBMP3.TabIndex = 26;
            this.cbBMP3.SelectedIndexChanged += new System.EventHandler(this.cbBMP3_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(25, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 23);
            this.label4.TabIndex = 25;
            this.label4.Text = "BMP 3:";
            // 
            // cbBMP4
            // 
            this.cbBMP4.FormattingEnabled = true;
            this.cbBMP4.Location = new System.Drawing.Point(91, 279);
            this.cbBMP4.Name = "cbBMP4";
            this.cbBMP4.Size = new System.Drawing.Size(220, 29);
            this.cbBMP4.TabIndex = 28;
            this.cbBMP4.SelectedIndexChanged += new System.EventHandler(this.cbBMP4_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(25, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 23);
            this.label5.TabIndex = 27;
            this.label5.Text = "BMP 4:";
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Exit the Current Worksheet";
            // 
            // btnOpen1
            // 
            this.btnOpen1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen1.Location = new System.Drawing.Point(317, 63);
            this.btnOpen1.Name = "btnOpen1";
            this.btnOpen1.Size = new System.Drawing.Size(112, 39);
            this.btnOpen1.TabIndex = 29;
            this.btnOpen1.Text = "Open";
            this.btnOpen1.UseVisualStyleBackColor = true;
            this.btnOpen1.Click += new System.EventHandler(this.btnOpen1_Click);
            // 
            // btnOpen2
            // 
            this.btnOpen2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen2.Location = new System.Drawing.Point(317, 125);
            this.btnOpen2.Name = "btnOpen2";
            this.btnOpen2.Size = new System.Drawing.Size(112, 39);
            this.btnOpen2.TabIndex = 30;
            this.btnOpen2.Text = "Open";
            this.btnOpen2.UseVisualStyleBackColor = true;
            this.btnOpen2.Click += new System.EventHandler(this.btnOpen2_Click);
            // 
            // btnOpen3
            // 
            this.btnOpen3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen3.Location = new System.Drawing.Point(317, 196);
            this.btnOpen3.Name = "btnOpen3";
            this.btnOpen3.Size = new System.Drawing.Size(112, 39);
            this.btnOpen3.TabIndex = 31;
            this.btnOpen3.Text = "Open";
            this.btnOpen3.UseVisualStyleBackColor = true;
            this.btnOpen3.Click += new System.EventHandler(this.btnOpen3_Click);
            // 
            // btnOpen4
            // 
            this.btnOpen4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen4.Location = new System.Drawing.Point(317, 269);
            this.btnOpen4.Name = "btnOpen4";
            this.btnOpen4.Size = new System.Drawing.Size(112, 39);
            this.btnOpen4.TabIndex = 32;
            this.btnOpen4.Text = "Open";
            this.btnOpen4.UseVisualStyleBackColor = true;
            this.btnOpen4.Click += new System.EventHandler(this.btnOpen4_Click);
            // 
            // btnAnoxicDepth
            // 
            this.btnAnoxicDepth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnoxicDepth.Location = new System.Drawing.Point(515, 102);
            this.btnAnoxicDepth.Name = "btnAnoxicDepth";
            this.btnAnoxicDepth.Size = new System.Drawing.Size(112, 39);
            this.btnAnoxicDepth.TabIndex = 62;
            this.btnAnoxicDepth.Text = "Anoxic Depth";
            this.btnAnoxicDepth.UseVisualStyleBackColor = true;
            this.btnAnoxicDepth.Visible = false;
            this.btnAnoxicDepth.Click += new System.EventHandler(this.btnAnoxicDepth_Click);
            // 
            // frmMultipleBMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 347);
            this.ControlBox = false;
            this.Controls.Add(this.btnAnoxicDepth);
            this.Controls.Add(this.btnOpen4);
            this.Controls.Add(this.btnOpen3);
            this.Controls.Add(this.btnOpen2);
            this.Controls.Add(this.btnOpen1);
            this.Controls.Add(this.cbBMP4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbBMP3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbBMP2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbBMP1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMultipleBMP";
            this.Text = "Multiple BMP Worksheet for Catchment";
            this.Load += new System.EventHandler(this.frmRetention_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMultipleBMP_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBMP1;
        private System.Windows.Forms.ComboBox cbBMP2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBMP3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbBMP4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnOpen1;
        private System.Windows.Forms.Button btnOpen2;
        private System.Windows.Forms.Button btnOpen3;
        private System.Windows.Forms.Button btnOpen4;
        private System.Windows.Forms.Button btnAnoxicDepth;
    }
}