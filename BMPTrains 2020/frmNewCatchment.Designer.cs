namespace BMPTrains_2020
{
    partial class frmNewCatchment
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateNewBlank = new System.Windows.Forms.Button();
            this.btnCreateCopy = new System.Windows.Forms.Button();
            this.btnCreateSum = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbC2 = new System.Windows.Forms.ComboBox();
            this.cbC1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(673, 30);
            this.label1.TabIndex = 26;
            this.label1.Text = "Create a new catchment by copying a catchment and associated BMP\'s";
            // 
            // cbTo
            // 
            this.cbTo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTo.FormattingEnabled = true;
            this.cbTo.Location = new System.Drawing.Point(377, 124);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(245, 38);
            this.cbTo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 30);
            this.label2.TabIndex = 27;
            this.label2.Text = "Create a new blank Catchment";
            // 
            // btnCreateNewBlank
            // 
            this.btnCreateNewBlank.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateNewBlank.Location = new System.Drawing.Point(644, 17);
            this.btnCreateNewBlank.Name = "btnCreateNewBlank";
            this.btnCreateNewBlank.Size = new System.Drawing.Size(87, 39);
            this.btnCreateNewBlank.TabIndex = 1;
            this.btnCreateNewBlank.Text = "Create";
            this.btnCreateNewBlank.UseVisualStyleBackColor = true;
            this.btnCreateNewBlank.Click += new System.EventHandler(this.btnCreateNewBlank_Click);
            // 
            // btnCreateCopy
            // 
            this.btnCreateCopy.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateCopy.Location = new System.Drawing.Point(644, 124);
            this.btnCreateCopy.Name = "btnCreateCopy";
            this.btnCreateCopy.Size = new System.Drawing.Size(87, 39);
            this.btnCreateCopy.TabIndex = 3;
            this.btnCreateCopy.Text = "Create";
            this.btnCreateCopy.UseVisualStyleBackColor = true;
            this.btnCreateCopy.Click += new System.EventHandler(this.btnCreateCopy_Click);
            // 
            // btnCreateSum
            // 
            this.btnCreateSum.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateSum.Location = new System.Drawing.Point(644, 224);
            this.btnCreateSum.Name = "btnCreateSum";
            this.btnCreateSum.Size = new System.Drawing.Size(87, 39);
            this.btnCreateSum.TabIndex = 6;
            this.btnCreateSum.Text = "Create";
            this.btnCreateSum.UseVisualStyleBackColor = true;
            this.btnCreateSum.Click += new System.EventHandler(this.btnCreateSum_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(740, 30);
            this.label3.TabIndex = 33;
            this.label3.Text = "Create a new catchment by adding 2 catchments (adds areas, averages values)";
            // 
            // cbC2
            // 
            this.cbC2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbC2.FormattingEnabled = true;
            this.cbC2.Location = new System.Drawing.Point(377, 225);
            this.cbC2.Name = "cbC2";
            this.cbC2.Size = new System.Drawing.Size(245, 38);
            this.cbC2.TabIndex = 5;
            // 
            // cbC1
            // 
            this.cbC1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbC1.FormattingEnabled = true;
            this.cbC1.Location = new System.Drawing.Point(82, 225);
            this.cbC1.Name = "cbC1";
            this.cbC1.Size = new System.Drawing.Size(245, 38);
            this.cbC1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 30);
            this.label4.TabIndex = 36;
            this.label4.Text = "+";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(644, 280);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(87, 39);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmNewCatchment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 331);
            this.ControlBox = false;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbC1);
            this.Controls.Add(this.btnCreateSum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbC2);
            this.Controls.Add(this.btnCreateCopy);
            this.Controls.Add(this.btnCreateNewBlank);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTo);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewCatchment";
            this.Text = "Create New Catchment";
            this.Load += new System.EventHandler(this.frmNewCatchment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateNewBlank;
        private System.Windows.Forms.Button btnCreateCopy;
        private System.Windows.Forms.Button btnCreateSum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbC2;
        private System.Windows.Forms.ComboBox cbC1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBack;
    }
}