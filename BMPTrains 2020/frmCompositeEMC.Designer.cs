namespace BMPTrains_2020
{
    partial class frmCompositeEMC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEMC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnCancel.Location = new System.Drawing.Point(730, 405);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 50);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(730, 461);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(145, 50);
            this.btnExit.TabIndex = 49;
            this.btnExit.Text = "Back";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Area
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Area.DefaultCellStyle = dataGridViewCellStyle7;
            this.Area.HeaderText = "Area (ac)";
            this.Area.Name = "Area";
            this.Area.Width = 130;
            // 
            // CN
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CN.DefaultCellStyle = dataGridViewCellStyle8;
            this.CN.HeaderText = "CN";
            this.CN.Name = "CN";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cArea,
            this.cEMC,
            this.CCN,
            this.cC,
            this.cWC});
            this.dataGridView1.Location = new System.Drawing.Point(10, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(678, 501);
            this.dataGridView1.TabIndex = 51;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cArea
            // 
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cArea.DefaultCellStyle = dataGridViewCellStyle9;
            this.cArea.HeaderText = "Area (ac)";
            this.cArea.Name = "cArea";
            this.cArea.Width = 130;
            // 
            // cEMC
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cEMC.DefaultCellStyle = dataGridViewCellStyle10;
            this.cEMC.HeaderText = "EMC";
            this.cEMC.Name = "cEMC";
            // 
            // CCN
            // 
            this.CCN.HeaderText = "CN";
            this.CCN.Name = "CCN";
            // 
            // cC
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cC.DefaultCellStyle = dataGridViewCellStyle11;
            this.cC.HeaderText = "C";
            this.cC.Name = "cC";
            this.cC.ReadOnly = true;
            // 
            // cWC
            // 
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cWC.DefaultCellStyle = dataGridViewCellStyle12;
            this.cWC.HeaderText = "Weighted C";
            this.cWC.Name = "cWC";
            this.cWC.ReadOnly = true;
            this.cWC.Width = 150;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(730, 237);
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
            this.label1.Location = new System.Drawing.Point(728, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 30);
            this.label1.TabIndex = 53;
            this.label1.Text = "Composite EMC";
            // 
            // lblCN
            // 
            this.lblCN.AutoSize = true;
            this.lblCN.Location = new System.Drawing.Point(771, 183);
            this.lblCN.Name = "lblCN";
            this.lblCN.Size = new System.Drawing.Size(51, 30);
            this.lblCN.TabIndex = 54;
            this.lblCN.Text = "0.00";
            // 
            // lblWC
            // 
            this.lblWC.AutoSize = true;
            this.lblWC.Location = new System.Drawing.Point(768, 42);
            this.lblWC.Name = "lblWC";
            this.lblWC.Size = new System.Drawing.Size(51, 30);
            this.lblWC.TabIndex = 56;
            this.lblWC.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(725, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 30);
            this.label3.TabIndex = 55;
            this.label3.Text = "Avg Weighted C";
            // 
            // lblDCIA
            // 
            this.lblDCIA.AutoSize = true;
            this.lblDCIA.Location = new System.Drawing.Point(768, 114);
            this.lblDCIA.Name = "lblDCIA";
            this.lblDCIA.Size = new System.Drawing.Size(51, 30);
            this.lblDCIA.TabIndex = 58;
            this.lblDCIA.Text = "0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(739, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 30);
            this.label4.TabIndex = 57;
            this.label4.Text = "DCIA Percent";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(730, 293);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(145, 50);
            this.btnCopy.TabIndex = 59;
            this.btnCopy.Text = "Copy";
            this.toolTip1.SetToolTip(this.btnCopy, "Copies Data into Excel Format");
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(730, 349);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(145, 50);
            this.btnPaste.TabIndex = 61;
            this.btnPaste.Text = "Paste";
            this.toolTip1.SetToolTip(this.btnPaste, "Pastes data from Excel into Grid");
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // frmCompositeEMC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 523);
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
            this.Name = "frmCompositeEMC";
            this.Text = "Composite EMC Calculator - Enter Area, CN,  and EMC";
            this.Load += new System.EventHandler(this.frmCompositeEMC_Load);
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
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCN;
        private System.Windows.Forms.Label lblWC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDCIA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.DataGridViewTextBoxColumn cArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEMC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn cC;
        private System.Windows.Forms.DataGridViewTextBoxColumn cWC;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnPaste;
    }
}