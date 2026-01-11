using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BMPTrains_2020.DomainCode;
namespace BMPTrains_2020
{
    
    public partial class frmOpenFile : Form
    {
        GeneralSiteInformation parent;
        public frmOpenFile(GeneralSiteInformation frm)
        {
            InitializeComponent();
            parent = frm;

        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            parent.btnPre_Click(sender, e);
            this.Close();
            //OpenFileDialog dlg = new OpenFileDialog();
            //dlg.InitialDirectory = Common.WorkingDirectory();

            //dlg.Filter = "BMP Trains files (*.bmpt)|*.bmpt";

            //BMPTrainsProject pre = new BMPTrainsProject();
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{

            //    DialogResult dialogResult = MessageBox.Show("This will set all pre-condition catchment values equal to the pre-condition values from the selected file. It will replace all existing pre-condition data, continue?", "Use Existing Pre-Condition Values", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (dialogResult != DialogResult.Yes)
            //    {
            //        return;
            //    }

            //    string fileName = dlg.FileName;
            //    string res = pre.openFromFile(fileName);
            //    if (res == "")
            //    {
            //        pre.FileName = fileName;
            //        pre.Calculate();
            //        Globals.Project.getValuesFromPreDevelopment(pre);
            //        parent.lblN.Text = "Existing N Discharge (kg/yr)";
            //        lblP.Text = "Existing P Discharge (kg/yr)";
            //        tbN.Text = Globals.Project.TargetNMassLoad.ToString("##.##");
            //        tbP.Text = Globals.Project.TargetPMassLoad.ToString("##.###");

            //    }
            //    else
            //    {
            //        MessageBox.Show(res);
            //        return;
            //    }
            //}

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            parent.btnOpen_Click(sender, e);
            this.Close();
            //OpenFileDialog dlg = new OpenFileDialog();
            //dlg.InitialDirectory = Common.WorkingDirectory();

            //dlg.Filter = "BMP Trains files (*.bmpt)|*.bmpt";

            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    string fileName = dlg.FileName;
            //    OpenFile(fileName);
            //    Globals.Project.Calculate();
            //}
        }

        private void OpenFile(string filename)
        {

            string res = Globals.Project.openFromFile(filename);
            if (res == "")
            {
                Globals.Project.FileName = filename;
            }
            else
            {
                MessageBox.Show(res);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOpenFile_Load(object sender, EventArgs e)
        {
            FileList fl = new FileList();
            fl.FillListBox(lbFiles);
        }

        private void lbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbFiles_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                // Double Click to Open a File
                string filename = FileList.GetFullPathFromListBox(lbFiles); 
                parent.OpenFile(filename);
                this.UseWaitCursor = false;
                this.Close();
            }
            catch
            {
                this.UseWaitCursor = false;
                MessageBox.Show("File Not Found");
            }
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            string s = Globals.Project.PrintAll();
            s += Globals.Project.PrintAllCatchments();

            Form form = new frmReport(s);
            this.UseWaitCursor = false;
            form.ShowDialog();
        }
    }
}
