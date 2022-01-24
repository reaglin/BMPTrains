namespace BMPTrains_2020
{
    partial class frmSelectCatchmentConfiguration
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
            this.cbOptions = new System.Windows.Forms.ComboBox();
            this.pbOptions = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddCatchment = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbOptions
            // 
            this.cbOptions.FormattingEnabled = true;
            this.cbOptions.Location = new System.Drawing.Point(15, 9);
            this.cbOptions.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbOptions.Name = "cbOptions";
            this.cbOptions.Size = new System.Drawing.Size(736, 38);
            this.cbOptions.TabIndex = 5;
            this.cbOptions.Visible = false;
            this.cbOptions.SelectedIndexChanged += new System.EventHandler(this.cbOptions_SelectedIndexChanged);
            // 
            // pbOptions
            // 
            this.pbOptions.BackColor = System.Drawing.Color.White;
            this.pbOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbOptions.Location = new System.Drawing.Point(631, 465);
            this.pbOptions.Margin = new System.Windows.Forms.Padding(12, 16, 12, 16);
            this.pbOptions.Name = "pbOptions";
            this.pbOptions.Size = new System.Drawing.Size(46, 33);
            this.pbOptions.TabIndex = 3;
            this.pbOptions.TabStop = false;
            this.pbOptions.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(697, 456);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(171, 42);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Back";
            this.toolTip1.SetToolTip(this.btnSave, "Exit the Current Worksheet");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(760, 6);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(108, 42);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Text = "Select";
            this.toolTip1.SetToolTip(this.btnSelect, "This will create the Catchments and routing for the selected configuration.");
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Visible = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(583, 429);
            this.dataGridView1.TabIndex = 9;
            // 
            // btnAddCatchment
            // 
            this.btnAddCatchment.Location = new System.Drawing.Point(613, 382);
            this.btnAddCatchment.Name = "btnAddCatchment";
            this.btnAddCatchment.Size = new System.Drawing.Size(255, 42);
            this.btnAddCatchment.TabIndex = 10;
            this.btnAddCatchment.Text = "Add Catchment";
            this.toolTip1.SetToolTip(this.btnAddCatchment, "Goes to Watershed Characteristic Worksheet");
            this.btnAddCatchment.UseVisualStyleBackColor = true;
            this.btnAddCatchment.Click += new System.EventHandler(this.btnAddCatchment_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(613, 323);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(255, 42);
            this.btnReport.TabIndex = 11;
            this.btnReport.Text = "Full Routing Report";
            this.toolTip1.SetToolTip(this.btnReport, "This report is a full balance and removal for all catchments in the configuration" +
        ".");
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 438);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(598, 60);
            this.label2.TabIndex = 12;
            this.label2.Text = "By using existing and adding new Catchments create a routing \r\nconfiguration. Spe" +
    "cify default BMP to be used.";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(608, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 162);
            this.label4.TabIndex = 45;
            this.label4.Text = "\r\n0 is Outlet";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // frmSelectCatchmentConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 519);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnAddCatchment);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbOptions);
            this.Controls.Add(this.pbOptions);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmSelectCatchmentConfiguration";
            this.Text = "Select Catchment Configuration";
            this.Load += new System.EventHandler(this.frmSelectCatchmentConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbOptions;
        private System.Windows.Forms.PictureBox pbOptions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddCatchment;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
    }
}