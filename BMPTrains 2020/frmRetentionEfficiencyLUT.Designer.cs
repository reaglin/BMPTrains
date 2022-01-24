namespace BMPTrains_2020
{
    partial class frmRetentionEfficiencyLUT
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
            this.cbMetZone = new System.Windows.Forms.ComboBox();
            this.btnTable = new System.Windows.Forms.Button();
            this.tbTable = new System.Windows.Forms.TextBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.btnColumn = new System.Windows.Forms.Button();
            this.tbColumn = new System.Windows.Forms.TextBox();
            this.lblColumn = new System.Windows.Forms.Label();
            this.btnRow = new System.Windows.Forms.Button();
            this.tbRow = new System.Windows.Forms.TextBox();
            this.lblRow = new System.Windows.Forms.Label();
            this.wbReport = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDepth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // cbMetZone
            // 
            this.cbMetZone.FormattingEnabled = true;
            this.cbMetZone.Location = new System.Drawing.Point(169, 8);
            this.cbMetZone.Name = "cbMetZone";
            this.cbMetZone.Size = new System.Drawing.Size(206, 38);
            this.cbMetZone.TabIndex = 34;
            // 
            // btnTable
            // 
            this.btnTable.Location = new System.Drawing.Point(821, 54);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(75, 34);
            this.btnTable.TabIndex = 33;
            this.btnTable.Text = "Find";
            this.btnTable.UseVisualStyleBackColor = true;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // tbTable
            // 
            this.tbTable.Location = new System.Drawing.Point(727, 55);
            this.tbTable.Name = "tbTable";
            this.tbTable.Size = new System.Drawing.Size(88, 35);
            this.tbTable.TabIndex = 32;
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(625, 55);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(106, 30);
            this.lblTable.TabIndex = 31;
            this.lblTable.Text = "Efficiency:";
            // 
            // btnColumn
            // 
            this.btnColumn.Location = new System.Drawing.Point(509, 54);
            this.btnColumn.Name = "btnColumn";
            this.btnColumn.Size = new System.Drawing.Size(75, 34);
            this.btnColumn.TabIndex = 30;
            this.btnColumn.Text = "Find";
            this.btnColumn.UseVisualStyleBackColor = true;
            this.btnColumn.Click += new System.EventHandler(this.btnColumn_Click);
            // 
            // tbColumn
            // 
            this.tbColumn.Location = new System.Drawing.Point(415, 54);
            this.tbColumn.Name = "tbColumn";
            this.tbColumn.Size = new System.Drawing.Size(88, 35);
            this.tbColumn.TabIndex = 29;
            // 
            // lblColumn
            // 
            this.lblColumn.AutoSize = true;
            this.lblColumn.Location = new System.Drawing.Point(325, 55);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(84, 30);
            this.lblColumn.TabIndex = 28;
            this.lblColumn.Text = "DCIA %";
            // 
            // btnRow
            // 
            this.btnRow.Location = new System.Drawing.Point(235, 52);
            this.btnRow.Name = "btnRow";
            this.btnRow.Size = new System.Drawing.Size(75, 34);
            this.btnRow.TabIndex = 27;
            this.btnRow.Text = "Find";
            this.btnRow.UseVisualStyleBackColor = true;
            this.btnRow.Click += new System.EventHandler(this.btnRow_Click);
            // 
            // tbRow
            // 
            this.tbRow.Location = new System.Drawing.Point(141, 54);
            this.tbRow.Name = "tbRow";
            this.tbRow.Size = new System.Drawing.Size(88, 35);
            this.tbRow.TabIndex = 26;
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(23, 55);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(112, 30);
            this.lblRow.TabIndex = 25;
            this.lblRow.Text = "NDCIA CN";
            // 
            // wbReport
            // 
            this.wbReport.Location = new System.Drawing.Point(12, 99);
            this.wbReport.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbReport.Name = "wbReport";
            this.wbReport.Size = new System.Drawing.Size(1046, 440);
            this.wbReport.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 30);
            this.label1.TabIndex = 35;
            this.label1.Text = "Rainfall Zone:";
            // 
            // tbDepth
            // 
            this.tbDepth.Location = new System.Drawing.Point(727, 8);
            this.tbDepth.Name = "tbDepth";
            this.tbDepth.Size = new System.Drawing.Size(88, 35);
            this.tbDepth.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(475, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 30);
            this.label2.TabIndex = 36;
            this.label2.Text = "Retention Depth (> 0.25):";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(983, 9);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 34);
            this.btnBack.TabIndex = 38;
            this.btnBack.Text = "Back";
            this.toolTip1.SetToolTip(this.btnBack, "Items are not saved in Calculators, make copy before returning if you wish to sav" +
        "e.");
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(983, 49);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 34);
            this.btnCopy.TabIndex = 39;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // frmRetentionEfficiencyLUT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 567);
            this.ControlBox = false;
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tbDepth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMetZone);
            this.Controls.Add(this.btnTable);
            this.Controls.Add(this.tbTable);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.btnColumn);
            this.Controls.Add(this.tbColumn);
            this.Controls.Add(this.lblColumn);
            this.Controls.Add(this.btnRow);
            this.Controls.Add(this.tbRow);
            this.Controls.Add(this.lblRow);
            this.Controls.Add(this.wbReport);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmRetentionEfficiencyLUT";
            this.Text = "Retention Efficiency";
            this.Load += new System.EventHandler(this.frmRetentionEfficiencyLUT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMetZone;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.TextBox tbTable;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Button btnColumn;
        private System.Windows.Forms.TextBox tbColumn;
        private System.Windows.Forms.Label lblColumn;
        private System.Windows.Forms.Button btnRow;
        private System.Windows.Forms.TextBox tbRow;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.WebBrowser wbReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDepth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}