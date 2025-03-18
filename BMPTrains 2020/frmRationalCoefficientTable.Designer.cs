namespace BMPTrains_2020
{
    partial class frmRationalCoefficientTable
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnBack = new System.Windows.Forms.Button();
            this.cbMetZone = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTable
            // 
            this.btnTable.Location = new System.Drawing.Point(1011, 10);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(65, 34);
            this.btnTable.TabIndex = 22;
            this.btnTable.Text = "Find";
            this.btnTable.UseVisualStyleBackColor = true;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // tbTable
            // 
            this.tbTable.Location = new System.Drawing.Point(917, 10);
            this.tbTable.Name = "tbTable";
            this.tbTable.Size = new System.Drawing.Size(88, 35);
            this.tbTable.TabIndex = 21;
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(851, 13);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(60, 30);
            this.lblTable.TabIndex = 20;
            this.lblTable.Text = "ROC:";
            // 
            // btnColumn
            // 
            this.btnColumn.Location = new System.Drawing.Point(732, 8);
            this.btnColumn.Name = "btnColumn";
            this.btnColumn.Size = new System.Drawing.Size(64, 34);
            this.btnColumn.TabIndex = 19;
            this.btnColumn.Text = "Find";
            this.btnColumn.UseVisualStyleBackColor = true;
            this.btnColumn.Click += new System.EventHandler(this.btnColumn_Click);
            // 
            // tbColumn
            // 
            this.tbColumn.Location = new System.Drawing.Point(633, 10);
            this.tbColumn.Name = "tbColumn";
            this.tbColumn.Size = new System.Drawing.Size(88, 35);
            this.tbColumn.TabIndex = 18;
            // 
            // lblColumn
            // 
            this.lblColumn.AutoSize = true;
            this.lblColumn.Location = new System.Drawing.Point(540, 15);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(84, 30);
            this.lblColumn.TabIndex = 17;
            this.lblColumn.Text = "DCIA %";
            // 
            // btnRow
            // 
            this.btnRow.Location = new System.Drawing.Point(454, 9);
            this.btnRow.Name = "btnRow";
            this.btnRow.Size = new System.Drawing.Size(63, 34);
            this.btnRow.TabIndex = 16;
            this.btnRow.Text = "Find";
            this.toolTip1.SetToolTip(this.btnRow, "Items are not saved in Calculators, make copy before returning if you wish to sav" +
        "e.");
            this.btnRow.UseVisualStyleBackColor = true;
            this.btnRow.Click += new System.EventHandler(this.btnRow_Click);
            // 
            // tbRow
            // 
            this.tbRow.Location = new System.Drawing.Point(360, 10);
            this.tbRow.Name = "tbRow";
            this.tbRow.Size = new System.Drawing.Size(88, 35);
            this.tbRow.TabIndex = 15;
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(252, 15);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(112, 30);
            this.lblRow.TabIndex = 14;
            this.lblRow.Text = "NDCIA CN";
            // 
            // wbReport
            // 
            this.wbReport.Location = new System.Drawing.Point(15, 58);
            this.wbReport.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbReport.Name = "wbReport";
            this.wbReport.Size = new System.Drawing.Size(1145, 440);
            this.wbReport.TabIndex = 13;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1166, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 50);
            this.btnBack.TabIndex = 24;
            this.btnBack.Text = "Back";
            this.toolTip1.SetToolTip(this.btnBack, "Items are not saved in Calculators, make copy before returning if you wish to sav" +
        "e.");
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // cbMetZone
            // 
            this.cbMetZone.FormattingEnabled = true;
            this.cbMetZone.Location = new System.Drawing.Point(40, 8);
            this.cbMetZone.Name = "cbMetZone";
            this.cbMetZone.Size = new System.Drawing.Size(206, 38);
            this.cbMetZone.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1166, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 48);
            this.button1.TabIndex = 25;
            this.button1.Text = "Copy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmRationalCoefficientTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 512);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBack);
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
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmRationalCoefficientTable";
            this.Text = "Rational Coefficient Lookup";
            this.Load += new System.EventHandler(this.frmRationalCoefficientTable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cbMetZone;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button button1;
    }
}