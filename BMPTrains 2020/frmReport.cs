using BMPTrains_2020.DomainCode;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        public frmReport(string text, string reportHeader = "", string pageHeader = "")
        {
            InitializeComponent();


            string html = BMPTrains_2020.DomainCode.BMPTrainsReports.MasterReportHeader(text, reportHeader);
            wbReport.DocumentText = html;

            if (!string.IsNullOrWhiteSpace(pageHeader))
            {
                this.Text = pageHeader;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Globals.IsValidatedUser)
            {
                ShowRegistrationRequired();
                return;
            }

            wbReport.Print();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Globals.IsValidatedUser)
            {
                ShowRegistrationRequired();
                return;
            }

            Save();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void wbReport_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
        public void Save()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name

            savefile.InitialDirectory = Common.WorkingDirectory();

            savefile.FileName = "report.html";
            // set filters - this can be done in properties as well
            savefile.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                if (saveToFile(savefile.FileName))
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                    MessageBox.Show("File " + savefile.FileName + " Saved Successfully");
                }
                else
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                    MessageBox.Show("File " + savefile.FileName + " Error occurred in save");
                }
            }
        }
        public bool saveToFile(string filename)
        {            
            try
            {
                using (StreamWriter sw = new StreamWriter(filename))
                    sw.WriteLine(wbReport.Document.Body.Parent.OuterHtml);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BMPTrainsProject.OpenWebsite();
        }

        private void frmReport_Resize(object sender, EventArgs e)
        {
            wbReport.Width = this.Width - 20;
            wbReport.Height = this.Height - 60;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Globals.IsValidatedUser)
            {
                ShowRegistrationRequired();
                return;
            }

            this.wbReport.Document.ExecCommand("Copy", false, null);
        }

        private void copyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!Globals.IsValidatedUser)
            {
                ShowRegistrationRequired();
                return;
            }

            this.wbReport.Document.Focus();
            SendKeys.SendWait("^a");
            SendKeys.SendWait("^a^c");
            DialogResult dialogResult = MessageBox.Show("Report has been copied to the clipboard as HTML text", "Copy Report", MessageBoxButtons.OK);
        }

        public void setURL(string url)
        {
            wbReport.Navigate(url);
        }

        private void frmReport_Load(object sender, EventArgs e)
        {

        }

        // Helper to inform unregistered users
        private void ShowRegistrationRequired()
        {
            string msg = $"These features are only available to registered users. Visit {BMPTrainsProject.URL_Website} for more information";
            MessageBox.Show(msg, "Registered Users Only", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
