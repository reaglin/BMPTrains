using BMPTrains_2020.DomainCode;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmRetentionInSeries : Form
    {
        private Label lblError;
        private Button btnSave;
        private WebBrowser wbOutput;
        private Button btnPrint;
        private Label label2;
        private string reportType;

        public frmRetentionInSeries(string report = "Retention")
        {
            reportType = "Retention";
            InitializeComponent();
            if (report == "Detention")
            {
                this.Text = "Detention in Series Worksheet";
                reportType = "Detention";
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRetentionInSeries));
            this.label2 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.wbOutput = new System.Windows.Forms.WebBrowser();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(759, 60);
            this.label2.TabIndex = 13;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(12, 630);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(70, 25);
            this.lblError.TabIndex = 14;
            this.lblError.Text = "label1";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(663, 621);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 42);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Back";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // wbOutput
            // 
            this.wbOutput.Location = new System.Drawing.Point(17, 72);
            this.wbOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOutput.Name = "wbOutput";
            this.wbOutput.Size = new System.Drawing.Size(757, 543);
            this.wbOutput.TabIndex = 16;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(544, 621);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(115, 42);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmRetentionInSeries
            // 
            this.ClientSize = new System.Drawing.Size(784, 675);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.wbOutput);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label2);
            this.Name = "frmRetentionInSeries";
            this.Text = "Retention in Series Worksheet";
            this.Load += new System.EventHandler(this.frmRetentionInSeries_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void frmRetentionInSeries_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (reportType == "Retention") { 
                if (!checkIfRetentionInSeries())
                {
                    lblError.Text = "Error: Not all catchments have retention BMPs selected.";
                    return;
                }
            }
            if (reportType == "Detention")
            {
                if (!checkIfDetentionInSeries())
                {
                    lblError.Text = "Error: Not all catchments have detention BMPs selected.";
                    return;
                }
            }

            string html = "";
            if (reportType == "Retention") html =Globals.Project.PrintRetentionInSeriesReport() ?? "";
            if (reportType == "Detention") html = Globals.Project.PrintDetentionInSeriesReport() ?? "";

            if (string.IsNullOrWhiteSpace(html))
            {
                lblError.Text = "No content to display.";
                return;
            }

            if (!html.TrimStart().StartsWith("<", StringComparison.Ordinal) || !html.Contains("X-UA-Compatible"))
            {
                html = "<html><head><meta http-equiv='X-UA-Compatible' content='IE=Edge'></head><body>" + html + "</body></html>";
            }

            // Ensure the underlying ActiveX host is created before we assign the document
            // (fixes timing issues that appeared when debug code forced creation).
            wbOutput.CreateControl();
            var _ = wbOutput.Handle; // extra assurance the control/host is created

            // optional: ensure visible and not covered
            wbOutput.Visible = true;
            wbOutput.BringToFront();
            // display
            wbOutput.DocumentText = html;
        }

        private bool checkIfRetentionInSeries()
        {
            for (int i = 1; i <= Globals.Project.numCatchments; i++)
            {
                Catchment c = Globals.Project.getCatchment(i);
                if (!c.getSelectedBMP().isRetention())
                {
                    return false;
                }
            }
            return true;
        }
        private bool checkIfDetentionInSeries()
        {
            for (int i = 1; i <= Globals.Project.numCatchments; i++)
            {
                Catchment c = Globals.Project.getCatchment(i);
                if (!c.getSelectedBMP().isDetention())
                {
                    return false;
                }
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            wbOutput.Print();
        }
    }
}
