namespace BMPTrains_2020
{
    partial class frmCreateCodes
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
            this.tbEmails = new System.Windows.Forms.TextBox();
            this.tbCodes = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbEmails
            // 
            this.tbEmails.Location = new System.Drawing.Point(12, 21);
            this.tbEmails.Multiline = true;
            this.tbEmails.Name = "tbEmails";
            this.tbEmails.Size = new System.Drawing.Size(254, 397);
            this.tbEmails.TabIndex = 0;
            // 
            // tbCodes
            // 
            this.tbCodes.Location = new System.Drawing.Point(401, 21);
            this.tbCodes.Multiline = true;
            this.tbCodes.Name = "tbCodes";
            this.tbCodes.Size = new System.Drawing.Size(254, 397);
            this.tbCodes.TabIndex = 1;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(284, 163);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(89, 40);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 431);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Paste List of Emails Into Left Textbox and click generate to generate codes.";
            // 
            // frmCreateCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 462);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.tbCodes);
            this.Controls.Add(this.tbEmails);
            this.Name = "frmCreateCodes";
            this.Text = "Create Codes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbEmails;
        private System.Windows.Forms.TextBox tbCodes;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label1;
    }
}