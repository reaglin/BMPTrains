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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        public Splash(string[] args)
        {
            InitializeComponent();
            try
            {
                Globals.Project.FileName = Globals.Project.openFromFile(args[0]);
            }
            catch
            {
                // Do Nothing
            }
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            Form siteInfo = new GeneralSiteInformation();
            siteInfo.Show();

            this.Hide();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome to " + Globals.Project.Version();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
