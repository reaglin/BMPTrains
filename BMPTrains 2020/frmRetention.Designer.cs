namespace BMPTrains_2020
{
    partial class frmRetention
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRetention));
            this.tbDepth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.wbOutput = new System.Windows.Forms.WebBrowser();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnHelpOld = new System.Windows.Forms.Button();
            this.btnMediaMix = new System.Windows.Forms.Button();
            this.btnPlot = new System.Windows.Forms.Button();
            this.btnCost = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnDepthFromEfficiency = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDepth
            // 
            this.tbDepth.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDepth.Location = new System.Drawing.Point(627, 36);
            this.tbDepth.Name = "tbDepth";
            this.tbDepth.Size = new System.Drawing.Size(89, 35);
            this.tbDepth.TabIndex = 1;
            this.tbDepth.DoubleClick += new System.EventHandler(this.tbDepth1_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(250, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(371, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "Provided Retention Volume (acre-feet):";
            // 
            // wbOutput
            // 
            this.wbOutput.Location = new System.Drawing.Point(17, 86);
            this.wbOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOutput.Name = "wbOutput";
            this.wbOutput.Size = new System.Drawing.Size(706, 341);
            this.wbOutput.TabIndex = 6;
            this.wbOutput.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbOutput_DocumentCompleted);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(744, 386);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 39);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Back";
            this.toolTip1.SetToolTip(this.btnClose, "Exit the Current Worksheet");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(744, 341);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(112, 39);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "Copy";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(744, 206);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 39);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(868, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(744, 71);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(112, 39);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate";
            this.toolTip1.SetToolTip(this.btnCalculate, "Calculate Values from Depth Input");
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnHelpOld
            // 
            this.btnHelpOld.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelpOld.Location = new System.Drawing.Point(8, 12);
            this.btnHelpOld.Name = "btnHelpOld";
            this.btnHelpOld.Size = new System.Drawing.Size(112, 22);
            this.btnHelpOld.TabIndex = 19;
            this.btnHelpOld.Text = "Help";
            this.btnHelpOld.UseVisualStyleBackColor = true;
            this.btnHelpOld.Visible = false;
            this.btnHelpOld.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnMediaMix
            // 
            this.btnMediaMix.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMediaMix.Location = new System.Drawing.Point(744, 116);
            this.btnMediaMix.Name = "btnMediaMix";
            this.btnMediaMix.Size = new System.Drawing.Size(112, 39);
            this.btnMediaMix.TabIndex = 3;
            this.btnMediaMix.Text = "Media";
            this.toolTip1.SetToolTip(this.btnMediaMix, "Allows for Selection of a Media Mix for Groundwater Discharge");
            this.btnMediaMix.UseVisualStyleBackColor = true;
            this.btnMediaMix.Click += new System.EventHandler(this.btnMediaMix_Click);
            // 
            // btnPlot
            // 
            this.btnPlot.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlot.Location = new System.Drawing.Point(744, 251);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(112, 39);
            this.btnPlot.TabIndex = 6;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // btnCost
            // 
            this.btnCost.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCost.Location = new System.Drawing.Point(744, 296);
            this.btnCost.Name = "btnCost";
            this.btnCost.Size = new System.Drawing.Size(112, 39);
            this.btnCost.TabIndex = 7;
            this.btnCost.Text = "Cost";
            this.btnCost.UseVisualStyleBackColor = true;
            this.btnCost.Click += new System.EventHandler(this.btnCost_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Yellow;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(126, 29);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(46, 40);
            this.btnHelp.TabIndex = 59;
            this.toolTip1.SetToolTip(this.btnHelp, "Retention Methodology");
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click_1);
            // 
            // btnDepthFromEfficiency
            // 
            this.btnDepthFromEfficiency.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepthFromEfficiency.Location = new System.Drawing.Point(744, 161);
            this.btnDepthFromEfficiency.Name = "btnDepthFromEfficiency";
            this.btnDepthFromEfficiency.Size = new System.Drawing.Size(112, 39);
            this.btnDepthFromEfficiency.TabIndex = 4;
            this.btnDepthFromEfficiency.Text = "Get Depth";
            this.toolTip1.SetToolTip(this.btnDepthFromEfficiency, "Calculate Depth from Average Annual Efficiency");
            this.btnDepthFromEfficiency.UseVisualStyleBackColor = true;
            this.btnDepthFromEfficiency.Click += new System.EventHandler(this.btnDepthFromEfficiency_Click);
            // 
            // frmRetention
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 441);
            this.ControlBox = false;
            this.Controls.Add(this.btnDepthFromEfficiency);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCost);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.btnMediaMix);
            this.Controls.Add(this.btnHelpOld);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.wbOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDepth);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmRetention";
            this.Text = "Retention System Worksheet";
            this.Load += new System.EventHandler(this.frmRetention_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbDepth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser wbOutput;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnHelpOld;
        private System.Windows.Forms.Button btnMediaMix;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Button btnCost;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnDepthFromEfficiency;
    }
}