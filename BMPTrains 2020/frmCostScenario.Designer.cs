namespace BMPTrains_2020
{
    partial class frmCostScenario
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
            this.btnPlot = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnScenarioReport = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPV = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnnualRecovery = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlot
            // 
            this.btnPlot.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlot.Location = new System.Drawing.Point(761, 135);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(173, 39);
            this.btnPlot.TabIndex = 27;
            this.btnPlot.Text = "Construction Cost";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(702, 234);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(236, 39);
            this.btnReport.TabIndex = 26;
            this.btnReport.Text = "Full Cost Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(702, 324);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(236, 39);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Back";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnScenarioReport
            // 
            this.btnScenarioReport.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScenarioReport.Location = new System.Drawing.Point(702, 279);
            this.btnScenarioReport.Name = "btnScenarioReport";
            this.btnScenarioReport.Size = new System.Drawing.Size(236, 39);
            this.btnScenarioReport.TabIndex = 28;
            this.btnScenarioReport.Text = "Scenario Report";
            this.btnScenarioReport.UseVisualStyleBackColor = true;
            this.btnScenarioReport.Click += new System.EventHandler(this.btnScenarioReport_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(666, 368);
            this.dataGridView1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(721, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 63);
            this.label1.TabIndex = 30;
            this.label1.Text = "You can get reports and\r\nplots of cost information\r\nfrom this window.\r\n";
            // 
            // btnPV
            // 
            this.btnPV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPV.Location = new System.Drawing.Point(761, 180);
            this.btnPV.Name = "btnPV";
            this.btnPV.Size = new System.Drawing.Size(173, 39);
            this.btnPV.TabIndex = 31;
            this.btnPV.Text = "Present Value";
            this.btnPV.UseVisualStyleBackColor = true;
            this.btnPV.Click += new System.EventHandler(this.btnPV_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(697, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 30);
            this.label2.TabIndex = 32;
            this.label2.Text = "Plot";
            // 
            // btnAnnualRecovery
            // 
            this.btnAnnualRecovery.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnualRecovery.Location = new System.Drawing.Point(761, 90);
            this.btnAnnualRecovery.Name = "btnAnnualRecovery";
            this.btnAnnualRecovery.Size = new System.Drawing.Size(173, 39);
            this.btnAnnualRecovery.TabIndex = 33;
            this.btnAnnualRecovery.Text = "Annual Recovery";
            this.btnAnnualRecovery.UseVisualStyleBackColor = true;
            this.btnAnnualRecovery.Click += new System.EventHandler(this.btnAnnualRecovery_Click);
            // 
            // frmCostScenario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 396);
            this.ControlBox = false;
            this.Controls.Add(this.btnAnnualRecovery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnScenarioReport);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCostScenario";
            this.Text = "Cost Scenario Management";
            this.Load += new System.EventHandler(this.frmCostScenario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnScenarioReport;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnnualRecovery;
    }
}