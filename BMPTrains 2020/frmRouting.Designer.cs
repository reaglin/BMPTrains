namespace BMPTrains_2020
{
    partial class frmRouting
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
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBMP = new System.Windows.Forms.ComboBox();
            this.btnDisable = new System.Windows.Forms.Button();
            this.lblActive = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbDelayTime = new System.Windows.Forms.TextBox();
            this.btnBalance = new System.Windows.Forms.Button();
            this.btnEditBMP = new System.Windows.Forms.Button();
            this.lblDelay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFrom.Location = new System.Drawing.Point(103, 20);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(435, 25);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "label1";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFrom.Click += new System.EventHandler(this.lblFrom_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(557, 151);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(170, 39);
            this.btnHelp.TabIndex = 21;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(557, 202);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(170, 39);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Back";
            this.toolTip1.SetToolTip(this.btnClose, "Exit the Current Worksheet");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(557, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(170, 39);
            this.btnEdit.TabIndex = 22;
            this.btnEdit.Text = "Edit Catchment";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cbTo
            // 
            this.cbTo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTo.FormattingEnabled = true;
            this.cbTo.Location = new System.Drawing.Point(293, 57);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(245, 38);
            this.cbTo.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "Select Catchment to Route to:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "Select BMP to use in routing:";
            // 
            // cbBMP
            // 
            this.cbBMP.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBMP.FormattingEnabled = true;
            this.cbBMP.Location = new System.Drawing.Point(293, 104);
            this.cbBMP.Name = "cbBMP";
            this.cbBMP.Size = new System.Drawing.Size(245, 38);
            this.cbBMP.TabIndex = 25;
            // 
            // btnDisable
            // 
            this.btnDisable.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisable.Location = new System.Drawing.Point(293, 157);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(245, 39);
            this.btnDisable.TabIndex = 27;
            this.btnDisable.Text = "Disable Catchment";
            this.btnDisable.UseVisualStyleBackColor = true;
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(102, 165);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(159, 25);
            this.lblActive.TabIndex = 28;
            this.lblActive.Text = "Catchment Active";
            // 
            // tbDelayTime
            // 
            this.tbDelayTime.Location = new System.Drawing.Point(473, 207);
            this.tbDelayTime.Name = "tbDelayTime";
            this.tbDelayTime.Size = new System.Drawing.Size(64, 33);
            this.tbDelayTime.TabIndex = 31;
            this.toolTip1.SetToolTip(this.tbDelayTime, "Commingling Delay time only used if routing to Retention System.");
            // 
            // btnBalance
            // 
            this.btnBalance.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBalance.Location = new System.Drawing.Point(557, 259);
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.Size = new System.Drawing.Size(170, 39);
            this.btnBalance.TabIndex = 32;
            this.btnBalance.Text = "Flow Balance";
            this.toolTip1.SetToolTip(this.btnBalance, "Exit the Current Worksheet");
            this.btnBalance.UseVisualStyleBackColor = true;
            this.btnBalance.Visible = false;
            this.btnBalance.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEditBMP
            // 
            this.btnEditBMP.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditBMP.Location = new System.Drawing.Point(557, 103);
            this.btnEditBMP.Name = "btnEditBMP";
            this.btnEditBMP.Size = new System.Drawing.Size(170, 39);
            this.btnEditBMP.TabIndex = 29;
            this.btnEditBMP.Text = "Edit BMP";
            this.btnEditBMP.UseVisualStyleBackColor = true;
            this.btnEditBMP.Click += new System.EventHandler(this.btnEditBMP_Click);
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(323, 210);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(144, 25);
            this.lblDelay.TabIndex = 30;
            this.lblDelay.Text = "Delay Time (hr):";
            // 
            // frmRouting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 335);
            this.ControlBox = false;
            this.Controls.Add(this.btnBalance);
            this.Controls.Add(this.tbDelayTime);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.btnEditBMP);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.btnDisable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBMP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTo);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblFrom);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmRouting";
            this.Text = "Edit Routing";
            this.Load += new System.EventHandler(this.frmRouting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cbTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBMP;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnEditBMP;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.TextBox tbDelayTime;
        private System.Windows.Forms.Button btnBalance;
    }
}