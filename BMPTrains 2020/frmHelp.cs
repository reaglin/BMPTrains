using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    
    public partial class frmHelp : Form
    {
        public string url;
        public frmHelp()
        {
            InitializeComponent();
        }

        public frmHelp(string _url)
        {
            InitializeComponent();
            url = "http://roneaglin.online/bmptrains/help/";
            Uri uri = new Uri(url);
            wbReport.Url = uri;
        }

        private void frmHelp_Load(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wbReport.Print();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DomainCode.Common.OpenURL(url);
        }
    }
}
