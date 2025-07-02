using BMPTrains_2020.DomainCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmMultipleBMP : Form
    {
        int currentCatchmentID = 1;
        public frmMultipleBMP(int id)
        {
            currentCatchmentID = id;
            InitializeComponent();
        }

        private void frmRetention_Load(object sender, EventArgs e)
        {
            // Add this to each object assigned to a Catchment, Implement MenuItemClickhandler
            InterfaceCommon.BuildCatchmentMenu(menuStrip1, MenuItemClickHandler);
            menuStrip1.Items[currentCatchmentID - 1].BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);

            List<string> l = currentCatchment().getAvailableBMPs();
            //l.Add("None");
            cbBMP1.Items.AddRange(l.ToArray());
            // First BMP cannot be Stormwater Harvesting
            //cbBMP1.Items.Remove(BMPTrainsProject.sStormwaterHarvesting);
        
            cbBMP2.Items.AddRange(l.ToArray());
            cbBMP3.Items.AddRange(l.ToArray());
            cbBMP4.Items.AddRange(l.ToArray());

            if (cbBMP1.Items.Contains(BMPTrainsProject.sMultipleBMP)) cbBMP1.Items.Remove(BMPTrainsProject.sMultipleBMP);
            if (cbBMP2.Items.Contains(BMPTrainsProject.sMultipleBMP)) cbBMP2.Items.Remove(BMPTrainsProject.sMultipleBMP);
            if (cbBMP3.Items.Contains(BMPTrainsProject.sMultipleBMP)) cbBMP3.Items.Remove(BMPTrainsProject.sMultipleBMP);
            if (cbBMP4.Items.Contains(BMPTrainsProject.sMultipleBMP)) cbBMP4.Items.Remove(BMPTrainsProject.sMultipleBMP);

            this.Text += " " + currentCatchmentID.ToString();

            currentCatchment().Calculate();

            setValues();
            Calculate();
            setOutputText();
        }

        private Catchment currentCatchment()
        {
            // Add this to each BMP edit form
            return Globals.Project.getCatchment(currentCatchmentID);
        }

        private MultipleBMP currentBMP()
        {
            // Add a custom version for each BMP edit form
            return currentCatchment().getMultipleBMP();
        }
        private void setOutputText()
        {
            // Add to each form
            wbOutput.DocumentText = currentBMP().getReport();
        }


        private void setValues()
        {
            FixWetDetention(); // Because I did not use a space the first time
            Common.setValue(cbBMP1, currentCatchment().BMP1);
            Common.setValue(cbBMP2, currentCatchment().BMP2);
            Common.setValue(cbBMP3, currentCatchment().BMP3);
            Common.setValue(cbBMP4, currentCatchment().BMP4);

            btnOpen1.Visible = isViewableBMP(currentCatchment().BMP1);
            btnOpen2.Visible = isViewableBMP(currentCatchment().BMP2);
            btnOpen3.Visible = isViewableBMP(currentCatchment().BMP3);
            btnOpen4.Visible = isViewableBMP(currentCatchment().BMP4);

            setOutputText();
        }

        private bool isViewableBMP(string name)
        {
            if (name == "None") return false;
            if (name == "") return false;
            return true;
        }

        private void getValues()
        {
            currentCatchment().setMultipleBMP(1, Common.getString(cbBMP1));
            currentCatchment().setMultipleBMP(2, Common.getString(cbBMP2));
            currentCatchment().setMultipleBMP(3, Common.getString(cbBMP3));
            currentCatchment().setMultipleBMP(4, Common.getString(cbBMP4));

            //if (Common.getString(cbBMP1) != BMPTrainsProject.sNone && Common.getString(cbBMP1) != "") currentCatchment().setMultipleBMP(1, Common.getString(cbBMP1));
            //if (Common.getString(cbBMP2) != BMPTrainsProject.sNone && Common.getString(cbBMP2) != "") currentCatchment().setMultipleBMP(2, Common.getString(cbBMP2));
            //if (Common.getString(cbBMP3) != BMPTrainsProject.sNone && Common.getString(cbBMP3) != "") currentCatchment().setMultipleBMP(3, Common.getString(cbBMP3));
            //if (Common.getString(cbBMP4) != BMPTrainsProject.sNone && Common.getString(cbBMP4) != "") currentCatchment().setMultipleBMP(4, Common.getString(cbBMP4));


            btnCalculate.Enabled = true;
            if (!ValidateBMP())
            {
                btnCalculate.Enabled = false;
                MessageBox.Show("Note, a BMP can only be used once in series routing");
            }

            if (BlankBMP())
            {
                btnCalculate.Enabled = false;
                MessageBox.Show("You cannot have a blank BMP or a No BMP routing to a valid BMP");
            }

            if (HarvestBeforeDetention())
            {
                btnCalculate.Enabled = false;
                MessageBox.Show("Stormwater Harvesting cannot be used before Wet Detention");
            }
        }

        private void FixWetDetention()
        {
            if (currentCatchment().BMP1 == "WetDetention") currentCatchment().setMultipleBMP(1, BMPTrainsProject.sWetDetention);
            if (currentCatchment().BMP2 == "WetDetention") currentCatchment().setMultipleBMP(2, BMPTrainsProject.sWetDetention);
            if (currentCatchment().BMP3 == "WetDetention") currentCatchment().setMultipleBMP(3, BMPTrainsProject.sWetDetention);
            if (currentCatchment().BMP4 == "WetDetention") currentCatchment().setMultipleBMP(4, BMPTrainsProject.sWetDetention);
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            // This must be added to handle events from every form that edits objects associated with
            // Catchments.
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            // Get current values            
            getValues();

            InterfaceCommon.resetMenuColors(menuStrip1);
            clickedItem.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.MenuHighlight);
            currentCatchmentID = Convert.ToInt32(clickedItem.Name);

            setValues();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            getValues();
            currentBMP().Calculate();
            Globals.Project.Modified = true;
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.wbOutput.Document.Focus();
            SendKeys.SendWait("^a");
            SendKeys.SendWait("^a^c");
            DialogResult dialogResult = MessageBox.Show("Report has been copied to the clipboard as HTML text", "Copy Report", MessageBoxButtons.OK);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            getValues();
            Calculate();
            if (lastBMPID() == 0) return;
            if (lastBMP().BMPType == BMPTrainsProject.sWetDetention) btnAnoxicDepth.Visible = true; else btnAnoxicDepth.Visible = false;
        }

        private void Calculate()
        {
            // If using naming convention, this should always be the same
            
            currentCatchment().Calculate();
            //currentBMP().Calculate();
            setOutputText();

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Same for every edit form
            wbOutput.Print();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Same for every edit form - URL will change
            // This allows us to have external help by pulling up a web site in the application
            //Form form = new frmHelp(currentCatchment().HelpURL);
            //form.ShowDialog();
        }

        private bool ValidateBMP()
        {   
            string s1 = Common.getString(cbBMP1);
            string s2 = Common.getString(cbBMP2);
            string s3 = Common.getString(cbBMP3);
            string s4 = Common.getString(cbBMP4);

            if (s1 != "None" && s1 != "")
            {
                if (s1 == s2 || s1 == s3 || s1 == s4) return false;
            }
            if (s2 != "None" && s2 != "")
            {
                if ( s2 == s3 || s2 == s4) return false;
            }

            if (s3 != "None" && s3 != "")
            {
                if (s3 == s4) return false;
            }

            return true;
        }

        private bool BlankBMP()
        {
            string s1 = Common.getString(cbBMP1);
            string s2 = Common.getString(cbBMP2);
            string s3 = Common.getString(cbBMP3);
            string s4 = Common.getString(cbBMP4);

            if (s4 != "None" && s4 != "")
            {
                if (s3 == "None" || s3 == "") return true;
                if (s2 == "None" || s2 == "") return true;
                if (s1 == "None" || s1 == "") return true;
            }

            if (s3 != "None" && s3 != "")
            {
                if (s2 == "None" || s2 == "") return true;
                if (s1 == "None" || s1 == "") return true;
            }
            if (s2 != "None" && s2 != "")
            {
                if (s1 == "None" || s1 == "") return true;
            }

            return false;
        }

        private int lastBMPID()
        {
            string s1 = Common.getString(cbBMP1);
            string s2 = Common.getString(cbBMP2);
            string s3 = Common.getString(cbBMP3);
            string s4 = Common.getString(cbBMP4);
            if (s4 != "None" && s4 != "") return 4;
            if (s3 != "None" && s3 != "") return 3;
            if (s2 != "None" && s2 != "") return 2;
            if (s1 != "None" && s1 != "") return 1;
            return 0; 
        }

        private BMP lastBMP()
        {
            if (lastBMPID() == 4) return currentBMP().bmp4;
            if (lastBMPID() == 3) return currentBMP().bmp3;
            if (lastBMPID() == 2) return currentBMP().bmp2;
            if (lastBMPID() == 1) return currentBMP().bmp1;

            return null;
        }

        private bool HarvestBeforeDetention()
        {
            string s1 = Common.getString(cbBMP1);
            string s2 = Common.getString(cbBMP2);
            string s3 = Common.getString(cbBMP3);
            string s4 = Common.getString(cbBMP4);

            if (s1 == BMPTrainsProject.sStormwaterHarvesting && s2 == BMPTrainsProject.sWetDetention) return true;
            if (s2 == BMPTrainsProject.sStormwaterHarvesting && s3 == BMPTrainsProject.sWetDetention) return true;
            if (s3 == BMPTrainsProject.sStormwaterHarvesting && s4 == BMPTrainsProject.sWetDetention) return true;

            return false;
        }

        private void OpenBMP(string bmpType)
        {
            BMPTrainsProject.OpenSelectedBMPForm(bmpType, currentCatchmentID);
        }

        private void frmMultipleBMP_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.Blue, 6))
            using (GraphicsPath capPath = new GraphicsPath())
            {
                p.EndCap = LineCap.ArrowAnchor;
                e.Graphics.DrawLine(p, label2.Left + label2.Width / 2, label2.Top + label2.Height + 2, label2.Left + label2.Width / 2, label3.Top - 2);
                e.Graphics.DrawLine(p, label3.Left + label3.Width / 2, label3.Top + label3.Height + 2, label3.Left + label3.Width / 2, label4.Top - 2);
                e.Graphics.DrawLine(p, label4.Left + label4.Width / 2, label4.Top + label4.Height + 2, label4.Left + label4.Width / 2, label5.Top - 2);
            }
        }

        private void btnOpen1_Click(object sender, EventArgs e)
        {
            OpenBMP(Common.getString(cbBMP1));
        }

        private void btnOpen2_Click(object sender, EventArgs e)
        {
            OpenBMP(Common.getString(cbBMP2));
        }

        private void btnOpen3_Click(object sender, EventArgs e)
        {
            OpenBMP(Common.getString(cbBMP3));
        }

        private void btnOpen4_Click(object sender, EventArgs e)
        {
            OpenBMP(Common.getString(cbBMP4));
        }

        private void cbBMP3_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCalculate.Enabled = !BlankBMP()&&ValidateBMP();

            string s4 = Common.getString(cbBMP4);
            if ((Common.getString(cbBMP3) == BMPTrainsProject.sWetDetention) && (s4 == "None" || s4 == ""))
                btnAnoxicDepth.Visible = true;
            else
                btnAnoxicDepth.Visible = false;
        }

        private void cbBMP4_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCalculate.Enabled = !BlankBMP() && ValidateBMP();
            if (Common.getString(cbBMP4) == BMPTrainsProject.sWetDetention)
                btnAnoxicDepth.Visible = true;
            else
                btnAnoxicDepth.Visible = false;

        }

        private void cbBMP2_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCalculate.Enabled = !BlankBMP() && ValidateBMP();

            string s3 = Common.getString(cbBMP3);
            if ((Common.getString(cbBMP2) == BMPTrainsProject.sWetDetention) && (s3 == "None" || s3 == ""))
                btnAnoxicDepth.Visible = true;
            else
                btnAnoxicDepth.Visible = false;
        }

        private void cbBMP1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCalculate.Enabled = !BlankBMP() && ValidateBMP();
        }

        private void btnAnoxicDepth_Click(object sender, EventArgs e)
        {
            getValues();
            Calculate();
            if (lastBMPID() == 0) return;
            wbOutput.DocumentText = currentBMP().reportAnoxicDepth(lastBMPID(), currentBMP().ProvidedPTreatmentEfficiency);
        }
    }
}
