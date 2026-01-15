namespace BMPTrains_2020
{
    partial class frmExfiltrationCalculator
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPipeSpan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPipeRise = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPipeLength = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTrenchLength = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTrenchDepth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTrenchWidth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbVoidRatio = new System.Windows.Forms.TextBox();
            this.wbOutput = new System.Windows.Forms.WebBrowser();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(664, 299);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 39);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Back";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(664, 190);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(112, 39);
            this.btnCalculate.TabIndex = 9;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.CausesValidation = false;
            this.label2.Location = new System.Drawing.Point(22, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 30);
            this.label2.TabIndex = 22;
            this.label2.Text = "Pipe Span (in):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbPipeSpan
            // 
            this.tbPipeSpan.Location = new System.Drawing.Point(217, 9);
            this.tbPipeSpan.Name = "tbPipeSpan";
            this.tbPipeSpan.Size = new System.Drawing.Size(89, 35);
            this.tbPipeSpan.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.CausesValidation = false;
            this.label1.Location = new System.Drawing.Point(22, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 30);
            this.label1.TabIndex = 24;
            this.label1.Text = "Pipe Rise (in):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbPipeRise
            // 
            this.tbPipeRise.Location = new System.Drawing.Point(217, 50);
            this.tbPipeRise.Name = "tbPipeRise";
            this.tbPipeRise.Size = new System.Drawing.Size(89, 35);
            this.tbPipeRise.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.CausesValidation = false;
            this.label3.Location = new System.Drawing.Point(22, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 30);
            this.label3.TabIndex = 26;
            this.label3.Text = "Pipe Length (ft):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbPipeLength
            // 
            this.tbPipeLength.Location = new System.Drawing.Point(217, 91);
            this.tbPipeLength.Name = "tbPipeLength";
            this.tbPipeLength.Size = new System.Drawing.Size(89, 35);
            this.tbPipeLength.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.CausesValidation = false;
            this.label4.Location = new System.Drawing.Point(358, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 30);
            this.label4.TabIndex = 32;
            this.label4.Text = "Trench Length (ft):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbTrenchLength
            // 
            this.tbTrenchLength.Location = new System.Drawing.Point(553, 91);
            this.tbTrenchLength.Name = "tbTrenchLength";
            this.tbTrenchLength.Size = new System.Drawing.Size(89, 35);
            this.tbTrenchLength.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.CausesValidation = false;
            this.label5.Location = new System.Drawing.Point(358, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 30);
            this.label5.TabIndex = 30;
            this.label5.Text = "Trench Depth (ft):";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbTrenchDepth
            // 
            this.tbTrenchDepth.Location = new System.Drawing.Point(553, 50);
            this.tbTrenchDepth.Name = "tbTrenchDepth";
            this.tbTrenchDepth.Size = new System.Drawing.Size(89, 35);
            this.tbTrenchDepth.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.CausesValidation = false;
            this.label6.Location = new System.Drawing.Point(358, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 30);
            this.label6.TabIndex = 28;
            this.label6.Text = "Trench Width (ft):";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbTrenchWidth
            // 
            this.tbTrenchWidth.Location = new System.Drawing.Point(553, 9);
            this.tbTrenchWidth.Name = "tbTrenchWidth";
            this.tbTrenchWidth.Size = new System.Drawing.Size(89, 35);
            this.tbTrenchWidth.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.CausesValidation = false;
            this.label7.Location = new System.Drawing.Point(312, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(234, 30);
            this.label7.TabIndex = 34;
            this.label7.Text = "Aggregate Void %:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbVoidRatio
            // 
            this.tbVoidRatio.Location = new System.Drawing.Point(553, 132);
            this.tbVoidRatio.Name = "tbVoidRatio";
            this.tbVoidRatio.Size = new System.Drawing.Size(89, 35);
            this.tbVoidRatio.TabIndex = 33;
            // 
            // wbOutput
            // 
            this.wbOutput.Location = new System.Drawing.Point(27, 190);
            this.wbOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOutput.Name = "wbOutput";
            this.wbOutput.Size = new System.Drawing.Size(615, 149);
            this.wbOutput.TabIndex = 35;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(664, 245);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 39);
            this.btnPrint.TabIndex = 36;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmExfiltrationCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 351);
            this.ControlBox = false;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.wbOutput);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbVoidRatio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTrenchLength);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbTrenchDepth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbTrenchWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPipeLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPipeRise);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPipeSpan);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmExfiltrationCalculator";
            this.Text = "Exfiltration Calculator";
            this.Load += new System.EventHandler(this.frmExfiltrationCalculator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPipeSpan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPipeRise;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPipeLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTrenchLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTrenchDepth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTrenchWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbVoidRatio;
        private System.Windows.Forms.WebBrowser wbOutput;
        private System.Windows.Forms.Button btnPrint;
    }
}