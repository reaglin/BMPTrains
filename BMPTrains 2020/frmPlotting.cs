using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BMPTrains_2020.DomainCode;

namespace BMPTrains_2020
{
    public partial class frmPlotting : Form
    {        
        public frmPlotting()
        {
            InitializeComponent();
        }


        private void Plotting_Load(object sender, EventArgs e)
        {
        }

        private void blnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (chart1.Visible) CopyChart();
            if (pb.Visible) CopyImage();
        }

        public void CopyChart()
        {
            using (var memoryStream = new System.IO.MemoryStream())
            {
                // Save the chart as an image to a memory stream
                chart1.SaveImage(memoryStream, ChartImageFormat.Png);

                // Create an image from the memory stream
                using (var image = Image.FromStream(memoryStream))
                {
                    // Copy the image to the clipboard
                    Clipboard.SetImage(image);
                }
            }
            MessageBox.Show("Chart copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CopyImage()
        {
            if (pb.Image != null)
            {
                Clipboard.SetImage(pb.Image);
                MessageBox.Show("Image copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No image in the PictureBox to copy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintVisibleItem();
        }

        public void PrintVisibleItem()
        {
           
            PrintDialog printDialog = new PrintDialog
            {
                Document = pd
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }

        }

        public Chart BaseChart()
        {
            return chart1;
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            if (chart1.Visible) { 
                // Set the size of the PictureBox to match the Chart
                pb.Width = chart1.Width;
                pb.Height = chart1.Height;

                // Set the location of the PictureBox to match the Chart
                pb.Location = chart1.Location;

                // Bring the PictureBox to the front
                pb.BringToFront();
                pb.Visible = true;
                chart1.Visible = false;
                pb.Image = getImage();
                btnSource.Text = "Show Chart Plot";
                return;
            }
            if (!chart1.Visible)
            {
                chart1.BringToFront();
                pb.Visible = false;
                chart1.Visible = true;
                btnSource.Text = "Show Source Plots";
                return;
            }

        }

        // This should be overriden to return the image that 
        public virtual Image getImage()
        {
            return Properties.Resources.REV_Zone1;
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (chart1.Visible) chart1.Printing.PrintPaint(e.Graphics, e.MarginBounds); ;
            if (pb.Visible) e.Graphics.DrawImage(pb.Image, e.MarginBounds); 
        }
    }
}
