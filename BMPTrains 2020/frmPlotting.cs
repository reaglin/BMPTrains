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
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        public Chart BaseChart()
        {
            return chart1;
        }


    }
}
