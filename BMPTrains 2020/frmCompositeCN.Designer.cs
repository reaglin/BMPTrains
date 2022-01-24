namespace BMPTrains_2020
{
    partial class frmCompositeCN
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cWC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCN = new System.Windows.Forms.Label();
            this.lblWC = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDCIA = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(583, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 50);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(583, 440);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(145, 50);
            this.btnExit.TabIndex = 49;
            this.btnExit.Text = "Back";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Area
            // 
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Area.DefaultCellStyle = dataGridViewCellStyle13;
            this.Area.HeaderText = "Area (ac)";
            this.Area.Name = "Area";
            this.Area.Width = 130;
            // 
            // CN
            // 
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CN.DefaultCellStyle = dataGridViewCellStyle14;
            this.CN.HeaderText = "CN";
            this.CN.Name = "CN";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cArea,
            this.cCN,
            this.cC,
            this.cWC});
            this.dataGridView1.Location = new System.Drawing.Point(10, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(562, 479);
            this.dataGridView1.TabIndex = 51;
            // 
            // cArea
            // 
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cArea.DefaultCellStyle = dataGridViewCellStyle15;
            this.cArea.HeaderText = "Area (ac)";
            this.cArea.Name = "cArea";
            this.cArea.Width = 130;
            // 
            // cCN
            // 
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cCN.DefaultCellStyle = dataGridViewCellStyle16;
            this.cCN.HeaderText = "CN";
            this.cCN.Name = "cCN";
            // 
            // cC
            // 
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cC.DefaultCellStyle = dataGridViewCellStyle17;
            this.cC.HeaderText = "C";
            this.cC.Name = "cC";
            this.cC.ReadOnly = true;
            // 
            // cWC
            // 
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cWC.DefaultCellStyle = dataGridViewCellStyle18;
            this.cWC.HeaderText = "Weighted C";
            this.cWC.Name = "cWC";
            this.cWC.ReadOnly = true;
            this.cWC.Width = 150;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(583, 216);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(145, 50);
            this.btnCalculate.TabIndex = 52;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(581, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 30);
            this.label1.TabIndex = 53;
            this.label1.Text = "Composite CN";
            // 
            // lblCN
            // 
            this.lblCN.AutoSize = true;
            this.lblCN.Location = new System.Drawing.Point(624, 181);
            this.lblCN.Name = "lblCN";
            this.lblCN.Size = new System.Drawing.Size(51, 30);
            this.lblCN.TabIndex = 54;
            this.lblCN.Text = "0.00";
            // 
            // lblWC
            // 
            this.lblWC.AutoSize = true;
            this.lblWC.Location = new System.Drawing.Point(621, 40);
            this.lblWC.Name = "lblWC";
            this.lblWC.Size = new System.Drawing.Size(51, 30);
            this.lblWC.TabIndex = 56;
            this.lblWC.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(578, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 30);
            this.label3.TabIndex = 55;
            this.label3.Text = "Avg Weighted C";
            // 
            // lblDCIA
            // 
            this.lblDCIA.AutoSize = true;
            this.lblDCIA.Location = new System.Drawing.Point(621, 112);
            this.lblDCIA.Name = "lblDCIA";
            this.lblDCIA.Size = new System.Drawing.Size(51, 30);
            this.lblDCIA.TabIndex = 58;
            this.lblDCIA.Text = "0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(592, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 30);
            this.label4.TabIndex = 57;
            this.label4.Text = "DCIA Percent";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(583, 272);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(145, 50);
            this.btnCopy.TabIndex = 59;
            this.btnCopy.Text = "Copy";
            this.toolTip1.SetToolTip(this.btnCopy, "Copies Data into Spreadsheet format ");
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(583, 328);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(145, 50);
            this.btnPaste.TabIndex = 60;
            this.btnPaste.Text = "Paste";
            this.toolTip1.SetToolTip(this.btnPaste, "Pastes values from Excel into Form");
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // frmCompositeCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 502);
            this.ControlBox = false;
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lblDCIA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCompositeCN";
            this.Text = "Composite CN Calculator - Enter Area and CN (for Impervious Area CN = 95)";
            this.Load += new System.EventHandler(this.frmCompositeCN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn CN;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn cC;
        private System.Windows.Forms.DataGridViewTextBoxColumn cWC;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCN;
        private System.Windows.Forms.Label lblWC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDCIA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}