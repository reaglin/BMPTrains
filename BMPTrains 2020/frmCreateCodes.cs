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
    public partial class frmCreateCodes : Form
    {
        public frmCreateCodes()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string[] EmailArray = tbEmails.Lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
            tbCodes.Text = string.Join(Environment.NewLine, EmailArray.Select(email => "E-Mail: "+ email + "  Code: " + Globals.GenerateCodeFromEmail(email)));
        }
    }
}
