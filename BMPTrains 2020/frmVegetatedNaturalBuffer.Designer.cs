namespace BMPTrains_2020
{
    partial class frmVegetatedNaturalBuffer
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
            this.wbOutput = new System.Windows.Forms.WebBrowser();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.tbFeederW = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbStorage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbD = new System.Windows.Forms.TextBox();
            this.tbL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbW = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSlope = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPlot = new System.Windows.Forms.Button();
            this.btnCost = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnMedia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // wbOutput
            // 
            this.wbOutput.Location = new System.Drawing.Point(12, 250);
            this.wbOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOutput.Name = "wbOutput";
            this.wbOutput.Size = new System.Drawing.Size(516, 289);
            this.wbOutput.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(549, 498);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 39);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Back";
            this.toolTip1.SetToolTip(this.btnClose, "Exit the Current Worksheet");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(548, 453);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(112, 39);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "Copy";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(548, 363);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 39);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(683, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(549, 275);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(112, 39);
            this.btnCalculate.TabIndex = 18;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(549, 230);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(112, 39);
            this.btnHelp.TabIndex = 19;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Visible = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // tbFeederW
            // 
            this.tbFeederW.Location = new System.Drawing.Point(240, 134);
            this.tbFeederW.Name = "tbFeederW";
            this.tbFeederW.Size = new System.Drawing.Size(54, 29);
            this.tbFeederW.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 21);
            this.label5.TabIndex = 32;
            this.label5.Text = "Soil Storage Capacity (in/in):";
            // 
            // tbStorage
            // 
            this.tbStorage.Location = new System.Drawing.Point(240, 169);
            this.tbStorage.Name = "tbStorage";
            this.tbStorage.Size = new System.Drawing.Size(54, 29);
            this.tbStorage.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 21);
            this.label1.TabIndex = 31;
            this.label1.Text = "Storage depth (< 1ft):";
            // 
            // tbD
            // 
            this.tbD.Location = new System.Drawing.Point(240, 99);
            this.tbD.Name = "tbD";
            this.tbD.Size = new System.Drawing.Size(54, 29);
            this.tbD.TabIndex = 3;
            // 
            // tbL
            // 
            this.tbL.Location = new System.Drawing.Point(240, 64);
            this.tbL.Name = "tbL";
            this.tbL.Size = new System.Drawing.Size(54, 29);
            this.tbL.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 21);
            this.label4.TabIndex = 30;
            this.label4.Text = "Width of Feeder Area (ft):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 21);
            this.label3.TabIndex = 29;
            this.label3.Text = "Length (ft):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 21);
            this.label2.TabIndex = 28;
            this.label2.Text = "Width (10 - 350 ft):";
            // 
            // tbW
            // 
            this.tbW.Location = new System.Drawing.Point(240, 29);
            this.tbW.Name = "tbW";
            this.tbW.Size = new System.Drawing.Size(54, 29);
            this.tbW.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 21);
            this.label6.TabIndex = 33;
            this.label6.Text = "Buffer Width Slope (2-6%):";
            // 
            // tbSlope
            // 
            this.tbSlope.Location = new System.Drawing.Point(240, 204);
            this.tbSlope.Name = "tbSlope";
            this.tbSlope.Size = new System.Drawing.Size(54, 29);
            this.tbSlope.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::BMPTrains_2020.Properties.Resources.VegBuffer;
            this.pictureBox1.Location = new System.Drawing.Point(328, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 196);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // btnPlot
            // 
            this.btnPlot.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlot.Location = new System.Drawing.Point(548, 408);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(112, 39);
            this.btnPlot.TabIndex = 36;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // btnCost
            // 
            this.btnCost.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCost.Location = new System.Drawing.Point(548, 318);
            this.btnCost.Name = "btnCost";
            this.btnCost.Size = new System.Drawing.Size(112, 39);
            this.btnCost.TabIndex = 37;
            this.btnCost.Text = "Cost";
            this.btnCost.UseVisualStyleBackColor = true;
            this.btnCost.Click += new System.EventHandler(this.btnCost_Click);
            // 
            // btnMedia
            // 
            this.btnMedia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedia.Location = new System.Drawing.Point(548, 186);
            this.btnMedia.Name = "btnMedia";
            this.btnMedia.Size = new System.Drawing.Size(112, 39);
            this.btnMedia.TabIndex = 38;
            this.btnMedia.Text = "Media";
            this.btnMedia.UseVisualStyleBackColor = true;
            this.btnMedia.Click += new System.EventHandler(this.btnMedia_Click);
            // 
            // frmVegetatedNaturalBuffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 551);
            this.ControlBox = false;
            this.Controls.Add(this.btnMedia);
            this.Controls.Add(this.btnCost);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbSlope);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbFeederW);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbStorage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbD);
            this.Controls.Add(this.tbL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbW);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.wbOutput);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmVegetatedNaturalBuffer";
            this.Text = "Vegetated Natural Buffer Worksheet";
            this.Load += new System.EventHandler(this.frmRetention_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.WebBrowser wbOutput;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TextBox tbFeederW;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbStorage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbD;
        private System.Windows.Forms.TextBox tbL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbW;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSlope;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Button btnCost;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnMedia;
    }
}