namespace BMPTrains_2020
{
    partial class FormMeanAnnualRainfall
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
            this.btnAll = new System.Windows.Forms.Button();
            this.btnNW = new System.Windows.Forms.Button();
            this.btnCentral = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNE = new System.Windows.Forms.Button();
            this.btnZones = new System.Windows.Forms.Button();
            this.pbState = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbState)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(12, 3);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(112, 30);
            this.btnAll.TabIndex = 0;
            this.btnAll.Text = "Entire State";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnNW
            // 
            this.btnNW.Location = new System.Drawing.Point(130, 3);
            this.btnNW.Name = "btnNW";
            this.btnNW.Size = new System.Drawing.Size(112, 30);
            this.btnNW.TabIndex = 1;
            this.btnNW.Text = "Northwest";
            this.btnNW.UseVisualStyleBackColor = true;
            this.btnNW.Click += new System.EventHandler(this.btnNW_Click);
            // 
            // btnCentral
            // 
            this.btnCentral.Location = new System.Drawing.Point(366, 3);
            this.btnCentral.Name = "btnCentral";
            this.btnCentral.Size = new System.Drawing.Size(112, 30);
            this.btnCentral.TabIndex = 3;
            this.btnCentral.Text = "Central";
            this.btnCentral.UseVisualStyleBackColor = true;
            this.btnCentral.Click += new System.EventHandler(this.btnCentral_Click);
            // 
            // btnSouth
            // 
            this.btnSouth.Location = new System.Drawing.Point(484, 3);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(112, 30);
            this.btnSouth.TabIndex = 4;
            this.btnSouth.Text = "South";
            this.btnSouth.UseVisualStyleBackColor = true;
            this.btnSouth.Click += new System.EventHandler(this.btnSouth_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(722, 3);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(112, 30);
            this.btnInfo.TabIndex = 5;
            this.btnInfo.Text = "Recent Data";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(848, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 30);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Back";
            this.toolTip1.SetToolTip(this.btnExit, "Exit the Current Worksheet");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNE
            // 
            this.btnNE.Location = new System.Drawing.Point(248, 3);
            this.btnNE.Name = "btnNE";
            this.btnNE.Size = new System.Drawing.Size(112, 30);
            this.btnNE.TabIndex = 8;
            this.btnNE.Text = "Northeast";
            this.btnNE.UseVisualStyleBackColor = true;
            this.btnNE.Click += new System.EventHandler(this.btnNE_Click_1);
            // 
            // btnZones
            // 
            this.btnZones.Location = new System.Drawing.Point(602, 3);
            this.btnZones.Name = "btnZones";
            this.btnZones.Size = new System.Drawing.Size(112, 30);
            this.btnZones.TabIndex = 9;
            this.btnZones.Text = "Zones";
            this.btnZones.UseVisualStyleBackColor = true;
            this.btnZones.Click += new System.EventHandler(this.btnZones_Click);
            // 
            // pbState
            // 
            this.pbState.Image = global::BMPTrains_2020.Properties.Resources.RainfallMapOverall;
            this.pbState.Location = new System.Drawing.Point(14, 39);
            this.pbState.Name = "pbState";
            this.pbState.Size = new System.Drawing.Size(946, 693);
            this.pbState.TabIndex = 7;
            this.pbState.TabStop = false;
            // 
            // FormMeanAnnualRainfall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(973, 736);
            this.ControlBox = false;
            this.Controls.Add(this.btnZones);
            this.Controls.Add(this.btnNE);
            this.Controls.Add(this.pbState);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnCentral);
            this.Controls.Add(this.btnNW);
            this.Controls.Add(this.btnAll);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMeanAnnualRainfall";
            this.Text = "Meteorological Zones and Mean Annual Rainfall Map";
            ((System.ComponentModel.ISupportInitialize)(this.pbState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnNW;
        private System.Windows.Forms.Button btnCentral;
        private System.Windows.Forms.Button btnSouth;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pbState;
        private System.Windows.Forms.Button btnNE;
        private System.Windows.Forms.Button btnZones;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}