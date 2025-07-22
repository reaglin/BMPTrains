namespace BMPTrains_2020
{
    partial class frmPlotting
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.blnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSource = new System.Windows.Forms.Button();
            this.pb = new System.Windows.Forms.PictureBox();
            this.pd = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(23, 12);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(884, 608);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // blnClose
            // 
            this.blnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.blnClose.Location = new System.Drawing.Point(23, 637);
            this.blnClose.Name = "blnClose";
            this.blnClose.Size = new System.Drawing.Size(122, 38);
            this.blnClose.TabIndex = 1;
            this.blnClose.Text = "Close";
            this.blnClose.UseVisualStyleBackColor = true;
            this.blnClose.Click += new System.EventHandler(this.blnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnPrint.Location = new System.Drawing.Point(162, 637);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(122, 38);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnCopy.Location = new System.Drawing.Point(307, 637);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(122, 38);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSource
            // 
            this.btnSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnSource.Location = new System.Drawing.Point(452, 637);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(122, 38);
            this.btnSource.TabIndex = 5;
            this.btnSource.Text = "Source";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(631, 626);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(100, 50);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb.TabIndex = 6;
            this.pb.TabStop = false;
            this.pb.Visible = false;
            // 
            // pd
            // 
            this.pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
            // 
            // frmPlotting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 687);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.btnSource);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.blnClose);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPlotting";
            this.Text = "Plot Form";
            this.Load += new System.EventHandler(this.Plotting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button blnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.PictureBox pb;
        private System.Drawing.Printing.PrintDocument pd;
    }
}