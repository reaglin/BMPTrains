namespace BMPTrains_2020
{
    partial class frmTableViewer2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wbReport = new System.Windows.Forms.WebBrowser();
            this.lblRow = new System.Windows.Forms.Label();
            this.tbRow = new System.Windows.Forms.TextBox();
            this.btnRow = new System.Windows.Forms.Button();
            this.btnColumn = new System.Windows.Forms.Button();
            this.tbColumn = new System.Windows.Forms.TextBox();
            this.lblColumn = new System.Windows.Forms.Label();
            this.btnTable = new System.Windows.Forms.Button();
            this.tbTable = new System.Windows.Forms.TextBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1023, 29);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(55, 25);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.exitToolStripMenuItem.Text = "&Back";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // wbReport
            // 
            this.wbReport.Location = new System.Drawing.Point(12, 78);
            this.wbReport.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbReport.Name = "wbReport";
            this.wbReport.Size = new System.Drawing.Size(997, 440);
            this.wbReport.TabIndex = 3;
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(12, 40);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(113, 30);
            this.lblRow.TabIndex = 4;
            this.lblRow.Text = "Row Value:";
            // 
            // tbRow
            // 
            this.tbRow.Location = new System.Drawing.Point(120, 37);
            this.tbRow.Name = "tbRow";
            this.tbRow.Size = new System.Drawing.Size(88, 35);
            this.tbRow.TabIndex = 5;
            // 
            // btnRow
            // 
            this.btnRow.Location = new System.Drawing.Point(214, 38);
            this.btnRow.Name = "btnRow";
            this.btnRow.Size = new System.Drawing.Size(75, 34);
            this.btnRow.TabIndex = 6;
            this.btnRow.Text = "Find";
            this.btnRow.UseVisualStyleBackColor = true;
            this.btnRow.Click += new System.EventHandler(this.btnRow_Click);
            // 
            // btnColumn
            // 
            this.btnColumn.Location = new System.Drawing.Point(567, 37);
            this.btnColumn.Name = "btnColumn";
            this.btnColumn.Size = new System.Drawing.Size(75, 34);
            this.btnColumn.TabIndex = 9;
            this.btnColumn.Text = "Find";
            this.btnColumn.UseVisualStyleBackColor = true;
            this.btnColumn.Click += new System.EventHandler(this.btnColumn_Click);
            // 
            // tbColumn
            // 
            this.tbColumn.Location = new System.Drawing.Point(473, 37);
            this.tbColumn.Name = "tbColumn";
            this.tbColumn.Size = new System.Drawing.Size(88, 35);
            this.tbColumn.TabIndex = 8;
            // 
            // lblColumn
            // 
            this.lblColumn.AutoSize = true;
            this.lblColumn.Location = new System.Drawing.Point(333, 40);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(146, 30);
            this.lblColumn.TabIndex = 7;
            this.lblColumn.Text = "Column Value:";
            // 
            // btnTable
            // 
            this.btnTable.Location = new System.Drawing.Point(917, 37);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(75, 34);
            this.btnTable.TabIndex = 12;
            this.btnTable.Text = "Find";
            this.btnTable.UseVisualStyleBackColor = true;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // tbTable
            // 
            this.tbTable.Location = new System.Drawing.Point(820, 37);
            this.tbTable.Name = "tbTable";
            this.tbTable.Size = new System.Drawing.Size(88, 35);
            this.tbTable.TabIndex = 11;
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(692, 39);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(122, 30);
            this.lblTable.TabIndex = 10;
            this.lblTable.Text = "Table Value:";
            // 
            // frmTableViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 530);
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
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmTableViewer";
            this.Text = "Table Viewer";
            this.Load += new System.EventHandler(this.frmTableViewer_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.WebBrowser wbReport;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.TextBox tbRow;
        private System.Windows.Forms.Button btnRow;
        private System.Windows.Forms.Button btnColumn;
        private System.Windows.Forms.TextBox tbColumn;
        private System.Windows.Forms.Label lblColumn;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.TextBox tbTable;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}