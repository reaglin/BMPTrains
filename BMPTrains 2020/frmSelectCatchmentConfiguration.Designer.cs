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
            this.btnFlowBalance = new System.Windows.Forms.Button();
            this.btnRetention = new System.Windows.Forms.Button();
            this.btnDetention = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBasic = new System.Windows.Forms.Button();
            this.btnRetentionReport = new System.Windows.Forms.Button();
            this.btnDetentionReport = new System.Windows.Forms.Button();
            this.lblRouting = new System.Windows.Forms.Label();
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
            this.cbOptions.Size = new System.Drawing.Size(768, 38);
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
            this.btnSelect.Location = new System.Drawing.Point(792, 6);
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
            this.btnAddCatchment.Location = new System.Drawing.Point(729, 51);
            this.btnAddCatchment.Name = "btnAddCatchment";
            this.btnAddCatchment.Size = new System.Drawing.Size(171, 42);
            this.btnAddCatchment.TabIndex = 10;
            this.btnAddCatchment.Text = "Add Catchment";
            this.toolTip1.SetToolTip(this.btnAddCatchment, "Goes to Watershed Characteristic Worksheet");
            this.btnAddCatchment.UseVisualStyleBackColor = true;
            this.btnAddCatchment.Click += new System.EventHandler(this.btnAddCatchment_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(771, 306);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(141, 42);
            this.btnReport.TabIndex = 11;
            this.btnReport.Text = "Full Routing";
            this.toolTip1.SetToolTip(this.btnReport, "This report is a full balance and removal for all catchments in the configuration" +
        ".");
            this.btnReport.UseVisualStyleBackColor = true;
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
            // btnFlowBalance
            // 
            this.btnFlowBalance.Location = new System.Drawing.Point(613, 306);
            this.btnFlowBalance.Name = "btnFlowBalance";
            this.btnFlowBalance.Size = new System.Drawing.Size(141, 42);
            this.btnFlowBalance.TabIndex = 46;
            this.btnFlowBalance.Text = "Flow Balance";
            this.toolTip1.SetToolTip(this.btnFlowBalance, "This report shows the flows into and out of each routing.");
            this.btnFlowBalance.UseVisualStyleBackColor = true;
            this.btnFlowBalance.Click += new System.EventHandler(this.btnFlowBalance_Click);
            // 
            // btnRetention
            // 
            this.btnRetention.Location = new System.Drawing.Point(631, 177);
            this.btnRetention.Name = "btnRetention";
            this.btnRetention.Size = new System.Drawing.Size(255, 42);
            this.btnRetention.TabIndex = 48;
            this.btnRetention.Text = "Retention in Series";
            this.toolTip1.SetToolTip(this.btnRetention, "Shows the calculations for retention systems in series.");
            this.btnRetention.UseVisualStyleBackColor = true;
            this.btnRetention.Click += new System.EventHandler(this.btn_Retention_Click);
            // 
            // btnDetention
            // 
            this.btnDetention.Location = new System.Drawing.Point(631, 228);
            this.btnDetention.Name = "btnDetention";
            this.btnDetention.Size = new System.Drawing.Size(255, 42);
            this.btnDetention.TabIndex = 49;
            this.btnDetention.Text = "Detention in Series";
            this.toolTip1.SetToolTip(this.btnDetention, "Goes to Watershed Characteristic Worksheet");
            this.btnDetention.UseVisualStyleBackColor = true;
            this.btnDetention.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(608, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 42);
            this.label4.TabIndex = 45;
            this.label4.Text = "0 is Outlet";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(689, 273);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 30);
            this.label1.TabIndex = 47;
            this.label1.Text = "Report Options";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(673, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 30);
            this.label3.TabIndex = 50;
            this.label3.Text = "Calculation Options";
            // 
            // btnBasic
            // 
            this.btnBasic.Location = new System.Drawing.Point(631, 129);
            this.btnBasic.Name = "btnBasic";
            this.btnBasic.Size = new System.Drawing.Size(255, 42);
            this.btnBasic.TabIndex = 51;
            this.btnBasic.Text = "Basic Routing";
            this.toolTip1.SetToolTip(this.btnBasic, "Each Catchment is calculated independently");
            this.btnBasic.UseVisualStyleBackColor = true;
            this.btnBasic.Click += new System.EventHandler(this.btnBasic_Click);
            // 
            // btnRetentionReport
            // 
            this.btnRetentionReport.Location = new System.Drawing.Point(613, 354);
            this.btnRetentionReport.Name = "btnRetentionReport";
            this.btnRetentionReport.Size = new System.Drawing.Size(141, 42);
            this.btnRetentionReport.TabIndex = 52;
            this.btnRetentionReport.Text = "Retention";
            this.toolTip1.SetToolTip(this.btnRetentionReport, "Only available for retention in series calculations");
            this.btnRetentionReport.UseVisualStyleBackColor = true;
            this.btnRetentionReport.Click += new System.EventHandler(this.btnRetentionReport_Click);
            // 
            // btnDetentionReport
            // 
            this.btnDetentionReport.Location = new System.Drawing.Point(772, 354);
            this.btnDetentionReport.Name = "btnDetentionReport";
            this.btnDetentionReport.Size = new System.Drawing.Size(141, 42);
            this.btnDetentionReport.TabIndex = 53;
            this.btnDetentionReport.Text = "Detention";
            this.toolTip1.SetToolTip(this.btnDetentionReport, "Only available for Detention in Series Calculations");
            this.btnDetentionReport.UseVisualStyleBackColor = true;
            this.btnDetentionReport.Click += new System.EventHandler(this.btnDetentionReport_Click);
            // 
            // lblRouting
            // 
            this.lblRouting.AutoSize = true;
            this.lblRouting.Location = new System.Drawing.Point(625, 405);
            this.lblRouting.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRouting.Name = "lblRouting";
            this.lblRouting.Size = new System.Drawing.Size(85, 30);
            this.lblRouting.TabIndex = 54;
            this.lblRouting.Text = "Routing";
            // 
            // frmSelectCatchmentConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 519);
            this.ControlBox = false;
            this.Controls.Add(this.lblRouting);
            this.Controls.Add(this.btnDetentionReport);
            this.Controls.Add(this.btnRetentionReport);
            this.Controls.Add(this.btnBasic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDetention);
            this.Controls.Add(this.btnRetention);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFlowBalance);
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
        private System.Windows.Forms.Button btnFlowBalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRetention;
        private System.Windows.Forms.Button btnDetention;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBasic;
        private System.Windows.Forms.Button btnRetentionReport;
        private System.Windows.Forms.Button btnDetentionReport;
        private System.Windows.Forms.Label lblRouting;
    }
}